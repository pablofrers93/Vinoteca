using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vinoteca.Entidades.Entidades;
using Vinoteca.Web.ViewModels.Variedad;

namespace Vinoteca.Web.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            LoadVariedadesMapping();
        }
        private void LoadVariedadesMapping()
        {
            CreateMap<Variedad, VariedadListVm>();
            CreateMap<Variedad, VariedadEditVm>().ReverseMap();
        }
    }
}