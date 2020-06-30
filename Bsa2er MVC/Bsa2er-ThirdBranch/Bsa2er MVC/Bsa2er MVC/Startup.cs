using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Bsa2er_MVC.Startup))]
namespace Bsa2er_MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
