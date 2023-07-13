using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vinoteca.Entidades.Entidades;
using Vinoteca.Servicios.Interfaces;
using Vinoteca.Web.ViewModels.Variedad;
using Vinoteca.Web.Views.Bodegas;

namespace Vinoteca.Web.Controllers
{
    public class BodegasController : Controller
    {
        // GET: Bodegas
        private readonly IServiciosBodegas _servicios;
        public BodegasController(IServiciosBodegas servicios)
        {
            _servicios = servicios;
        }
        public ActionResult Index()
        {
            var lista = _servicios.GetBodegas();
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
    }
}