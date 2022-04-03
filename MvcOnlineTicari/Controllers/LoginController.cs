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
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        Context context = new Context();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult RegisterCurrent()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RegisterCurrent(Current current)
        {
            context.Currents.Add(current);
            current.CurrentStatus = true;
            context.SaveChanges();
            return RedirectToAction("Index");
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
                ViewBag.message = "Girmiş olduğunuz mail adresi veya şifre yanlıştır!";
                return View("Index");
            }
        }
        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminLogin(Admin admin)
        {
            var values = context.Admins.FirstOrDefault(x => x.AdminUserName == admin.AdminUserName && x.AdminPassword == admin.AdminPassword);
            if (values != null)
            {
                FormsAuthentication.SetAuthCookie(values.AdminUserName, false);
                Session["AdminUserName"] = values.AdminUserName.ToString();
                return RedirectToAction("Index", "Category");
            }
            else
            {
                ViewBag.message = "Girmiş olduğunuz kullanıcı adı veya şifre yanlıştır!";
                return View();
            }
        }
        public ActionResult AdminLogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
        public PartialViewResult LoggedAs()
        {
            var adminUserName = (string)Session["AdminUserName"];
            ViewBag.adminUserName = adminUserName;
            return PartialView();
        }
    }
}