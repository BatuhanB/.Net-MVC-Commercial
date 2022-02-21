using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicari.Models.Context;
using MvcOnlineTicari.Models.Entity;

namespace MvcOnlineTicari.Controllers
{
    public class SaleController : Controller
    {
        // GET: Sale
        Context context = new Context();
        public ActionResult Index()
        {
            var values = context.SaleBehaviors.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult NewSale()
        {
            List<SelectListItem> value1 = (from x in context.Products.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.ProductName,
                                               Value = x.ProductID.ToString()
                                           }).ToList();

            List<SelectListItem> value2 = (from x in context.Currents.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CurrentName,
                                               Value = x.CurrentID.ToString()
                                           }).ToList();

            List<SelectListItem> value3 = (from x in context.Employees.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.EmployeeName + " " + x.EmployeeSurName,
                                               Value = x.EmployeeID.ToString()
                                           }).ToList();

            ViewBag.prdcts = value1;
            ViewBag.crrnts = value2;
            ViewBag.emplys = value3;
            return View();
        }
        [HttpPost]
        public ActionResult NewSale(SaleBehavior sale)
        {
            sale.SaleDate = DateTime.Today;
            context.SaleBehaviors.Add(sale);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetSale(int id)
        {
            List<SelectListItem> value1 = (from x in context.Products.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.ProductName,
                                               Value = x.ProductID.ToString()
                                           }).ToList();

            List<SelectListItem> value2 = (from x in context.Currents.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CurrentName,
                                               Value = x.CurrentID.ToString()
                                           }).ToList();

            List<SelectListItem> value3 = (from x in context.Employees.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.EmployeeName + " " + x.EmployeeSurName,
                                               Value = x.EmployeeID.ToString()
                                           }).ToList();

            ViewBag.prdcts = value1;
            ViewBag.crrnts = value2;
            ViewBag.emplys = value3;
            var values = context.SaleBehaviors.Find(id);
            return View("GetSale", values);
        }
        public ActionResult UpdateSale(SaleBehavior sale)
        {
            if (!ModelState.IsValid) { return View("GetSale"); }

            var sales = context.SaleBehaviors.Find(sale.SaleID);
            sales.ProductID = sale.ProductID;
            sales.CurrentID = sale.CurrentID;
            sales.EmployeeID = sale.EmployeeID;
            sales.SaleQuantity = sale.SaleQuantity;
            sales.SaleSumAmount = sale.SaleSumAmount;
            sales.SaleDate = sale.SaleDate;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SaleDetail(int id)
        {
            var values = context.SaleBehaviors.Where(x => x.SaleID == id).ToList();
            return View(values);
        }
    }
}