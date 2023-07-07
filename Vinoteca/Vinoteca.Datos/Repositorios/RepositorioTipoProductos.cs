using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Vinoteca.Datos.Interfaces;
using Vinoteca.Entidades.Entidades;

namespace Vinoteca.Datos.Repositorios
{
    public class RepositorioTipoProductos : IRepositorioTipoProductos
    {
        public void Agregar(TipoProducto tipoProducto)
        {
            throw new NotImplementedException();
        }

        public void Borrar(int id)
        {
            throw new NotImplementedException();
        }

        public void Editar(TipoProducto tipoProducto)
        {
            throw new NotImplementedException();
        }

        public bool EstaRelacionado(TipoProducto tipoProducto)
        {
            throw new NotImplementedException();
        }

        public bool Existe(TipoProducto tipoProducto)
        {
            throw new NotImplementedException();
        }

        public int GetCantidad()
        {
            throw new NotImplementedException();
        }

        public TipoProducto GetTipoProductoPorId(int tipoProductoId)
        {
            throw new NotImplementedException();
        }

        public List<TipoProducto> GetTipoProductos()
        {
            throw new NotImplementedException();
        }

        public List<SelectListItem> GetTipoProductosDropDownList()
        {
            throw new NotImplementedException();
        }

        public List<TipoProducto> GetTipoProductosPorPagina(int cantidad, int pagina)
        {
            throw new NotImplementedException();
        }
    }
}
