using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vinoteca.Entidades.Entidades;

namespace Vinoteca.Datos.EntityTypeConfigurations
{
    public class VentaEntityTypeConfigurations:EntityTypeConfiguration<Venta>
    {
        public VentaEntityTypeConfigurations()
        {
            ToTable("Ventas");
            Property(r => r.RowVersion).IsRowVersion().IsConcurrencyToken();
        }
    }
}
