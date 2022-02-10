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
        [Column(TypeName = "varchar")]
        [StringLength(100)]
        public string InvoiceItemDesc { get; set; }//Fatura kalemi aciklama
        public int InvoiceItemQuantity { get; set; }//Fatura kalemi miktar
        public decimal InvoiceItemUnitPrice { get; set; }//Fatura kalemi birim fiyat
        public decimal InvoiceItemPrice { get; set; }//Fatura kalemi fiyat
        public virtual Invoice Invoice { get; set; }//Fatura ve fatura kalemi arasinda 1- n relations
    }
}