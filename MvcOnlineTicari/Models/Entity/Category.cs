using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicari.Models.Entity
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(30)]
        public string CategoryName { get; set; }//Kategori adi
        public bool CategoryStatus { get; set; }
        public ICollection<Product> Products { get; set; }// Kategori ve urun 1 - n relation
    }
}