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

        [Required(ErrorMessage = "Bu alan boş geçilemez!")]
        [Column(TypeName ="varchar")]
        [Display(Name = "Ürün Adı")]
        [StringLength(30, ErrorMessage = "En fazla 30 karakter kullannılabilir!")]
        public string ProductName { get; set; }//Urun adi

        [Required(ErrorMessage ="Bu alan boş geçilemez!")]
        [Column(TypeName = "varchar")]
        [Display(Name = "Ürün Markası")]
        [StringLength(30,ErrorMessage ="En fazla 30 karakter kullanılabilir!")]
        public string ProductBrand { get; set; }//Urun markasi

        [Required(ErrorMessage = "Bu alan boş geçilemez!")]
        [Column(TypeName = "varchar")]
        [Display(Name = "Ürün Resmi")]
        [StringLength(250)]
        public string ProductImage { get; set; }//Urun resmi

        [Required(ErrorMessage = "Bu alan boş geçilemez!")]
        [Display(Name = "Ürün Stok Sayısı")]
        public short ProductStock { get; set; }//Urun stok sayisi

        [Required(ErrorMessage = "Bu alan boş geçilemez!")]
        [Display(Name = "Ürün Alış Fiyatı")]
        public decimal ProductPurchasePrice { get; set; }//Urun alis fiyati

        [Required(ErrorMessage = "Bu alan boş geçilemez!")]
        [Display(Name = "Ürün Satış Fiyatı")]
        public decimal ProductSalePrice { get; set; }//Urun satis fiyati

        [Required(ErrorMessage = "Bu alan boş geçilemez!")]
        [Display(Name = "Ürün Durumu")]
        public bool ProductStatus { get; set; }//Urun durumu

        [Display(Name = "Ürün Kategorisi")]
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }// Kategori ve urun 1 - n relation
        public ICollection<SaleBehavior> SaleBehaviors { get; set; }//Satis hareketi ile urunler arasinda 1 - n relation
    }
}