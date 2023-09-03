[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Vinoteca.Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Vinoteca.Web.App_Start.NinjectWebCommon), "Stop")]

namespace Vinoteca.Web.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Web.Common.WebHost;
    using Vinoteca.Datos;
    using Vinoteca.Datos.Interfaces;
    using Vinoteca.Datos.Repositorios;
    using Vinoteca.Servicios;
    using Vinoteca.Servicios.Interfaces;
    using Vinoteca.Servicios.Servicios;
    using Vinoteca.Web.Models;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application.
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<VinotecaDbContext>().ToSelf().InRequestScope();
            kernel.Bind<IRepositorioBodegas>().To<RepositorioBodegas>().InRequestScope();
            kernel.Bind<IServiciosBodegas>().To<ServiciosBodegas>().InRequestScope();
            kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();
            kernel.Bind<IRepositorioVariedades>().To<RepositorioVariedades>().InRequestScope();
            kernel.Bind<IServiciosVariedades>().To<ServiciosVariedades>().InRequestScope();
            kernel.Bind<IRepositorioUsuarios>().To<RepositorioUsuarios>().InRequestScope();
            kernel.Bind<IServiciosUsuarios>().To<ServiciosUsuarios>().InRequestScope();
            kernel.Bind<IRepositorioProductos>().To<RepositorioProductos>().InRequestScope();
            kernel.Bind<IServiciosProductos>().To<ServiciosProductos>().InRequestScope();
            kernel.Bind<IRepositorioVentas>().To<RepositorioVentas>().InRequestScope();
            kernel.Bind<IServiciosVentas>().To<ServiciosVentas>().InRequestScope();
            kernel.Bind<IRepositorioCarritos>().To<RepositorioCarrito>().InRequestScope();
            kernel.Bind<IServiciosCarritos>().To<ServiciosCarritos>().InRequestScope();
            kernel.Bind<IRepositorioTipoProductos>().To<RepositorioTipoProductos>().InRequestScope();
            kernel.Bind<IServiciosTipoProductos>().To<ServiciosTipoProductos>().InRequestScope();
            kernel.Bind<IRepositorioVentasProductos>().To<RepositorioVentasProductos>().InRequestScope();

        }
    }
}