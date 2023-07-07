using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vinoteca.Entidades.Entidades;

namespace Vinoteca.Datos.EntityTypeConfigurations
{
    public class VariedadEntityTypeConfigurations:EntityTypeConfiguration<Variedad>
    {
        public VariedadEntityTypeConfigurations()
        {
            ToTable("Variedades");
            Property(r => r.NombreVariedad).HasColumnName("Variedad");
            Property(r => r.RowVersion).IsRowVersion().IsConcurrencyToken();
        }
    }
}
