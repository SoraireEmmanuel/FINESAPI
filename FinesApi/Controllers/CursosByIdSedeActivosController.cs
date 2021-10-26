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
    public class CursosByIdSedeActivosController : ApiController
    {


        [HttpGet]
        public async Task<IHttpActionResult> getCursosBySede(int id)
        {
            using (FinesContext finesContext=new FinesContext())
            {
                try
                {
                    var curso = await (from c in finesContext.Cursos join
                                       m in finesContext.Materias on c.Id_Materias equals m.Id_Materias
                                         where c.Id_Sede == id && c.estado== true
                                         select new
                                         {
                                             Id_Curso = c.Id_Curso,
                                             Ige = c.Ige,
                                             Materia = m.NombreMateria,
                                             CiloLectivo = c.AnioCurso,
                                             Anio = m.Anio,
                                             Cuatrimestre = m.Cuatrimestre,
                                             DocenteId = c.Id_Usuario==7?-1:c.Id_Usuario
                                         }).ToListAsync();
                    return Ok(curso);
                }
                catch (Exception ex)
                {
                    return InternalServerError(ex);
                }
            }
          
        }

    }
}
