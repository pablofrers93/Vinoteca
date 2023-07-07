using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vinoteca.Entidades.Entidades
{
    public class Bodega
    {
        public int BodegaId { get; set; }
        public string NombreBodega { get; set; }

        public string Direccion { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
