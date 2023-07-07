using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vinoteca.Entidades.Dtos.Venta
{
    public class VentaListDto
    {
        public int VentaId { get; set; }
        public string Usuario { get; set; }
        public DateTime Fecha { get; set; }
        public int Numero { get; set; }
        public bool Anulado { get; set; }
        public decimal Importe { get; set; }
    }
}
