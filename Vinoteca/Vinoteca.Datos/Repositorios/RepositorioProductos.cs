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
            var productoInDb = _context.Productos.SingleOrDefault(p => p.IdProducto == productoId);
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
            var productoInDb = _context.Productos.SingleOrDefault(p => p.IdProducto == id);
            if (productoInDb == null)
            {
                throw new Exception("Producto borrado por otro usuario");
            }
            _context.Entry(productoInDb).State = EntityState.Deleted;
        }

        public void Editar(Producto producto)
        {
            var productoInDb = _context.Productos.SingleOrDefault(p => p.IdProducto == producto.IdProducto);
            if (productoInDb == null)
            {
                throw new Exception("Producto borrado por otro usuario");
            }
            productoInDb.Descripcion = producto.Descripcion;
            productoInDb.IdVariedad = producto.IdVariedad;
            productoInDb.IdTipoProducto = producto.IdTipoProducto;
            productoInDb.PrecioVenta = producto.PrecioVenta;
            productoInDb.FichaTecnica = producto.FichaTecnica;
            productoInDb.IdBodega = producto.IdBodega;
            productoInDb.Stock = producto.Stock;
        }

        public bool EstaRelacionado(Producto producto)
        {
            return false;
        }

        public bool Existe(Producto producto)
        {
            if (producto.IdProducto == 0)
            {
                return _context.Productos.Any(p => p.Descripcion == producto.Descripcion &&
                p.IdVariedad == producto.IdVariedad);
            }
            return _context.Productos.Any(p => p.Descripcion == producto.Descripcion &&
                p.IdVariedad == producto.IdVariedad && p.IdProducto != producto.IdProducto);
        }

        public List<ProductoListDto> Filtrar(Func<Producto, bool> predicado)
        {
            throw new NotImplementedException();
        }

        public Producto GetProductoPorId(int id)
        {
            return _context.Productos.Include(p => p.Variedad)
                .Include(p => p.Bodega).SingleOrDefault(p => p.IdProducto == id);
        }

        public List<ProductoListDto> GetProductos()
        {
            return _context.Productos.Include(p => p.Variedad)
                .Select(p => new ProductoListDto()
                {
                    IdProducto = p.IdProducto,
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
                .Where(p => p.IdVariedad == variedadId)
                .Select(p => new ProductoListDto()
                {
                    IdProducto = p.IdProducto,
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
    }
}
