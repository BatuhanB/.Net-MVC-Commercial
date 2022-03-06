using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicari.Models.Entity
{
    public class Admin
    {
        [Key]
        public int AdminID { get; set; }

        [Required(ErrorMessage ="Bu alan boş bırakılamaz!")]
        [Column(TypeName = "varchar")]
        [Display(Name ="Kullanıcı Adı")]
        [StringLength(10,ErrorMessage ="En fazla 10 karakter kullanılabilir!")]
        public string AdminUserName { get; set; }

        [Required(ErrorMessage = "Bu alan boş bırakılamaz!")]
        [Column(TypeName = "varchar")]
        [Display(Name = "Şifre")]
        [StringLength(10, ErrorMessage = "En fazla 10 karakter kullanılabilir!")]
        public string AdminPassword { get; set; }

        [Column(TypeName = "char")]
        [Display(Name = "Yetki Sınıfı")]
        [StringLength(1)]
        public string AdminWarrant { get; set; }//Admin yetki sinifi
    }
}