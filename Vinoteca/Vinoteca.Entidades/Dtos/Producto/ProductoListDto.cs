using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vinoteca.Entidades.Dtos.Producto
{
    public class ProductoListDto
    {
        public int IdProducto { get; set; }
        public string Descripcion { get; set; }
        public string Variedad { get; set; }
        public string TipoProducto { get; set; }
        public decimal PrecioVenta { get; set; }
        public string FichaTecnica { get; set; }
        public string Bodega { get; set; }
        public int Stock { get; set; }
    }
}
