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
    public class ActualizarAsistenciaController : ApiController
    {
        private IMapper mapper;
        private readonly AsistenciaServices asistenciaServices= new AsistenciaServices(new AsistenciaRepository(FinesContext.Create()));
        public ActualizarAsistenciaController()
        {
            this.mapper = WebApiApplication.MapperConfiguration.CreateMapper();
        }
        [HttpPost]
        public async Task<IHttpActionResult> ActualizarAsistencia(ActualizarAsistenciaDTO actualizarAsistenciaDTO)
        {
            using (FinesContext finesContext = new FinesContext())
            {
                try
                {
                    var asistencia = await (from a in finesContext.Asistencias
                                       where a.Id_Asistencia == actualizarAsistenciaDTO.Id_Asistencia
                                       select new
                                       {
                                           Id_Asistencia = a.Id_Asistencia,
                                           Asistio = a.Asistio,
                                           NumeroClase = a.NumeroClase,
                                           Id_Cursada = a.Id_Cursada,
                                           Id_Clase = a.Id_Clase                                           
                                       }).ToListAsync();
                    var asistenciaDTO = new AsistenciaDTO();
                    asistenciaDTO.Id_Asistencia = asistencia[0].Id_Asistencia;
                    asistenciaDTO.Asistio = !asistencia[0].Asistio;
                    asistenciaDTO.NumeroClase = asistencia[0].NumeroClase;
                    asistenciaDTO.Id_Cursada = asistencia[0].Id_Cursada;
                    asistenciaDTO.Id_Clase = asistencia[0].Id_Clase;

                    var asistencia2 = mapper.Map<Asistencia>(asistenciaDTO);
                    asistencia2 = await asistenciaServices.Update(asistencia2);
                    return Ok(asistencia);
                }
                catch (Exception ex)
                {
                    return InternalServerError(ex);
                }
            }

        }
    }
}
