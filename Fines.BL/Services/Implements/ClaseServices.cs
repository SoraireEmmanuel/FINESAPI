using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fines.BL.Models;
using Fines.BL.Repositories;

namespace Fines.BL.Services.Implements
{
    public class ClaseServices:GenericService<Clase>, IClaseServices
    {
        public ClaseServices(IClase claseRepository):base(claseRepository)
        {

        }
    }
}
