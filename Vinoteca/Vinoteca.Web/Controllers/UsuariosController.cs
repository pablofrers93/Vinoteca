using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vinoteca.Servicios.Interfaces;
using Vinoteca.Web.App_Start;

namespace Vinoteca.Web.Controllers
{
    public class UsuariosController : Controller
    {
        // GET: Usuarios
        private readonly IServiciosUsuarios _servicios;
        private readonly IMapper _mapper;
        public UsuariosController(IServiciosUsuarios servicios)
        {
            _servicios = servicios;
            _mapper = AutoMapperConfig.Mapper;
        }
        public ActionResult Index()
        {
            return View();
        }
        
    }
}