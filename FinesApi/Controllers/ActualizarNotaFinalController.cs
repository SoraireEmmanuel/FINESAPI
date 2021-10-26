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
    public class ActualizarNotaFinalController : ApiController
    {
        private IMapper mapper;
        private readonly CursadaServices cursadaServices = new CursadaServices(new CursadaRepository(FinesContext.Create()));
        public ActualizarNotaFinalController()
        {
            this.mapper = WebApiApplication.MapperConfiguration.CreateMapper();
        }
        [HttpPost]
        public async Task<IHttpActionResult> ActualizarEstado(ActualizarNotaDTO actualizarNotaDTO)
        {
            using (FinesContext finesContext = new FinesContext())
            {
                try
                {
                    var nota = await (from c in finesContext.Cursadas
                                      where c.Id_Cursada == actualizarNotaDTO.Id_Cursada
                                      select new
                                      {
                                          Id_Cursada = c.Id_Cursada,
                                          Nota1 = c.Nota1,
                                          Nota2 = c.Nota2,
                                          NotaFinal = c.NotaFinal,
                                          Id_Usuario = c.Id_Usuario,
                                          Id_Curso = c.Id_Curso,
                                          estado = c.Estado
                                      }).ToListAsync();
                    var cursadaDTO = new CursadaDTO();
                    cursadaDTO.Id_Cursada = nota[0].Id_Cursada;
                    cursadaDTO.Nota1 = nota[0].Nota1;
                    cursadaDTO.Nota2 = nota[0].Nota2;
                    cursadaDTO.NotaFinal = actualizarNotaDTO.NotaFinal;
                    cursadaDTO.Id_Usuario = nota[0].Id_Usuario;
                    cursadaDTO.Id_Curso = nota[0].Id_Curso;
                    cursadaDTO.Estado = nota[0].estado;

                    var cursada2 = mapper.Map<Cursada>(cursadaDTO);
                    cursada2 = await cursadaServices.Update(cursada2);
                    return Ok(cursada2);
                }
                catch (Exception ex)
                {
                    return InternalServerError(ex);
                }
            }

        }
    }
}
