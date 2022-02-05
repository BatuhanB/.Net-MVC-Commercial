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
        [Column(TypeName = "varchar")]
        [StringLength(30)]
        public string DepartmentName { get; set; }//Departman adi
        public ICollection<Employee> Employees { get; set; }//Departman ile personeller arasinda 1 - n relation
    }
}