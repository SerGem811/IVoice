using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace IVoice
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.LowercaseUrls = true;
            routes.MapMvcAttributeRoutes(); //This line enables attribute routing 

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}/{secondid}/{thirdid}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional, secondid = UrlParameter.Optional, thirdid = UrlParameter.Optional }
            );
        }
    }
}
