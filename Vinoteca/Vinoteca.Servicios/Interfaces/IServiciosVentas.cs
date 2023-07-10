﻿using System;
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
        List<VentaProductoListDto> GetDetalleVenta(int ventaId);
        List<VentaListDto> GetVentas();
        void Guardar(Venta venta);
        int GetCantidad();
        VentaListDto GetVentasPorId(int value);
    }
}
