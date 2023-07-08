using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Vinoteca.Datos.Interfaces;
using Vinoteca.Entidades.Dtos.Producto;
using Vinoteca.Entidades.Entidades;

namespace Vinoteca.Datos.Repositorios
{
    public class RepositorioTipoProductos : IRepositorioTipoProductos
    {
        private readonly VinotecaDbContext _context;
        public RepositorioTipoProductos(VinotecaDbContext context)
        {
            _context = context;
        }
        public void Agregar(TipoProducto tipoProducto)
        {
            _context.TipoProductos.Add(tipoProducto);   
        }

        public void Borrar(int id)
        {
            var tipoProductoInDb = _context.Productos.SingleOrDefault(p => p.TipoProductoId == id);
            if (tipoProductoInDb == null)
            {
                throw new Exception("Tipo tipoProducto borrado por otro usuario");
            }
            _context.Entry(tipoProductoInDb).State = EntityState.Deleted;
        }

        public void Editar(TipoProducto tipoProducto)
        {
            var tipoProductoInDb = _context.TipoProductos.SingleOrDefault(p => p.TipoProductoId == tipoProducto.TipoProductoId);
            if (tipoProductoInDb == null)
            {
                throw new Exception("Tipo Producto borrado por otro usuario");
            }
            tipoProductoInDb.NombreTipoProducto = tipoProducto.NombreTipoProducto;
        }

        public bool EstaRelacionado(TipoProducto tipoProducto)
        {
            return false;
        }

        public bool Existe(TipoProducto tipoProducto)
        {
            try
            {
                if (tipoProducto.TipoProductoId == 0)
                {
                    return _context.TipoProductos.Any(c => c.NombreTipoProducto == tipoProducto.NombreTipoProducto);
                }
                return _context.TipoProductos.Any(c => c.NombreTipoProducto == tipoProducto.NombreTipoProducto && c.TipoProductoId != tipoProducto.TipoProductoId);

            }
            catch (Exception)
            {
                throw;
            }
        }

        public int GetCantidad()
        {
            return _context.Productos.Count();
        }

        public TipoProducto GetTipoProductoPorId(int tipoProductoId)
        {
            throw new NotImplementedException();
        }

        public List<TipoProducto> GetTipoProductos()
        {
            return _context.TipoProductos
                .Select(p => new TipoProducto()
                {
                    TipoProductoId = p.TipoProductoId,
                    NombreTipoProducto = p.NombreTipoProducto
                }).ToList();
        }

        public List<SelectListItem> GetTipoProductosDropDownList()
        {
            var lista = GetTipoProductos();
            var dropDown = lista.Select(p => new SelectListItem
            {
                Text = p.NombreTipoProducto,
                Value = p.TipoProductoId.ToString()
            }).ToList();
            return dropDown;
        }

        public List<TipoProducto> GetTipoProductosPorPagina(int cantidad, int pagina)
        {
            return _context.TipoProductos
                .OrderBy(c => c.TipoProductoId)
                .Skip(cantidad * (pagina - 1))
                .Take(cantidad)
                .Select(c => new TipoProducto
                {
                    TipoProductoId = c.TipoProductoId,
                    NombreTipoProducto = c.NombreTipoProducto
                }).ToList();
        }
    }
}
