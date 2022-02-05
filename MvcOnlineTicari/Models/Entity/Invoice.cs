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
        [Column(TypeName = "char")]
        [StringLength(1)]
        public string InvoiceSerialNo { get; set; }// Fatura seri no
        [Column(TypeName = "varchar")]
        [StringLength(6)]
        public string InvoiceQueueNo { get; set; }// Fatura sira no
        public DateTime InvoiceDate { get; set; }// Fatura tarih
        public DateTime InvoiceTime { get; set; }// Fatura saati
        [Column(TypeName = "varchar")]
        [StringLength(60)]
        public string InvoiceTaxAuthority { get; set; }//Fatura vergi dairesi
        [Column(TypeName = "varchar")]
        [StringLength(30)]
        public string InvoiceBillTo { get; set; }//Fatura teslim eden
        [Column(TypeName = "varchar")]
        [StringLength(30)]
        public string InvoiceShipTo { get; set; }//Fatura teslim alan
        public ICollection<InvoiceItem> InvoiceItems { get; set; }//Fatura ve fatura kalemi arasinda 1- n relations
    }
}