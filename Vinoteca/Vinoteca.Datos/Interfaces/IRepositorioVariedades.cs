using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Vinoteca.Entidades.Entidades;

namespace Vinoteca.Datos.Interfaces
{
    public interface IRepositorioVariedades
    {
        List<Variedad> GetVariedads();
        void Agregar(Variedad variedad);
        void Editar(Variedad variedad);
        void Borrar(int id);
        bool Existe(Variedad variedad);
        Variedad GetVariedadPorId(int variedadId);
        bool EstaRelacionado(Variedad variedad);
        List<Variedad> GetVariedadesPorPagina(int cantidad, int pagina);
        int GetCantidad();
        List<SelectListItem> GetVariedadesDropDownList();
    }
}
