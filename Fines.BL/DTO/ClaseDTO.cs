using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fines.BL.DTO
{
    public class ClaseDTO
    {
        public int Id_Clase { get; set; }
        public string Contenido { get; set; }
        public string Titulo { get; set; }
        public string Fecha { get; set; }
        public int ClaseNumero { get; set; }

        public int Id_Curso { get; set; }
        public CursoDTO Curso { get; set; }
    }
}
