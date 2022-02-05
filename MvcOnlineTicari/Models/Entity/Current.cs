using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicari.Models.Entity
{
    public class Current
    {
        [Key]
        public int CurrentID { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(30)]
        public string CurrentName { get; set; }//Cari adi
        [Column(TypeName = "varchar")]
        [StringLength(30)]
        public string CurrentSurName { get; set; }//Cari soyadi
        [Column(TypeName = "varchar")]
        [StringLength(13)]
        public string CurrentCity { get; set; }//Cari sehiri
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string CurrentMail { get; set; }//Cari maili
        public ICollection<SaleBehavior> SaleBehaviors { get; set; }//Satis hareketi ile cariler arasinda 1 - n relation
    }
}