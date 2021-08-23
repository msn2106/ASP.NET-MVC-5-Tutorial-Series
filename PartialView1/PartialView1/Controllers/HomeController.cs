using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PartialView1.Models;

namespace PartialView1.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            List<Employee> emp = new List<Employee>()
            {
                new Employee()
                {
                    Name = "Mayank Singh",
                    Id = 1,
                    Email = "msn2106@gmail.com",
                    Description = "This is Description 1"
                },
                new Employee()
                {
                    Name = "Manish Singh",
                    Id = 2,
                    Email = "msn2106@gmail.com",
                    Description = "This is Description 2"
                },
                new Employee()
                {
                    Name = "ABC Singh",
                    Id = 3,
                    Email = "msn2106@gmail.com",
                    Description = "This is Description 3"
                },
                new Employee()
                {
                    Name = "XYZ Singh",
                    Id = 4,
                    Email = "msn2106@gmail.com",
                    Description = "This is Description 4"
                },
            };
            return View(emp);
            //return View();
        }

        
    }
}