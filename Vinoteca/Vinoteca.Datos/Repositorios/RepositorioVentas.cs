using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vinoteca.Datos.Interfaces;
using Vinoteca.Entidades.Dtos.Venta;
using Vinoteca.Entidades.Entidades;

namespace Vinoteca.Datos.Repositorios
{
    public class RepositorioVentas : IRepositorioVentas
    {
        private readonly VinotecaDbContext _context;
        public RepositorioVentas(VinotecaDbContext context)
        {
            _context = context;
        }
        public void Agregar(Venta venta)
        {
            _context.Ventas.Add(venta);
        }

        public List<VentaListDto> Filtrar(Func<Venta, bool> predicado)
        {
            throw new NotImplementedException();
        }

        public int GetCantidad()
        {
            return _context.Ventas.Count();
        }

        public VentaListDto GetVentaPorId(int id)
        {
            return _context.Ventas.Include(v => v.Usuario)

                .Select(v => new VentaListDto
                {
                    VentaId = v.VentaId,
                    Fecha = v.Fecha,
                    Usuario = v.Usuario.Nombre,
                    Importe = v.Importe,
                    Anulado = v.Anulado,
                    Numero = v.Numero
                }).SingleOrDefault(v => v.VentaId == id);
        }

        public List<VentaListDto> GetVentas()
        {
            return _context.Ventas
                .Include(v => v.Usuario)
                .OrderBy(v => v.Fecha)
                .Select(v => new VentaListDto
                {
                    VentaId = v.VentaId,
                    Fecha = v.Fecha,
                    Usuario = v.Usuario.Nombre,
                    Importe = v.Importe,
                    Anulado = v.Anulado,
                    Numero = v.Numero
                }).ToList();
        }
    }
}
