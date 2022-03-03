using MvcOnlineTicari.Models.Context;
using MvcOnlineTicari.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicari.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        Context context = new Context();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult RegisterCurrent()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult RegisterCurrent(Current current)
        {
            context.Currents.Add(current);
            current.CurrentStatus = true;
            context.SaveChanges();
            return PartialView();
        }
        public PartialViewResult LoginCurrent()
        {
            return PartialView();
        }
        public PartialViewResult LoginEmployee()
        {
            return PartialView();
        }
    }
}