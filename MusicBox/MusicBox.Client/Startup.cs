using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using MusicBox.App_Start.Core;
using MusicBox.Data.Context;
using MusicBox.Utilities.Logger;
using Owin;

[assembly: OwinStartup(typeof(MusicBox.Startup))]

namespace MusicBox
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            Log.Info("Login-page started...");

            // настраиваем контекст и менеджер
            app.CreatePerOwinContext(MusicBoxDbContext.Create);
            app.CreatePerOwinContext<AppUserManager>(AppUserManager.Create);

            app.CreatePerOwinContext<AppRoleManager>(AppRoleManager.Create);

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
            });
        }
    }
}