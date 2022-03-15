using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicari.Models.Entity
{
    public class CargoDetail
    {
        [Key]
        [Display(Name = "Kargo ID")]
        public int CargoDetailID { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(300)]
        [Display(Name = "Kargo Açıklaması")]
        public string CargoDetailDesc { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(10)]
        [Display(Name = "Kargo Takip Kodu")]
        public string CargoDetailTrackCode { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(20)]
        [Display(Name = "Kargo Personel")]
        public string CargoDetailEmployee { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(20)]
        [Display(Name = "Kargo Alıcı")]
        public string CargoDetailReceiver { get; set; }

        [Display(Name = "Kargo Tarih")]
        public DateTime CargoDetailDate { get; set; }
    }
}