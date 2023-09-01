using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vinoteca.Datos;
using Vinoteca.Datos.Interfaces;
using Vinoteca.Entidades.Dtos.Usuario;
using Vinoteca.Entidades.Entidades;
using Vinoteca.Servicios.Interfaces;

namespace Vinoteca.Servicios.Servicios
{
    public class ServiciosUsuarios : IServiciosUsuarios
    {
        private readonly IRepositorioUsuarios _repositorio;
        private readonly IUnitOfWork _unitOfWork;

        public ServiciosUsuarios(IRepositorioUsuarios repositorio, IUnitOfWork unitOfWork)
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

        public bool EstaRelacionado(Usuario usuario)
        {
            try
            {
                return _repositorio.EstaRelacionado(usuario);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Existe(Usuario usuario)
        {
            try
            {
                return _repositorio.Existe(usuario);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<UsuarioListDto> Filtrar(Func<Usuario, bool> predicado)
        {
            try
            {
                return _repositorio.Filtrar(predicado);
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

        public Usuario GetUsuarioPorEmail(string mail)
        {
            try
            {
                return _repositorio.GetUsuarioPorEmail(mail);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Usuario GetUsuarioPorId(int id)
        {
            try
            {
                return _repositorio.GetUsuarioPorId(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<UsuarioListDto> GetUsuarios()
        {
            try
            {
                return _repositorio.GetUsuarios();
            }
            catch (Exception)
            {
                throw;
            }
        }


        public void Guardar(Usuario usuario)
        {
            try
            {
                if (usuario.UsuarioId == 0)
                {
                    _repositorio.Agregar(usuario);
                }
                else
                {
                    _repositorio.Editar(usuario);
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
