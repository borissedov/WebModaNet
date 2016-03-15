using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(EW.WebModaNet.Startup))]

namespace EW.WebModaNet
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
           // ConfigureAuth(app);
        }
    }
}