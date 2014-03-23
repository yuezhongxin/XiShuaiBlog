using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using XQH.EasyUi.Entity;
using XQH.EasyUi.Database;
using XQH.EasyUi.Database.EasyUiDataSetTableAdapters;

namespace XQH.EasyUi.Access
{
    /// <summary>
    /// 角色操作
    /// </summary>
    public class RoleAccess
    {
        RoleTableAdapter roleAdp = new RoleTableAdapter();
        private static RoleAccess accessInstance = null;

        public static RoleAccess GetInstance()
        {
            if (accessInstance == null)
            {
                accessInstance = new RoleAccess();
            }

            return accessInstance;
        }

        /// <summary>
        /// 获取角色信息
        /// </summary>
        /// <returns></returns>
        public List<RoleEntity> GetRoleInfo()
        {
            List<RoleEntity> ls = new List<RoleEntity>();

            try
            {
                EasyUiDataSet.RoleDataTable dt = roleAdp.GetRoleInfo();

                foreach (EasyUiDataSet.RoleRow dr in dt.Rows)
                {
                    RoleEntity entity = new RoleEntity(
                        dr.RoleId,
                        dr.RoleName,
                        dr.RoleDes
                        );
                    ls.Add(entity);
                }

                return ls;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 根据用户名获取角色ID
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public int? GetRoleIdByUsername(string username)
        {
            try
            {
                int? roleId = roleAdp.GetRoleIdByUsername(username);
                return roleId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
