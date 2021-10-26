using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Fines.BL.Models
{
    [Table("Sede", Schema = "dbo")]
    public class Sede
    {
        [Key]
        public int Id_Sede { get; set; }
        public string Nombre { get; set; }
        public string localidad { get; set; }
        public string Direccion { get; set; }
        [ForeignKey("Cens")]
        public int Id_Cens { get; set; }
        public Cens Cens { get; set; }
        public virtual ICollection<curso> cursos { get; set; }
    }
}
