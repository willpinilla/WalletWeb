using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WalletWeb.Startup))]
namespace WalletWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
