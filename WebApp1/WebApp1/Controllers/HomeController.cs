using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Model;
using WebAppDB.DBOperations;

namespace WebApp1.Controllers
{
    public class HomeController : Controller
    {
        EmployeeRepository repository = null;
        public HomeController()
        {
            repository = new EmployeeRepository();

        }

        // GET: Home
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(EmployeModel model)
        {
            if (ModelState.IsValid)
            {
                int id = repository.AddEmployee(model);
                if(id > 0)
                {
                    ModelState.Clear();
                    ViewBag.IsSuccess = "Data Added Successfully";
                }
            }
            return View();
        }

        public ActionResult GetAllRecords()
        {
            var result = repository.GetAllEmployees();
            return View(result);
        }

        public ActionResult Details(int id)
        {
            var employee = repository.GetEmployee(id);
            return View(employee);
        }

        [HttpGet]
        public ActionResult Edit(int id) 
        {
            var employee = repository.GetEmployee(id);
            return View(employee);
        }

        [HttpPost]
        public ActionResult Edit(EmployeModel model)
        {
            bool Success = false;

            if (ModelState.IsValid)
            {
                Success = repository.UpdateEmployee(model.ID, model);
                return RedirectToAction("GetAllRecords");
            }

            if (Success) return View();
            else return View("Error"); // if update unsuccessful
        }

        public ActionResult Delete(int id)
        {
            repository.DeleteEmployee(id);
            return RedirectToAction("GetAllRecords");
        }
    }
}