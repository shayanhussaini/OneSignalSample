using Owin;
using OneSignalApp.Models;
using Unity;

namespace OneSignalApp
{
    public partial class Startup
    {
       public void ConfigureUnity(IAppBuilder app)
        {
            var container = new UnityContainer();
            container.RegisterType<IAppRestService, AppRestService>();

        }
    }
}