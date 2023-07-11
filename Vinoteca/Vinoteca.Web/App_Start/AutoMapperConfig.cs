using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vinoteca.Web.App_Start
{
    public class AutoMapperConfig
    {
        public static IMapper Mapper { get; set; }

        public static void Inicialize()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            Mapper = config.CreateMapper();
        }
    }
}