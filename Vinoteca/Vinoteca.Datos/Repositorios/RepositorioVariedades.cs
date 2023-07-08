using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Vinoteca.Datos.Interfaces;
using Vinoteca.Entidades.Entidades;

namespace Vinoteca.Datos.Repositorios
{
    public class RepositorioVariedades : IRepositorioVariedades
    {
        private readonly VinotecaDbContext _context;
        public RepositorioVariedades(VinotecaDbContext context)
        {
            _context = context;
        }
        public void Agregar(Variedad variedad)
        {
            _context.Variedades.Add(variedad);
        }

        public void Borrar(int id)
        {
            try
            {
                var variedadInDb = _context.Variedades.SingleOrDefault(p => p.VariedadId == id);
                if (variedadInDb == null)
                {
                    Exception ex = new Exception("Borrado por otro usuario");
                    throw ex;
                }
                _context.Entry(variedadInDb).State = EntityState.Deleted;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Editar(Variedad variedad)
        {
            try
            {
                var variedadInDb = _context.Variedades.SingleOrDefault(c => c.VariedadId == variedad.VariedadId);
                if (variedadInDb == null)
                {
                    throw new Exception("Borrado por otro usuario");
                }
                variedadInDb.NombreVariedad = variedad.NombreVariedad;
                _context.Entry(variedadInDb).State = EntityState.Modified;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool EstaRelacionado(Variedad variedad)
        {
            try
            {
                return _context.Productos.Any(c => c.VariedadId == variedad.VariedadId);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Existe(Variedad variedad)
        {
            try
            {
                if (variedad.VariedadId == 0)
                {
                    return _context.Variedades.Any(p => p.NombreVariedad == variedad.NombreVariedad);
                }
                return _context.Variedades.Any(p => p.NombreVariedad == variedad.NombreVariedad && p.VariedadId != variedad.VariedadId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int GetCantidad()
        {
            return _context.Variedades.Count();
        }

        public List<SelectListItem> GetVariedadesDropDownList()
        {
            var lista = GetVariedades();
            var dropDown = lista.Select(c => new SelectListItem
            {
                Text = c.NombreVariedad,
                Value = c.VariedadId.ToString()
            }).ToList();
            return dropDown;
        }

        public List<Variedad> GetVariedadesPorPagina(int cantidad, int pagina)
        {
            return _context.Variedades.OrderBy(p => p.NombreVariedad)
              .Skip(cantidad * (pagina - 1))
              .Take(cantidad)
              .ToList();
        }

        public Variedad GetVariedadPorId(int variedadId)
        {
            try
            {
                var variedadInDb = _context.Variedades
                    .SingleOrDefault(p => p.VariedadId == variedadId);
                return variedadInDb;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Variedad> GetVariedades()
        {
            try
            {
                return _context.Variedades
                    .OrderBy(p => p.NombreVariedad)
                    .ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
