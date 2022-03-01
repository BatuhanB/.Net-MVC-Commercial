using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicari.Models.Entity;
using MvcOnlineTicari.Models.Context;

namespace MvcOnlineTicari.Controllers
{
    public class ToDoController : Controller
    {
        // GET: ToDo
        Context context = new Context();
        public ActionResult Index()
        {
            var value1 = context.Currents.Count().ToString();
            ViewBag.crrnts = value1;
            var value2 = context.Products.Count().ToString();
            ViewBag.prdcts = value2;
            var value3 = context.Categories.Count().ToString();
            ViewBag.ctgrs = value3;
            var value4 = (from x in context.Currents select x.CurrentCity).Distinct().Count().ToString();
            ViewBag.cities = value4;
            var todos = context.ToDoLists.ToList();
            return View(todos);
        }
    }
}