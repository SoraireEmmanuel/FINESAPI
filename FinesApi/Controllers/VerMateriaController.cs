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
    public class VerMateriaController : ApiController
    {
        public VerMateriaController()
        {

        }
        /// <summary>
        /// Retorna la info de una cursada.
        /// </summary>
        /// <remarks>Se le da al endPoint un id de cursada y este retorna la info de la misma</remarks>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IHttpActionResult> getById(int id)
        {
            using (FinesContext fines = new FinesContext())
            {
                try
                {
                    var materia = await (from c in fines.Cursadas
                                         join cc in fines.Cursos
                                         on c.Id_Curso equals cc.Id_Curso
                                         join m in fines.Materias
                                         on cc.Id_Materias equals m.Id_Materias
                                         join s in fines.Sedes
                                         on cc.Id_Sede equals s.Id_Sede
                                         join cens in fines.Censs
                                         on s.Id_Cens equals cens.Id_Cens
                                         where (c.Id_Cursada == id)
                                         select new { 
                                             IGE = cc.Ige,
                                             CodigoMateria = m.CodigoMateria,
                                             Cuatrimestre = m.Cuatrimestre,
                                             AnioCurso = m.Anio,
                                              NotaFinal = (int?)c.NotaFinal,
                                             AnioCurs = cc.AnioCurso,
                                             sede= s.Nombre,
                                             DireccionSede = s.Direccion,
                                             cens = cens.Nombre,
                                             DireccionCens = cens.Direccion,
                                             NombreMateria = m.NombreMateria 
                                         }).ToListAsync();
                    if (materia.Count == 0)
                        return BadRequest("No existe la Cursada");
                    return Ok(materia);
                }
                catch (Exception ex)
                {
                    return InternalServerError(ex);
                }

            
            }
        }
    }
}
