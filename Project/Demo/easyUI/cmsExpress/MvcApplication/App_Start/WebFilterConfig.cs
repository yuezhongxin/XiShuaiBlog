using System.Web;
using System.Web.Mvc;

namespace CMSExpress.MvcApplication
{
    public class WebFilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}