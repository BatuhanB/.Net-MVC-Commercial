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
    }
}