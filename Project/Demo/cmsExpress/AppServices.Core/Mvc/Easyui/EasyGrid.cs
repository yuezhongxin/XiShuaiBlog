using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Web.Mvc;

namespace CMSExpress.AppServices.Mvc.Easyui
{
    public partial class EasyGrid
    {
        private string _name;
        private string _url;
        private string _idField;
        private bool _pagination;

        private IList<TagBuilder> _columns;

        public string Name
        {
            get { return this._name; }
            set
            {
                this._name = value;
                this.Attribute("id", value);
                this.Attribute("name", value);
            }
        }

        public string IdField
        {
            get { return this._idField; }
            set
            {
                this._idField = value;
                if (!string.IsNullOrEmpty(value))
                {
                    this.Attribute("idField", value);
                }
            }
        }

        public string Url
        {
            get { return this._url; }
            set
            {
                this._url = value;
                this.Attribute("url", value);
            }
        }

        public IDictionary<string, object> Attributes { get; set; }

        public EasyGrid()
        {
            this.Attributes = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
            this._columns = new List<TagBuilder>();
            this.Attributes["class"] = "dynamicGrid easyui-datagrid";
            this.Attributes["rownumbers"] = "true";
            this.Attributes["fit"] = "true";
            this.Attributes["striped"] = "true";
        }

        public EasyGrid(string name, string idField = null, string url = null)
            : this()
        {
            this.Name = name;
            this.Url = url;
            this.IdField = idField;
        }

        public EasyGrid Pagination(bool pagination, int pageSize = 20)
        {
            if (pagination)
            {
                this.Attributes["pagination"] = "true";
                this.Attributes["pageSize"] = pageSize;
            }
            return this;
        }

        public EasyGrid Attribute(string name, object value)
        {
            if (value == null)
            {
                if (this.Attributes.ContainsKey(name))
                    this.Attributes.Remove(name);
                return this;
            }
            if (name.Equals("style"))
                this.Style(value.ToString());
            else if (name.Equals("class"))
                this.AddClass(value.ToString());
            else
                this.Attributes[name] = value;
            return this;
        }

        public EasyGrid Style(string style)
        {
            if (!string.IsNullOrEmpty(style))
            {
                string data = ((string)this.Attributes["style"]) ?? string.Empty;
                if (data.Length > 0 && !data.EndsWith(";"))
                    data = data + ";";
                this.Attributes["style"] = data + style;
            }
            return this;
        }

        public EasyGrid AddClass(string className)
        {
            if (!string.IsNullOrEmpty(className))
            {
                string data = ((string)this.Attributes["class"]) ?? string.Empty;
                if (data.Length > 0 && !data.EndsWith(" "))
                    data = data + " ";
                this.Attributes["class"] = data + className;
            }
            return this;
        }

        public EasyGrid Column(string name, string text, object htmlAttributes = null)
        {
            TagBuilder tagBuilder = new TagBuilder("th");
            var attributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
            attributes["field"] = name;
            tagBuilder.MergeAttributes(attributes);
            tagBuilder.InnerHtml = text;
            
            this._columns.Add(tagBuilder);
            return this;
        }

        public MvcHtmlString Table(Action<EasyGrid> handler)
        {
            if (handler != null)
                handler(this);
            return this.ToMvcHtmlString();
        }

        public override string ToString()
        {
            TagBuilder tagBuilder = new TagBuilder("table");
            tagBuilder.MergeAttributes<string, object>(this.Attributes);
            
            StringBuilder result = new StringBuilder();
            result.AppendLine("<thead>");
            foreach (TagBuilder head in this._columns)
                result.AppendLine(head.ToString());
            result.AppendLine("</thead>");

            tagBuilder.InnerHtml = result.ToString();

            return tagBuilder.ToString();
        }

        public MvcHtmlString ToMvcHtmlString()
        {
            return new MvcHtmlString(this.ToString());
        }
    }
}
