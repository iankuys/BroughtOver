using MVCApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;
using DataLibrary.BusinessLogic;
 

namespace MVCApp.Controllers
{
    public class UserAccountController : Controller
    {
        public ActionResult loginGet()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult loginGet(LoginModel login)
        {
            if (ModelState.IsValid)
            {
                var data = EmployeeProcessor.SelectEmployees(login.EmailAddress, login.Password);
                foreach (var row in data)
                {
                    if (row.Password.Equals(login.Password))
                    {
                        FormsAuthentication.SetAuthCookie(login.EmailAddress, true);
                        return RedirectToAction("Index", "Home");
                    }

                }
            }
               
            return View();

        }
    }
}
