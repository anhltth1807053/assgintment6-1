using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Assignment_6_1.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Assignment_6_1.Controllers
{
    public class RolesController : Controller
    {
        private MyDbContext dbContext = new MyDbContext();

        private RoleManager<Role> roleManager;

        public RolesController()
        {
            RoleStore<Role>roleStore = new RoleStore<Role>(dbContext);
            roleManager = new RoleManager<Role>(roleStore);
        }
        // GET: Roles
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Store(string name)
        {
            var role = new Role()
            {
                Name = name,
                createdAt = DateTime.Now
            };
            var result = roleManager.Create(role);
            return View("Create");
        }
    }
}