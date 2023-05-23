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
    public class BrandController : Controller
    {
        CompanyDbContext companyDbContext;
        IBrandsService brandServices;

        public BrandController(IBrandsService bService)
        {
            this.companyDbContext = new CompanyDbContext();
            this.brandServices = bService;
        }

        public ActionResult Index()
        {
            try
            {
                List<Brand> brands = companyDbContext.Brands.ToList();
                if (brands.Count() == 0)
                {
                    return View("Error404");
                }
                else
                {
                    return View(brands);
                }
            }
            catch (Exception exception)
            {
                ViewBag.ExceptionMessage = exception.Message;
                return View("Error");
            }
        }

        public ActionResult CreateBrand()
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
        public ActionResult CreateBrand(Brand brand)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    brandServices.InsertBrand(brand);
                    if (brand != null)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return View("Error404");
                    }
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

        public ActionResult DeleteBrand(long id)
        {
            try
            {
                Brand existingBrand = brandServices.GetBrandByBrandID(id);
                if (existingBrand != null)
                {
                    return View(existingBrand);
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
        public ActionResult DeleteBrand(long id, Brand brand)
        {
            try
            {
                brandServices.DeleteBrand(id);
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