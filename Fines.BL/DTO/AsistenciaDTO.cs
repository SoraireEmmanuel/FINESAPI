using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fines.BL.Models;

namespace Fines.BL.DTO
{
    public class AsistenciaDTO
    {
        public int Id_Asistencia { get; set; }
        public Boolean Asistio { get; set; }
        public int NumeroClase { get; set; }
        public int Id_Cursada { get; set; }        
        public int Id_Clase { get; set; }
        public CursadaDTO Cursada { get; set; }
        public ClaseDTO Clase { get; set; }
    }
}
