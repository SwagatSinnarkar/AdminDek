using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AdminDek.Startup))]
namespace AdminDek
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
