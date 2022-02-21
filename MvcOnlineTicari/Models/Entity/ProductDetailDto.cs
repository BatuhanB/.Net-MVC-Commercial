using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcOnlineTicari.Models.Entity
{
    public class ProductDetailDto
    {
        public IEnumerable<Product> Products { get; set;}
        public IEnumerable<Detail> Details { get; set;}
    }
}