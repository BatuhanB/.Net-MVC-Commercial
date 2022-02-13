using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicari.Models.Entity
{
    public class SaleBehavior
    {
        [Key]
        public int SaleID { get; set; }

        [Display(Name ="Satış Miktarı")]
        public int SaleQuantity { get; set; }//Satis  miktari

        [Display(Name = "Satış Tarihi")]
        public DateTime SaleDate { get; set; }//Satis tarihi

        [Display(Name = "Satış Fiyatı")]
        public decimal SalePrice { get; set; }//Satis fiyati

        [Display(Name = "Satış Toplam Tutarı")]
        public decimal SaleSumAmount { get; set; }//Satis toplam tutari

        [Display(Name = "Ürün Adı")]
        public int ProductID { get; set; }

        [Display(Name = "Cari Adı")]
        public int CurrentID { get; set; }

        [Display(Name = "Personel Adı")]
        public int EmployeeID { get; set; }

        public virtual Product Product { get; set; }//Satis hareketi ile urunler arasinda 1 - n relation
        public virtual Current Current { get; set; }//Satis hareketi ile cari arasinda 1 - n relation
        public virtual Employee Employee { get; set; }//Satis hareketi ile personel arasinda 1 - n relation

    }
}