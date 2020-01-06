using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Assignment_6_1.App_Start;
using Assignment_6_1.Models;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

[assembly: OwinStartup(typeof(Assignment_6_1.Startup))]

namespace Assignment_6_1
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext<MyDbContext>(MyDbContext.Create);
            app.CreatePerOwinContext<IdentityConfig.MyUserManager>(IdentityConfig.MyUserManager.Create);
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login")
            });
        }
    }
}