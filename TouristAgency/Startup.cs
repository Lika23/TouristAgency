using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TouristAgency.Startup))]
namespace TouristAgency
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
