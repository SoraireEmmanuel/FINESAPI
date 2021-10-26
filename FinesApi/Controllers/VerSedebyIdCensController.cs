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
    public class VerSedebyIdCensController : ApiController
    {
        private IMapper mapper;
        private readonly CensServices censServices = new CensServices(new CensRepository(FinesContext.Create()));
        public VerSedebyIdCensController()
        {
            this.mapper = WebApiApplication.MapperConfiguration.CreateMapper();
        }
        [HttpGet]
        public async Task<IHttpActionResult> GetSedeByIdCens(int id)
        {
            using (FinesContext fines = new FinesContext())
            {
                try
                {
                    var se = await (from s in fines.Sedes
                                    where s.Id_Cens == id
                                    select new
                                    {
                                        Id = s.Id_Sede,
                                        SedeNombre = s.Nombre
                                    }).ToListAsync();
                    var sedeDTO = new SedeDTO();
                    
                    return Ok(se);
                }
                catch (Exception ex)
                {
                    return InternalServerError(ex);
                }

            }

        }
    }
}
