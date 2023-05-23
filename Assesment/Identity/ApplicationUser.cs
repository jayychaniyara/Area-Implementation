using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assesment.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public DateTime? Birthday { get; set; }

        public string Gender { get; set; }

        public bool Active { get; set; }

    }
}