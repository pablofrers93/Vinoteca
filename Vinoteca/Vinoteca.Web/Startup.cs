using Owin;
using Microsoft.Owin;

[assembly: OwinStartup(typeof(Vinoteca.Web.Startup))]
namespace Vinoteca.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
