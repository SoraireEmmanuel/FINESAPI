using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Fines.BL.Models
{
    [Table("Cursada", Schema = "dbo")]
    public class Cursada
    {
        [Key]
        public int Id_Cursada { get; set; }
        public double Nota1 { get; set; }
        public double Nota2 { get; set; }
        public double NotaFinal { get; set; }
        public string Estado { get; set; }
        [ForeignKey("Usuario")]
        public int Id_Usuario { get; set; }
        [ForeignKey("Curso")]
        public int Id_Curso { get; set; }
        public Usuario Usuario { get; set; }
        public curso Curso { get; set; }
        public virtual ICollection<TrayectoriaAcademica> TrayectoriaAcademicas{ get; set; }
        public virtual ICollection<Asistencia> Asistencias{ get; set; }
    }
}
