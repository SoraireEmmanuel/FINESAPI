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
    public class AdministrarCursosController : ApiController
    {
        private IMapper mapper;
        private readonly CursoServices cursoServices = new CursoServices(new CursoRepository(FinesContext.Create()));
        private readonly ClaseServices claseServices = new ClaseServices(new ClaseRepository(FinesContext.Create()));
        public AdministrarCursosController()
        {
            this.mapper = WebApiApplication.MapperConfiguration.CreateMapper();
        }
        /// <summary>
        /// Genera un Curso
        /// </summary>
        /// <param name="nuevoCursoDTO"></param>
        /// <returns></returns>
        [HttpPost]
        [ResponseType(typeof(IEnumerable<curso>))]
        public async Task<IHttpActionResult> Insert(NuevoCursoDTO nuevoCursoDTO)
        {
            using (FinesContext finesContext = new FinesContext())
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                var cursoDTO = new CursoDTO();
                var claseDTO = new ClaseDTO();
                cursoDTO.Id_Materias = nuevoCursoDTO.Id_Materia;
                cursoDTO.Id_Sede = nuevoCursoDTO.Id_Sede;
                cursoDTO.AnioCurso = nuevoCursoDTO.Anio;
                cursoDTO.Ige = nuevoCursoDTO.IGE;
                cursoDTO.Id_Usuario = 7;
                cursoDTO.estado = nuevoCursoDTO.estado;
                cursoDTO.diaHorario=nuevoCursoDTO.diaHorario;
                var curso = mapper.Map<curso>(cursoDTO);
                try
                {
                    curso = await cursoServices.Insert(curso);
                    for (var i=1; i< 21; i++)
                    {
                        claseDTO.ClaseNumero = i;
                        claseDTO.Id_Curso = curso.Id_Curso;
                        var clase = mapper.Map<Clase>(claseDTO);
                        await claseServices.Insert(clase);
                    }
                    return Ok(curso);
                }
                catch (Exception ex)
                {
                    return InternalServerError(ex);
                }
            }
        }
    //    [HttpGet]
    //    [ResponseType(typeof(IEnumerable<curso>))]
    //    public async Task<IHttpActionResult> GetByIGE(string IGE)
    //    {
    //        using (FinesContext finesContext = new FinesContext)
    //        {
    //            return Ok();
    //        }
    //        
    //    }

    }
}
