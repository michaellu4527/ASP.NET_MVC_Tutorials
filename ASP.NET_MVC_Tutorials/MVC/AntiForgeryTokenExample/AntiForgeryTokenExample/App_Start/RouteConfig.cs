using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AntiForgeryTokenExample
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{account}/{amount}",
                defaults: new { controller = "Home", action = "Index", account = UrlParameter.Optional, amount = UrlParameter.Optional }
            );
        }
    }
}
