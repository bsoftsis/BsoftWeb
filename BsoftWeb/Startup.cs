using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BsoftWeb.Startup))]
namespace BsoftWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
