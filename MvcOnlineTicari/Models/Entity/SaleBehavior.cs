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
        public int SaleQuantity { get; set; }//Satis  miktari
        public DateTime SaleDate { get; set; }//Satis tarihi
        public decimal SalePrice { get; set; }//Satis fiyati
        public decimal SaleSumAmount { get; set; }//Satis toplam tutari
        public Product Product { get; set; }//Satis hareketi ile urunler arasinda 1 - n relation
        public Current Current { get; set; }//Satis hareketi ile cari arasinda 1 - n relation
        public Employee Employee { get; set; }//Satis hareketi ile personel arasinda 1 - n relation

    }
}