using AutoMapper;
using System.Collections.Generic;
using System.Web.Mvc;
using Vinoteca.Servicios.Interfaces;
using Vinoteca.Web.App_Start;
using Vinoteca.Web.ViewModels.Producto;

namespace Vinoteca.Web.Controllers
{
    public class ProductosController : Controller
    {
        // GET: Productos
        private readonly IServiciosProductos _servicios;
        private readonly IServiciosBodegas _serviciosBodegas;
        private readonly IServiciosVariedades _serviciosVariedades;
        private readonly IServiciosTipoProductos _serviciosTipoProductos;
        private readonly IMapper _mapper;
        public ProductosController(IServiciosProductos servicios,
            IServiciosBodegas serviciosBodegas,
            IServiciosVariedades serviciosVariedades,
            IServiciosTipoProductos serviciosTipoProductos)
        {
            _servicios = servicios;
            _serviciosBodegas = serviciosBodegas;
            _serviciosVariedades = serviciosVariedades;
            _serviciosTipoProductos = serviciosTipoProductos;
            _mapper = AutoMapperConfig.Mapper;
        }
        // GET: Productos
        public ActionResult Index()
        {
            var lista = _servicios.GetProductos();
            var listaVm = _mapper.Map<List<ProductoListVm>>(lista);
            return View(listaVm);
        }
        public ActionResult Create()
        {
            var productoVm = new ProductoEditVm
            {
                Bodegas = _serviciosBodegas.GetBodegasDropDownList(),
                Variedades = _serviciosVariedades.GetVariedadesDropDownList(),
                TiposProductos = _serviciosTipoProductos.GetTipoProductosDropDownList()
            };
            return View(productoVm);
        }
    }
}