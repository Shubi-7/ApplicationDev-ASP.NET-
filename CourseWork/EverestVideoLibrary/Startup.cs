using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CourseWork2.Startup))]
namespace CourseWork2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
