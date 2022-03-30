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
            invoice.InvoiceDate = DateTime.Now;
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
            var invoiceID = context.Invoices.Where(x => x.InvoiceID == invoiceItem.InvoiceItemID).Select(x => x.InvoiceID).FirstOrDefault();
            ViewBag.invcID = invoiceID;
            return RedirectToAction("Index");
        }
        public ActionResult Dynamic()
        {
            Class4 class4 = new Class4();
            class4.val1 = context.Invoices.ToList();
            class4.val2 = context.InvoiceItems.ToList();
            return View(class4);
        }
        public ActionResult SaveInvoice(string InvoiceSerialNo, string InvoiceQueueNo, DateTime InvoiceDate,string InvoiceTaxAuthority,string InvoiceTime,string InvoiceBillTo,string InvoiceShipTo,string InvoiceSumAmount, InvoiceItem[] invoiceItems)
        {
            Invoice invoice = new Invoice();
            invoice.InvoiceSerialNo = InvoiceSerialNo;
            invoice.InvoiceQueueNo = InvoiceQueueNo;
            invoice.InvoiceDate = InvoiceDate;
            invoice.InvoiceTaxAuthority = InvoiceTaxAuthority;
            invoice.InvoiceTime = InvoiceTime;
            invoice.InvoiceBillTo = InvoiceBillTo;
            invoice.InvoiceShipTo = InvoiceShipTo;
            invoice.InvoiceSumAmount = decimal.Parse(InvoiceSumAmount);
            context.Invoices.Add(invoice);
            foreach(var x in invoiceItems)
            {
                InvoiceItem invoiceItem = new InvoiceItem();
                invoiceItem.InvoiceItemDesc = x.InvoiceItemDesc;
                invoiceItem.InvoiceItemUnitPrice = x.InvoiceItemUnitPrice;
                invoiceItem.InvoiceItemQuantity = x.InvoiceItemQuantity;
                invoiceItem.InvoiceItemID = x.InvoiceItemID;
                invoiceItem.InvoiceItemPrice = x.InvoiceItemPrice;
                context.InvoiceItems.Add(invoiceItem);
            }
            context.SaveChanges();
            return Json("İşlem Başarılı",JsonRequestBehavior.AllowGet);
        }
    }
}