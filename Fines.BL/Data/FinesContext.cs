using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Fines.BL.Models;

namespace Fines.BL.Data
{
    public class FinesContext: DbContext 
    {
        public FinesContext():base("PebaContext")
        {
            
        }
        public DbSet<Cens> Censs { get; set; }
        public DbSet<CompetenciaDocente> CompetenciaDocentes{ get; set; }
        public DbSet<Cursada> Cursadas{ get; set; }
        public DbSet<curso> Cursos{ get; set; }
        public DbSet<Materias> Materias{ get; set; }
        public DbSet<Sede> Sedes{ get; set; }
        public DbSet<TrayectoriaAcademica> TrayectoriaAcademicas{ get; set; }
        public DbSet<Usuario> Usuarios{ get; set; }
        public DbSet<Clase> Clases { get; set; }
        public DbSet<Asistencia> Asistencias { get; set; }
        public static FinesContext Create()
        {
            return new FinesContext();
        }

    }
}
