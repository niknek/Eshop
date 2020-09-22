using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ShoppingStore.Startup))]
namespace ShoppingStore
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
