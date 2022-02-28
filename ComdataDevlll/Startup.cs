using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ComdataDevlll.Startup))]
namespace ComdataDevlll
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
