using MvcOnlineTicari.Models.Context;
using MvcOnlineTicari.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicari.Controllers
{
    public class CargoController : Controller
    {
        // GET: Cargo
        Context context = new Context();
        public ActionResult Index(string search)
        {
            var values = from x in context.CargoDetails select x;
            if (!string.IsNullOrEmpty(search))
            {
                values = values.Where(y => y.CargoDetailTrackCode == search);
            }
            return View(values.ToList());
        }

        [HttpGet]
        public ActionResult AddCargo()
        {
            Random random = new Random();
            string[] chars = { "A", "B", "C", "D", "E", "F", "G" };
            int c1, c2, c3;
            c1 = random.Next(0, chars.Length);
            c2 = random.Next(0, chars.Length);
            c3 = random.Next(0, chars.Length);
            int n1, n2, n3;
            n1 = random.Next(100, 1000);
            n2 = random.Next(10, 99);
            n3 = random.Next(10, 99);
            string code = n1.ToString() + chars[c1] + n2.ToString() + chars[c2] + n3.ToString() + chars[c3];
            ViewBag.trackCode = code;
            return View();
        }
        [HttpPost]
        public ActionResult AddCargo(CargoDetail cargo)
        {
            context.CargoDetails.Add(cargo);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult TrackCargo(string id)
        {
            var values = context.CargoTracks.Where(x => x.CargoTrackCode == id).ToList();
            var trackCode = context.CargoDetails.Where(x => x.CargoDetailTrackCode == id).Select(x => x.CargoDetailTrackCode).FirstOrDefault(); ;
            ViewBag.cargoTrackCode = trackCode;
            return View(values);
        }
    }
}