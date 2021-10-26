using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fines.BL.Models;
using Fines.BL.Data;

namespace Fines.BL.Repositories.Implements
{
    public class MateriasRepository:GenericRepository<Materias>,IMaterias
    {
        public MateriasRepository(FinesContext finesContext) : base(finesContext)
        {

        }
    }
}
