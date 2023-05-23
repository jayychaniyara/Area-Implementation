using Assesment.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assesment
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new Microsoft.Owin.Security.Cookies.CookieAuthenticationOptions() { AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie, LoginPath = new PathString("/Account/Login") });
            this.CreateRolesAndUsers();
        }

        public void CreateRolesAndUsers()
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>());
            var appDbContext = new ApplicationDbContext();
            var appUserStore = new ApplicationUserStore(appDbContext);
            var userManger = new ApplicationUserManager(appUserStore);

            //Create Admin Role


            //Create Admin User
            if (userManger.FindByName("admin") == null)
            {
                var user = new ApplicationUser();
                user.UserName = "admin";
                user.Email = "admin@gmail.com";
                string userPassword = "admin123";
                var chkUser = userManger.Create(user, userPassword);
                if (chkUser.Succeeded)
                {
                    if (!roleManager.RoleExists("Admin"))
                    {
                        var role = new IdentityRole();
                        role.Name = "Admin";
                        roleManager.Create(role);
                        userManger.AddToRole(user.Id, "Admin");
                    }
                    else
                    {
                        userManger.AddToRole(user.Id, "Admin");
                    }
                }
            }

            ////Create Manager Role
            //if (!roleManager.RoleExists("Manager"))
            //{
            //    var role = new IdentityRole();
            //    role.Name = "Manager";
            //    roleManager.Create(role);
            //}

            ////Create Manager User
            //if (userManger.FindByName("manager") == null)
            //{
            //    var user = new ApplicationUser();
            //    user.UserName = "manager";
            //    user.Email = "manager@gmail.com";
            //    string userPassword = "manager123";
            //    var chkUser = userManger.Create(user, userPassword);
            //    if (chkUser.Succeeded)
            //    {
            //        userManger.AddToRole(user.Id, "Manager");
            //    }
            //}

            //Create Customer Role
            if (!roleManager.RoleExists("Customer"))
            {
                var role = new IdentityRole();
                role.Name = "Customer";
                roleManager.Create(role);
            }

        }
    }
}