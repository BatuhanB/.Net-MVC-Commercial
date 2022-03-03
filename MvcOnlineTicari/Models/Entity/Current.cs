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
        [Display(Name = "Cari Adı")]
        [StringLength(30, ErrorMessage = "En fazla 30 karakter kullanabilirsiniz!")]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz!")]
        public string CurrentName { get; set; }//Cari adi

        [Column(TypeName = "varchar")]
        [Display(Name = "Cari Soyadı")]
        [StringLength(30, ErrorMessage = "En fazla 30 karakter kullanabilirsiniz!")]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz!")]
        public string CurrentSurName { get; set; }//Cari soyadi

        [Column(TypeName = "varchar")]
        [Display(Name = "Cari Şehri")]
        [StringLength(13, ErrorMessage = "En fazla 13 karakter kullanabilirsiniz!")]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz!")]
        public string CurrentCity { get; set; }//Cari sehiri

        [Column(TypeName = "varchar")]
        [Display(Name = "Cari Mail adresi")]
        [StringLength(50)]
        public string CurrentMail { get; set; }//Cari maili

        [Column(TypeName = "varchar")]
        [Display(Name = "Cari Şifresi")]
        [StringLength(20)]
        public string CurrentPassword { get; set; }//Cari şifresi

        [Display(Name = "Cari durumu")]
        public bool CurrentStatus { get; set; }
        public ICollection<SaleBehavior> SaleBehaviors { get; set; }//Satis hareketi ile cariler arasinda 1 - n relation
    }
}