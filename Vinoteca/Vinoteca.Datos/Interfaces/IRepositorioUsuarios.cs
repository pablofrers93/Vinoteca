using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vinoteca.Entidades.Dtos.Usuario;
using Vinoteca.Entidades.Entidades;

namespace Vinoteca.Datos.Interfaces
{
    public interface IRepositorioUsuarios
    {
        void Agregar(Usuario usuario);
        void Borrar(int id);
        void Editar(Usuario usuario);
        bool EstaRelacionado(Usuario usuario);
        bool Existe(Usuario usuario);
        Usuario GetUsuarioPorId(int id);
        List<UsuarioListDto> GetUsuarios();
        //List<UsuarioListDto> GetUsuarios(int paisId, int ciudadId);
        List<UsuarioListDto> Filtrar(Func<Usuario, bool> predicado);
        int GetCantidad();
    }
}
