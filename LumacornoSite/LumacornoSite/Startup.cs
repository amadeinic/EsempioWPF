using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LumacornoSite.Startup))]
namespace LumacornoSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
