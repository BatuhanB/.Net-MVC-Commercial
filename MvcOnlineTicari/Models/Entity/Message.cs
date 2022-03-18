using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicari.Models.Entity
{
    public class Message
    {
        [Key]
        public int MessageId { get; set; }

        [Required(ErrorMessage = "Bu alan boş bırakılamaz!")]
        [Column(TypeName = "varchar")]
        [Display(Name = "Gönderici")]
        [StringLength(50, ErrorMessage = "En fazla 30 karakter kullanılabilir!")]
        public string Sender { get; set; }//Mesaj gondericisi

        [Required(ErrorMessage = "Bu alan boş bırakılamaz!")]
        [Column(TypeName = "varchar")]
        [Display(Name = "Alıcı")]
        [StringLength(50, ErrorMessage = "En fazla 30 karakter kullanılabilir!")]
        public string Receiver { get; set; }//Mesaj alicisi

        [Required(ErrorMessage = "Bu alan boş bırakılamaz!")]
        [Column(TypeName = "nvarchar")]
        [Display(Name = "Konu")]
        [StringLength(50, ErrorMessage = "En fazla 30 karakter kullanılabilir!")]
        public string Subject { get; set; }//Mesaj konusu

        [Required(ErrorMessage = "Bu alan boş bırakılamaz!")]
        [Column(TypeName = "varchar")]
        [Display(Name = "İçerik")]
        [StringLength(2000, ErrorMessage = "En fazla 30 karakter kullanılabilir!")]
        public string Content { get; set; }//Mesaj İçeriği

        [Column(TypeName = "Date")]
        public DateTime MessageDate { get; set; }
    }
}