using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Resources;
using System.Text;
using System.Web.Mvc;
using System.Web.Routing;

namespace CMSExpress.AppServices.Mvc.Extensions
{
    public static class LocalizationExtension
    {
        private static Type _resourceType = null;
        private static ResourceManager _rm = null;

        public static void Configure(Type resourceType)
        {
            _resourceType = resourceType;
        }

        internal static ResourceManager ResourceManager
        {
            get
            {
                if (_rm == null)
                {
                    _rm = new ResourceManager(_resourceType);
                    _rm.IgnoreCase = true;
                }
                return _rm;
            }
        }

        public static MvcHtmlString LocalizeLabel<dynamic, TValue>(this HtmlHelper<dynamic> html, Expression<Func<dynamic, TValue>> expression)
        {
            return LocalizeLabel(html, expression, null);
        }

        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "This is an appropriate nesting of generic types")]
        public static MvcHtmlString LocalizeLabel<dynamic, TValue>(this HtmlHelper<dynamic> html, Expression<Func<dynamic, TValue>> expression, object htmlAttributes)
        {
            if (html == null || expression == null)
                return MvcHtmlString.Empty;

            string name = ExpressionHelper.GetExpressionText((LambdaExpression)expression);
            string labelText = Localize(name);
            if (string.IsNullOrEmpty(labelText))
                labelText = name;
            Type propertyType = expression.ReturnType;
            TagBuilder tagBuilder = new TagBuilder("label");
            tagBuilder.Attributes.Add("for", name);
            tagBuilder.SetInnerText(labelText);
            if (htmlAttributes != null)
            {
                var attributes = new RouteValueDictionary(htmlAttributes);
                tagBuilder.MergeAttributes(attributes);
            }
            return new MvcHtmlString(tagBuilder.ToString());
        }

        public static MvcHtmlString Localize<dynamic, TValue>(this HtmlHelper<dynamic> html, Expression<Func<dynamic, TValue>> expression, params object[] args)
        {
            if (expression == null)
                return MvcHtmlString.Empty;
            string name = ExpressionHelper.GetExpressionText((LambdaExpression)expression);
            name = Localize(name, args);
            return new MvcHtmlString(name);
        }

        /// <summary>
        /// 本地化.
        /// </summary>
        /// <param name="html"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string Localize(this HtmlHelper<dynamic> html, string name, params object[] args)
        {
            return Localize(name, args);
        }

        public static string Localize(this System.Web.Mvc.Controller source, string name, params object[] args)
        {
            return Localize(name, args);
        }

        public static string Localize(string name, params object[] args)
        {
            if (ResourceManager == null)
                return name;
            string text = ResourceManager.GetString(name);
            return text == null ? string.Empty : string.Format(text, args);
        }
    }
}
