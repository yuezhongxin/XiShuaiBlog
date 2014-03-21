using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using CMSExpress.AppServices.Mvc.Extensions;

namespace CMSExpress.AppServices.Mvc.Easyui
{
    public static partial class EasyHtmlDataExtension
    {
        public static MvcHtmlString EasyToolbar(this HtmlHelper<dynamic> htmlHelper, string commands)
        {
            StringBuilder result = new StringBuilder();

            return new MvcHtmlString(result.ToString());
        }

        public static MvcHtmlString CheckBoxForStatus<TModel>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, int>> expression, string labelText = null, object htmlAttributes = null)
        {
            // Status: -1:逻辑删除, 0:禁用, 1:启用.
            return HtmlHelperExtension.CheckBoxFor<TModel>(htmlHelper, expression, 1, labelText, htmlAttributes);
        }

        public static MvcHtmlString DropDownListForEnum<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, string enumType, object htmlAttributes = null)
        {
            IList<SelectListItem> data = new List<SelectListItem>();
            data.Insert(0, new SelectListItem() { Text = "", Value = "" });
            return htmlHelper.DropDownListFor(expression, data, htmlAttributes);
        }
    }
}
