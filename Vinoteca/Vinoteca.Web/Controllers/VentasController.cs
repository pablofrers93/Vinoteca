using Antlr.Runtime.Misc;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vinoteca.Servicios.Interfaces;
using Vinoteca.Web.App_Start;
using Vinoteca.Web.ViewModels.Venta;

namespace Vinoteca.Web.Controllers
{
    public class VentasController : Controller
    {
        // GET: Ventas
        private readonly IServiciosVentas _servicios;
        private readonly IMapper _mapper;
        public VentasController(IServiciosVentas servicios)
        {
            _servicios = servicios;
            _mapper = AutoMapperConfig.Mapper;
        }
        public ActionResult Index()
        {
            var lista = _servicios.GetVentas();
            var listaVm = _mapper.Map<List<VentaListVm>>(lista);
            return View(listaVm);
        }
    }
}