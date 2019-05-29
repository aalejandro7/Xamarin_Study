using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Test.Backend.Startup))]
namespace Test.Backend
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
