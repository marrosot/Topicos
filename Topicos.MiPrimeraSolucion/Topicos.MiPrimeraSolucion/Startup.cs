using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Topicos.MiPrimeraSolucion.Startup))]
namespace Topicos.MiPrimeraSolucion
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
