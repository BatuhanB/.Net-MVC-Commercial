using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicari.Models.Entity;
using MvcOnlineTicari.Models.Context;

namespace MvcOnlineTicari.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department
        Context context = new Context();
        public ActionResult Index()
        {
            var values = context.Departments.Where(x => x.DepartmentStatus == true).ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddDepartment()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddDepartment(Department department)
        {
            context.Departments.Add(department);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteDepartment(int id)
        {
            var department = context.Departments.Find(id);
            department.DepartmentStatus = false;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetDepartment(int id)
        {
            var department = context.Departments.Find(id);
            return View("GetDepartment", department);
        }
        public ActionResult UpdateDepartment(Department department)
        {
            if (!ModelState.IsValid) { return View("GetDepartment"); }

            var departments = context.Departments.Find(department.DepartmentID);
            departments.DepartmentName = department.DepartmentName;
            departments.DepartmentStatus = department.DepartmentStatus;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmentDetail(int id)
        {
            var values = context.Employees.Where(x => x.DepartmentID == id).ToList();
            var department = context.Departments.Where(x => x.DepartmentID == id).Select(y => y.DepartmentName).FirstOrDefault();
            ViewBag.departmentName = department;
            return View(values);
        }
        public ActionResult DepartmentEmployeeSale(int id)
        {
            var employee = context.Employees.Where(x => x.EmployeeID == id).Select(y => y.EmployeeName + " " + y.EmployeeSurName).FirstOrDefault();
            ViewBag.employeeName = employee;
            var values = context.SaleBehaviors.Where(x => x.EmployeeID == id).ToList();
            return View(values);
        }
    }
}