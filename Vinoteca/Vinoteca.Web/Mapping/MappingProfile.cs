using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vinoteca.Entidades.Dtos.Producto;
using Vinoteca.Entidades.Dtos.Venta;
using Vinoteca.Entidades.Entidades;
using Vinoteca.Web.ViewModels.Producto;
using Vinoteca.Web.ViewModels.Variedad;
using Vinoteca.Web.ViewModels.Venta;

namespace Vinoteca.Web.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            LoadVariedadesMapping();
            LoadProductosMapping();
            LoadVentasMapping();
        }

        private void LoadVentasMapping()
        {
            CreateMap<VentaListDto, VentaListVm>();
        }

        private void LoadProductosMapping()
        {
            CreateMap<ProductoListDto, ProductoListVm>();
            CreateMap<ProductoEditVm, Producto>().ReverseMap();
            CreateMap<Producto, ProductoListVm>()
                .ForMember(dest => dest.Variedad,
                opt => opt.MapFrom(src => src.Variedad.NombreVariedad));
            CreateMap<Producto, ProductoListVm>().ReverseMap();
        }

        private void LoadVariedadesMapping()
        {
            CreateMap<Variedad, VariedadListVm>();
            CreateMap<Variedad, VariedadEditVm>().ReverseMap();
        }
    }
}