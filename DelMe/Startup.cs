using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DelMe.Startup))]
namespace DelMe
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
