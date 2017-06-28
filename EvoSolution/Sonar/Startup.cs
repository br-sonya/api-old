using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Sonar.Startup))]
namespace Sonar
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
