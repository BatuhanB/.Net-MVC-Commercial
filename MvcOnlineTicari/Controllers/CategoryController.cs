﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicari.Models.Entity;
using MvcOnlineTicari.Models.Context;

namespace MvcOnlineTicari.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        Context context = new Context();
        public ActionResult Index()
        {
            var values =context.Categories.ToList();    
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
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteCategory(int id)
        {
            var category = context.Categories.Find(id);
            context.Categories.Remove(category);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetCategory(int id)
        {
            var category = context.Categories.Find(id);
            return View("GetCategory",category);  
        }
        public ActionResult UpdateCategory(Category category)
        {
            var categories = context.Categories.Find(category.CategoryID);
            categories.CategoryName = category.CategoryName;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}