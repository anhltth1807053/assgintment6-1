using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Assignment_6_1.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Unity;
using Unity.Mvc5;

namespace Assignment_6_1.App_Start
{
    public class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();
            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            container.RegisterType<IUserStore<User>, UserStore<User>>();
            container.RegisterType<UserManager<User>>();
            container.RegisterType<DbContext, MyDbContext>();
            container.RegisterType<IdentityConfig.MyUserManager>();
        }
    }
}