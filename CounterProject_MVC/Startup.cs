using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CounterProject_MVC.Startup))]
namespace CounterProject_MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
