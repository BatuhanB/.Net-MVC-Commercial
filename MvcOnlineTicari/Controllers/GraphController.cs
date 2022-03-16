using MvcOnlineTicari.Models.Context;
using MvcOnlineTicari.Models.Entity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace MvcOnlineTicari.Controllers
{
    public class GraphController : Controller
    {
        // GET: Graph
        Context context = new Context();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Index2()
        {
            var drawGraph = new Chart(750, 750);
            drawGraph.AddTitle("Kategori - Ürün Stok Sayısı").AddLegend("Stok").AddSeries("Değerler", xValue: new[] { "Ev Esyalari", "Ofis Esyalari", "Teknoloji Urunleri", "Kisisel Bakim" },yValues:new [] {12,25,124,242}).Write();
            return File(drawGraph.ToWebImage().GetBytes(), "image/jpeg");
        }
        public ActionResult Index3()
        {
            ArrayList xvalue = new ArrayList();
            ArrayList yvalue = new ArrayList();
            var results = context.Products.ToList();
            results.ToList().ForEach(x => xvalue.Add(x.ProductName));
            results.ToList().ForEach(y => yvalue.Add(y.ProductStock));
            var drawGraph = new Chart(width: 1000, height: 1000)
                .AddTitle("Stoklar")
                .AddSeries(chartType: "Pie", name: "Stok", xValue: xvalue, yValues: yvalue);
            return File(drawGraph.ToWebImage().GetBytes(), "image/jpeg");
        }
        public ActionResult Index4()
        {
            return View();
        }
        public ActionResult VisualizeProductResults()
        {
            return Json(ProductList(), JsonRequestBehavior.AllowGet);
        }
        public List<Class1> ProductList()
        {
            List<Class1> class1s = new List<Class1>();
            class1s.Add(new Class1()
            {
                ProductName = "Bilgisayar",
                ProductStock = 120
            });
            class1s.Add(new Class1()
            {
                ProductName = "Mobilya",
                ProductStock = 220
            });
            class1s.Add(new Class1()
            {
                ProductName = "Beyaz Esya",
                ProductStock = 140
            });
            class1s.Add(new Class1()
            {
                ProductName = "Kucuk Ev Aletleri",
                ProductStock = 320
            });
            return class1s;
        }
    }
}