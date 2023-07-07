using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Vinoteca.Entidades.Entidades;

namespace Vinoteca.Datos
{
    public class VinotecaDbContext : DbContext
    {
        public VinotecaDbContext()
        {
            
        }
        public DbSet<Bodega >Bodegas { get; set; }   
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<TipoProducto> TipoProductos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }    
        public DbSet<Variedad> Variedades { get; set; } 
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<VentaProducto> VentasProductos { get;set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<VinotecaDbContext>(null);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
