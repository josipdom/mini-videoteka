using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Videoteka.Startup))]
namespace Videoteka
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
