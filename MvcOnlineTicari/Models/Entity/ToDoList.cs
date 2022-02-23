using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicari.Models.Entity
{
    public class ToDoList
    {
        [Key]
        public int ToDoID { get; set; }

        [Column(TypeName = "varchar")]
        [Display(Name = "Başlık")]
        [StringLength(100, ErrorMessage = "En fazla 100 karakter kullanılabilir!")]
        public string ToDoTitle { get; set; }//Calisan adi

        [Column(TypeName = "bit")]
        [Display(Name = "Durum")]
        public bool ToDoStatus { get; set; }//Calisan soyadi
    }
}