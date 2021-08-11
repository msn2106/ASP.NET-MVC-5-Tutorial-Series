using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Filter2HandleError.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        // GET: Home
        
        //[HandleError]
        public ActionResult Index()
        {
            //try
            //{
            //    throw new Exception("This is an exception.");
            //}
            //catch (Exception)
            //{
            //    return RedirectToAction("Index", "Error");
            //}

            throw new Exception("This is an exception.");
        }

        public ActionResult About()
        {
            throw new Exception("This is an exception.");
        }
    }
}