using Microsoft.Owin;

using Owin;

[assembly: OwinStartupAttribute(typeof(TheSchool.Web.Startup))]

namespace TheSchool.Web
{
    /// <summary>
    /// Description for StyleCop :)
    /// </summary>
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
        }
    }
}
