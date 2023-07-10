using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vinoteca.Datos.Repositorios;
using Vinoteca.Datos;
using Vinoteca.Entidades.Dtos.Producto;
using Vinoteca.Entidades.Entidades;
using Vinoteca.Servicios.Interfaces;
using System.Runtime.Remoting.Contexts;

namespace Vinoteca.Servicios.Servicios
{
    public class ServiciosProductos : IServiciosProductos
    {
        private readonly RepositorioProductos _repositorio;
        private readonly IUnitOfWork _unitOfWork;
        public ServiciosProductos(RepositorioProductos repositorio, IUnitOfWork unitOfWork)
        {
            _repositorio = repositorio;
            _unitOfWork = unitOfWork;
        }
        public void ActualizarUnidadesEnPedido(int productoId, int cantidad)
        {
            try
            {
                _repositorio.ActualizarUnidadesEnPedido(productoId, cantidad);
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

        public bool EstaRelacionado(Producto producto)
        {
            try
            {
                return _repositorio.EstaRelacionado(producto);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Existe(Producto producto)
        {
            try
            {
                return _repositorio.Existe(producto);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<ProductoListDto> Filtrar(Func<Producto, bool> predicado)
        {
            throw new NotImplementedException();
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

        public Producto GetProductoPorId(int id)
        {
            try
            {
                return _repositorio.GetProductoPorId(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<ProductoListDto> GetProductos()
        {
            try
            {
                return _repositorio.GetProductos();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<ProductoListDto> GetProductos(int variedadId)
        {
            try
            {
                return _repositorio.GetProductos(variedadId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Guardar(Producto producto)
        {
            try
            {
                if (producto.ProductoId == 0)
                {
                    _repositorio.Agregar(producto);
                }
                else
                {
                    _repositorio.Editar(producto);
                }
                _unitOfWork.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
