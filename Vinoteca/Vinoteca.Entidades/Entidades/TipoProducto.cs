﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vinoteca.Entidades.Entidades
{
    public class TipoProducto
    {
        public int TipoProductoId { get; set; }
        public string NombreTipoProducto { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
