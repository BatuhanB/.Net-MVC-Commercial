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
        [Column(TypeName = "varchar")]
        [StringLength(30)]
        public string ChargeDesc { get; set; }//Gider aciklama
        public DateTime ChargeDate { get; set; }//Gider tarihi
        public decimal ChargeAmount { get; set; }//Gider tutari
    }
}