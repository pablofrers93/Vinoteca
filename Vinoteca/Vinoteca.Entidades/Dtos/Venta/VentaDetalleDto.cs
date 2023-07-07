using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vinoteca.Entidades.Dtos.VentaProducto;

namespace Vinoteca.Entidades.Dtos.Venta
{
     public class VentaDetalleDto
    {
        public VentaListDto Venta { get; set; }
        public List<VentaProductoListDto> VentaProducto { get; set; }
    }
}
