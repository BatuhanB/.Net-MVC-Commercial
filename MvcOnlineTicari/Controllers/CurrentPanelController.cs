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
        public ActionResult Orders()
        {
            var mail = (string)Session["CurrentMail"];
            var id = context.Currents.Where(x=>x.CurrentMail == mail).Select(y => y.CurrentID).FirstOrDefault();
            var values = context.SaleBehaviors.Where(x=>x.CurrentID == id).ToList();
            return View(values);
        }
        public ActionResult InComingMessage()
        {
            var values = context.Messages.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(Message message)
        {
            return View();
        }
    }
}