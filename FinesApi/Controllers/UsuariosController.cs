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
  
    public class UsuariosController : ApiController
    {
            private IMapper mapper;
            private readonly UsuarioServices usuarioServices = new UsuarioServices(new UsuarioRepository(FinesContext.Create()));
        public UsuariosController()
        {
            this.mapper = WebApiApplication.MapperConfiguration.CreateMapper(); 
        }
        /// <summary>
        /// Obtiene los Usuarios
        /// </summary>
        /// <remarks>Explicacion del EndPoint</remarks>
        /// <returns>Todos los Objetos Usuarios</returns>
        /// <response code="200">Ok. Retorna todos los Usuarios</response>
        [HttpGet]
        [ResponseType(typeof(IEnumerable<UsuarioDTO>))]
        public async Task<IHttpActionResult> GetAll()
        {
            var usuarios = await usuarioServices.GetAll();
            var usuarioDTO = usuarios.Select(x => mapper.Map<UsuarioDTO>(x));
            return Ok(usuarioDTO);
        }
        [HttpGet]
        public async Task<IHttpActionResult> GetById(int id)
        {
            var usuario = await usuarioServices.GetById(id);
            if (usuario == null)
                return NotFound();

            var usuarioDTO = mapper.Map<UsuarioDTO>(usuario);
            return Ok(usuarioDTO);
        }
        [HttpPost]
        public async Task<IHttpActionResult> Insert(UsuarioDTO usuarioDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var usuario = mapper.Map<Usuario>(usuarioDTO);//le damos un usuarioDTO y nos retorna un usuario
            //agregar validacion para que detrmine si el DNI y el mail ya estan registrados.

            try
            {
                usuario = await usuarioServices.Insert(usuario);
                return Ok(usuario);
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
        }
        [HttpPut]
        public async Task<IHttpActionResult> Actualizar(UsuarioDTO usuarioDTO, int id )
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (usuarioDTO.Id_Usuario != id)
                return BadRequest();

            var flag = await usuarioServices.GetById(id);
            if (flag == null)
                return NotFound();
            try
            {
                var usuario = mapper.Map<Usuario>(usuarioDTO);
                usuario = await usuarioServices.Update(usuario);
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
