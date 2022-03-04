using MvcOnlineTicari.Models.Context;
using MvcOnlineTicari.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicari.Controllers
{
    public class CurrentPanelController : Controller
    {
        // GET: CurrentPanel
        Context context = new Context();    
        [Authorize]
        public ActionResult Index()
        {
            var mail = (string)Session["CurrentMail"];
            var values = context.Currents.FirstOrDefault(x => x.CurrentMail == mail);
            ViewBag.Mail = mail;    
            return View(values);
        }
    }
}