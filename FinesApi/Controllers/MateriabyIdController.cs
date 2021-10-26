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
    public class MateriabyIdController : ApiController
    {
        private IMapper mapper;
        private readonly MateriaServices materiaServices= new MateriaServices(new MateriasRepository(FinesContext.Create()));
        public MateriabyIdController()
        {
            this.mapper = WebApiApplication.MapperConfiguration.CreateMapper();
        }
        [HttpGet]
        public async Task<IHttpActionResult> GetById(int id)
        {
            var materia = await materiaServices.GetById(id);
            if (materia == null)
                return NotFound();

            var materiaDTO = mapper.Map<MateriaDTO>(materia);
            return Ok(materiaDTO);
        }

    }
}
