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
            var values = context.Products.ToList(); 
            return View(values);
        }
        [HttpGet]
        public ActionResult AddProduct()
        {

            return View();
        }
        [HttpPost]
        public ActionResult AddProduct(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges(); 
            return RedirectToAction("Index");
        }
    }
}