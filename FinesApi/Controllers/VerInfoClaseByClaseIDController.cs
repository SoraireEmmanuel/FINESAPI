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
    public class VerInfoClaseByClaseIDController : ApiController
    {
        private IMapper mapper;
        private readonly ClaseServices claseServices= new ClaseServices(new ClaseRepository(FinesContext.Create()));
        public VerInfoClaseByClaseIDController()
        {
            this.mapper = WebApiApplication.MapperConfiguration.CreateMapper();
        }
        [HttpGet]
        public async Task<IHttpActionResult> GetInfoClaseByClaseId(int id)
        {
            try
            {
                var clases = await claseServices.GetById(id);
                var clasesDTO = mapper.Map<ClaseDTO>(clases);
                if (clases == null)
                    return NotFound();
                return Ok(clasesDTO);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }
    }
}
