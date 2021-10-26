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
    public class NotasByCursoIdController : ApiController
    {
        [HttpGet]
        public async Task<IHttpActionResult> GetNotaByCursoId(int id)
        {
            using(FinesContext fines = new FinesContext())
            {
                try
                {
                    var notas = await (from c in fines.Cursadas
                                       join u in fines.Usuarios
                                       on c.Id_Usuario equals u.Id_Usuario
                                       where c.Id_Curso == id
                                       select new
                                       {
                                           Id_Cursada = c.Id_Cursada,
                                           Nota1 = c.Nota1,
                                           Nota2 = c.Nota2,
                                           NotaFinal = c.NotaFinal,
                                           AlumnoNombre = u.Nombre,
                                           AlumnoApellido = u.Apellido
                                       }).ToListAsync();
                    return Ok(notas);
                }
                catch (Exception ex)
                {
                    return InternalServerError(ex);
                }
            }
        }
    }
}
