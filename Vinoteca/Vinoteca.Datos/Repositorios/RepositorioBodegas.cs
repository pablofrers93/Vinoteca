using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Vinoteca.Datos.Interfaces;
using Vinoteca.Entidades.Entidades;

namespace Vinoteca.Datos.Repositorios
{
    public class RepositorioBodegas : IRepositorioBodegas
    {
        private readonly VinotecaDbContext _context;
        public RepositorioBodegas(VinotecaDbContext context)
        {
            _context = context;
        }
        public void Agregar(Bodega bodega)
        {
            _context.Bodegas.Add(bodega);
        }

        public void Borrar(int id)
        {
            try
            {
                var bodegaInDb = _context.Bodegas.SingleOrDefault(p => p.BodegaId == id);
                if (bodegaInDb == null)
                {
                    Exception ex = new Exception("Borrado por otro usuario");
                    throw ex;
                }
                _context.Entry(bodegaInDb).State = EntityState.Deleted;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Editar(Bodega bodega)
        {
            try
            {
                var bodegaInDb = _context.Bodegas.SingleOrDefault(c => c.BodegaId == bodega.BodegaId);
                if (bodegaInDb == null)
                {
                    throw new Exception("Borrado por otro usuario");
                }
                bodegaInDb.NombreBodega = bodega.NombreBodega;
                bodegaInDb.Direccion = bodega.Direccion;
                _context.Entry(bodegaInDb).State = EntityState.Modified;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool EstaRelacionada(Bodega bodega)
        {
            try
            {
                return _context.Productos.Any(c => c.BodegaId == bodega.BodegaId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Existe(Bodega bodega)
        {
            try
            {
                if (bodega.BodegaId == 0)
                {
                    return _context.Bodegas.Any(p => p.NombreBodega == bodega.NombreBodega);
                }
                return _context.Bodegas.Any(p => p.NombreBodega == bodega.NombreBodega && p.BodegaId != bodega.BodegaId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Bodega GetBodegaPorId(int bodegaId)
        {
            try
            {
                var bodegaInDb = _context.Bodegas
                    .SingleOrDefault(b => b.BodegaId == bodegaId); 
                return bodegaInDb;
            }
            catch (Exception)
            { 
                throw;
            }
        }

        public List<Bodega> GetBodegas()
        {
            try
            {
                return _context.Bodegas
                    .OrderBy(b => b.NombreBodega)
                    .ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Bodega> GetBodegasPorPagina(int cantidad, int pagina)
        {
            return _context.Bodegas.OrderBy(p => p.NombreBodega)
                .Skip(cantidad * (pagina - 1))
                .Take(cantidad)
                .ToList();
        }

        public List<SelectListItem> GetBodegasDropDownList()
        {
            var lista = GetBodegas();
            var dropDown = lista.Select(b => new SelectListItem
            {
                Text = b.NombreBodega,
                Value = b.BodegaId.ToString()
            }).ToList();
            return dropDown;
        }

        public int GetCantidad()
        {
            return _context.Bodegas.Count();
        }

        public List<Bodega> Filtrar(Func<Bodega, bool> predicado, int cantidad, int pagina)
        {
            return _context.Bodegas
                .Where(predicado)
                .OrderBy(c => c.NombreBodega)
                .Skip(cantidad * (pagina - 1))
                .Take(cantidad)
                .Select(c => new Bodega
                {
                    BodegaId = c.BodegaId,
                    NombreBodega = c.NombreBodega,
                    Direccion = c.Direccion

                }).ToList();
        }

        public int GetCantidad(Func<Bodega, bool> predicado)
        {
            return _context.Bodegas.Count(predicado);
        }
    }
}
