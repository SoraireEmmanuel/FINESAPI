using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Fines.BL.DTO;
using Fines.BL.Data;

namespace FinesApi.Controllers
{
    [AllowAnonymous]
    public class AutenticacionesController : ApiController
    {
        /// <summary>
        /// Metodo Encargado de realizar la Autenticacion
        /// </summary>
        /// <param name="autenticacionDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult Login(AutenticacionDTO autenticacionDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            using (FinesContext finesContext = new FinesContext())
            {
                var isCredentialValid = finesContext.Usuarios.Where(x => x.Mail == autenticacionDTO.Mail &&
                                                           x.PasswordCuenta == autenticacionDTO.PasswordCuenta).ToList();

                if (isCredentialValid.Count == 1)
                {
                    var token = TokenGenerator.GenerateTokenJwt(autenticacionDTO.Mail);
                    var idUsuario = (from a in finesContext.Usuarios where (a.Mail== autenticacionDTO.Mail) 
                                     select new {id = a.Id_Usuario, rol =a.Rol }).ToList();
                        
                    var tokenDTO = new TokenDTO();
                    tokenDTO.Token = token;
                    tokenDTO.Id_Usuario = idUsuario[0].id;
                    tokenDTO.rol= idUsuario[0].rol;
                    return Ok(tokenDTO);
                }
                else
                    return Unauthorized();//Status code 401

            };
        }
    }
}
