using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fines.BL.DTO
{
    public class ActualizarNotaDTO
    {
        public int Id_Cursada { get; set; }
        public double Nota1 { get; set; }
        public double Nota2 { get; set; }
        public double NotaFinal { get; set; }
    }
}
