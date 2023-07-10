using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using Vinoteca.Datos.Interfaces;
using Vinoteca.Entidades.Dtos.VentaProducto;
using Vinoteca.Entidades.Entidades;

namespace Vinoteca.Datos.Repositorios
{
    public class RepositorioVentasProductos : IRepositorioVentasProductos
    {
        private readonly VinotecaDbContext _context;
        public RepositorioVentasProductos(VinotecaDbContext context)
        {
            _context = context; 
        }
        public void Agregar(VentaProducto ventaProducto)
        {
            _context.VentasProductos.Add(ventaProducto);
        }

        public void Borrar(int id)
        {
            throw new NotImplementedException();
        }

        public void Editar(VentaProducto ventaProducto)
        {
            throw new NotImplementedException();
        }

        public bool EstaRelacionado(VentaProducto ventaProducto)
        {
            throw new NotImplementedException();
        }

        public bool Existe(VentaProducto ventaProducto)
        {
            throw new NotImplementedException();
        }

        public VentaProducto GetVentaProductoPorId(int id)
        {
            throw new NotImplementedException();
        }

        public List<VentaProductoListDto> GetVentaProductos(int ventaId)
        {
            return _context.VentasProductos.Include(d => d.Producto)
                .Where(d => d.VentaId == ventaId)
                .Select(d => new VentaProductoListDto()
                {
                    VentaProductoId = d.VentaProductoId,
                    Producto = d.Producto.Descripcion,
                    Cantidad = d.Cantidad,
                    Precio = d.Precio,

                }).ToList();
        }
    }
}
