using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Fines.BL.Models
{
    [Table("Usuario", Schema = "dbo")]
    public class Usuario
    {
        [Key]
        public int Id_Usuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string DNI { get; set; }
        public string PasswordCuenta { get; set; }
        public string Direccion { get; set; }
        public string Mail { get; set; }
        public string telefono { get; set; }
        public int Rol { get; set; }
        public virtual ICollection<curso> cursos {get; set;}
        public virtual ICollection<TrayectoriaAcademica> TrayectoriaAcademicas {get; set;}
        public virtual ICollection<Cursada> Cursadas{get; set;}
        public virtual ICollection<CompetenciaDocente> CompetenciaDocentes { get; set; }
    }
}
