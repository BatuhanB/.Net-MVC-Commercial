using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicari.Models.Entity
{
    public class CargoTrack
    {
        [Key]
        [Display(Name = "Takip Kodu")]
        public int CargoTrackID { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(10)]
        [Display(Name ="Kargo Takip Kodu")]
        public string CargoTrackCode { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(100)]
        [Display(Name = "Kargo Takip Açıklaması")]
        public string CargoTrackDesc { get; set; }

        [Display(Name = "Kargo Takip Tarihi")]
        public DateTime CargoTrackDate { get; set; }
    }
}