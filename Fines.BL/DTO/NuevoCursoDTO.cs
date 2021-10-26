using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Fines.BL.DTO
{
    public class NuevoCursoDTO
    {
        [Required]
        public int Id_Materia { get; set; }
        [Required]
        public int Id_Sede { get; set; }
        [Required]
        public int Anio { get; set; }
        [Required]
        public string IGE { get; set; } 
        public bool estado { get; set; }
        public string diaHorario { get; set; }
    }
}
