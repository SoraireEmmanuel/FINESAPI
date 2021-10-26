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
    public class TodasLasNotasPorNumeroClaseController : ApiController
    {
        [HttpPost]
        public async Task<IHttpActionResult> TodasLasNotas(TodasNotasPorNumeroDTO todasNotasPorNumeroDTO)
        {
            using (FinesContext fines = new FinesContext())
            {
                try
                {
                    var asistencias = await (from c in fines.Clases
                                             join a in fines.Asistencias
                                             on c.Id_Clase equals a.Id_Clase
                                             join cc in fines.Cursadas
                                             on a.Id_Cursada equals cc.Id_Cursada
                                             join u in fines.Usuarios
                                             on cc.Id_Usuario equals u.Id_Usuario
                                             where c.ClaseNumero == todasNotasPorNumeroDTO.NumeroClase
                                             && c.Id_Curso == todasNotasPorNumeroDTO.Id_Curso
                                             select new
                                             {
                                                 NombreAlumno = u.Nombre,
                                                 ApellidoAlumno = u.Apellido,
                                                 Asistio = a.Asistio                                                
                                             }).ToListAsync();
                    return Ok(asistencias);
                }
                catch (Exception ex)
                {
                    return InternalServerError(ex);
                }

            }

        }
    }
}
