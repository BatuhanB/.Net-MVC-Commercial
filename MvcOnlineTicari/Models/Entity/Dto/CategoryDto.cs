using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcOnlineTicari.Models.Entity.Dto
{
    public class CategoryDto
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public bool CategoryStatus { get; set; }
        public string CategoryStatusText { get; set; }
    }
}