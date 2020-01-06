using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Assignment_6_1.Models
{
    public class Role : IdentityRole
    {
        public string description { get; set; }
        public DateTime createdAt { get; set; }
    }
}