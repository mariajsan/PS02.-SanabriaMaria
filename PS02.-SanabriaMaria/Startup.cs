using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PS02._SanabriaMaria.Startup))]
namespace PS02._SanabriaMaria
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
