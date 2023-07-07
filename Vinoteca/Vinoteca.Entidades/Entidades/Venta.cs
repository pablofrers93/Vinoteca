using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vinoteca.Entidades.Entidades
{
    public class Venta
    {
        public int IdVenta { get; set; }
        public int IdUsuario { get; set; }
        public DateTime Fecha { get; set; }
        public int Numero { get; set; }
        public bool Anulado { get; set; }
        public decimal Importe { get; set; }
        public Usuario Usuario { get; set; }
        public List<VentaProducto> Detalles { get; set; }
        public Venta()
        {
            Detalles = new List<VentaProducto>();
        }
        public byte[] RowVersion { get; set; }
    }
}
