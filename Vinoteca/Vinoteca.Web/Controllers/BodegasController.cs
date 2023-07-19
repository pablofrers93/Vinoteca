using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vinoteca.Entidades.Entidades;
using Vinoteca.Servicios.Interfaces;
using Vinoteca.Servicios.Servicios;
using Vinoteca.Web.App_Start;
using Vinoteca.Web.ViewModels.Producto;
using Vinoteca.Web.ViewModels.Variedad;
using Vinoteca.Web.Views.Bodegas;

namespace Vinoteca.Web.Controllers
{
    public class BodegasController : Controller
    {
        // GET: Bodegas
        private readonly IServiciosBodegas _servicio;
        private readonly IMapper _mapper;
        public BodegasController(IServiciosBodegas servicios)
        {
            _servicio = servicios;
            _mapper = AutoMapperConfig.Mapper;
        }
        public ActionResult Index()
        {
            var lista = _servicio.GetBodegas();
            var listaVm = GetListaBodegasListVm(lista);
            return View(listaVm);
        }

        private List<BodegaListVm> GetListaBodegasListVm(List<Bodega> lista)
        {
            var listaVm = new List<BodegaListVm>();
            foreach (var item in lista)
            {
                var bodegaVm = GetBodegaListVm(item);
                listaVm.Add(bodegaVm);
            }
            return listaVm;
        }

        private BodegaListVm GetBodegaListVm(Bodega item)
        {
            return new BodegaListVm()
            {
                BodegaId = item.BodegaId,
                NombreBodega = item.NombreBodega,
                Direccion = item.Direccion,
                RowVersion = item.RowVersion
            };
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BodegaListVm bodegaVm)
        {
            if (ModelState.IsValid)
            {
                var bodega = GetBodegaFromBodegaListVm(bodegaVm);
                if (_servicio.Existe(bodega))
                {
                    ModelState.AddModelError(string.Empty, "Bodega Existente");
                    return View(bodegaVm);
                }
                else
                {
                    _servicio.Guardar(bodega);
                    TempData["Msg"] = "Registro guardado satisfactoriamente";
                    return RedirectToAction("Index");
                }
            }
            else
            {
                return View(bodegaVm);
            }
        }

        private Bodega GetBodegaFromBodegaListVm(BodegaListVm bodegaVm)
        {
            return new Bodega
            {
                BodegaId = bodegaVm.BodegaId,
                NombreBodega = bodegaVm.NombreBodega,
                Direccion = bodegaVm.Direccion,
                RowVersion = bodegaVm.RowVersion
            };
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            var bodega = _servicio.GetBodegaPorId(id.Value);
            if (bodega == null)
            {
                return HttpNotFound("Código de bodega inexistente");
            }
            var bodegaVm = GetBodegaListVm(bodega);
            return View(bodegaVm);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id)
        {
            var bodega = _servicio.GetBodegaPorId(id);
            if (_servicio.EstaRelacionada(bodega))
            {
                var bodegaVm = GetBodegaListVm(bodega);
                ModelState.AddModelError(string.Empty, "Bodega relacionada, baja denegada.");
                return View(bodegaVm);
            }
            _servicio.Borrar(id);
            TempData["Msg"] = "Registro borrado satisfactoriamente";
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            var bodega = _servicio.GetBodegaPorId(id.Value);
            if (bodega == null)
            {
                return HttpNotFound("Código de bodega inexistente");
            }
            var bodegaVm = _mapper.Map<BodegaListVm>(bodega);
            return View(bodegaVm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit (BodegaListVm bodegaVm)
        {
            if (!ModelState.IsValid)
            {
                return View(bodegaVm);
            }
            try
            {
                var bodega = _mapper.Map<Bodega>(bodegaVm);
                if (!_servicio.Existe(bodega))
                {
                    _servicio.Guardar(bodega);
                    TempData["Msg"] = "Registro editado satisfactoriamente";
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "¡Bodega existente!");
                    return View(bodegaVm);
                }
            }
            catch (System.Exception)
            {
                ModelState.AddModelError(string.Empty, "¡Bodega existente!");
                return View(bodegaVm);
            }
        }
        public ActionResult Details (int? id )
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            var bodega = _servicio.GetBodegaPorId(id.Value);
            if (bodega == null)
            {
                return HttpNotFound("Código de bodega inexistente");
            }
            var bodegaVm = _mapper.Map<BodegaListVm>(bodega);
            return View(bodegaVm);
        }
    }
}