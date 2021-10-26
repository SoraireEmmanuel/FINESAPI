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
    public class TodasLasClasesPorCursoController : ApiController
    {
        [HttpGet]
        public async Task<IHttpActionResult> GetClasesByCursoId(int id)
        {
            using (FinesContext fines=new FinesContext())
            {
                try
                {
                    var clases = await (from c in fines.Clases
                                        where c.Id_Curso == id
                                        select new
                                        {
                                            Id_Clase = c.Id_Clase,
                                            Titulo = c.Titulo,
                                            ClaseNumero = c.ClaseNumero,
                                            Contenido = c.Contenido,
                                            Fecha = c.Fecha
                                        }).ToListAsync();
                    return Ok(clases);
                }
                catch (Exception ex)
                {
                    return InternalServerError(ex);
                }
            }
        }
    }
}
