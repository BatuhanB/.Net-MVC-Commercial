using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicari.Models.Entity
{
    public class Charges
    {
        [Key]
        public int ChargeID { get; set; }

        [Required(ErrorMessage ="Bu alan boş geçilemez!")]
        [Column(TypeName = "varchar")]
        [Display(Name ="Gider Açıklaması")]
        [StringLength(30,ErrorMessage ="En fazla 30 karakter kullanılabilir!")]
        public string ChargeDesc { get; set; }//Gider aciklama

        [Display(Name = "Gider Tarihi")]
        public DateTime ChargeDate { get; set; }//Gider tarihi

        [Display(Name = "Gider Tutarı")]
        public decimal ChargeAmount { get; set; }//Gider tutari
    }
}