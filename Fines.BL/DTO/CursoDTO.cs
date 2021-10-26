using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fines.BL.DTO
{
    public class CursoDTO
    {
        public int Id_Curso { get; set; }
        public int AnioCurso { get; set; }
        public string Ige { get; set; }
        public bool estado { get; set; }
        public string diaHorario { get; set; }
        public int Id_Sede { get; set; }
        public int Id_Materias { get; set; }
        public int Id_Usuario { get; set; }
    }
}
