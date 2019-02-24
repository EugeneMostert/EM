using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EM.Portal.Startup))]
namespace EM.Portal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
