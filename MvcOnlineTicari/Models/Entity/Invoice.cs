using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicari.Models.Entity
{
    public class Invoice
    {
        [Key]
        public int InvoiceID { get; set; }
        [Required(ErrorMessage ="Bu alan boş geçilemez!")]
        [Column(TypeName = "char")]
        [Display(Name ="Seri No")]
        [StringLength(1)]
        public string InvoiceSerialNo { get; set; }// Fatura seri no

        [Required(ErrorMessage = "Bu alan boş geçilemez!")]
        [Column(TypeName = "varchar")]
        [Display(Name = "Sıra No")]
        [StringLength(6)]
        public string InvoiceQueueNo { get; set; }// Fatura sira no

        public DateTime InvoiceDate { get; set; }// Fatura tarih
        public DateTime InvoiceTime { get; set; }// Fatura saati

        [Required(ErrorMessage = "Bu alan boş geçilemez!")]
        [Column(TypeName = "varchar")]
        [Display(Name = "Vergi Dairesi")]
        [StringLength(60, ErrorMessage = "En fazla 60 karakter kullanılabilir!")]
        public string InvoiceTaxAuthority { get; set; }//Fatura vergi dairesi

        [Required(ErrorMessage = "Bu alan boş geçilemez!")]
        [Column(TypeName = "varchar")]
        [Display(Name = "Teslim Eden")]
        [StringLength(30,ErrorMessage ="En fazla 30 karakter kullanılabilir!")]
        public string InvoiceBillTo { get; set; }//Fatura teslim eden

        [Required(ErrorMessage = "Bu alan boş geçilemez!")]
        [Column(TypeName = "varchar")]
        [Display(Name = "Teslim Alan")]
        [StringLength(30, ErrorMessage = "En fazla 30 karakter kullanılabilir!")]
        public string InvoiceShipTo { get; set; }//Fatura teslim alan
        public ICollection<InvoiceItem> InvoiceItems { get; set; }//Fatura ve fatura kalemi arasinda 1- n relations
    }
}