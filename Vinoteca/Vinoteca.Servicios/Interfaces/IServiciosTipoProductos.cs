using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Vinoteca.Entidades.Dtos.TipoProductos;
using Vinoteca.Entidades.Entidades;

namespace Vinoteca.Servicios.Interfaces
{
    public interface IServiciosTipoProductos
    {
        List<TipoProductoListDto> GetTipoProductos();
        void Agregar(TipoProducto tipoProducto);
        void Borrar(int id);
        bool Existe(TipoProducto tipoProducto);
        TipoProducto GetTipoProductoPorId(int tipoProductoId);
        bool EstaRelacionado(TipoProducto tipoProducto);
        List<TipoProducto> GetTipoProductosPorPagina(int cantidad, int pagina);
        List<SelectListItem> GetTipoProductosDropDownList();
        int GetCantidad();
    }
}
