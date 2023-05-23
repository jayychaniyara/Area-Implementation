using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assesment.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            try
            {
                // ViewBag example below
                List<string> viewDataExample = new List<string>();
                viewDataExample.Add("ViewData is used to Transfer data from controller to view.");
                viewDataExample.Add("Once it sends information, it becomes null.");
                viewDataExample.Add("ViewData is a Dictionary Object that is derived from ViewDataDictionary.");
                viewDataExample.Add("ViewData uses Key-Value pair for storing and retrieving information.");
                viewDataExample.Add("ViewData requires typecasting for complex data type.");
                ViewData["viewData"] = viewDataExample;

                // View Bag example below
                List<string> viewBagExample = new List<string>();
                viewBagExample.Add("ViewBag is used to pass data from controllers to views.");
                viewBagExample.Add("ViewBag has a short life means once it passed value from controllers to views, it becomes null.");
                viewBagExample.Add("ViewBag doesn't require typecasting.");
                viewBagExample.Add("ViewBag is able to set and get value dynamically and able to add any number of additional fields without converting it to strongly typed.");
                ViewBag.viewBagExample = viewBagExample;

                // Temp Data example below
                List<string> tempDataExample = new List<string>();
                tempDataExample.Add("TempData internally use Session to store value.");
                tempDataExample.Add("TempData used to pass data between two action methods.");
                tempDataExample.Add("TempData is only work during the current and subsequent request.");
                tempDataExample.Add("It is generally used to store one time messages.");
                tempDataExample.Add("With the help of the TempData.Keep() method we can keep value in TempData object after request completion.");
                TempData["tempData"] = tempDataExample;

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