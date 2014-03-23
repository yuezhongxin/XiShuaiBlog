using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace CMSExpress.AppServices.Mvc.Extensions
{
    public static class HtmlApplicationExtension
    {
        public const int DEFAULT_PAGE_SIZE = 20;
        internal static string _ApplicationName = "CMS Express";

        public static string ApplicationName(this HtmlHelper<dynamic> htmlHelper)
        {
            return _ApplicationName;
        }

        public static MvcHtmlString Copyright(this HtmlHelper<dynamic> htmlHelper)
        {
            string value = "Copyright &copy; All Rights Reserved 2012 (CMSExpress contact: <a href=\"mailto:tangfrank@foxmail.com\">tangfrank@foxmail.com</a>)";
            return new MvcHtmlString(value);
        }

        public static int DefaultPageSize(this HtmlHelper<dynamic> htmlHelper)
        {
            return DEFAULT_PAGE_SIZE;
        }
    }
}
