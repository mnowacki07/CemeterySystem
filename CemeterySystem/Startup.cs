using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CemeterySystem.Startup))]
namespace CemeterySystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}