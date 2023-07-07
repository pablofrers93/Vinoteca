using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vinoteca.Entidades.Dtos.VentaProducto;
using Vinoteca.Entidades.Entidades;

namespace Vinoteca.Datos.Interfaces
{
    public interface IRepositorioVentasProductos
    {
        void Agregar(VentaProducto ventaProducto);
        void Borrar(int id);
        void Editar(VentaProducto ventaProducto);
        bool EstaRelacionado(VentaProducto ventaProducto);
        bool Existe(VentaProducto ventaProducto);
        VentaProducto GetVentaProductoPorId(int id);
        List<VentaProductoListDto> GetVentaProductos(int ventaId);
    }
}
