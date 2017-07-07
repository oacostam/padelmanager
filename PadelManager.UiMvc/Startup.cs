using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PadelManager.UiMvc.Startup))]
namespace PadelManager.UiMvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
