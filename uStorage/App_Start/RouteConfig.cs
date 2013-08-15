using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using LowercaseRoutesMVC4;

namespace uStorage
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRouteLowercase(null, "connector", new
            {
                controller = "Files",
                action = "Index"
            });
            routes.MapRouteLowercase(null, "Thumbnails/{tmb}", new
            {
                controller = "Files",
                action = "Thumbs",
                tmb = UrlParameter.Optional
            });

            routes.MapRouteLowercase(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new
                {
                    controller = "Home",
                    action = "Index",
                    id = UrlParameter.Optional
                }
            );
        }
    }
}