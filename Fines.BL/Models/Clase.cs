using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace Fines.BL.Models
{
    [Table("Clase", Schema = "dbo")]
    public class Clase
    {
        [Key]
        public int Id_Clase { get; set; }
        public string Contenido { get; set; }
        public string Titulo { get; set; }
        public string Fecha { get; set; }
        public int ClaseNumero { get; set; }
        [ForeignKey("Curso")]
        public int Id_Curso { get; set; }
        public curso Curso { get; set; }
        public virtual ICollection<Asistencia> Asistencias{ get; set; }

    }
}
