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

        [Required(ErrorMessage ="Bu alan boş bırakılamaz!")]
        [Column(TypeName = "varchar")]
        [Display(Name ="Kategori Adı")]
        [StringLength(30,ErrorMessage = "En fazla 30 karakter kullanılabilir!")]
        public string CategoryName { get; set; }//Kategori adi

        [Display(Name = "Kategori Durumu")]
        public bool CategoryStatus { get; set; }
        public ICollection<Product> Products { get; set; }// Kategori ve urun 1 - n relation
    }
}