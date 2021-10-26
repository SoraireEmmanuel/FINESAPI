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


namespace FinesApi.Controllers
{
    public class VerListaMateriasController : ApiController
    {
        private IMapper mapper;
        private readonly MateriaServices materiaServices = new MateriaServices(new MateriasRepository(FinesContext.Create()));
        public VerListaMateriasController()
        {
            this.mapper = WebApiApplication.MapperConfiguration.CreateMapper();
        }
        /// <summary>
        /// Retorna todas las materias del plan
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {
            try
            {
                var materias = await materiaServices.GetAll();
                var materiasDTO = materias.Select(x => mapper.Map<MateriaDTO>(x));
                return Ok(materiasDTO);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
