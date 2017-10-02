using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Deployment.Web.Startup))]
namespace Deployment.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
