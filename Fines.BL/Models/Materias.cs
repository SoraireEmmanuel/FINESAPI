using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Fines.BL.Models
{
    [Table("Materias", Schema = "dbo")]
    public class Materias
    {
        [Key]
        public int Id_Materias { get; set; }
        public int Anio { get; set; }
        public int Cuatrimestre { get; set; }
        public string NombreMateria { get; set; }
        public string CargaHoraria { get; set; }
        public string CodigoMateria { get; set; }
        public virtual ICollection<CompetenciaDocente> CompetenciaDocentes{ get; set; }
        public virtual ICollection<curso> Cursos{ get; set; }

    }
}
