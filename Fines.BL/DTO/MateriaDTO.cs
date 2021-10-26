using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fines.BL.DTO
{
    public class MateriaDTO
    {
        public int Id_Materias { get; set; }
        public int Anio { get; set; }
        public int Cuatrimestre { get; set; }
        public string NombreMateria { get; set; }
        public string CargaHoraria { get; set; }
        public string CodigoMateria { get; set; }
    }
}
