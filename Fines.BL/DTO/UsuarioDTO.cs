using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fines.BL.DTO
{
    public class UsuarioDTO
    {
        public int Id_Usuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string DNI { get; set; }
        public string PasswordCuenta { get; set; }
        public string Direccion { get; set; }
        public string Mail { get; set; }
        public string telefono { get; set; }
        public int Rol { get; set; }
    }
}
