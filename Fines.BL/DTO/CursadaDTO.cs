using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fines.BL.DTO
{
    public class CursadaDTO
    {
        public int Id_Cursada { get; set; }
        public double Nota1 { get; set; }
        public double Nota2 { get; set; }
        public double NotaFinal { get; set; }
        public string Estado { get; set; }
      
        public int Id_Usuario { get; set; }
     
        public int Id_Curso { get; set; }
        public UsuarioDTO Usuario { get; set; }
        public CursoDTO Curso { get; set; }
    }
}
