using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vinoteca.Entidades.Dtos.Usuario;
using Vinoteca.Entidades.Entidades;

namespace Vinoteca.Servicios.Interfaces
{
    public interface IServiciosUsuarios
    {
        void Borrar(int id);
        bool EstaRelacionado(Usuario usuario);
        bool Existe(Usuario usuario);
        Usuario GetUsuarioPorId(int id);
        List<UsuarioListDto> GetUsuarios();
        List<UsuarioListDto> GetUsuarios(int paisId, int ciudadId);
        void Guardar(Usuario usuario);
        List<UsuarioListDto> Filtrar(Func<Usuario, bool> predicado);
        int GetCantidad();
    }
}
