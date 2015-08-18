using Microsoft.Owin;
using Owin;


[assembly: OwinStartupAttribute(typeof(BankCheck.Web.Startup))]
namespace BankCheck.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
