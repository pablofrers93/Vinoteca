using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vinoteca.Datos.Interfaces;
using Vinoteca.Entidades.Entidades;

namespace Vinoteca.Datos.Repositorios
{
    public class RepositorioCarrito : IRepositorioCarritos
    {
        private readonly VinotecaDbContext _context;

        public RepositorioCarrito(VinotecaDbContext context)
        {
            _context = context;
        }

        public void Guardar(ItemCarrito carritoTemp)
        {
            var itemInDb = GetItem(carritoTemp.UserName,
                carritoTemp.ProductoId);

            if (itemInDb != null)
            {
                itemInDb.Cantidad += carritoTemp.Cantidad;
                _context.Entry(itemInDb).State = EntityState.Modified;

            }
            else
            {
                _context.Carrito.Add(carritoTemp);
            }
        }

        public void Borrar(string user, int productoId)
        {
            var itemInDb = GetItem(user, productoId);
            if (itemInDb != null)
            {
                _context.Entry(itemInDb).State = EntityState.Deleted;
            }
        }
        public int GetCantidad(string user)
        {
            return _context.Carrito.Count(c => c.UserName == user);
        }

        public List<ItemCarrito> GetCarrito(string user)
        {
            return _context.Carrito
               .Where(c => c.UserName == user).ToList();
        }

        public ItemCarrito GetItem(string user, int productoId)
        {
            return _context.Carrito
                        .SingleOrDefault(i => i.UserName == user && i.ProductoId == productoId);
        }
    }
}