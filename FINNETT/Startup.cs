using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FINNETT.Startup))]

namespace FINNETT
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            
        }
    }
}