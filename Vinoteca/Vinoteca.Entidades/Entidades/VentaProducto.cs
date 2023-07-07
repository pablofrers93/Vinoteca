using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vinoteca.Entidades.Entidades
{
    public class VentaProducto
    {
        public int VentaProductoId { get; set; }
        public int VentaId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }

        public Producto Producto { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
