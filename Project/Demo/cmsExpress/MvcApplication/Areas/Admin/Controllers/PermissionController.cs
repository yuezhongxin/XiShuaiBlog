using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CMSExpress.Common;
using CMSExpress.Common.Models;
using CMSExpress.Common.Data;
using CMSExpress.AppServices.Models;
using CMSExpress.AppServices.Data;
using CMSExpress.AppServices.Mvc;
using CMSExpress.AppServices.Mvc.Controllers;
using CMSExpress.AppServices.Mvc.Extensions;
using CMSExpress.AppServices.Mvc.Easyui;

namespace CMSExpress.MvcApplication.Areas.Admin.Controllers
{
    public class PermissionController : WebDataController<Permission>
    {
        protected override IDbRepository<Permission> ModelRepository
        {
            get { return ServiceFactory.Get<IPermissionRepository>(); }
        }

        protected override string ControllerName
        {
            get { return this.Localize("model_permission"); }
        }


        public ActionResult TreeJson(string type, int? excludeId)
        {
            int[] excludes = excludeId.HasValue ? new int[] { excludeId.Value } : new int[0];
            var data = ServiceFactory.Get<IPermissionRepository>().GetEntities(type, excludes);

            string text = EasyTreeNode.Json(data, "0", (entity) =>
            {
                return new EasyTreeNode()
                {
                    id = entity.Id.ToString(),
                    parentId = entity.ParentId.ToString(),
                    text = entity.PermissionName,
                };
            });
            return new TextResult(text, "application/json");
        }
        #region override

        protected override bool OnBeforeEdit(Permission model, string id)
        {
            int pid;
            if (string.IsNullOrEmpty(id) || !int.TryParse(id, out pid))
            {
                model.SortOrder = model.Status = 1;
                return false;
            }

            model.Id = pid;
            return true;
        }

        protected override bool OnBeforeSave(Permission model, string id, FormCollection forms)
        {
            return true;
        }

        #endregion
    }
}
