using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Fines.BL.Models
{
    [Table("Cens", Schema = "dbo")]
    public class Cens
    {
        [Key]
        public int Id_Cens { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public virtual ICollection<Sede> Sedes { get; set; }
    }
}
