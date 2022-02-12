using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicari.Models.Context;
using MvcOnlineTicari.Models.Entity;

namespace MvcOnlineTicari.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        Context context = new Context();
        public ActionResult Index()
        {
            var values = context.Products.Where(x => x.ProductStatus == true).ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddProduct()
        {
            List<SelectListItem> value = (from x in context.Categories.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.CategoryName,
                                              Value = x.CategoryID.ToString()
                                          }).ToList();
            ViewBag.value1 = value;
            return View();
        }
        [HttpPost]
        public ActionResult AddProduct(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges(); 
            return RedirectToAction("Index");
        }
        public ActionResult DeleteProduct(int id)
        {
            var product = context.Products.Find(id);
            product.ProductStatus = false;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetProduct(int id)
        {
            List<SelectListItem> value = (from x in context.Categories.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.CategoryName,
                                              Value = x.CategoryID.ToString()
                                          }).ToList();
            ViewBag.value1 = value;
            var product = context.Products.Find(id);
            return View("GetProduct", product);
        }
        public ActionResult UpdateProduct(Product product)
        {
            var products = context.Products.Find(product.ProductID);
            products.ProductName = product.ProductName;
            products.ProductBrand = product.ProductBrand;
            products.ProductImage = product.ProductName;
            products.ProductPurchasePrice = product.ProductPurchasePrice;
            products.ProductSalePrice = product.ProductSalePrice;
            products.ProductStock = product.ProductStock;
            products.ProductStatus = product.ProductStatus;
            products.CategoryID = product.CategoryID;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}