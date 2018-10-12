using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EbookWebApp.Startup))]
namespace EbookWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
