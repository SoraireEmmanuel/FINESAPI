using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fines.BL.DTO
{
    public class SedeDTO
    {
        public int Id_Sede { get; set; }
        public string Nombre { get; set; }
        public string localidad { get; set; }
        public string Direccion { get; set; }
        public int Id_Cens { get; set; }
        public CensDTO Cens { get; set; }
    }
}
