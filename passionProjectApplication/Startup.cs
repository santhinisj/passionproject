using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(passionProjectApplication.Startup))]
namespace passionProjectApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
