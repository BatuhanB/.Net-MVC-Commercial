using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicari.Models.Entity
{
    public class Detail
    {
        [Key]
        public int DetailID { get; set; }

        [Required(ErrorMessage = "Bu alan boş geçilemez!")]
        [Column(TypeName = "varchar")]
        [Display(Name = "Ürün Adı")]
        [StringLength(30, ErrorMessage = "En fazla 30 karakter kullannılabilir!")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Bu alan boş geçilemez!")]
        [Column(TypeName = "varchar")]
        [Display(Name = "Ürün Açıklaması")]
        [StringLength(2000)]
        public string ProductInfo { get; set; }
    }
}