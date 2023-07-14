using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Vinoteca.Datos;
using Vinoteca.Datos.Interfaces;
using Vinoteca.Entidades.Entidades;
using Vinoteca.Servicios.Interfaces;

namespace Vinoteca.Servicios.Servicios
{
    public class ServiciosBodegas : IServiciosBodegas
    {
        private readonly IRepositorioBodegas _repositorioBodegas;
        private readonly IUnitOfWork _unitOfWork;
        public ServiciosBodegas(IRepositorioBodegas repositorioBodegas, IUnitOfWork unitOfWork)
        {
            _repositorioBodegas = repositorioBodegas;
            _unitOfWork = unitOfWork;   
        }
        public void Borrar(int bodegaId)
        {
            try
            {
                _repositorioBodegas.Borrar(bodegaId);
                _unitOfWork.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool EstaRelacionada(Bodega bodega)
        {
            try
            {
                return _repositorioBodegas.EstaRelacionada(bodega);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Existe(Bodega bodega)
        {
            try
            {
                return _repositorioBodegas.Existe(bodega);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Bodega> Filtrar(Func<Bodega, bool> predicado, int cantidad, int pagina)
        {
            try
            {
                return _repositorioBodegas.Filtrar(predicado, cantidad, pagina);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Bodega> GetBodegas()
        {
            try
            {
                return _repositorioBodegas.GetBodegas();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Bodega> GetBodegasPorPagina(int cantidad, int pagina)
        {
            try
            {
                return _repositorioBodegas.GetBodegasPorPagina(cantidad, pagina);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Bodega GetBodegaPorId(int bodegaId)
        {
            try
            {
                return _repositorioBodegas.GetBodegaPorId(bodegaId);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<SelectListItem> GetBodegasDropDownList()
        {
            try
            {
                return _repositorioBodegas.GetBodegasDropDownList();
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
                return _repositorioBodegas.GetCantidad();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int GetCantidad(Func<Bodega, bool> predicado)
        {
            try
            {
                return _repositorioBodegas.GetCantidad(predicado);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Guardar(Bodega bodega)
        {
            try
            {
                if (bodega.BodegaId == 0)
                {
                    _repositorioBodegas.Agregar(bodega);

                }
                else
                {
                    _repositorioBodegas.Editar(bodega);
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
