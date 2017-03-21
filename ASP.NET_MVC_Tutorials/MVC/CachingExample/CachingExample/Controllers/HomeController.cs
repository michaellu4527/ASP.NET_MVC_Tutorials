using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CachingExample.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home

        // * means vary by every parameter
        // NoStore means the server should NOT store a permanent copy of the cached content. This means that the content will have to be re-exectuted each time it is requested as the cache isn't allowed to store it.
        [OutputCache(Duration = 10, VaryByParam="*", Location=System.Web.UI.OutputCacheLocation.Any, NoStore=true)]
        public ActionResult Index()
        {
            ViewBag.CurrentExecutedDateTime = DateTime.Now.ToString("hh:mm:ss.fff");
            return View();
        }

        [OutputCache(Duration = 10)]    // Will wait 10 seconds before running the code again (uses cached in downtime)
        public ActionResult DonutHoleCache()
        {
          ViewBag.LastExecutedDateTime = DateTime.Now.ToString("hh:mm:ss.fff");
          return PartialView("_DonutHole");
        }
    }
}