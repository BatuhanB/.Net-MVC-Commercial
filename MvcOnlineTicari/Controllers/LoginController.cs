using MvcOnlineTicari.Models.Context;
using MvcOnlineTicari.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

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
        [HttpGet]
        public ActionResult LoginCurrent()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginCurrent(Current current)
        {
            var values = context.Currents.FirstOrDefault(x => x.CurrentMail == current.CurrentMail && x.CurrentPassword == current.CurrentPassword);
            if (values != null)
            {
                FormsAuthentication.SetAuthCookie(values.CurrentMail, false);
                Session["CurrentMail"] = values.CurrentMail.ToString();
                return RedirectToAction("Index", "CurrentPanel");
            }
            else
            {
                return RedirectToAction("Index","Login");

            }
        }
    }
}