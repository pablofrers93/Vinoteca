using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Vinoteca.Web.ViewModels.Carrito
{
    public class ItemCarritoVm
    {
        public int ProductoId { get; set; }

        [DisplayName("Producto")]
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }

        [DisplayName("P. Unit.")]

        public decimal Precio { get; set; }

        [DisplayName("P. Total")]
        public decimal Importe => Cantidad * Precio;
    }
}