using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Fines.BL.Data;
using Fines.BL.Services.Implements;
using Fines.BL.DTO;
using Fines.BL.Repositories.Implements;
using System.Threading.Tasks;
using AutoMapper;
using Fines.BL.Models;
using System.Data.Entity;
namespace FinesApi.Controllers
{
    public class InscripcionMateriaController : ApiController                
    {
        private IMapper mapper;
        private readonly CursadaServices cursadaServices = new CursadaServices(new CursadaRepository(FinesContext.Create()));
        private readonly TrayectoriaAcademicaServices trayectoriaAcademicaServices = new TrayectoriaAcademicaServices(new TrayectoriaAcademicaRepository(FinesContext.Create()));
        private readonly ClaseServices claseServices = new ClaseServices(new ClaseRepository(FinesContext.Create()));
        private readonly AsistenciaServices asistenciaServices = new AsistenciaServices(new AsistenciaRepository(FinesContext.Create()));
        public InscripcionMateriaController()
        {
            this.mapper = WebApiApplication.MapperConfiguration.CreateMapper();
        }
        /// <summary>
        /// Este endpoint realiza la innscripcion
        /// </summary>
        /// <param name="cursadaDTO"></param>
        /// <remarks>Se realiza la iscripcion en un curso activo. </remarks>
        /// <returns></returns>
        [HttpPost]
        public async Task<IHttpActionResult> inscripcionCursada(InscripcionDTO inscripcionDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            //Creamos el objeto Cursada
            var cursadaDTO = new CursadaDTO();
            cursadaDTO.Id_Curso = inscripcionDTO.Id_Curso;
            cursadaDTO.Nota1 = 0;
            cursadaDTO.Nota2 = 0;
            cursadaDTO.NotaFinal = 0;
            cursadaDTO.Id_Usuario = inscripcionDTO.Id_Alumno;
            cursadaDTO.Estado = "En Curso";
            var cursada = mapper.Map<Cursada>(cursadaDTO);
            try
            {
                using (FinesContext fines = new FinesContext()) { 
                    cursada = await cursadaServices.Insert(cursada); //inserta la nueva cursada
                    //recupera el ID de la materia relacioada a la cursada
                    var trayectoriaDTO = new TrayectoriaAcademicaDTO();
                    var idMatria = await (from cc in fines.Cursos
                                          join m in fines.Materias
                                          on cc.Id_Materias equals m.Id_Materias
                                          where cc.Id_Curso == cursadaDTO.Id_Curso
                                          select new
                                          {
                                              idMateria = m.Id_Materias
                                          }).ToListAsync();
                    var materiaId = idMatria[0].idMateria;
                    //recupera el id de la trayectoria academica que se usa como indice
                    var trayectoriaActualizar = await (from c in fines.Cursadas
                                                       join cc in fines.Cursos
                                                       on c.Id_Curso equals cc.Id_Curso
                                                       join m in fines.Materias
                                                       on cc.Id_Materias equals m.Id_Materias
                                                       join ta in fines.TrayectoriaAcademicas
                                                       on c.Id_Cursada equals ta.Id_Cursada                                                       
                                                       where ta.Id_Usuario == inscripcionDTO.Id_Alumno
                                                       && m.Id_Materias == materiaId
                                                       select new
                                                       {
                                                           idTrayectoria = ta.Id_TrayectoriaAcademica                                                           
                                                       }
                                                      ).ToListAsync();
                    //Actualiza la trayectoria academica
                    trayectoriaDTO.Id_Usuario = inscripcionDTO.Id_Alumno;
                    var trayectoriaId = trayectoriaActualizar[0].idTrayectoria;
                    trayectoriaDTO.Id_TrayectoriaAcademica = trayectoriaId;
                    trayectoriaDTO.Id_Cursada = cursada.Id_Cursada;
                    var trayectoria = mapper.Map<TrayectoriaAcademica>(trayectoriaDTO);
                    trayectoria = await trayectoriaAcademicaServices.Update(trayectoria);
                    //Crear los objetos asistencia para la cursada
                    var asistenciaDTO = new AsistenciaDTO();
                    var idClase = await (from c in fines.Clases
                                         where c.Id_Curso == inscripcionDTO.Id_Curso
                                         select new
                                         {
                                             idClase = c.Id_Clase
                                         }).ToListAsync();
                    for(var i = 0; i < 20; i++)
                    {
                        asistenciaDTO.Id_Cursada = cursada.Id_Cursada;
                        asistenciaDTO.Id_Clase = idClase[i].idClase;
                        var asistencia = mapper.Map<Asistencia>(asistenciaDTO);
                        await asistenciaServices.Insert(asistencia); 
                    }
                return Ok(cursada);
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

    }
}
