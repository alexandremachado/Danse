using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Danse.Startup))]
namespace Danse
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
