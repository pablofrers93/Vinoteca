using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vinoteca.Entidades.Entidades;

namespace Vinoteca.Datos.EntityTypeConfigurations
{
    public class BodegaEntityTypeConfigurations:EntityTypeConfiguration<Bodega>
    {
        public BodegaEntityTypeConfigurations()
        {
            ToTable("Bodegas");
            Property(b => b.NombreBodega).HasColumnName("Bodega");
            Property(b => b.RowVersion).IsRowVersion().IsConcurrencyToken();
        }       
    }
}
