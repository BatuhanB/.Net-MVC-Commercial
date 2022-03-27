using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicari.Models.Entity
{
    public class Class3
    {
        public IEnumerable<SelectListItem> Categories { get; set; }
        public IEnumerable<SelectListItem> Products { get; set; }
    }
}