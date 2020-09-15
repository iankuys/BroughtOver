using MVCApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLibrary;
using static DataLibrary.BusinessLogic.EmployeeProcessor;
using DataLibrary.DataAccess;

namespace MVCApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
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

        public ActionResult ViewEmployee()
        {
            var data = LoadEmployees();
            List<EmployeeModel> employees = new List<EmployeeModel>();

            foreach (var row in data)
            {
                employees.Add(new EmployeeModel{
                    EmployeeId = row.EmployeeId,
                    FirstName = row.FirstName,
                    LastName = row.LastName,
                    EmailAddress = row.EmailAddress,
                    ConfirmEmail = row.EmailAddress,
                });
            }
            return View(employees);
        }

        public ActionResult SignUp()
        {
            ViewBag.Message = "Employee Sign Up";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(EmployeeModel model)
        {

            if(ModelState.IsValid)
            {
                int recordCreated = CreateEmployee(model.EmployeeId,
                    model.FirstName,
                    model.LastName,
                    model.EmailAddress,
                    model.Password);
                return RedirectToAction("Index");
            }
            ViewBag.Message = "Employee Sign Up";

            return View();
        }

        public string hoe()
        {
            return "your mom a hoe";
        }
    }
}