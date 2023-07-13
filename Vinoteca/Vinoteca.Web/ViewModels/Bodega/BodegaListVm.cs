using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Vinoteca.Web.Views.Bodegas
{
    public class BodegaListVm
    {
        public int BodegaId { get; set; }
        [DisplayName("Bodega")]
        public string NombreBodega { get; set; }
        [DisplayName("Dirección")]
        public string Direccion { get; set; }
        public byte[] RowVersion { get; set; }
    }
}