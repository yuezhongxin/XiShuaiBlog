using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace CMSExpress.MvcApplication
{
    public class WebRouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            // 不同Area存在同名 Controller，引入默认的命名空间

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Centre", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Admin",
                url: "admin/{controller}/{action}/{id}",
                defaults: new { controller = "Permission", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}