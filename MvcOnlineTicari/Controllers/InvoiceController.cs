using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicari.Models.Context;
using MvcOnlineTicari.Models.Entity;

namespace MvcOnlineTicari.Controllers
{
    public class InvoiceController : Controller
    {
        // GET: Invoice
        Context context = new Context();
        public ActionResult Index()
        {
            var values = context.Invoices.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddInvoice()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddInvoice(Invoice invoice)
        {
            if (!ModelState.IsValid)
            {
                return View("AddInvoice");
            }
            context.Invoices.Add(invoice);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetInvoice(int id)
        {
            var values = context.Invoices.Find(id);
            return View("GetInvoice", values);
        }
        public ActionResult UpdateInvoice(Invoice invoice)
        {
            if (!ModelState.IsValid)
            {
                return View("GetInvoice");
            }
            var invoices = context.Invoices.Find(invoice.InvoiceID);
            invoices.InvoiceSerialNo = invoice.InvoiceSerialNo;
            invoices.InvoiceQueueNo = invoice.InvoiceQueueNo;
            invoices.InvoiceSumAmount = invoice.InvoiceSumAmount;
            invoices.InvoiceDate = invoice.InvoiceDate;
            invoices.InvoiceTime = invoice.InvoiceTime;
            invoices.InvoiceTaxAuthority = invoice.InvoiceTaxAuthority;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult InvoiceDetails(int id)
        {
            var invoiceItem = context.InvoiceItems.Where(x => x.InvoiceID == id).ToList();
            var invoiceDetails = context.Invoices.Where(x => x.InvoiceID == id).Select(x => x.InvoiceSerialNo).FirstOrDefault();
            ViewBag.invcs = invoiceDetails;
            return View(invoiceItem);
        }
        [HttpGet]
        public ActionResult AddInvoiceItem()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddInvoiceItem(InvoiceItem invoiceItem)
        {
            context.InvoiceItems.Add(invoiceItem);
            context.SaveChanges();
            var invoiceID = context.Invoices.Where(x=>x.InvoiceID == invoiceItem.InvoiceItemID).Select(x => x.InvoiceID).FirstOrDefault();
            ViewBag.invcID = invoiceID;
            return RedirectToAction("Index");
        }
    }
}