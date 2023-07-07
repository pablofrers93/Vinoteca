using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vinoteca.Entidades.Entidades;

namespace Vinoteca.Datos.EntityTypeConfigurations
{
    public class RolesEntityTypeConfigurations : EntityTypeConfiguration<Rol>
    {
        public RolesEntityTypeConfigurations()
        {
            ToTable("Roles");
            Property(r => r.NombreRol).HasColumnName("Rol");
            Property(r => r.RowVersion).IsRowVersion().IsConcurrencyToken();
        }
    }
}
