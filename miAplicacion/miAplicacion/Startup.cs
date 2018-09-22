using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(miAplicacion.Startup))]
namespace miAplicacion
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
