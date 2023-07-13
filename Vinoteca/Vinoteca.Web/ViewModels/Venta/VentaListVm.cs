using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Vinoteca.Web.ViewModels.Venta
{
    public class VentaListVm
    {
        [DisplayName("N° Venta")]
        public int VentaId { get; set; }
        public string Usuario { get; set; }
        public DateTime Fecha { get; set; }
        public bool Anulado { get; set; }
        public decimal Importe { get; set; }
    }
}