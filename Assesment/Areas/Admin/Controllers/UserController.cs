using Assesment.DataLayer;
using Assesment.DomainModels;
using Assesment.Identity;
using Assesment.ViewModel;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assesment.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        CompanyDbContext companyDbContext;
        public UserController()
        {
            this.companyDbContext = new CompanyDbContext();
        }

        public ActionResult Index()
        {
            try
            {
                var loggedInUserId = (string)Session["loggdInUserId"];
                ViewBag.LoggedInUserId = loggedInUserId;
                return View();
            }
            catch (Exception exception)
            {
                ViewBag.ExceptionMessage = exception.Message;
                return View("Error");
            }
        }
    }
}