using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ExpendituresALevel.Startup))]
namespace ExpendituresALevel
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
