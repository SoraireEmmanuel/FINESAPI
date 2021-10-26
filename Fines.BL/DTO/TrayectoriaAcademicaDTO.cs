using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fines.BL.DTO
{
    public class TrayectoriaAcademicaDTO
    {
        public int Id_TrayectoriaAcademica { get; set; }
        public int Id_Usuario { get; set; }
        public int Id_Cursada { get; set; }
        public UsuarioDTO Usuario { get; set; }
        public CursadaDTO Cursada { get; set; }
    }
}
