using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GruppAsc.Startup))]
namespace GruppAsc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
