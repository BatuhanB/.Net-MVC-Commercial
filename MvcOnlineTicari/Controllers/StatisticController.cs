using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicari.Models.Entity;
using MvcOnlineTicari.Models.Context;

namespace MvcOnlineTicari.Controllers
{
    public class StatisticController : Controller
    {
        // GET: Statistic
        Context context = new Context();
        public ActionResult Index()
        {
            var val1 = context.Currents.Count().ToString();
            ViewBag.curr = val1;
            var val2 = context.Products.Count().ToString();
            ViewBag.prod = val2;
            var val3 = context.Employees.Count().ToString();
            ViewBag.empl = val3;
            var val4 = context.Categories.Count().ToString();
            ViewBag.cate = val4;
            var val5 = context.Products.Sum(x => x.ProductStock).ToString();
            ViewBag.stock = val5;
            var val6 = (from x in context.Products select x.ProductBrand).Distinct().Count().ToString();
            ViewBag.brand = val6;
            var val7 = context.Products.Count(x => x.ProductStock <= 20).ToString();
            ViewBag.crit = val7;
            var val8 = (from x in context.Products orderby x.ProductSalePrice descending select x.ProductName).FirstOrDefault();
            ViewBag.maxVal = val8;
            var val9 = (from x in context.Products orderby x.ProductSalePrice ascending select x.ProductName).FirstOrDefault();
            ViewBag.minVal = val9;
            var val10 = context.Products.Count(x => x.ProductName == "Buzdolabi").ToString();
            ViewBag.refr = val10;
            var val11 = context.Products.Count(x => x.ProductName == "Bilgisayar").ToString();
            ViewBag.comp = val11;
            var val12 = context.Products.GroupBy(x => x.ProductBrand).OrderByDescending(y => y.Count()).Select(z => z.Key).FirstOrDefault();
            ViewBag.maxBrand = val12;
            var val13 = context.Products.Where(u => u.ProductID ==(context.SaleBehaviors.GroupBy(x => x.ProductID).OrderByDescending(y => y.Count()).Select(z => z.Key).FirstOrDefault())).Select(k=>k.ProductName).FirstOrDefault();
            ViewBag.mostSale = val13;
            var val14 = context.SaleBehaviors.Sum(x => x.SaleSumAmount).ToString();
            ViewBag.sum = val14;
            DateTime today = DateTime.Today;
            var val15 = context.SaleBehaviors.Count(x => x.SaleDate == today).ToString();
            ViewBag.todaySale = val15;
            var val16 = (from x in context.SaleBehaviors where x.SaleDate == today select x.SaleSumAmount).Sum().ToString();
            ViewBag.sumToday = val16;
            return View();
        }
    }
}