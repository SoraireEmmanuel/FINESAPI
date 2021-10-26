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
    public class MateriasCursosPorLocalidadController : ApiController
    {

        [HttpGet]
        public async Task<IHttpActionResult> materiascursosporlocalidad(int id)
        {
            using (FinesContext finesContext = new FinesContext())
            {
                try
                {
                    var localidad = await (from c in finesContext.Cursos
                                       join m in finesContext.Materias on c.Id_Materias equals m.Id_Materias
                                       join s in finesContext.Sedes on c.Id_Sede equals s.Id_Sede
                                       where m.Id_Materias == id && c.estado == true
                                       select new
                                       {    
                                           Localidad = s.localidad
                                       }).Distinct().ToListAsync();
                    return Ok(localidad);
                }
                catch (Exception ex)
                {
                    return InternalServerError(ex);
                }
            }

        }
        [HttpPost]
        public async Task<IHttpActionResult> materiaporlocalidad(LocalidadMateriaDTO localidadMateriaDTO)
        {
            using (FinesContext finesContext = new FinesContext())
            {
                try
                {
                    var Curso = await (from c in finesContext.Cursos
                                           join m in finesContext.Materias on c.Id_Materias equals m.Id_Materias
                                           join s in finesContext.Sedes on c.Id_Sede equals s.Id_Sede
                                           join cc in finesContext.Censs on s.Id_Cens equals cc.Id_Cens
                                           where m.Id_Materias == localidadMateriaDTO.Id_Materia && c.estado == true 
                                           && s.localidad==localidadMateriaDTO.Localidad
                                           select new
                                           {
                                               Id_Curso=c.Id_Curso,
                                               DiayHorario= c.diaHorario,
                                               SedeNombre = s.Nombre,
                                               SedeDireccion=s.Direccion,

                                               Cens = cc.Nombre

                                          }).ToListAsync();
                    return Ok(Curso);
                }
                catch (Exception ex)
                {
                    return InternalServerError(ex);
                }
            }

        }
    }
}
