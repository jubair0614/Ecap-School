using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC5Property.Startup))]
namespace MVC5Property
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
