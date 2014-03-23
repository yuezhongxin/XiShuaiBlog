using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMSExpress.AppServices.Models
{
    public partial class Permission
    {
        public string JsonIsAuthorized
        {
            get { return this.IsAuthorized ? "有" : "无"; }
        }

        public string JsonStatus
        {
            get { return this.Status == 1 ? "已启用" : "<span class='state-red'>已禁用</span>"; }
        }

        public string JsonLastUpdateDate
        {
            get { return string.Format("{0:yyyy-MM-dd HH:mm:ss}", this.LastUpdateDate); }
        }
    }
}
