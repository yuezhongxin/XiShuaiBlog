using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace CMSExpress.AppServices.Mvc.Easyui
{
    [Serializable]
    public partial class EasyTreeNode
    {
        public string id { get; set; }

        public string parentId { get; set; }

        public string text { get; set; }

        public string state { get; set; }

        public NameValueCollection attributes { get; set; }

        public EasyTreeNode()
        {
            this.attributes = new NameValueCollection(StringComparer.OrdinalIgnoreCase);
        }

        public EasyTreeNode(string id, string parentId, string text)
            : this()
        {
            this.id = id;
            this.parentId = parentId;
            this.text = text;
        }

        public static string Json(IList<EasyTreeNode> nodes, string rootId)
        {
            string result = OnBuildJson(nodes, rootId);
            if (result.Length > 12)
            {
                result = result.Substring(12);
            }
            return result;
        }

        private static string OnBuildJson(IList<EasyTreeNode> nodes, string rootId)
        {
            StringBuilder sb = new StringBuilder();
            List<EasyTreeNode> drs = nodes.Where(t => t.parentId == rootId).ToList<EasyTreeNode>();
            if (drs.Count < 1)
                return "";
            sb.Append(",\"children\":[");
            foreach (EasyTreeNode dr in drs)
            {
                string pcv = dr.id;
                sb.Append("{");
                sb.AppendFormat("\"id\":\"{0}\",", dr.id);
                sb.AppendFormat("\"text\":\"{0}\"", dr.text);
                if (!string.IsNullOrEmpty(dr.state))
                {
                    sb.AppendFormat(",\"state\":\"{0}\"", dr.state);
                }
                if (dr.attributes.Count > 0)
                {
                    StringBuilder attr = new StringBuilder();
                    foreach (string key in dr.attributes.AllKeys)
                    {
                        attr.AppendFormat("\"{0}\":\"{1}\",", key, dr.attributes[key]);
                    }
                    attr.Length = attr.Length - 1;
                    sb.Append(",\"attributes\":{" + attr.ToString() + "}");
                }
                if (pcv != rootId)
                {
                    sb.Append(OnBuildJson(nodes, pcv).TrimEnd(','));
                }
                sb.Append("},");
            }
            if (sb.ToString().EndsWith(","))
            {
                sb.Remove(sb.Length - 1, 1);
            }
            sb.Append("]");
            return sb.ToString();
        }

        public static string Json<T>(IEnumerable<T> data, string rootId, Func<T, EasyTreeNode> handler)
        {
            if (data == null || handler == null)
                return "{}";

            IList<EasyTreeNode> nodes = new List<EasyTreeNode>();
            // 第一行为请选择.
            nodes.Add(new EasyTreeNode() { id = "", parentId = "0", text = "请选择" });
            foreach (T item in data)
                nodes.Add(handler(item));

            return Json(nodes, rootId);
        }
    }
}
