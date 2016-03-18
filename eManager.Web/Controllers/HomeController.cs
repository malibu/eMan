using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using eManager.Core;
using eManager.Web.Infrastructure;

namespace eManager.Web.Controllers
{
    public class HomeController : Controller
    {
        public IDepartmentDataSource _db = new DepartmentDb();

        public HomeController(IDepartmentDataSource db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            var allDepartments = _db.Departments;
            return View(allDepartments);
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult SayHi()
        {
            ViewBag.Message = "hi there page.";

            return View();
        }
    }
}