using Assesment.Identity;
using Assesment.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Assesment.ApiControllers
{
    [System.Web.Http.Authorize(Roles = "Admin")]
    public class AccountWebApiController : ApiController
    {
        public List<ApplicationUser> GetUsers()
        {
            ApplicationDbContext dbContext = new ApplicationDbContext();
            List<ApplicationUser> users = dbContext.Users.ToList();
            return users;
        }

        public ApplicationUser GetUserByUserId(string Id)
        {
            ApplicationDbContext dbContext = new ApplicationDbContext();
            ApplicationUser user = dbContext.Users.FirstOrDefault(x => x.Id == Id);
            return user;
        }

        public void PutActiveStatus(string Id, bool active)
        {
            ApplicationDbContext dbContext = new ApplicationDbContext();
            var existingUser = dbContext.Users.FirstOrDefault(u => u.Id == Id);
            existingUser.Active = active;
            dbContext.SaveChanges();
        }

        public void PutUserInformation(ApplicationUser userInfo)
        {

        }

        public void DeleteUser(string Id)
        {
            ApplicationDbContext dbContext = new ApplicationDbContext();
            var existingUser = dbContext.Users.FirstOrDefault(u => u.Id == Id);
            dbContext.Users.Remove(existingUser);
            dbContext.SaveChanges();
        }

        public void PostActiveStatus(string Id, bool active)
        {
            ApplicationDbContext dbContext = new ApplicationDbContext();

            if (active == true)
            {
                dbContext.UpdateUserActiveStatusTrue(Id);
                dbContext.SaveChanges();
            }
            else if (active == false)
            {
                dbContext.UpdateUserActiveStatusFalse(Id);
                dbContext.SaveChanges();
            }
        }
    }
}
