using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Fines.BL.Models
{
    [Table("CompetenciaDocente", Schema = "dbo")]
    public class CompetenciaDocente
    {
        [Key]
        public int Id_CompetenciaDocente { get; set; }
        public double AnioCompetencia { get; set; }
        public int Id_Usuario { get; set; }
        public int Id_Materias { get; set; }
        public Usuario Usuario { get; set; }
        public Materias Materias { get; set; }

    }
}
