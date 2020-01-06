using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Assignment_6_1.Models
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
        public DateTime createdAt { get; set; }
    }
}