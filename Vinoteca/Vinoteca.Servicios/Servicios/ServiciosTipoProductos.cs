using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Vinoteca.Datos;
using Vinoteca.Datos.Repositorios;
using Vinoteca.Entidades.Dtos.TipoProductos;
using Vinoteca.Entidades.Entidades;
using Vinoteca.Servicios.Interfaces;

namespace Vinoteca.Servicios.Servicios
{
    public class ServiciosTipoProductos : IServiciosTipoProductos
    {
        private readonly RepositorioTipoProductos _repositorio;
        private readonly UnitOfWork _unitOfWork;
        public ServiciosTipoProductos(RepositorioTipoProductos repositorio, UnitOfWork unitOfWork)
        {
            _repositorio = repositorio;
            _unitOfWork = unitOfWork;
        }
        public void Agregar(TipoProducto tipoProducto)
        {
            try
            {
                if (tipoProducto.TipoProductoId == 0)
                {
                    _repositorio.Agregar(tipoProducto);
                }
                else
                {
                    _repositorio.Editar(tipoProducto);
                }
                _unitOfWork.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Borrar(int id)
        {
            try
            {
                _repositorio.Borrar(id);
                _unitOfWork.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool EstaRelacionado(TipoProducto tipoProducto)
        {
            try
            {
                return _repositorio.EstaRelacionado(tipoProducto);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Existe(TipoProducto tipoProducto)
        {
            try
            {
                return _repositorio.Existe(tipoProducto);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int GetCantidad()
        {
            try
            {
                return _repositorio.GetCantidad();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public TipoProducto GetTipoProductoPorId(int tipoProductoId)    
        {
            try
            {
                return _repositorio.GetTipoProductoPorId(tipoProductoId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<TipoProductoListDto> GetTipoProductos()
        {
            try
            {
                return _repositorio.GetTipoProductos();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<SelectListItem> GetTipoProductosDropDownList()
        {
            try
            {
                return _repositorio.GetTipoProductosDropDownList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<TipoProducto> GetTipoProductosPorPagina(int cantidad, int pagina)
        {
            try
            {
                return _repositorio.GetTipoProductosPorPagina(cantidad, pagina);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
