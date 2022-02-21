using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicari.Models.Entity;
using MvcOnlineTicari.Models.Context;

namespace MvcOnlineTicari.Controllers
{
    public class ProductDetailController : Controller
    {
        // GET: ProductDetail
        Context context = new Context();
        public ActionResult Index()
        {
            //var values = context.Products.Where(x=>x.ProductID == 2).ToList();
            ProductDetailDto productDetailDto = new ProductDetailDto();
            productDetailDto.Products = context.Products.Where(x=>x.ProductID == 2).ToList();
            productDetailDto.Details = context.Details.Where(x=>x.DetailID == 1).ToList();
            return View(productDetailDto);
        }
    }
}