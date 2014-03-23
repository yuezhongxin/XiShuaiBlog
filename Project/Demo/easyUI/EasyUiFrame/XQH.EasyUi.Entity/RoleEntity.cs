using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XQH.EasyUi.Entity
{
    /// <summary>
    /// 角色实体
    /// </summary>
    public class RoleEntity
    {
        /// <summary>
        /// 角色ID
        /// </summary>
        public int RoleId { get; set; }

        /// <summary>
        /// 角色名称
        /// </summary>
        public string RoleName { get; set; }

        /// <summary>
        /// 角色描述
        /// </summary>
        public string RoleDes { get; set; }

        public RoleEntity(int roleId,string roleName,string roleDes)
        {
            this.RoleId = roleId;
            this.RoleName = roleName;
            this.RoleDes = roleDes;
        }
    }
}
