using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vinoteca.Entidades.Dtos.Producto
{
    public class ProductoListDto
    {
        public int ProductoId { get; set; }
        public string Descripcion { get; set; }
        public string Variedad { get; set; }
        public decimal PrecioVenta { get; set; }
        [DisplayName("Stock")]
        public int UnidadesDisponibles { get; set; }
        public string Bodega { get; set; }
        public int Stock { get; set; }
        public bool Suspendido { get; set; }
        [DisplayName("Imágen")]
        public string Imagen { get; set; }
    }
}
