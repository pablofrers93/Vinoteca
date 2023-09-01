using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vinoteca.Entidades.Entidades;

namespace Vinoteca.Web.Models.Carrito
{
    public class Carrito
    {
        public List<ItemCarrito> Items { get; set; }
        public Carrito()
        {
            Items = new List<ItemCarrito>();
        }
        public int GetCantidad() => Items.Sum(i => i.Cantidad);

        public void AddToCart(ItemCarrito itemCarrito)
        {
            var itemInCarrito = Items
                .SingleOrDefault(i => i.ProductoId == itemCarrito.ProductoId);
            if (itemInCarrito == null)
            {
                Items.Add(itemCarrito);

            }
            else
            {
                itemInCarrito.Cantidad += itemCarrito.Cantidad;
            }
        }
        public List<ItemCarrito> GetItems() => Items;

        public void Clear()
        {
            Items.Clear();
        }

        public void RemoveFromCart(int productoId)
        {
            var itemInCarrito = Items
                .SingleOrDefault(i => i.ProductoId == productoId);
            Items.Remove(itemInCarrito);
        }

        public decimal GetTotal()
        {
            return Items.Sum(i => i.PrecioTotal);
        }
    }
}