using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicari.Models.Entity
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        [Column(TypeName ="varchar")]
        [StringLength(30)]
        public string ProductName { get; set; }//Urun adi
        [Column(TypeName = "varchar")]
        [StringLength(30)]
        public string ProductBrand { get; set; }//Urun markasi
        [Column(TypeName = "varchar")]
        [StringLength(250)]
        public string ProductImage { get; set; }//Urun resmi
        public short ProductStock { get; set; }//Urun stok sayisi
        public decimal ProductPurchasePrice { get; set; }//Urun alis fiyati
        public decimal ProductSalePrice { get; set; }//Urun satis fiyati
        public bool ProductStatus { get; set; }//Urun durumu
        public Category Category { get; set; }// Kategori ve urun 1 - n relation
        public ICollection<SaleBehavior> SaleBehaviors { get; set; }//Satis hareketi ile urunler arasinda 1 - n relation
    }
}