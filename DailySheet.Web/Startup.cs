using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DailySheet.Web.Startup))]
namespace DailySheet.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
