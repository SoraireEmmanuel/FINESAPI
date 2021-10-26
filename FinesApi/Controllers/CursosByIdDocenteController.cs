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
    public class CursosByIdDocenteController : ApiController
    {
        [HttpGet]
        public async Task<IHttpActionResult> GetCursoByDocenteID(int id)
        {
            using (FinesContext fines = new FinesContext())
            {
                try
                {
                    var cursos = await (from c in fines.Cursos
                                        join m in fines.Materias
                                        on c.Id_Materias equals m.Id_Materias
                                        join s in fines.Sedes
                                        on c.Id_Sede equals s.Id_Sede
                                        where c.Id_Usuario == id
                                        select new
                                        {
                                            Id_Curso = c.Id_Curso,
                                            IGE = c.Ige,
                                            CicloLectivo = c.AnioCurso,
                                            MateriaNombre = m.NombreMateria,
                                            MateriaCodigo = m.CodigoMateria,
                                            MateriaCargaHoraria = m.CargaHoraria,
                                            Sede = s.Nombre,
                                            Estado = c.estado

                                        }
                                        ).ToListAsync();
                    return Ok(cursos);
                }
                catch (Exception ex)
                {
                    return InternalServerError(ex);
                }

            }
        }
    }

}
