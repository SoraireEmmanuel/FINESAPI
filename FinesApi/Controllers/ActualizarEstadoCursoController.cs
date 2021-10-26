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
    public class ActualizarEstadoCursoController : ApiController
    {
        private IMapper mapper;
        private readonly CursoServices cursoServices= new CursoServices(new CursoRepository(FinesContext.Create()));
        private readonly CursadaServices cursadaServices = new CursadaServices(new CursadaRepository(FinesContext.Create()));

        public ActualizarEstadoCursoController()
        {
            this.mapper = WebApiApplication.MapperConfiguration.CreateMapper();
        }
        [HttpPost]
        public async Task<IHttpActionResult> ActualizarEstado(ActualizarEstadoDTO actualizarEstadoDTO)
        {
            using (FinesContext finesContext = new FinesContext())
            {
                try
                {
                    var curso = await (from c in finesContext.Cursos                                       
                                       where c.Id_Curso== actualizarEstadoDTO.Id_Curso
                                       select new
                                       {
                                           Id_Curso = c.Id_Curso,
                                           Anio_Curso = c.AnioCurso,
                                           Ige = c.Ige,
                                           Id_Sede = c.Id_Sede,
                                           Id_Materia = c.Id_Materias,
                                           Id_Usuario = c.Id_Usuario,
                                           estado = c.estado,
                                           diaHorario = c.diaHorario
                                       }).ToListAsync();
                    var cursoDTO = new CursoDTO();
                    cursoDTO.Id_Curso = curso[0].Id_Curso;
                    cursoDTO.AnioCurso = curso[0].Anio_Curso;
                    cursoDTO.Ige = curso[0].Ige;
                    cursoDTO.Id_Sede = curso[0].Id_Sede;
                    cursoDTO.Id_Materias = curso[0].Id_Materia;
                    cursoDTO.Id_Usuario = curso[0].Id_Usuario;
                    cursoDTO.estado = !curso[0].estado;
                    cursoDTO.diaHorario = curso[0].diaHorario;
                    var curso2 = mapper.Map<curso>(cursoDTO);
                    curso2 = await cursoServices.Update(curso2);
                    var cursada = await (from c in finesContext.Cursadas
                                         where c.Id_Curso == cursoDTO.Id_Curso
                                         select new
                                         {
                                             Id_Cursada=c.Id_Cursada,
                                             Nota_1=c.Nota1,
                                             Nota_2=c.Nota2,
                                             NotaFinal=c.NotaFinal,
                                             Id_Usuario=c.Id_Usuario,
                                             Id_Curso=c.Id_Curso,
                                             Estado = c.Estado
                                         }).ToListAsync();                   
                        var cant = cursada.Count;
                        var cursadaAux = new CursadaDTO();
                        for(var i = 0; i < cant; i++)
                        {
                            cursadaAux.Id_Cursada = cursada[i].Id_Cursada;
                            cursadaAux.Nota1 = cursada[i].Nota_1;
                            cursadaAux.Nota2 = cursada[i].Nota_2;
                            cursadaAux.Id_Usuario = cursada[i].Id_Usuario;
                            cursadaAux.Id_Curso = cursada[i].Id_Curso;
                            cursadaAux.Estado = cursada[i].Estado;
                            cursadaAux.NotaFinal = cursada[i].NotaFinal;
                        if (cursoDTO.estado)
                            {
                            cursadaAux.Estado = "En Curso";
                            }
                         else
                            {
                            if (cursadaAux.NotaFinal >= 7)
                            {
                                cursadaAux.Estado = "Aprobada";
                            }
                            else
                            {
                                cursadaAux.Estado = "No Cursada";
                            }
                        }
                        var cursada2 = mapper.Map<Cursada>(cursadaAux);
                        cursada2 = await cursadaServices.Update(cursada2);
                    }               
                    return Ok(curso2);
                }
                catch (Exception ex)
                {
                    return InternalServerError(ex);
                }
            }

        }
    }
}
