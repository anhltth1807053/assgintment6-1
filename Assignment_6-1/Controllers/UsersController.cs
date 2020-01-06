using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Assignment_6_1.App_Start;
using Assignment_6_1.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Provider;

namespace Assignment_6_1.Controllers
{

    public class UsersController : Controller
    {
        private MyDbContext dbContext ;

        private IdentityConfig.MyUserManager _userManager;
        public UsersController(MyDbContext myDbContext,IdentityConfig.MyUserManager myuserManager)
        {
            dbContext = myDbContext;
            _userManager = myuserManager;
        }
        // GET: Users
        public ActionResult Register()
        {
            Debug.WriteLine("Count: " + dbContext.Users.ToList().Count);
            return View();
        }

    
        [HttpPost]
    public async Task<ActionResult> ProcessRegister(string userName, string password, string email, string fullname, string phoneNumber)
    {
        var user = new User()
        {
            UserName = userName,
            Email = email,
            Name = fullname,
            PhoneNumber = phoneNumber,
            createdAt = DateTime.Now
        };
            // success
            IdentityResult result = await _userManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                _userManager.AddToRole(user.Id, "User");
                return Redirect("/Home");
            }
            return Redirect("/Home");
        }
    
    public ActionResult Login(string username, string password)
        {
            var user = _userManager.Find(username, password);
            if (user == null)
            {
                return HttpNotFound();
            }
            // success
            var ident = _userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
            //use the instance that has been created. 
            var authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignIn(
                new AuthenticationProperties { IsPersistent = false }, ident);
            return Redirect("/Home");
        }
    [HttpPost]
    public ActionResult ProcessLogin(string username, string password)
        {
            User user = _userManager.Find(username, password);
            if (user == null)
            {
                return HttpNotFound();
            }
            // success
            var ident = _userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
            //use the instance that has been created. 
            var authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignIn(
                new AuthenticationProperties { IsPersistent = false }, ident);
            return Redirect("/Home");
        }
        [HttpPost]
        [Authorize]
    public ActionResult logout()
        {
            HttpContext.GetOwinContext().Authentication.SignOut();
            return Redirect("/Home");
        }
    }
}