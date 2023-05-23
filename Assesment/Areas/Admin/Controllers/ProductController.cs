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
    public class ProductController : Controller
    {
        CompanyDbContext companyDbContext;
        IProductsService prodService;

        public ProductController(IProductsService pService)
        {
            this.companyDbContext = new CompanyDbContext();
            this.prodService = pService;
        }

        public ActionResult Index()
        {
            try
            {
                List<Product> Products = companyDbContext.Products.ToList();
                if (Products.Count() == 0)
                {
                    return View("Error404");
                }
                else
                {
                    return View(Products);
                }
            }
            catch (Exception exception)
            {
                ViewBag.ExceptionMessage = exception.Message;
                return View("Error");
            }
        }

        public ActionResult Details(long id)
        {
            try
            {
                Product Product = prodService.GetProductByProductID(id);
                if (Product != null)
                {
                    ViewBag.ProductName = Product.ProductName;
                    return View(Product);
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

        public ActionResult Create()
        {
            try
            {
                ViewBag.Cat = companyDbContext.Categories.ToList();
                ViewBag.Bd = companyDbContext.Brands.ToList();
                return View();
            }
            catch (Exception exception)
            {
                ViewBag.ExceptionMessage = exception.Message;
                return View("Error");
            }
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "ProductID,ProductName,DateOfPurchase,AvailablityStatus,CategoryId,BrandId,Active,Photo,Price")] Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (Request.Files.Count >= 1)
                    {
                        var file = Request.Files[0];
                        var imageBytes = new Byte[file.ContentLength];
                        file.InputStream.Read(imageBytes, 0, file.ContentLength);
                        var base64String = Convert.ToBase64String(imageBytes, 0, imageBytes.Length);
                        product.Photo = base64String;
                    }
                    prodService.InsertProduct(product);
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

        public ActionResult Edit(long id)
        {
            try
            {
                Product existingProduct = prodService.GetProductByProductID(id);
                if (existingProduct != null)
                {
                    ViewBag.AvailablityStatus = existingProduct.AvailablityStatus;
                    ViewBag.Categories = companyDbContext.Categories.ToList();
                    ViewBag.Brands = companyDbContext.Brands.ToList();
                    return View(existingProduct);
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
        public ActionResult Edit(Product product)
        {
            try
            {
                Product existingProduct = companyDbContext.Products.Where(temp => temp.ProductID == product.ProductID).FirstOrDefault();
                if (existingProduct != null)
                {
                    if (Request.Files.Count >= 1)
                    {
                        var file = Request.Files[0];
                        var imageBytes = new Byte[file.ContentLength];
                        file.InputStream.Read(imageBytes, 0, file.ContentLength);
                        var base64String = Convert.ToBase64String(imageBytes, 0, imageBytes.Length);
                        existingProduct.Photo = base64String;
                    }

                    existingProduct.ProductName = product.ProductName;
                    existingProduct.DateOfPurchase = product.DateOfPurchase;
                    existingProduct.CategoryId = product.CategoryId;
                    existingProduct.BrandId = product.BrandId;
                    existingProduct.AvailablityStatus = product.AvailablityStatus;
                    existingProduct.Active = product.Active;
                    existingProduct.Price = product.Price;
                    prodService.UpdateProduct(existingProduct);
                    return RedirectToAction("Index", "Product");
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

        public ActionResult Delete(long id)
        {
            try
            {
                Product existingProduct = prodService.GetProductByProductID(id);
                if (existingProduct != null)
                {
                    return View(existingProduct);
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
        public ActionResult Delete(long id, Product p)
        {
            try
            {
                prodService.DeleteProduct(id);
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