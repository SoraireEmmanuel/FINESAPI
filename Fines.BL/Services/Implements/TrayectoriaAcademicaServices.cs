using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fines.BL.Models;
using Fines.BL.Repositories;

namespace Fines.BL.Services.Implements
{
    public class TrayectoriaAcademicaServices:GenericService<TrayectoriaAcademica>, ITrayectoriaAcademicaServices
    {
        public TrayectoriaAcademicaServices(ITrayectoriaAcademica trayectoriaAcademicaRepository):base(trayectoriaAcademicaRepository)
        {

        }
    }
}
