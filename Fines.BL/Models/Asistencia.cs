using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Fines.BL.Models
{
    [Table("Asistencia", Schema = "dbo")]
    public class Asistencia
    {
        [Key]
        public int Id_Asistencia { get; set; }
        public Boolean Asistio { get; set; }
        public int NumeroClase { get; set; }
        [ForeignKey("Cursada")]
        public int Id_Cursada { get; set; }
        [ForeignKey("Clase")]
        public int Id_Clase { get; set; }
        public Cursada Cursada{ get; set; }
        public Clase Clase { get; set; }

    }
}
