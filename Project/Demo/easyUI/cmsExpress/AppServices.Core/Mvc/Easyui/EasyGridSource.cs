using System;
using System.Collections.Generic;
using System.Text;

namespace CMSExpress.AppServices.Mvc.Easyui
{
    [Serializable]
    public partial class EasyGridSource<T>
    {
        public int pageNumber { get; set; }

        public string message { get; set; }

        public int total { get; set; }

        public IList<T> rows { get; set; }

        public EasyGridSource()
        {
            this.pageNumber = 1;
            this.rows = new List<T>();
        }

        public EasyGridSource(int total)
            : this()
        {
            this.total = total;
        }

        public EasyGridSource(int total, IList<T> rows)
            : this(total)
        {
            this.rows = rows;
        }
    }
}
