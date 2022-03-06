using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicari.Models.Context;
using MvcOnlineTicari.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace MvcOnlineTicari.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        Context context = new Context();
        public ActionResult Index( string search, int page = 1)
        {
            var values = from x in context.Products select x;
            if (!string.IsNullOrEmpty(search))
            {
                values = values.Where(y=>y.ProductName.Contains(search));
            }
            return View(values.Where(x => x.ProductStatus == true).ToList().ToPagedList(page, 6));
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
            if (!ModelState.IsValid) { return View("AddProduct"); }
            List<SelectListItem> value = (from x in context.Categories.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.CategoryName,
                                              Value = x.CategoryID.ToString()
                                          }).ToList();
            ViewBag.value1 = value;
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
            if (!ModelState.IsValid) { return View("GetProduct"); }

            List<SelectListItem> value = (from x in context.Categories.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.CategoryName,
                                              Value = x.CategoryID.ToString()
                                          }).ToList();
            ViewBag.value1 = value;
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
        public ActionResult ProductList()
        {
            var values = context.Products.ToList();
            return View(values);
        }
    }
}