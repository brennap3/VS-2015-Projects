using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ServiceConsumer.Startup))]
namespace ServiceConsumer
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
