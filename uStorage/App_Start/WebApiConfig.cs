using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using LowercaseRoutesMVC4;

namespace uStorage
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new
                {
                    action = "Index",
                    controller = "Account",
                    id = RouteParameter.Optional
                }
            );
        }
    }
}
