using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vinoteca.Entidades.Entidades;
using Vinoteca.Servicios.Interfaces;
using Vinoteca.Web.ViewModels.Variedad;

namespace Vinoteca.Web.Controllers
{
    public class VariedadesController : Controller
    {
        // GET: Variedades
        private readonly IServiciosVariedades _servicio;
        public VariedadesController(IServiciosVariedades servicio)
        {
            _servicio = servicio;
        }
        public ActionResult Index()
        {
            var lista = _servicio.GetVariedades();
            var listaVm = GetListaVariedadesListVm(lista);
            return View(listaVm);
        }
        private List<VariedadListVm> GetListaVariedadesListVm(List<Variedad> lista)
        {
            var listaVm = new List<VariedadListVm>();
            foreach (var item in lista)
            {
                var categoriaVm = GetVariedadListVm(item);
                listaVm.Add(categoriaVm);
            }
            return listaVm;
        }
        private VariedadListVm GetVariedadListVm(Variedad item)
        {
            return new VariedadListVm()
            {
                VariedadId = item.VariedadId,
                NombreVariedad = item.NombreVariedad,
                RowVersion = item.RowVersion
            };
        }
    }
}