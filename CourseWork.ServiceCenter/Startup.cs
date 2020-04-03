using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CourseWork.ServiceCenter.Startup))]
namespace CourseWork.ServiceCenter
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
