using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicari.Models.Entity;
using MvcOnlineTicari.Models.Context;

namespace MvcOnlineTicari.Controllers
{
    public class GalleryController : Controller
    {
        // GET: Gallery
        Context context = new Context();
        public ActionResult Index()
        {
            var values = context.Products.ToList();
            return View(values);
        }
    }
}