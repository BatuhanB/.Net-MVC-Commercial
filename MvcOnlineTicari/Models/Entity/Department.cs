using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicari.Models.Entity
{
    public class Department
    {
        [Key]
        public int DepartmentID { get; set; }
        [Required(ErrorMessage ="Bu alan boş bırakılamaz!")]
        [Column(TypeName = "varchar")]
        [Display(Name ="Departman Adı")]
        [StringLength(30,ErrorMessage ="En fazla 30 karakter kullanılabilir!")]
        public string DepartmentName { get; set; }//Departman adi\

        [Display(Name = "Departman Durumu")]
        public bool DepartmentStatus { get; set; }
        public ICollection<Employee> Employees { get; set; }//Departman ile personeller arasinda 1 - n relation
    }
}