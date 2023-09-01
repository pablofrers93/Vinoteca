using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Vinoteca.Web.ViewModels.Producto
{
    public class ProductoListVm
    {
        public int ProductoId { get; set; }
        [DisplayName("Producto")]
        public string Descripcion { get; set; }
        public string Variedad { get; set; }

        [DisplayName("Precio")]
        public decimal PrecioVenta { get; set; }
        public string Bodega { get; set; }
        public int Stock { get; set; }
        public bool Suspendido { get; set; }
        [DisplayName("Imágen")]
        public string Imagen { get; set; }
    }
}