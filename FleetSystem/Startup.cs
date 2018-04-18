using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FleetSystem.Startup))]
namespace FleetSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
