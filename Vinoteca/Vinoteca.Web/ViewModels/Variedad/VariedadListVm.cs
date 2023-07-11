using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Vinoteca.Web.ViewModels.Variedad
{
    public class VariedadListVm
    {
        public int VariedadId { get; set; }
        [DisplayName("Variedad")]
        public string NombreVariedad { get; set; }
        public byte[] RowVersion { get; set; }
    }
}