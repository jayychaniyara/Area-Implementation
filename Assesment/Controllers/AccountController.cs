using Assesment.Identity;
using Assesment.ViewModel;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Assesment.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            try
            {
                return View();
            }
            catch (Exception exception)
            {
                ViewBag.ExceptionMessage = exception.Message;
                return View("Error");
            }
        }

        public ActionResult Register()
        {
            try
            {
                return View();
            }
            catch (Exception exception)
            {
                ViewBag.ExceptionMessage = exception.Message;
                return View("Error");
            }
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel registerViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var appDbContext = new ApplicationDbContext();
                    var userStore = new ApplicationUserStore(appDbContext);
                    var userManager = new ApplicationUserManager(userStore);
                    var passwordHash = Crypto.HashPassword(registerViewModel.Password);
                    var user = new ApplicationUser()
                    {
                        Email = registerViewModel.Email,
                        UserName = registerViewModel.Username,
                        PasswordHash = passwordHash,
                        Birthday = registerViewModel.DateOfBirth,
                        PhoneNumber = registerViewModel.Mobile,
                        Gender = registerViewModel.Gender,
                        Active = true,
                    };

                    IdentityResult result = userManager.Create(user);

                    if (result.Succeeded)
                    {
                        //Role
                        userManager.AddToRole(user.Id, "Customer");

                        //Login
                        var authenticationManager = HttpContext.GetOwinContext().Authentication;
                        var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                        authenticationManager.SignIn(new AuthenticationProperties(), userIdentity);

                    }

                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    ModelState.AddModelError("My Error", "Invalid Data");
                    return View("Index");
                }
            }
            catch (Exception exception)
            {
                ViewBag.ExceptionMessage = exception.Message;
                return View("Error");
            }
        }

        public ActionResult Login()
        {
            try
            {
                return View();
            }
            catch (Exception exception)
            {
                ViewBag.ExceptionMessage = exception.Message;
                return View("Error");
            }
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel loginViewModel)
        {
            try
            {
                //Login 
                var appDbContext = new ApplicationDbContext();
                var userStore = new ApplicationUserStore(appDbContext);
                var userManager = new ApplicationUserManager(userStore);
                var user = userManager.Find(loginViewModel.Username, loginViewModel.Password);
                if (user != null)
                {
                    //Login Successful
                    var authenticationManager = HttpContext.GetOwinContext().Authentication;
                    var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                    authenticationManager.SignIn(new AuthenticationProperties(), userIdentity);

                    if (userManager.IsInRole(user.Id, "Admin"))
                    {
                        Session["loggdInUserId"] = user.Id;
                        return RedirectToAction("Index", "Home", new { area = "Admin" });
                    }
                    else
                    {
                        if (user.Active == true)
                        {
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            return View("UserInactive");
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError("My Error", "Invalid UserName or Password");
                    return View();
                }
            }
            catch (Exception exception)
            {
                ViewBag.ExceptionMessage = exception.Message;
                return View("Error");
            }
        }

        public ActionResult Logout()
        {
            try
            {
                var authenticationManager = HttpContext.GetOwinContext().Authentication;
                authenticationManager.SignOut();
                return RedirectToAction("Login", "Account");
            }
            catch (Exception exception)
            {
                ViewBag.ExceptionMessage = exception.Message;
                return View("Error");
            }
        }

        public ActionResult MyProfile()
        {
            var appDbContext = new ApplicationDbContext();
            var userStore = new ApplicationUserStore(appDbContext);
            var userManager = new ApplicationUserManager(userStore);
            ApplicationUser appUser = userManager.FindById(User.Identity.GetUserId());
            if (appUser == null)
            {
                return View("Error404");
            }
            else
            {
                return View(appUser);
            }
        }
    }
}