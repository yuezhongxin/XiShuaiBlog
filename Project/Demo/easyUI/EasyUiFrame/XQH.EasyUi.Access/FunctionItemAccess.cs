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
    /// 功能选择操作
    /// </summary>
    public class FunctionItemAccess
    {
        FunctionItemTableAdapter functionItemAdp = new FunctionItemTableAdapter();
        private static FunctionItemAccess accessInstance = null;

        public static FunctionItemAccess GetInstance()
        {
            if (accessInstance == null)
            {
                accessInstance = new FunctionItemAccess();
            }

            return accessInstance;
        }

        /// <summary>
        /// 根据父ID获取其下所有功能模块信息
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        public List<FunctionItemEntity> GetFunctionItemByPid(string pid)
        {
            List<FunctionItemEntity> ls = new List<FunctionItemEntity>();

            try
            {
                EasyUiDataSet.FunctionItemDataTable dt = functionItemAdp.GetFunctionNameByPid(pid);

                foreach (EasyUiDataSet.FunctionItemRow dr in dt.Rows)
                {
                    FunctionItemEntity entity = new FunctionItemEntity(
                        dr.Id, 
                        dr.FunctionName, 
                        dr.ParentId,
                        dr.Url);
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
        /// 获取同一类模块的父类名称
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<FunctionItemEntity> GetFunctionNameById(string id)
        {
            List<FunctionItemEntity> ls = new List<FunctionItemEntity>();

            try
            {
                EasyUiDataSet.FunctionItemDataTable dt = functionItemAdp.GetFunctionNameById(id);

                foreach (EasyUiDataSet.FunctionItemRow dr in dt.Rows)
                {
                    FunctionItemEntity entity = new FunctionItemEntity(
                        dr.Id,
                        dr.FunctionName,
                        dr.ParentId,
                        dr.Url);
                    ls.Add(entity);
                }

                return ls;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 获取操作权限
        /// </summary>
        /// <param name="pid"></param>
        /// <param name="roleId"></param>
        /// <param name="onoff"></param>
        /// <returns></returns>
        public List<FunctionItemEntity> GetOperationPermission(string pid,int roleId)
        {
            List<FunctionItemEntity> ls = new List<FunctionItemEntity>();

            try
            {
                EasyUiDataSet.FunctionItemDataTable dt = functionItemAdp.GetOperationPermission(roleId, pid);

                foreach (EasyUiDataSet.FunctionItemRow dr in dt.Rows)
                {
                    FunctionItemEntity entity = new FunctionItemEntity(
                        dr.Id,
                        dr.FunctionName,
                        dr.ParentId,
                        dr.Url);
                    ls.Add(entity);
                }

                return ls;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
