using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC_project.Startup))]
namespace MVC_project
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
