using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicari.Models.Entity
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(30)]
        public string EmployeeName { get; set; }//Calisan adi
        [Column(TypeName = "varchar")]
        [StringLength(30)]
        public string EmployeeSurName { get; set; }//Calisan soyadi
        [Column(TypeName = "varchar")]
        [StringLength(250)]
        public string EmployeeImage { get; set; }//Calisan fotografi
        public ICollection<SaleBehavior> SaleBehaviors { get; set; }//Satis hareketi ile personeller arasinda 1 - n relation
        public int DepartmentID { get; set; }
        public virtual Department Department { get; set; }//Departman ile personeller arasinda 1 - n relation
    }
}