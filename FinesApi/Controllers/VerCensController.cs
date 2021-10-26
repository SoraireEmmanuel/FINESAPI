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
    public class VerCensController : ApiController
    {
        private IMapper mapper;
        private readonly CensServices censServices = new CensServices(new CensRepository(FinesContext.Create()));
        public VerCensController()
        {
            this.mapper = WebApiApplication.MapperConfiguration.CreateMapper();
        }
   
        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {
            try
            {
                var cens = await censServices.GetAll();
                var censDTO = cens.Select(x => mapper.Map<CensDTO>(x));
                return Ok(censDTO);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
