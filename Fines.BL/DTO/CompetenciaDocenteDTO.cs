using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fines.BL.DTO
{
    public class CompetenciaDocenteDTO
    {
        public int Id_CompetenciaDocente { get; set; }
        public double AnioCompetencia { get; set; }
        public int Id_Usuario { get; set; }
        public int Id_Materias { get; set; }
        public UsuarioDTO Usuario { get; set; }
        public MateriaDTO Materias { get; set; }
    }
}
