﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vinoteca.Entidades.Dtos.Usuario
{
    public class UsuarioListDto
    {
        public int UsuarioId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Pass { get; set; }
        public string Rol { get; set; }
    }
}
