using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace CMSExpress.AppServices.Mvc.Easyui
{
    public static partial class EasyHtmlExtension
    {
        #region ui

        public static MvcHtmlString EasyShowMessage<T>(this HtmlHelper<T> html)
        {
            string message = (string)html.ViewData["Message_Content"];
            if (string.IsNullOrEmpty(message))
                return new MvcHtmlString(string.Empty);
            int autoClose = html.ViewData["Message_AutoClose"] == null || true.Equals(html.ViewData["Message_AutoClose"]) ? 1 : 0;
            return new MvcHtmlString(string.Format("<input type='hidden' id='action_message' value='{0}' autoclose='{1}' />", message, autoClose));
        }

        public static MvcHtmlString EasyShowMessage(this HtmlHelper<dynamic> html)
        {
            return EasyShowMessage<dynamic>(html);
        }

        public static MvcHtmlString EasyToolbar<T>(this HtmlHelper<T> htmlHelper, string toolbarItems)
        {
            StringBuilder reuslt = new StringBuilder();
            return new MvcHtmlString(toolbarItems);
        }
        public static MvcHtmlString EasyToolbar(this HtmlHelper<dynamic> htmlHelper, string toolbarItems)
        {
            return EasyToolbar<dynamic>(htmlHelper, toolbarItems);
        }
        #endregion

        #region control

        public static MvcHtmlString EasyCombox<TModel>(this HtmlHelper<TModel> html, string name, string value = null, string url = null, object htmlAttributes = null)
        {
            TagBuilder tagBuilder = new TagBuilder("select");

            var attributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
            attributes["id"] = name;
            attributes["name"] = name;
            attributes["method"] = "get";
            attributes["cascadecheck"] = "false";
            attributes["style"] = string.Format("width:{0};margin-left:3px;", attributes["width"] == null ? "161px" : attributes["width"]);
            attributes.Remove("width");
            attributes["selectedValue"] = value;
            if (url != null)
            {
                if (url.IndexOf("?") > -1)
                {
                    url = url + (url.EndsWith("?") ? string.Empty : "&") + (new Random()).NextDouble().ToString();
                }
                attributes["url"] = url;
            }
            tagBuilder.MergeAttributes(attributes);

            tagBuilder.AddCssClass("easyui-combotree");

            return new MvcHtmlString(tagBuilder.ToString());
        }

        public static MvcHtmlString EasyCombox(this HtmlHelper<dynamic> html, string name, string value = null, string url = null, object htmlAttributes = null)
        {
            return EasyCombox<dynamic>(html, name, value, url, htmlAttributes);
        }

        public static MvcHtmlString EasyComboxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, string url = null, object htmlAttributes = null)
        {
            KeyValuePair<string, string> metadata = Extensions.HtmlHelperExtension.ToExpressionMetadata(htmlHelper, expression);

            return EasyCombox(htmlHelper, metadata.Key, metadata.Value, url, htmlAttributes);
        }

        public static MvcHtmlString EasyDateTimeBox<TModel>(this HtmlHelper<TModel> html, string name, string value = null, bool showTimeBox = false, object htmlAttributes = null)
        {
            TagBuilder tagBuilder = new TagBuilder("input");

            var attributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
            attributes["id"] = name;
            attributes["value"] = value;
            attributes["style"] = "width:173px;margin-left:3px;";
            tagBuilder.MergeAttributes(attributes);
            tagBuilder.AddCssClass(showTimeBox ? "easyui-datetimebox" : "easyui-datebox");

            return new MvcHtmlString(tagBuilder.ToString());
        }
        public static MvcHtmlString EasyDateTimeBox(this HtmlHelper<dynamic> html, string name, string value = null, bool showTimeBox = false, object htmlAttributes = null)
        {
            return EasyDateTimeBox<dynamic>(html, name, value, showTimeBox, htmlAttributes);
        }

        #endregion

        #region datagrid

        public static EasyGrid EasyDataGrid(this HtmlHelper<dynamic> htmlHelper, string name, string idField = "Id", string url = null)
        {
            return EasyDataGrid<dynamic>(htmlHelper, name, idField, url);
        }

        public static EasyGrid EasyDataGrid<TModel>(this HtmlHelper<TModel> htmlHelper, string name, string idField = "Id", string url = null)
        {
            return new EasyGrid(name, idField, url);
        }

        #endregion
    }
}
