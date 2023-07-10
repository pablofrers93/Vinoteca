using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vinoteca.Datos.Interfaces;
using Vinoteca.Entidades.Dtos.Producto;
using Vinoteca.Entidades.Entidades;

namespace Vinoteca.Datos.Repositorios
{
    public class RepositorioProductos : IRepositorioProductos
    {
        private readonly VinotecaDbContext _context;
        public RepositorioProductos(VinotecaDbContext context)
        {
            _context = context;
        }
        public void ActualizarStock(int productoId, int cantidad)
        {
            var productoInDb = _context.Productos.SingleOrDefault(p => p.ProductoId == productoId);
            //productoInDb.UnidadesEnPedido -= cantidad;
            productoInDb.Stock -= cantidad;
            _context.Entry(productoInDb).State = EntityState.Modified;
        }

        public void Agregar(Producto producto)
        {
            _context.Productos.Add(producto);
        }

        public void Borrar(int id)
        {
            var productoInDb = _context.Productos.SingleOrDefault(p => p.ProductoId == id);
            if (productoInDb == null)
            {
                throw new Exception("Producto borrado por otro usuario");
            }
            _context.Entry(productoInDb).State = EntityState.Deleted;
        }

        public void Editar(Producto producto)
        {
            var productoInDb = _context.Productos.SingleOrDefault(p => p.ProductoId == producto.ProductoId);
            if (productoInDb == null)
            {
                throw new Exception("Producto borrado por otro usuario");
            }
            productoInDb.Descripcion = producto.Descripcion;
            productoInDb.VariedadId = producto.VariedadId;
            productoInDb.TipoProductoId = producto.TipoProductoId;
            productoInDb.PrecioVenta = producto.PrecioVenta;
            productoInDb.FichaTecnica = producto.FichaTecnica;
            productoInDb.BodegaId = producto.BodegaId;
            productoInDb.Stock = producto.Stock;
        }

        public bool EstaRelacionado(Producto producto)
        {
            return false;
        }

        public bool Existe(Producto producto)
        {
            if (producto.ProductoId == 0)
            {
                return _context.Productos.Any(p => p.Descripcion == producto.Descripcion &&
                p.VariedadId == producto.VariedadId);
            }
            return _context.Productos.Any(p => p.Descripcion == producto.Descripcion &&
                p.VariedadId == producto.VariedadId && p.ProductoId != producto.ProductoId);
        }

        public List<ProductoListDto> Filtrar(Func<Producto, bool> predicado)
        {
            throw new NotImplementedException();
        }

        public Producto GetProductoPorId(int id)
        {
            return _context.Productos.Include(p => p.Variedad)
                .Include(p => p.Bodega).SingleOrDefault(p => p.ProductoId == id);
        }

        public List<ProductoListDto> GetProductos()
        {
            return _context.Productos.Include(p => p.Variedad)
                .Select(p => new ProductoListDto()
                {
                    ProductoId = p.ProductoId,
                    Descripcion = p.Descripcion,
                    Variedad = p.Variedad.NombreVariedad,
                    PrecioVenta = p.PrecioVenta,
                    TipoProducto = p.TipoProducto.NombreTipoProducto,
                    FichaTecnica = p.FichaTecnica,
                    Bodega = p.Bodega.NombreBodega,
                    Stock = p.Stock    
                }).ToList();
        }

        public List<ProductoListDto> GetProductos(int variedadId)
        {
            return _context.Productos.Include(p => p.Variedad)
                .Where(p => p.VariedadId == variedadId)
                .Select(p => new ProductoListDto()
                {
                    ProductoId = p.ProductoId,
                    Descripcion = p.Descripcion,
                    Variedad = p.Variedad.NombreVariedad,
                    PrecioVenta = p.PrecioVenta,
                    TipoProducto = p.TipoProducto.NombreTipoProducto,
                    FichaTecnica = p.FichaTecnica,
                    Bodega = p.Bodega.NombreBodega,
                    Stock = p.Stock
                }).ToList();
        }
        public int GetCantidad()
        {
            return _context.Productos.Count();
        }

        public void ActualizarUnidadesEnPedido(int productoId, int cantidad)
        {
            var productoInDb = _context.Productos.SingleOrDefault(p => p.ProductoId == productoId);
            productoInDb.UnidadesEnPedido += cantidad;
            _context.Entry(productoInDb).State = EntityState.Modified;
        }
    }
}
