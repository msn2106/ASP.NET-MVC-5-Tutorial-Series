using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Filter1OutputCache.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [OutputCache(Duration = 30, Location = System.Web.UI.OutputCacheLocation.Client)]
        public ActionResult GetDate()
        {
            return View();
        }
    }
}
// We cache data on server when we want to display the same data to every client.
// Default is Any
// Client is used when data is client specific, like their name
// this improves performance very much