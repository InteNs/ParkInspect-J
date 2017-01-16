using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ParkInspectPortal.Startup))]
namespace ParkInspectPortal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
