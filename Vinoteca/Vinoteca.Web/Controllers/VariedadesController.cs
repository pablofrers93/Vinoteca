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
                var variedadVm = GetVariedadListVm(item);
                listaVm.Add(variedadVm);
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
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VariedadEditVm variedadVm)
        {
            if (ModelState.IsValid)
            {
                var variedad = GetVariedadFromVariedadEditVm(variedadVm);
                if (_servicio.Existe(variedad))
                {
                    ModelState.AddModelError(string.Empty, "Variedad Existente");
                    return View(variedadVm);
                }
                else
                {
                    _servicio.Guardar(variedad);
                    TempData["Msg"] = "Registro guardado satisfactoriamente";
                    return RedirectToAction("Index");
                }
            }
            else
            {
                return View(variedadVm);
            }
        }
        private Variedad GetVariedadFromVariedadEditVm(VariedadEditVm variedadEditVm)
        {
            return new Variedad()
            {
                VariedadId = variedadEditVm.VariedadId,
                NombreVariedad = variedadEditVm.NombreVariedad,
                RowVersion = variedadEditVm.RowVersion
            };
        }
    }
}