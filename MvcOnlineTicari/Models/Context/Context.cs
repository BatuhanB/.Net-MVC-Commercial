using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MvcOnlineTicari.Models.Entity;

namespace MvcOnlineTicari.Models.Context
{
    public class Context:DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Current> Currents { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Charges> Charges { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceItem> InvoiceItems { get; set; }
        public DbSet<SaleBehavior> SaleBehaviors { get; set; }
        public DbSet<Detail> Details { get; set; }
        public DbSet<ToDoList> ToDoLists { get; set; }
        public DbSet<CargoDetail> CargoDetails { get; set; }
        public DbSet<CargoTrack> CargoTracks { get; set; }
        public DbSet<Message> Messages { get; set; }
    }
}