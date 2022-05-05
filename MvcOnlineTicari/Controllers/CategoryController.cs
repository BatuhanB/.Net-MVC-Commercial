using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicari.Models.Entity;
using MvcOnlineTicari.Models.Context;
using PagedList;
using PagedList.Mvc;
using MvcOnlineTicari.Models.Entity.Dto;

namespace MvcOnlineTicari.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        Context context = new Context();
        public ActionResult Index(int page = 1)
        {
            var result = from category in context.Categories
                         select new CategoryDto
                         {
                             CategoryName = category.CategoryName,
                             CategoryID = category.CategoryID,
                             CategoryStatus = category.CategoryStatus,
                             CategoryStatusText = category.CategoryStatus == true ? "Aktif" : "Pasif"
                         };
            var values = result.ToList().ToPagedList(page, 5);
            return View(values);
        }
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            context.Categories.Add(category);
            category.CategoryStatus = true;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteCategory(int id)
        {
            var category = context.Categories.Find(id);
            category.CategoryStatus = false;
            context.SaveChanges();
            return RedirectToAction("Index","Category");
        }
        public ActionResult GetCategory(int id)
        {
            var category = context.Categories.Find(id);
            return View("GetCategory", category);
        }
        public ActionResult UpdateCategory(Category category)
        {
            if (!ModelState.IsValid) { return View("GetCategory"); }
            var categories = context.Categories.Find(category.CategoryID);
            categories.CategoryName = category.CategoryName;
            categories.CategoryStatus = category.CategoryStatus;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Test()
        {
            Class3 cs = new Class3();
            cs.Categories = new SelectList(context.Categories, "CategoryID", "CategoryName");
            cs.Products = new SelectList(context.Products, "ProductID", "ProductName");
            return View(cs);
        }
        public JsonResult GetProducts(int p)
        {
            var productList = (from x in context.Products
                               join y in context.Categories
                               on x.Category.CategoryID equals y.CategoryID
                               where x.Category.CategoryID == p
                               select new
                               {
                                   Text = x.ProductName,
                                   Value = x.ProductID.ToString()
                               }).ToList();
            return Json(productList, JsonRequestBehavior.AllowGet);
        }
    }
}