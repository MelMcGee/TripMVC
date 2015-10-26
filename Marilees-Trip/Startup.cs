using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Marilees_Trip.Startup))]
namespace Marilees_Trip
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
