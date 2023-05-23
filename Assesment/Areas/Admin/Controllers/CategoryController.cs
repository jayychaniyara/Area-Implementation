using Assesment.DataLayer;
using Assesment.DomainModels;
using Assesment.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assesment.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        CompanyDbContext companyDbContext;
        ICategoriesService categoryServices;

        public CategoryController(ICategoriesService cService)
        {
            this.companyDbContext = new CompanyDbContext();
            this.categoryServices = cService;
        }

        public ActionResult Index()
        {
            try
            {
                List<Category> categories = companyDbContext.Categories.ToList();
                if (categories.Count() == 0)
                {
                    return View("Error404");
                }
                else
                {
                    return View(categories);
                }
            }
            catch (Exception exception)
            {
                ViewBag.ExceptionMessage = exception.Message;
                return View("Error");
            }
        }

        public ActionResult CreateCategory()
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
        public ActionResult CreateCategory(Category category)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    categoryServices.InsertCategory(category);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
            }
            catch (Exception exception)
            {
                ViewBag.ExceptionMessage = exception.Message;
                return View("Error");
            }
        }

        public ActionResult DeleteCategory(long id)
        {
            try
            {
                Category existingCategory = categoryServices.GetCategoryByCategoryID(id);
                if (existingCategory != null)
                {
                    return View(existingCategory);
                }
                else
                {
                    return View("Error404");
                }
            }
            catch (Exception exception)
            {
                ViewBag.ExceptionMessage = exception.Message;
                return View("Error");
            }
        }

        [HttpPost]
        public ActionResult DeleteCategory(long id, Brand brand)
        {
            try
            {
                categoryServices.DeleteCategory(id);
                return RedirectToAction("Index");
            }
            catch (Exception exception)
            {
                ViewBag.ExceptionMessage = exception.Message;
                return View("Error");
            }
        }

    }
}