using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vinoteca.Entidades.Dtos.Producto;
using Vinoteca.Entidades.Entidades;

namespace Vinoteca.Datos.Interfaces
{
    public interface IRepositorioProductos
    {
        void Agregar(Producto producto);
        void Borrar(int id);
        void Editar(Producto producto);
        bool EstaRelacionado(Producto producto);
        bool Existe(Producto producto);
        Producto GetProductoPorId(int id);
        List<ProductoListDto> GetProductos();
        List<ProductoListDto> GetProductos(int categoriaId);
        List<ProductoListDto> Filtrar(Func<Producto, bool> predicado);
        void ActualizarStock(int productoId, int cantidad);
        int GetCantidad();
    }
}
