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
    public class ActualizarClaseController : ApiController
    {
        private IMapper mapper;
        private readonly ClaseServices claseServices= new ClaseServices(new ClaseRepository(FinesContext.Create()));
        public ActualizarClaseController()
        {
            this.mapper = WebApiApplication.MapperConfiguration.CreateMapper();
        }
        [HttpPost]
        public async Task<IHttpActionResult> ActualizarClase(ActualizarClase actualizarClase)
        {
            using (FinesContext finesContext = new FinesContext())
            {
                try
                {
                    var clase = await (from c in finesContext.Clases
                                            where c.Id_Clase == actualizarClase.Id_Clase
                                            select new
                                            {
                                                Id_Curso = c.Id_Curso,
                                                ClaseNumero = c.ClaseNumero
                                            }).ToListAsync();
                    var claseDTO = new ClaseDTO();
                    claseDTO.Id_Clase = actualizarClase.Id_Clase;
                    claseDTO.Contenido = actualizarClase.Contenido;
                    claseDTO.Titulo = actualizarClase.Titulo;
                    claseDTO.Fecha = actualizarClase.Fecha;
                    claseDTO.ClaseNumero = clase[0].ClaseNumero;
                    claseDTO.Id_Curso = clase[0].Id_Curso;

                    var clase2 = mapper.Map<Clase>(claseDTO);
                    clase2 = await claseServices.Update(clase2);
                    return Ok(clase2);
                }
                catch (Exception ex)
                {
                    return InternalServerError(ex);
                }
            }

        }
    }
}
