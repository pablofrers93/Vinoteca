using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Vinoteca.Web.App_Start;
using Vinoteca.Web.Helpers;

namespace Vinoteca.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            CreateRolesAndSuperUser();
            AutoMapperConfig.Inicialize();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        private void CreateRolesAndSuperUser()
        {
            UserHelper.CheckRole("Admin");
            UserHelper.CheckRole("Usuario");
            UserHelper.CheckSuperUser();
        }
    }
}
