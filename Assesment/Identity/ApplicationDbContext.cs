using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Assesment.Identity
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext() : base("DefaultConnection")
        {

        }

        public void UpdateUserActiveStatusTrue(string userId)
        {
            var parameters = new[] {
            new SqlParameter("@LoggedInUserId", SqlDbType.NVarChar) { Value = userId }
            };

            Database.ExecuteSqlCommand("EXEC UpdateActiveTrue @LoggedInUserId", parameters);
        }

        public void UpdateUserActiveStatusFalse(string userId)
        {
            var parameters = new[] {
            new SqlParameter("@LoggedInUserId", SqlDbType.NVarChar) { Value = userId }
            };

            Database.ExecuteSqlCommand("EXEC UpdateActiveFalse @LoggedInUserId", parameters);
        }
    }
}