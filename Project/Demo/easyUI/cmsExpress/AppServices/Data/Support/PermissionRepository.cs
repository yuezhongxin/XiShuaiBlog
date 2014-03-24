using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CMSExpress.Common.Data;
using CMSExpress.AppServices.Models;

namespace CMSExpress.AppServices.Data.Support
{
    public partial class PermissionRepository : DbRepository<Permission>, IPermissionRepository
    {
        public override IList<Permission> GetEntities(Permission entity)
        {
            var result = entity.Select("SortOrder, PermissionName");
            return result == null ? null : result.ToList();
        }

        public IList<Permission> GetEntities(string type, params int[] excludes)
        {
            var data = this.GetEntities(new Permission() { Type = type });
            if (excludes != null && excludes.Length > 0)
            {
                foreach (int id in excludes)
                {
                    var item = data.FirstOrDefault(i => i.Id == id);
                    if (item != null)
                        data.Remove(item);
                }
            }
            return data;
        }

        public string GetPermissionCode(int parentId)
        {
            string sql = string.Format("select isnull(max(Code), 0) from app_Permissions where isnull(ParentId,'')='{0}'", parentId);
            int value = DataBase.Current.ExecuteScalar<int>(sql);
            string parentValue = (parentId == 0 ? string.Empty : string.Format("{0:00000}", parentId));
            return string.Format("{0}{1:00000}", (value == 0) ? parentValue : string.Empty, value + 1);
        }
    }
}
