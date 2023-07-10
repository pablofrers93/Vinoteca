using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Vinoteca.Entidades.Entidades
{
    public class Producto
    {
        public int ProductoId { get; set; }
        public string Descripcion { get; set; }
        public int VariedadId { get; set; }
        public int TipoProductoId { get; set; }
        public decimal PrecioVenta { get; set; }
        public string FichaTecnica { get; set; }
        public int BodegaId { get; set; }
        public int Stock { get; set; }
        public int UnidadesEnPedido { get; set; }
        public byte[] RowVersion { get; set; }

        public Variedad Variedad { get; set; }
        public TipoProducto TipoProducto { get; set; }
        public Bodega Bodega { get; set; }
        
    }
}
