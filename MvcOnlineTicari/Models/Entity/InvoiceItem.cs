using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicari.Models.Entity
{
    public class InvoiceItem
    {
        [Key]
        public int InvoiceItemID { get; set; }

        [Required(ErrorMessage ="Bu alan boş bırakılamaz!")]
        [Column(TypeName = "varchar")]
        [Display(Name ="Fatura Kalemi Açıklaması")]
        [StringLength(100,ErrorMessage ="En fazla 100 karakter kullanılabilir!")]
        public string InvoiceItemDesc { get; set; }//Fatura kalemi aciklama

        [Display(Name = "Fatura Kalemi Miktarı")]
        public int InvoiceItemQuantity { get; set; }//Fatura kalemi miktar

        [Display(Name = "Fatura Kalemi Birim Fiyatı")]
        public decimal InvoiceItemUnitPrice { get; set; }//Fatura kalemi birim fiyat

        [Display(Name = "Fatura Kalemi Fiyat")]
        public decimal InvoiceItemPrice { get; set; }//Fatura kalemi fiyat
        public int InvoiceID { get; set; }
        public virtual Invoice Invoice { get; set; }//Fatura ve fatura kalemi arasinda 1- n relations
    }
}