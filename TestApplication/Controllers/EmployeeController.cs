using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestApplication.Models;
using TestApplication.Services;
using TestApplication.ViewModels;

namespace TestApplication.Controllers
{
    public class EmployeeController : Controller
    {      
        db _db = new db();
        public ActionResult Index()
        {
            var data = new EmployeeViewModel();
            data._emplist = _db.GetAllEmployees();
            return View(data);
        }
        public ActionResult AddEmployee()
        {
            return View();

        }
        [HttpPost]
        public ActionResult AddEmployee(Employee model)
        {
            var check = _db.Add_Employee(model);
            if (check) return RedirectToAction("Index", "Employee");
            else
            {
                ViewBag.error = "Something went wrong";
                return View();
            }

        }
        public ActionResult EditEmployee(int Id)
        {
            var data = _db.GetEmployeeById(Id);
            data.Joining_Date = data.Joining_Date.Date;
            return View(data);
        }
        [HttpPost]
        public ActionResult EditEmployee(Employee _model)
        {
            var data = _db.Update_Employee(_model);
            return RedirectToAction("Index", "Employee");
        }
        public ActionResult DeleteEmployee(int Id)
        {
            var data = _db.Delete_Employee(Id);
            return RedirectToAction("Index", "Employee");
        }
    }
}