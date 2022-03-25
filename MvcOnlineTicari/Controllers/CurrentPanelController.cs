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
    public class CurrentPanelController : Controller
    {
        // GET: CurrentPanel
        Context context = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var mail = (string)Session["CurrentMail"];
            var values = context.Currents.Where(x => x.CurrentMail == mail).ToList();
            ViewBag.Mail = mail;
            var mailid = context.Currents.Where(x => x.CurrentMail == mail).Select(x => x.CurrentID).FirstOrDefault();
            ViewBag.mailID = mailid;
            var saleSumValue = context.SaleBehaviors.Where(x => x.CurrentID == mailid).Count();
            ViewBag.SaleSum = saleSumValue;
            var saleSumAmount = context.SaleBehaviors.Where(x => x.CurrentID == mailid).Sum(x => (decimal?)x.SaleSumAmount);
            ViewBag.SalesSumAmount = saleSumAmount;
            var saleProductCount = context.SaleBehaviors.Where(x => x.CurrentID == mailid).Sum(x => (int?)x.SaleQuantity);
            ViewBag.ProductCount = saleProductCount;
            return View(values);
        }
        [Authorize]
        public ActionResult Orders()
        {
            var mail = (string)Session["CurrentMail"];
            var id = context.Currents.Where(x => x.CurrentMail == mail).Select(y => y.CurrentID).FirstOrDefault();
            var values = context.SaleBehaviors.Where(x => x.CurrentID == id).ToList();
            return View(values);
        }
        [Authorize]
        public ActionResult InComingMessage()
        {
            var mail = (string)Session["CurrentMail"];
            var values = context.Messages.Where(x => x.Receiver == mail).OrderByDescending(x => x.MessageDate).ToList();
            var incomingValues = context.Messages.Where(x => x.Receiver == mail).Count().ToString();
            var sendedValues = context.Messages.Where(x => x.Sender == mail).Count().ToString();
            ViewBag.numberMail2 = sendedValues;
            ViewBag.numberMail = incomingValues;
            return View(values);
        }
        public ActionResult SentMessage()
        {
            var mail = (string)Session["CurrentMail"];
            var values = context.Messages.Where(x => x.Sender == mail).ToList();
            var incomingValues = context.Messages.Where(x => x.Receiver == mail).OrderBy(x => x.MessageDate).Count().ToString();
            ViewBag.numberMail = incomingValues;
            var sendedValues = context.Messages.Where(x => x.Sender == mail).Count().ToString();
            ViewBag.numberMail2 = sendedValues;
            return View(values);
        }
        public ActionResult MessageDetail(int id)
        {
            var values = context.Messages.Where(x => x.MessageId == id).ToList();
            var mail = (string)Session["CurrentMail"];
            var incomingValues = context.Messages.Where(x => x.Receiver == mail).Count().ToString();
            ViewBag.numberMail = incomingValues;
            var sendedValues = context.Messages.Where(x => x.Sender == mail).Count().ToString();
            ViewBag.numberMail2 = sendedValues;
            return View(values);
        }
        [HttpGet]
        public ActionResult NewMessage()
        {
            var mail = (string)Session["CurrentMail"];
            var incomingValues = context.Messages.Where(x => x.Receiver == mail).Count().ToString();
            ViewBag.numberMail = incomingValues;
            var sendedValues = context.Messages.Where(x => x.Sender == mail).Count().ToString();
            ViewBag.numberMail2 = sendedValues;
            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(Message message)
        {
            var mail = (string)Session["CurrentMail"];
            message.MessageDate = DateTime.Now;
            message.Sender = mail;
            context.Messages.Add(message);
            context.SaveChanges();
            return RedirectToAction("NewMessage");
        }
        [Authorize]
        public ActionResult CargoTrack(string search)
        {
            var values = from x in context.CargoDetails select x;
            values = values.Where(y => y.CargoDetailTrackCode == search);
            return View(values.ToList());
        }
        public ActionResult CargoTrackCurrent(string id)
        {
            var values = context.CargoTracks.Where(x => x.CargoTrackCode == id).ToList();
            var trackCode = context.CargoDetails.Where(x => x.CargoDetailTrackCode == id).Select(x => x.CargoDetailTrackCode).FirstOrDefault(); ;
            ViewBag.cargoTrackCode = trackCode;
            var counter = context.CargoTracks.Where(x => x.CargoTrackCode == id).Count();
            ViewBag.cntr = counter;
            return View(values);
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}