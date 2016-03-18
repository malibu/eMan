using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using eManager.Core;

namespace eManager.Web.Infrastructure
{
    public class DepartmentDb : DbContext, IDepartmentDataSource
    {
        public DbSet<Employee> Employes { get; set; }
        public DbSet<Department> Departments { get; set; }

        public DepartmentDb() : base("DefaultConnection")
        {

        }

         IQueryable<Employee> IDepartmentDataSource.Employee
        {
            get { return Employes; }
        }

         IQueryable<Department> IDepartmentDataSource.Departments
        {
            get { return Departments; }
        }



         public void Save()
         {
            
             this.SaveChanges();
         }
    }
}