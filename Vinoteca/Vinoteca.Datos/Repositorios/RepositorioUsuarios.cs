using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vinoteca.Datos.Interfaces;
using Vinoteca.Entidades.Dtos.Usuario;
using Vinoteca.Entidades.Entidades;

namespace Vinoteca.Datos.Repositorios
{
    public class RepositorioUsuarios : IRepositorioUsuarios
    {
        private readonly VinotecaDbContext _context;
        public RepositorioUsuarios(VinotecaDbContext context)
        {
            _context = context;
        }
        public void Agregar(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
        }

        public void Borrar(int id)
        {
            var usuarioInDb = _context.Usuarios.SingleOrDefault(p => p.UsuarioId == id);
            if (usuarioInDb == null)
            {
                throw new Exception("Usuario borrado por otro usuario");
            }
            _context.Entry(usuarioInDb).State = EntityState.Deleted;
        }

        public void Editar(Usuario usuario)
        {
            try
            {
                _context.Entry(usuario).State = EntityState.Modified;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Data.ToString());
                throw ex;
            }
        }

        public bool EstaRelacionado(Usuario usuario)
        {
            try
            {
                return _context.Ventas.Any(v => v.UsuarioId == usuario.UsuarioId);
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
                if (usuario.UsuarioId == 0)
                {
                    return _context.Usuarios.Any(c => c.Nombre == usuario.Nombre);
                }
                return _context.Usuarios.Any(c => c.Nombre == usuario.Nombre && c.UsuarioId != usuario.UsuarioId);

            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<UsuarioListDto> Filtrar(Func<Usuario, bool> predicado)
        {
            return _context.Usuarios.Where(predicado)
                .Select(c => new UsuarioListDto
                {
                    UsuarioId = c.UsuarioId,
                    Nombre = c.Nombre,
                    Apellido = c.Apellido,
                    Email = c.Email,
                    Pass = c.Pass,
                    Rol = c.Rol.NombreRol
                }).ToList();
        }

        public int GetCantidad()
        {
            return _context.Usuarios.Count();
        }

        public Usuario GetUsuarioPorEmail(string email)
        {
            try
            {
                return _context.Usuarios
                    .AsNoTracking()
                    .SingleOrDefault(c => c.Email == email);
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
                return _context.Usuarios.SingleOrDefault(c => c.UsuarioId == id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<UsuarioListDto> GetUsuarios()
        {
            return _context.Usuarios.Select(c => new UsuarioListDto
                {
                    UsuarioId = c.UsuarioId,
                    Nombre = c.Nombre,
                    Apellido = c.Apellido,
                    Email = c.Email,
                    Pass = c.Pass,
                    Rol = c.Rol.NombreRol
                })
                .OrderBy(c => c.Nombre)
                .ToList();
        }
    }
}
