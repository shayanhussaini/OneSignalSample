using Microsoft.Owin;
using OneSignalApp.Models;
using Owin;
using Unity;

[assembly: OwinStartupAttribute(typeof(OneSignalApp.Startup))]
namespace OneSignalApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            ConfigureUnity(app);
        }
    }
}
