using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using XQH.EasyUi.Database;
using XQH.EasyUi.Database.EasyUiDataSetTableAdapters;
using XQH.EasyUi.Entity;

namespace XQH.EasyUi.Access
{
    /// <summary>
    /// 角色-权限操作
    /// </summary>
    public class RolePermissionAccess
    {
        RolePermissionTableAdapter adp = new RolePermissionTableAdapter();
        private static RolePermissionAccess accessInstance = null;

        public static RolePermissionAccess GetInstance()
        {
            if (accessInstance == null)
            {
                accessInstance = new RolePermissionAccess();
            }

            return accessInstance;
        }

        public string IsPermissionOn(int roleId,string permissionId)
        {
            return adp.IsPermissionOn(roleId, permissionId);       
        }

        /// <summary>
        /// 添加权限
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="permissionId"></param>
        /// <returns></returns>
        public int AddPermission(int roleId,string permissionId)
        {
            return adp.AddPermission(roleId, permissionId);
        }

        /// <summary>
        /// 删除权限
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="permissionId"></param>
        /// <returns></returns>
        public int DeletePermission(int roleId,string permissionId)
        {
            return adp.DeletePermission(roleId, permissionId);
        }
    }
}
