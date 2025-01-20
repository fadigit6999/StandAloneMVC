using MVCStudentsPortal.Data;
using MVCStudentsPortal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCStudentsPortal.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataContextDB dB = new DataContextDB();

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

        #region Employee Management Action Methods

        [HttpGet]
        public ActionResult GetEmployee()
        {
            var list = dB.GetEmployees().ToList();
            return View(list);
        }

        [HttpGet]
        public ActionResult CreateEmployee()
        {
            return View(new Employees());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateEmployee(Employees model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Example: Saving the employee to the database
                    dB.AddEmployee(model.Name,model.Phone,model.Address,model.Salary);

                    return Redirect("/Home/GetEmployee/1"); // Redirect to the Index or Employee List page
                }
                catch (Exception ex)
                {
                    // Log the exception and show an error message
                    ModelState.AddModelError("", $"An error occurred while saving the employee: {ex.Message}");
                }
            }

            // If we got this far, something failed; redisplay the form
            return View(model);
        }

        [HttpGet]
        public ActionResult UpdateEmployee(int id)
        {
            var employee = dB.GetEmployees().Where(x=>x.Id == id).FirstOrDefault();
            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateEmployee(Employees model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Example: Saving the employee to the database
                    dB.Update(model.Id,model.Name, model.Phone, model.Address, model.Salary);

                    return Redirect("/Home/GetEmployee/2");
                }
                catch (Exception ex)
                {
                    // Log the exception and show an error message
                    ModelState.AddModelError("", $"An error occurred while saving the employee: {ex.Message}");
                }
            }

            // If we got this far, something failed; redisplay the form
            return View(model);
        }

        [HttpGet]
        public ActionResult DeleteEmployee(int id)
        {
            var employee = dB.GetEmployees().Where(x => x.Id == id).FirstOrDefault();
            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteEmployee(Employees model)
        {
            try
            {
                // Example: Saving the employee to the database
                dB.Delete(model.Id);

                return Redirect("/Home/GetEmployee/3");
            }
            catch (Exception ex)
            {
                // Log the exception and show an error message
                ModelState.AddModelError("", $"An error occurred while saving the employee: {ex.Message}");
            }

            // If we got this far, something failed; redisplay the form
            return View(model);
        }

        #endregion

        #region Partial Views
        [HttpGet]
        public ActionResult Style(string view)
        {
            return PartialView("~/Views/Shared/_Style.cshtml", view);
        }

        [HttpGet]
        public ActionResult Script(string view)
        {
            return PartialView("~/Views/Shared/_Script.cshtml", view);
        }
        #endregion
    }
}