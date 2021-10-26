using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Fines.BL.Models
{
    [Table("TrayectoriaAcademica", Schema = "dbo")]
    public class TrayectoriaAcademica
    {
        [Key]
        public int Id_TrayectoriaAcademica { get; set; }
        [ForeignKey("Usuario")]
        public int Id_Usuario { get; set; }
        [ForeignKey("Cursada")]
        public int Id_Cursada { get; set; }
        public Usuario Usuario { get; set; }
        public Cursada Cursada { get; set; }
    }
}
