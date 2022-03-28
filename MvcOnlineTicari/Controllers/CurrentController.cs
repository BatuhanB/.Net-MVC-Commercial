using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicari.Models.Entity;
using MvcOnlineTicari.Models.Context;
using PagedList;

namespace MvcOnlineTicari.Controllers
{
    public class CurrentController : Controller
    {
        // GET: Current
        Context context = new Context();    
        public ActionResult Index(int page = 1)
        {
            var values = context.Currents.Where(x=>x.CurrentStatus == true).ToList().ToPagedList(page, 6);
            return View(values);
        }
        [HttpGet]
        public ActionResult AddCurrent()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCurrent(Current current)
        {
            current.CurrentStatus = true;   
            context.Currents.Add(current);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteCurrent(int id)
        {
            var current = context.Currents.Find(id);
            current.CurrentStatus = false;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetCurrent(int id)
        {
            var current = context.Currents.Find(id);
            return View("GetCurrent",current);
        }
        public ActionResult UpdateCurrent(Current current)
        {
            if (!ModelState.IsValid)
            {
                return View("GetCurrent");
            }
            var currents = context.Currents.Find(current.CurrentID);
            currents.CurrentName = current.CurrentName;
            currents.CurrentSurName = current.CurrentSurName;
            currents.CurrentCity = current.CurrentCity;
            currents.CurrentMail = current.CurrentMail;
            currents.CurrentStatus = current.CurrentStatus;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult EmployeeSaleHistory(int id)
        {
            var currents = context.Currents.Where(x => x.CurrentID == id).Select(y => y.CurrentName + " " + y.CurrentSurName).FirstOrDefault();
            var values = context.SaleBehaviors.Where(x => x.CurrentID == id).ToList();
            ViewBag.Currents = currents;
            return View(values);
        }
    }
}