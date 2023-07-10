using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vinoteca.Entidades.Dtos.Producto;
using Vinoteca.Entidades.Entidades;

namespace Vinoteca.Servicios.Interfaces
{
    public interface IServiciosProductos
    {
        void Guardar(Producto producto);
        void Borrar(int id);
        bool EstaRelacionado(Producto producto);
        bool Existe(Producto producto);
        Producto GetProductoPorId(int id);
        List<ProductoListDto> GetProductos();
        List<ProductoListDto> GetProductos(int categoriaId);
        List<ProductoListDto> Filtrar(Func<Producto, bool> predicado);
        void ActualizarUnidadesEnPedido(int productoId, int cantidad);
        int GetCantidad();
    }
}
