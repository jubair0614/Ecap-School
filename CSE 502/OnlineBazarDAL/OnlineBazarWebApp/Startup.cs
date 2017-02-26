using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OnlineBazarWebApp.Startup))]
namespace OnlineBazarWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
