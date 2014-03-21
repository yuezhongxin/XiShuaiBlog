using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace CMSExpress.AppServices.Mvc.Extensions
{
    public static class HtmlHelperExtension
    {
        #region util

        /// <summary>
        /// 将属性转换为字符串.
        /// </summary>
        /// <param name="attributes"></param>
        /// <returns></returns>
        internal static string ToAttributes(NameValueCollection attributes)
        {
            if (attributes == null || attributes.Count == 0)
                return null;
            StringBuilder result = new StringBuilder();
            foreach (string key in attributes.AllKeys)
            {
                result.AppendFormat(" {0}=\"{1}\"", key, attributes[key]);
            }
            return result.ToString();
        }

        internal static KeyValuePair<string, string> ToExpressionMetadata<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
        {
            ModelState state;
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression<TModel, TProperty>(expression, htmlHelper.ViewData);
            string name = ExpressionHelper.GetExpressionText(expression);
            string fullHtmlFieldName = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name);
            if (htmlHelper.ViewData.ModelState.TryGetValue(fullHtmlFieldName, out state) && (state.Errors.Count > 0))
            {
                //    tagBuilder.AddCssClass(HtmlHelper.ValidationInputCssClassName);
            }

            string attemptedValue = null;
            if ((state != null) && (state.Value != null))
                attemptedValue = state.Value.AttemptedValue;
            else if (metadata.Model != null)
                attemptedValue = metadata.Model.ToString();
            else
                attemptedValue = string.Empty;

            return new KeyValuePair<string, string>(fullHtmlFieldName, attemptedValue);
        }
        #endregion

        #region CheckBox

        public static MvcHtmlString CheckBox(this HtmlHelper<dynamic> htmlHelper, string name, bool isChecked = false, string labelText = null, object htmlAttributes = null, IDictionary<string, string> extendAttributes = null)
        {
            return CheckBox<dynamic>(htmlHelper, name, isChecked, labelText, htmlAttributes, extendAttributes);
        }

        public static MvcHtmlString CheckBox<TModel>(this HtmlHelper<TModel> htmlHelper, string name, bool isChecked = false, string labelText = null, object htmlAttributes = null, IDictionary<string, string> extendAttributes = null)
        {
            var attributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
            if (extendAttributes != null)
            {
                foreach (string attrName in extendAttributes.Keys)
                    attributes[attrName] = extendAttributes[attrName];
            }

            MvcHtmlString tagHtml = htmlHelper.CheckBox(name, isChecked, attributes);

            labelText = string.IsNullOrEmpty(labelText) ? string.Empty : string.Format("<label for=\"{0}\">{1}</label>", name, labelText);
            return new MvcHtmlString(tagHtml.ToString() + labelText);
        }

        public static MvcHtmlString CheckBoxFor<TModel>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, bool>> expression, string labelText, object htmlAttributes = null)
        {
            KeyValuePair<string, string> metadata = ToExpressionMetadata(htmlHelper, expression);

            MvcHtmlString tagHtml = htmlHelper.CheckBoxFor<TModel>(expression, htmlHelper);

            labelText = string.IsNullOrEmpty(labelText) ? string.Empty : string.Format("<label for=\"{0}\">{1}</label>", metadata.Key, labelText);
            return new MvcHtmlString(tagHtml.ToString() + labelText);
        }

        public static MvcHtmlString CheckBoxFor<TModel>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, int>> expression, int trueValue = 1, string labelText = null, object htmlAttributes = null)
        {
            KeyValuePair<string, string> metadata = ToExpressionMetadata(htmlHelper, expression);

            int value = 0;
            int.TryParse(metadata.Value, out value);

            IDictionary<string, string> extendAttributes = new Dictionary<string, string>();
            extendAttributes["checkbox-type"] = metadata.Key;
            return HtmlHelperExtension.CheckBox<TModel>(htmlHelper, metadata.Key, value == trueValue, labelText, htmlAttributes, extendAttributes);
        }

        #endregion
    }
}
