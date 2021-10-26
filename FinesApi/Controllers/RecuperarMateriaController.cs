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
    public class RecuperarMateriaController : ApiController
    {
        
        public RecuperarMateriaController()
        {
        
        }
        /// <summary>
        /// Retorna el detalle de una Materia
        /// </summary>
        /// <param name="id"></param>
        /// <remarks>Se le pasa el id de una cursada, y se le retorna todos los detalle de la materia</remarks>
        /// <returns>El detalle de una materia</returns>
        [HttpGet]
        public async Task<IHttpActionResult> GetMateriaById(int id)
        {
            using (FinesContext finesContext2 = new FinesContext())
            {
                var isCursada = await (from c in finesContext2.Cursadas
                                       where (c.Id_Cursada == id)
                                       select c).ToListAsync();
                return Ok(isCursada);
                //if (isCursada.Count == 0)
                 //   return BadRequest("La cursada no existe");
            }
            return Ok();
            using (FinesContext fines = new FinesContext())
            {
             //   try
               // {

                    //var materiaDetalle = await (from c in fines.Cursadas
                                                    // join cc in finesContext2.Cursos on c.Id_Curso equals cc.Id_Curso
                                                    //join m in finesContext2.Materias on cc.Id_Materias equals m.Id_Materias
                                                    //join s in finesContext2.Sedes on cc.Id_Sede equals s.Id_Sede
                                                    //join cens in finesContext2.Censs on s.Id_Cens equals cens.Id_Cens

                      //                          select new { id = c.Estado }).ToListAsync();
                    return Ok();

              //  }
              //  catch (Exception ex)
               // {
                 //   return InternalServerError(ex);
               // }
            }
            
        }
    }
}
