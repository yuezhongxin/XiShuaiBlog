using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XQH.EasyUi.Entity
{
    /// <summary>
    /// 权限实体
    /// </summary>
    public class PermissionEntity
    {
        /// <summary>
        /// 权限ID
        /// </summary>
        public string PermissionId { get; set; }

        /// <summary>
        /// 权限模块
        /// </summary>
        public string OperationModule { get; set; }

        /// <summary>
        /// 权限名称
        /// </summary>
        public string OperationName { get; set; }

        /// <summary>
        /// 是否开启
        /// </summary>
        public bool OperationOn { get; set; }

        public PermissionEntity(string permissionId,string operationModule,string operationName,bool operationOn)
        {
            this.PermissionId = permissionId;
            this.OperationModule = operationModule;
            this.OperationName = operationName;
            this.OperationOn = operationOn;
        }
    }
}
