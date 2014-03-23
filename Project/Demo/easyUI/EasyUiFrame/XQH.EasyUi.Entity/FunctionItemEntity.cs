using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XQH.EasyUi.Entity
{
    /// <summary>
    /// 功能选项实体
    /// </summary>
    public class FunctionItemEntity
    {
        /// <summary>
        /// 编号
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 功能名称
        /// </summary>
        public string FunctionName { get; set; }

        /// <summary>
        /// 父ID
        /// </summary>
        public string ParentId { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public string Url { get; set; }

        public FunctionItemEntity(string id,string functionName,string parentId,string url)
        {
            this.Id = id;
            this.FunctionName = functionName;
            this.ParentId = parentId;
            this.Url = url;
        }
    }
}
