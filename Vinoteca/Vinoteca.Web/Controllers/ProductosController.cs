using AutoMapper;
using PagedList;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.IO;
using System.Web.Mvc;
using System.Web.UI;
using Vinoteca.Entidades.Entidades;
using Vinoteca.Servicios.Interfaces;
using Vinoteca.Utilidades;
using Vinoteca.Web.App_Start;
using Vinoteca.Web.ViewModels.Producto;
using Vinoteca.Web.ViewModels.Variedad;

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
        public ActionResult Index(int? page, int? pageSize)
        {
            var lista = _servicios.GetProductos();
            var listaVm = _mapper.Map<List<ProductoListVm>>(lista);
            page = page ?? 1;
            pageSize = pageSize ?? 10;
            ViewBag.PageSize = pageSize;

            return View(listaVm.ToPagedList(page.Value, pageSize.Value));
        }
        [Authorize]
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductoEditVm productoVm)
        {
            if (!ModelState.IsValid)
            {
                productoVm.Bodegas = _serviciosBodegas.GetBodegasDropDownList();
                productoVm.Variedades = _serviciosVariedades.GetVariedadesDropDownList();
                productoVm.TiposProductos = _serviciosTipoProductos.GetTipoProductosDropDownList();
                return View(productoVm);
            }
            try
            {
                var producto = _mapper.Map<Producto>(productoVm);
                if (!_servicios.Existe(producto))
                {
                    if (productoVm.imagenFile != null)
                    {
                        string extension = Path.GetExtension(productoVm.imagenFile.FileName);
                        string filename = Guid.NewGuid().ToString();

                        var file = $"{filename}{extension}";
                        var response = FileHelper.UploadPhoto(productoVm.imagenFile, WC.Vino1, file);
                        producto.Imagen = file;
                    }

                    _servicios.Guardar(producto);
                    TempData["Msg"] = "Registro agregado satisfactoriamente";
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Producto existente!!!");
                    productoVm.Bodegas = _serviciosBodegas.GetBodegasDropDownList();
                    productoVm.Variedades = _serviciosVariedades.GetVariedadesDropDownList();
                    productoVm.TiposProductos = _serviciosTipoProductos.GetTipoProductosDropDownList();

                    return View(productoVm);
                }
            }
            catch (System.Exception)
            {

                ModelState.AddModelError(string.Empty, "Error al intentar agregar un Producto");
                productoVm.Bodegas = _serviciosBodegas.GetBodegasDropDownList();
                productoVm.Variedades = _serviciosVariedades.GetVariedadesDropDownList();
                productoVm.TiposProductos = _serviciosTipoProductos.GetTipoProductosDropDownList();

                return View(productoVm);
            }
        }

        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            var producto = _servicios.GetProductoPorId(id.Value);
            if (producto == null)
            {
                return HttpNotFound("Código de producto inexistente");
            }
            var productoVm = _mapper.Map<ProductoEditVm>(producto);
            productoVm.Bodegas = _serviciosBodegas.GetBodegasDropDownList();
            productoVm.Variedades = _serviciosVariedades.GetVariedadesDropDownList();
            productoVm.TiposProductos = _serviciosTipoProductos.GetTipoProductosDropDownList();
            return View (productoVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit (ProductoEditVm productoVm)
        {
            if (!ModelState.IsValid)
            {
                productoVm.Bodegas = _serviciosBodegas.GetBodegasDropDownList();
                productoVm.Variedades = _serviciosVariedades.GetVariedadesDropDownList();
                productoVm.TiposProductos = _serviciosTipoProductos.GetTipoProductosDropDownList();
                return View(productoVm);
            }
            try
            {
                var producto = _mapper.Map<Producto>(productoVm);
                if (!_servicios.Existe(producto))
                {
                    _servicios.Guardar(producto);
                    TempData["Msg"] = "Registro editado satisfactoriamente";
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "¡Producto existente!");
                    productoVm.Bodegas = _serviciosBodegas.GetBodegasDropDownList();
                    productoVm.Variedades = _serviciosVariedades.GetVariedadesDropDownList();
                    productoVm.TiposProductos = _serviciosTipoProductos.GetTipoProductosDropDownList();
                    return View(productoVm);

                }
            }
            catch (System.Exception)
            {
                ModelState.AddModelError(string.Empty, "¡Producto existente!");
                productoVm.Bodegas = _serviciosBodegas.GetBodegasDropDownList();
                productoVm.Variedades = _serviciosVariedades.GetVariedadesDropDownList();
                productoVm.TiposProductos = _serviciosTipoProductos.GetTipoProductosDropDownList();
                return View(productoVm);
            }
        }

        [Authorize]
        public ActionResult Delete (int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            var producto = _servicios.GetProductoPorId(id.Value);
            if (producto == null)
            {
                return HttpNotFound("Código de producto inexistente");
            }
            var productoVm = _mapper.Map<ProductoListVm>(producto);
            return View (productoVm);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id)
        {
            var producto = _servicios.GetProductoPorId(id);
            var productoVm = _mapper.Map<ProductoListVm>(producto);
            try
            {
                if (!_servicios.EstaRelacionado(producto))
                {
                    _servicios.Borrar(id);
                    TempData["Msg"] = "Producto borrado satisfactoriamente";
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Registro relacionado... Baja denegada");
                    return View(productoVm);
                }
            }
            catch (System.Exception)
            {
                ModelState.AddModelError(string.Empty, "Error al intengar borrar un proveedor");
                return View(productoVm);
            }
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            var producto = _servicios.GetProductoPorId(id.Value);
            if (producto == null)
            {
                return HttpNotFound("Cód. producto inexistente!!!");
            }
            var productoVm = _mapper.Map<ProductoListVm>(producto);
            return View(productoVm);
        }
    }
}