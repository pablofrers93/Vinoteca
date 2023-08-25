using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vinoteca.Entidades.Entidades
{
    public class Permiso
    {
        public int PermisoId { get; set; }
        public int RolId { get; set; }
        public string NombreMenu { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
