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
    public class MateriaPorIgeController : ApiController
    {
        /// <summary>
        /// Este endpoint retorna los datos de la materia de un curso
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IHttpActionResult> materiascursosporlocalidad(int id)
        {
            using (FinesContext finesContext = new FinesContext())
            {
                try
                {
                    var materia = await (from c in finesContext.Cursos
                                           join m in finesContext.Materias on c.Id_Materias equals m.Id_Materias                                           
                                           where c.Id_Curso == id 
                                           select new
                                           {
                                             MateriaNombre=m.NombreMateria,
                                             Nivel=m.Anio,
                                             Cuatrimestre=m.Cuatrimestre,
                                             CargaHoraria=m.CargaHoraria,
                                             Ige=c.Ige
                                           }).ToListAsync();
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
