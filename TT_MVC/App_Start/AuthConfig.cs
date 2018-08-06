using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(TT_MVC.App_Start.AuthConfig))]
namespace TT_MVC.App_Start
{
	public class AuthConfig
	{
		public void Configuration( IAppBuilder app)
		{
			app.UseCookieAuthentication(new Microsoft.Owin.Security.Cookies.CookieAuthenticationOptions
			{
				AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
				LoginPath = new PathString("/Authentication/Login")
			});
		}
	}
}