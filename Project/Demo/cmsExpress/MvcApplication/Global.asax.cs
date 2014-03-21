using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using CMSExpress.AppServices.Mvc.Extensions;

namespace CMSExpress.MvcApplication
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class GlobalMvcApplication : CMSExpress.AppServices.Mvc.HttpApplicationBase
    {
        protected override void Application_Start()
        {
            base.Application_Start();

            LocalizationExtension.Configure(typeof(App_Start.AppLocale));

            AreaRegistration.RegisterAllAreas();

            WebFilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            WebRouteConfig.RegisterRoutes(RouteTable.Routes);
            WebBundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}