using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vinoteca.Datos.Interfaces;
using Vinoteca.Datos;
using Vinoteca.Entidades.Entidades;
using Vinoteca.Servicios.Interfaces;

namespace Vinoteca.Servicios
{
    public class ServiciosCarritos : IServiciosCarritos
    {
        private readonly IRepositorioCarritos _repositorio;
        private readonly IUnitOfWork _unitOfWork;

        public ServiciosCarritos(IRepositorioCarritos repositorio)
        {
            _repositorio = repositorio;
        }

        public ServiciosCarritos(IRepositorioCarritos repositorio, IUnitOfWork unitOfWork) : this(repositorio)
        {
            _unitOfWork = unitOfWork;
        }
        public void Borrar(string user, int productoId)
        {
            try
            {
                _repositorio.Borrar(user, productoId);
                _unitOfWork.SaveChanges();
            }
            catch (System.Exception)
            {

                throw;
            }
        }
        public int GetCantidad(string user)
        {
            try
            {
                return _repositorio.GetCantidad(user);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public List<ItemCarrito> GetCarrito(string user)
        {
            try
            {
                return _repositorio.GetCarrito(user);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public ItemCarrito GetItem(string user, int productoId)
        {
            throw new System.NotImplementedException();
        }

        public void Guardar(ItemCarrito item)
        {
            try
            {
                _repositorio.Guardar(item);
                _unitOfWork.SaveChanges();

            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}