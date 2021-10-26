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
    public class BuscarDocenteByDNIController : ApiController
    {

        [HttpGet]
        public async Task<IHttpActionResult> GetDocenteByDNI(string dni)
        {
            using(FinesContext fines = new FinesContext())
            {
                try
                {
                    var docente = await (from u in fines.Usuarios
                                         where u.DNI == dni && u.Rol==2
                                         select new
                                         {
                                             IdDocente = u.Id_Usuario,
                                             Nombre = u.Nombre,
                                             Apellido = u.Apellido,
                                             Telefono = u.telefono,
                                             DNI = u.DNI
                                         }).ToListAsync();
                    return Ok(docente);
                }
                catch (Exception ex)
                {
                    return InternalServerError(ex);
                }
            }

        }
    }
}
