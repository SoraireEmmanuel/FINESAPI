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
    public class TrayectoriaAcademicasController : ApiController
    {
        private IMapper mapper;
        private readonly UsuarioServices usuarioServices = new UsuarioServices(new UsuarioRepository(FinesContext.Create()));
        public TrayectoriaAcademicasController()
        {
            this.mapper = WebApiApplication.MapperConfiguration.CreateMapper();
        }
        /// <summary>
        /// Recupera la trayectoria de un alumno
        /// </summary>
        /// <remarks>Recupera la trayectoria del alumno,
        /// trae las 24 materias del plan con su estado actual</remarks>
        /// <param name="id"></param>
        /// <returns></returns>
        ///[ResponseType(typeof(IEnumerable<UsuarioDTO>))]
      
        [HttpGet]
        public async Task<IHttpActionResult> GetTrayectoriaByIdEstudiante(int id)
        {
            using(FinesContext finesContext1=new FinesContext())
            {
                var isAlumn = await (from u in finesContext1.Usuarios
                    where (u.Id_Usuario == id && u.Rol==1)
                    select new { id=u.Id_Usuario }).ToListAsync();
                if (isAlumn.Count == 0)
                    return BadRequest("El usuario no existe o no es un alumno");
            }
            using (FinesContext finesContext = new FinesContext())
            {
                try
                {
                    var trayectoria = await (from u in finesContext.Usuarios
                                             join ta in finesContext.TrayectoriaAcademicas on u.Id_Usuario equals ta.Id_Usuario
                                             join c in finesContext.Cursadas on ta.Id_Cursada equals c.Id_Cursada
                                             join cc in finesContext.Cursos on c.Id_Curso equals cc.Id_Curso
                                             join m in finesContext.Materias on cc.Id_Materias equals m.Id_Materias
                                             where u.Id_Usuario == id
                                             select new
                                             {
                                                 Id_Cursada = c.Id_Cursada,
                                                 Estado = c.Estado,
                                                 NombreMateria = m.NombreMateria,
                                                 Anio = m.Anio,
                                                 Cuatrimestre = m.Cuatrimestre
                                             }).ToListAsync();

                    return Ok(trayectoria);
                }
                catch (Exception ex)
                {

                    return InternalServerError(ex);
                }
            }         
        }
       
    }
}
