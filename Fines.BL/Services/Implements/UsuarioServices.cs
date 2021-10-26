﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fines.BL.Models;
using Fines.BL.Repositories;

namespace Fines.BL.Services.Implements
{
    public class UsuarioServices:GenericService<Usuario>, IUsuarioServices
    {
        public UsuarioServices(IUsuario usuarioRepository):base(usuarioRepository)
        {

        }
    }
}
