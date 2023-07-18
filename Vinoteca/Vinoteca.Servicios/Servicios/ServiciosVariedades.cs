using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Vinoteca.Datos;
using Vinoteca.Datos.Interfaces;
using Vinoteca.Entidades.Entidades;
using Vinoteca.Servicios.Interfaces;

namespace Vinoteca.Servicios.Servicios
{
    public class ServiciosVariedades : IServiciosVariedades
    {
        private readonly IRepositorioVariedades _repositorio;
        private readonly IUnitOfWork _unitOfWork;
        public ServiciosVariedades(IRepositorioVariedades repositorio, IUnitOfWork unitOfWork)
        {
            _repositorio = repositorio;
            _unitOfWork = unitOfWork;
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

        public bool EstaRelacionado(Variedad variedad)
        {
            try
            {
                return _repositorio.EstaRelacionado(variedad);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Existe(Variedad variedad)
        {
            try
            {
                return _repositorio.Existe(variedad);
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

        public List<Variedad> GetVariedadesPorPagina(int cantidad, int pagina)
        {
            try
            {
                return _repositorio.GetVariedadesPorPagina(cantidad, pagina);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Variedad GetVariedadPorId(int variedadId)
        {
            try
            {
                return _repositorio.GetVariedadPorId(variedadId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Variedad> GetVariedades()
        {
            try
            {
                return _repositorio.GetVariedades();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<SelectListItem> GetVariedadesDropDownList()
        {
            try
            {
                return _repositorio.GetVariedadesDropDownList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Guardar(Variedad variedad)
        {
            try
            {
                if (variedad.VariedadId == 0)
                {
                    _repositorio.Agregar(variedad);
                }
                else
                {
                    _repositorio.Editar(variedad);
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
