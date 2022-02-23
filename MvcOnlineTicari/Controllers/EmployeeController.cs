﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicari.Models.Context;
using MvcOnlineTicari.Models.Entity;

namespace MvcOnlineTicari.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        Context context  = new Context();
        public ActionResult Index()
        {
            var values = context.Employees.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddEmployee()
        {
            List<SelectListItem> value = (from x in context.Departments.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.DepartmentName,
                                              Value = x.DepartmentID.ToString()
                                          }).ToList();
            ViewBag.value1 = value;
            return View();
        }
        [HttpPost]
        public ActionResult AddEmployee(Employee employee)
        {
            context.Employees.Add(employee);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetEmployee(int id)
        {
            List<SelectListItem> value = (from x in context.Departments.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.DepartmentName,
                                              Value = x.DepartmentID.ToString()
                                          }).ToList();
            ViewBag.value1 = value;

            var employee = context.Employees.Find(id);
            return View("GetEmployee",employee);
        }
        public ActionResult UpdateEmployee(Employee employee)
        {
            var emp = context.Employees.Find(employee.EmployeeID);
            emp.EmployeeName = employee.EmployeeName;
            emp.EmployeeSurName = employee.EmployeeSurName;
            emp.EmployeeImage = employee.EmployeeImage;
            emp.DepartmentID = employee.DepartmentID;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult EmployeeCardList()
        {
            var values = context.Employees.ToList();
            return View(values);
        }
    }
}