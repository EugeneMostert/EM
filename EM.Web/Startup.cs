using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EM.Web.Startup))]
namespace EM.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
