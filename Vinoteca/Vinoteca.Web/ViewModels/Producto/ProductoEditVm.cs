using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Vinoteca.Web.ViewModels.Producto
{
    public class ProductoEditVm
    {
        public int ProductoId { get; set; }
        [DisplayName("Producto")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(100, ErrorMessage = "El campo {0} debe contener entre {2} y {1} caracteres", MinimumLength = 3)]
        public string Descripcion { get; set; }
        [DisplayName("Variedad")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar una categoría")]

        public int VariedadId { get; set; }
        [DisplayName("Tipo de Producto")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un tipo de producto")]
        public int TipoProductoId { get; set; }
        [DisplayName("Precio")]
        [Required(ErrorMessage = "El precio es requerido")]
        [Range(0.10, 10000, ErrorMessage = "Favor de ingresar un {0} entre {1} y{2}")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public decimal PrecioVenta { get; set; }
        [DisplayName("Ficha técnica")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(1500, ErrorMessage = "El campo {0} debe contener entre {2} y {1} caracteres", MinimumLength = 3)]
        public string FichaTecnica { get; set; }
        [DisplayName("Bodega")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar una bodega")]
        public int BodegaId { get; set; }
        public bool Suspendido { get; set; } = false;

        public int UnidadesEnPedido { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Stock mal ingresado")]
        public int Stock { get; set; }
        
        [DataType(DataType.ImageUrl)]
        public string Imagen { get; set; }
        [DisplayName("Imagen")]
        public HttpPostedFileBase imagenFile { get; set; }
        public byte[] RowVersion { get; set; }
        public List<SelectListItem> Bodegas { get; set; }
        public List<SelectListItem> Variedades { get; set; }
        public List<SelectListItem> TiposProductos { get; set; }
    }
}