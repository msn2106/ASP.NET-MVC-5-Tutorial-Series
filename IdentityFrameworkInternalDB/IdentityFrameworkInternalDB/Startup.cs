using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IdentityFrameworkInternalDB.Startup))]
namespace IdentityFrameworkInternalDB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
