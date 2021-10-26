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
    public class RegistroUsuariosController : ApiController
    {
        private IMapper mapper;
        private readonly UsuarioServices usuarioServices = new UsuarioServices(new UsuarioRepository(FinesContext.Create()));
        private readonly TrayectoriaAcademicaServices trayectoriaAcademicaServices = new TrayectoriaAcademicaServices(new TrayectoriaAcademicaRepository(FinesContext.Create()));


        public RegistroUsuariosController()
        {
            this.mapper = WebApiApplication.MapperConfiguration.CreateMapper();
        }
        /// <summary>
        /// Registra usuarios
        /// </summary>
        /// <remarks>Registra Usuarios, identifica que tipo de usuario se esta registrando, si es un docente lo registra directamente
        /// pero si se trata de un alumno inicializa su trayectoria academica.</remarks>
        /// <param name="usuarioDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IHttpActionResult> Insert(UsuarioDTO usuarioDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest("Modelo Invalido");
            using (FinesContext finesContext = new FinesContext())
            {
                var isExist = finesContext.Usuarios.Where(x => x.Mail == usuarioDTO.Mail ||
                                           x.DNI == usuarioDTO.DNI).ToList();
                if (isExist.Count != 0)
                    return BadRequest("El DNI y/o Mail registrado");
            }
            if(usuarioDTO.Rol == 1 || usuarioDTO.Rol == 2)
            {
                var usuario = mapper.Map<Usuario>(usuarioDTO);
               
                if (usuarioDTO.Rol == 1)
                {
                    try
                    {
                        usuario = await usuarioServices.Insert(usuario);
                        var trayectoriaDTO = new TrayectoriaAcademicaDTO();

                        for (int i = 58; i < 82; i++)
                        {
                            trayectoriaDTO.Id_Usuario = usuario.Id_Usuario;
                            trayectoriaDTO.Id_Cursada = i;
                            var trayectoria = mapper.Map<TrayectoriaAcademica>(trayectoriaDTO);
                            await trayectoriaAcademicaServices.Insert(trayectoria);
                        }
                        return Ok(usuario);
                    }
                    catch (Exception ex)
                    {
                        return InternalServerError(ex);
                    }
                }
                else
                {
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
            }
            else
                return BadRequest("Rol no identificado");
        }
        /// <summary>
        /// Actualizar Contraseña - Fuera de Funcionamiento
        /// </summary>
        /// <param name="usuarioDTO"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IHttpActionResult> Update(UsuarioDTO usuarioDTO, int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            return Ok();
        }
        

    }
}
