using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CustomRoutesExample
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            // I'm counting on the CategoriesByOrdinal route to handle the /Categories/Widgets case ...
            // This one should only handle the /Categories/Widgets/Detail-2

            // This allows multiple products to share the same ID as long as they are of a different category
            routes.MapRoute(
                name: "CategoriesById",
                url: "Categories/{category}/Detail-{id}",
                defaults: new { controller = "Categories", action = "Details", category = UrlParameter.Optional, id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "CategoriesByOrdinal",
                url: "Categories/{category}/{ordinal}",
                defaults: new { controller = "Categories", action = "Index", category = UrlParameter.Optional, ordinal = UrlParameter.Optional }
            );

            routes.MapRoute("blog", "{year}/{month}/{day}",
                new { controller = "blog", action = "index" },
                new { year = @"\d{4}", month = @"\d{2}", day = @"\d{2}" });

            // Default route that is only defined in this RouteConfig file
            routes.MapRoute(
                name: "Default",
                url: "{controller}-{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                constraints: new { id = @"\d+" }
            );

        }
    }
}
