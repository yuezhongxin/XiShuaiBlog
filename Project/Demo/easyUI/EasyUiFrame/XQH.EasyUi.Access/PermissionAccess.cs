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
    /// 权限操作
    /// </summary>
    public class PermissionAccess
    {
        PermissionTableAdapter adp = new PermissionTableAdapter();
        private static PermissionAccess accessInstance = null;

        public static PermissionAccess GetInstance()
        {
            if (accessInstance == null)
            {
                accessInstance = new PermissionAccess();
            }

            return accessInstance;
        }

        /// <summary>
        /// 获取所有父权限
        /// </summary>
        /// <returns></returns>
        public List<string> GetParentPermission()
        {
            List<string> ls = new List<string>();

            try
            {
                EasyUiDataSet.PermissionDataTable dt = adp.GetParentPermission();

                foreach (EasyUiDataSet.PermissionRow dr in dt.Rows)
                {
                    if (!ls.Contains(dr.OperationModule))
                    {
                        ls.Add(dr.OperationModule);
                    }
                }

                return ls;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 获取某个父类下面的所有权限
        /// </summary>
        /// <param name="pName"></param>
        /// <returns></returns>
        public List<PermissionEntity> GetChildPermission(string pName)
        {
            List<PermissionEntity> ls = new List<PermissionEntity>();

            try
            {
                EasyUiDataSet.PermissionDataTable dt = adp.GetChildPermission(pName);

                foreach (EasyUiDataSet.PermissionRow dr in dt.Rows)
                {
                    PermissionEntity entity = new PermissionEntity(
                        dr.PermissionId,
                        dr.OperationModule,
                        dr.OperationName,
                        dr.OperationOn);
                    ls.Add(entity);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ls;
        }
    }
}
