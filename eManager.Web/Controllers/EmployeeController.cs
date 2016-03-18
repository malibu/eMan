using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eManager.Core;
using eManager.Web.Models;
using Microsoft.Owin.Security.Provider;


namespace eManager.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class EmployeeController : Controller
    {
        private readonly IDepartmentDataSource _ds;

        public EmployeeController(IDepartmentDataSource ds)

        {

            _ds = ds;
        }


        [HttpGet]
 
        public ActionResult Create(int departmentId)
        {
            var model = new CreateEmployeeViewModel { DepartmentId = departmentId };
            return View(model);
        }


        //public ActionResult Dod(int departmentId)
        //{
        //    var evm = new CreateEmployeeViewModel { DepartmentId = departmentId };
        //    return View(evm);
        //}

        [HttpPost]
        public ActionResult Create(CreateEmployeeViewModel evEmployeeViewModel)
        {

            if (ModelState.IsValid)
            {
                var model = _ds.Departments.FirstOrDefault(dep => dep.Id == evEmployeeViewModel.DepartmentId);
                if (model != null) model.Employees.Add(new Employee() { Name = evEmployeeViewModel.Name });
                _ds.Save();
                return RedirectToAction("Detail", "Department", new { ID = evEmployeeViewModel.DepartmentId });
            }
            else
            {
                return View(evEmployeeViewModel);
            }
        }
    }
}