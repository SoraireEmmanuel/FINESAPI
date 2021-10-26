using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Fines.BL.Models
{
    [Table("curso", Schema = "dbo")]
    public class curso
    {

        [Key]
        public int Id_Curso { get; set; }
        public int AnioCurso { get; set; }
        public bool estado { get; set; }
        public string diaHorario { get; set; }
        public string Ige { get; set; }
        [ForeignKey("Sede")]
        public int Id_Sede { get; set; }
        [ForeignKey("Materias")]
        public int Id_Materias { get; set; }
        [ForeignKey("Usuario")]
        public int Id_Usuario { get; set; }
        public Sede Sede{ get; set; }
        public Materias Materias{ get; set; }
        public Usuario Usuario{ get; set; }
        public virtual ICollection<Cursada> Cursadas { get; set; }
        public virtual ICollection<Clase> Clases { get; set; }

    }
}
