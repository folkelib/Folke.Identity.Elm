﻿namespace Elm.AspNet.Identity.Sample.Models
{
    public class ApplicationUser : IdentityUser { }

    public class IdentityDbContextOptions
    {
        public string DefaultAdminUserName { get; set; }

        public string DefaultAdminPassword { get; set; }
    }
}
