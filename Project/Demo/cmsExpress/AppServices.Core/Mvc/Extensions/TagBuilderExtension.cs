using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace CMSExpress.AppServices.Mvc.Extensions
{
    public static class TagBuilderExtension
    {
        public static TagBuilder Attribute(this TagBuilder source, string name, object value)
        {
            if (source == null || string.IsNullOrEmpty(name))
                return source;
            source.Attributes[name] = (value == null ? string.Empty : value.ToString());
            return source;
        }

        public static TagBuilder MergeAttributes(this TagBuilder source, object attributes)
        {
            if (source == null)
                return source;
            var dict = HtmlHelper.AnonymousObjectToHtmlAttributes(attributes);
            source.MergeAttributes(dict);
            return source;
        }

        public static TagBuilder Style(this TagBuilder source, string value)
        {
            if (source == null || string.IsNullOrEmpty(value))
                return source;
            if (!value.EndsWith(";"))
                value = value + ";";
            string data = source.Attributes.ContainsKey("style") ? source.Attributes["style"] : string.Empty;
            if (data == null)
                data = string.Empty;
            data = data + value;
            return source.Attribute("style", data);
        }

        public static TagBuilder Value(this TagBuilder source, object value)
        {
            string data = value == null || value == DBNull.Value ? string.Empty : value.ToString();
            if (source.TagName == "textarea")
            {
                source.SetInnerText(data);
                return source;
            }
            return source.Attribute("value", value);
        }

        public static MvcHtmlString ToMvcHtmlString(this TagBuilder source)
        {
            if (source == null)
                return MvcHtmlString.Empty;
            return new MvcHtmlString(source.ToString());
        }
    }
}
