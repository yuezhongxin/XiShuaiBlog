using System;
using System.Collections.Generic;
using System.Text;
using CMSExpress.Common.Data;
using CMSExpress.AppServices.Models;

namespace CMSExpress.AppServices.Data
{
    public interface IPermissionRepository : IDbRepository<Permission>
    {
        /// <summary>
        /// 获取某类型列表, 排除指定的id以及以下权限.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="excludes"></param>
        /// <returns></returns>
        IList<Permission> GetEntities(string type, params int[] excludes);

        /// <summary>
        /// 生成权限编号(xxx三位数字一组).
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        string GetPermissionCode(int parentId);
    }
}
