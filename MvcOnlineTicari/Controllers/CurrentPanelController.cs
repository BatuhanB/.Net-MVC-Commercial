﻿using MvcOnlineTicari.Models.Context;
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
            var mail = (string)Session["CurrentMail"];
            var values = context.Messages.Where(x=>x.Receiver == mail).OrderByDescending(x=>x.MessageDate).ToList();
            var incomingValues = context.Messages.Where(x=>x.Receiver == mail).Count().ToString();
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
    }
}