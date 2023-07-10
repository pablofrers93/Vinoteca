using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Vinoteca.Entidades.Entidades;

namespace Vinoteca.Servicios.Interfaces
{
    public interface IServiciosBodegas
    {
        List<Bodega> GetBodegas();
        bool Existe(Bodega bodega);
        void Guardar(Bodega bodega);
        bool EstaRelacionada(Bodega bodega);
        Bodega GetBodegaPorId(int bodegaId);
        void Borrar(int bodegaId);
        List<Bodega> Filtrar(Func<Bodega, bool> predicado, int cantidad, int pagina);
        int GetCantidad();
        List<Bodega> GetBodegasPorPagina(int cantidad, int pagina);
        int GetCantidad(Func<Bodega, bool> predicado);
    }
}
