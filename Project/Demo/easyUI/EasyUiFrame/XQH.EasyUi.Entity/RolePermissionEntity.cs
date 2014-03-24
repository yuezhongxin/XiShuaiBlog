using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XQH.EasyUi.Entity
{
    /// <summary>
    /// 角色-权限实体
    /// </summary>
    public class RolePermissionEntity
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 角色ID
        /// </summary>
        public int RoleId { get; set; }

        /// <summary>
        /// 权限ID
        /// </summary>
        public string PermissionId { get; set; }

        public RolePermissionEntity(int id,int roleId,string permissionId)
        {
            this.Id = id;
            this.RoleId = roleId;
            this.PermissionId = permissionId;
        }
    }
}
