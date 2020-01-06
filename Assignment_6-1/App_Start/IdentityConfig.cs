using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Assignment_6_1.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace Assignment_6_1.App_Start
{
    public class IdentityConfig
    {
        public class MyUserManager : UserManager<User>
        {
            public MyUserManager(IUserStore<User> store) : base(store)
            {
            }

            public static MyUserManager Create(IdentityFactoryOptions<MyUserManager> options, IOwinContext context)
            {
                var manager = new MyUserManager(new UserStore<User>(new MyDbContext()));
                manager.UserValidator = new UserValidator<User>(manager)
                {
                    AllowOnlyAlphanumericUserNames = false,
                    RequireUniqueEmail = true
                };

                // Configure validation logic for passwords
                manager.PasswordValidator = new PasswordValidator
                {
                    RequiredLength = 6,
                    RequireNonLetterOrDigit = true,
                    RequireDigit = true,
                    RequireLowercase = true,
                    RequireUppercase = true,
                };

                // Configure user lockout defaults
                manager.UserLockoutEnabledByDefault = true;
                manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
                manager.MaxFailedAccessAttemptsBeforeLockout = 5;

                // Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
                // You can write your own provider and plug it in here.
//                manager.RegisterTwoFactorProvider("Phone Code", new PhoneNumberTokenProvider<Account>
//                {
//                    MessageFormat = "Your security code is {0}"
//                });
//                manager.RegisterTwoFactorProvider("Email Code", new EmailTokenProvider<Account>
//                {
//                    Subject = "Security Code",
//                    BodyFormat = "Your security code is {0}"
//                });
//
//                manager.EmailService = new EmailService();
//                //manager.SmsService = new SmsService();
//
//                var dataProtectionProvider = options.DataProtectionProvider;
//                if (dataProtectionProvider != null)
//                {
//                    manager.UserTokenProvider =
//                        new DataProtectorTokenProvider<Account>(dataProtectionProvider.Create("ASP.NET Identity"));
//                }
                return manager;
            }

        }
    }
}