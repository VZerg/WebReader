using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BashReaderMVS.Startup))]
namespace BashReaderMVS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
