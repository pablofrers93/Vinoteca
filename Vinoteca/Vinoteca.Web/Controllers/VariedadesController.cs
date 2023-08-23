using AutoMapper;
using PagedList;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using Vinoteca.Entidades.Entidades;
using Vinoteca.Servicios.Interfaces;
using Vinoteca.Web.App_Start;
using Vinoteca.Web.ViewModels.Variedad;

namespace Vinoteca.Web.Controllers
{
    public class VariedadesController : Controller
    {
        // GET: Variedades
        private readonly IServiciosVariedades _servicio;
        private readonly IMapper _mapper;
        public VariedadesController(IServiciosVariedades servicio)
        {
            _servicio = servicio;
            _mapper = AutoMapperConfig.Mapper;
        }
        public ActionResult Index(int? page, int? pageSize)
        {
            var lista = _servicio.GetVariedades();
            //var lista = new List<Categoria>();
            //var listaVm=GetListaPaisesLstVm(lista);
            var listaVm = _mapper.Map<List<VariedadListVm>>(lista);
            //listaVm.ForEach(c => c.CantidadVariedades = _servicio
            //        .GetCantidad(p => p.VariedadId == c.VariedadId));
            page = page ?? 1;
            pageSize = pageSize ?? 10;
            ViewBag.PageSize = pageSize;

            return View(listaVm.ToPagedList(page.Value, pageSize.Value));
        }

        private IPagedList<VariedadListVm> GetListaVariedadesListVm(List<Variedad> lista, int? page, int pageSize)
        {
            var variedadesVm = lista.Select(item => GetVariedadListVm(item)).ToList();
            return new StaticPagedList<VariedadListVm>(variedadesVm, page ?? 1, pageSize, lista.Count);
        }
        //private List<VariedadListVm> GetListaVariedadesListVm(List<Variedad> lista, int? page)
        //{
        //    var listaVm = new List<VariedadListVm>();
        //    foreach (var item in lista)
        //    {
        //        var variedadVm = GetVariedadListVm(item);
        //        listaVm.Add(variedadVm);
        //    }
        //    return listaVm;
        //}
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
        
        public ActionResult Delete (int? id)
        {
            if (id==null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            var variedad = _servicio.GetVariedadPorId(id.Value);
            if (variedad == null)
            {
                return HttpNotFound("Código de variedad inexistente");
            }
            var variedadVm = GetVariedadListVm(variedad);
            return View(variedadVm);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm (int id)
        {
            var variedad = _servicio.GetVariedadPorId(id);
            if (_servicio.EstaRelacionado(variedad))
            {
                var variedadVm = GetVariedadListVm(variedad);
                ModelState.AddModelError(string.Empty, "Variedad relacionada, baja denegada");
                return View(variedadVm);
            }
            _servicio.Borrar(id);
            TempData["Msg"] = "Registro borrado satisfactoriamente";
            return RedirectToAction("Index");
        }
        public ActionResult Edit (int? id)
        {
            if (id==null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            var variedad = _servicio.GetVariedadPorId(id.Value);
            if (variedad == null)
            {
                return HttpNotFound("Código de variedad inexistente");
            }
            var variedadVm = GetVariedadEditVmFromVariedad(variedad);
            return View(variedadVm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit (VariedadEditVm variedadVm)
        {
            if (!ModelState.IsValid)
            {
                return View(variedadVm);
            }
            var variedad = GetVariedadFromVariedadEditVm(variedadVm);
            if (_servicio.Existe(variedad))
            {
                ModelState.AddModelError(string.Empty, "Variedad existente");
                return View (variedadVm);   
            }
            _servicio.Guardar(variedad);
            TempData["Msg"] = "Registro editado satisfactoriamente";
            return RedirectToAction("Index");   
        }
        private VariedadEditVm GetVariedadEditVmFromVariedad(Variedad variedad)
        {
            return new VariedadEditVm()
            {
                VariedadId = variedad.VariedadId,
                NombreVariedad = variedad.NombreVariedad,
                RowVersion = variedad.RowVersion
            };
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