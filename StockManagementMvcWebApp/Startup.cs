using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StockManagementMvcWebApp.Startup))]
namespace StockManagementMvcWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
