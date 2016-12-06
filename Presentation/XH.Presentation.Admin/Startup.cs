using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(XH.Presentation.Admin.Startup))]
namespace XH.Presentation.Admin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
             
        }
    }
}
