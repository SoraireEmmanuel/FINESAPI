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
    public class AsignarDocenteController : ApiController
    {
        private IMapper mapper;
        private readonly CursoServices cursoServices = new CursoServices(new CursoRepository(FinesContext.Create()));
        public AsignarDocenteController()
        {
            this.mapper = WebApiApplication.MapperConfiguration.CreateMapper();
        }
        [HttpPost]
        public async Task<IHttpActionResult> UpdateDocenteByCurso(AsignarDocente asignarDocente)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
           
            var flag = await cursoServices.GetById(asignarDocente.Id_Curso);
            if (flag == null)
                return NotFound();
            try
            {
                var cursoDTO = new CursoDTO();
                cursoDTO.Id_Curso = flag.Id_Curso;
                cursoDTO.Id_Materias = flag.Id_Materias;
                cursoDTO.Id_Sede = flag.Id_Sede;
                cursoDTO.Id_Usuario = asignarDocente.Id_Docente;
                cursoDTO.Ige = flag.Ige;
                cursoDTO.estado = flag.estado;
                cursoDTO.diaHorario = flag.diaHorario;
                cursoDTO.AnioCurso = flag.AnioCurso;
           
                var cursos = mapper.Map < curso > (cursoDTO);
                cursos = await cursoServices.Update(cursos);
                return Ok(cursos);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
