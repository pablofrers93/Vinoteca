using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vinoteca.Entidades.Dtos.Venta;
using Vinoteca.Entidades.Dtos.VentaProducto;
using Vinoteca.Entidades.Entidades;

namespace Vinoteca.Servicios.Interfaces
{
    public interface IServiciosVentas
    {
        List<VentaProductoListDto> GetVentaProducto(int ventaId);
        List<VentaListDto> GetVentas();
        void Guardar(Venta venta, string name);
        int GetCantidad();
        VentaListDto GetVentasPorId(int id);
    }
}
