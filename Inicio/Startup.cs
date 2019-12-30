using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Inicio.Startup))]
namespace Inicio
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
        }
    }
}
