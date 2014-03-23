using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CMSExpress.Common;
using CMSExpress.Common.Models;
using CMSExpress.Common.Data;
using CMSExpress.AppServices.Mvc.Extensions;
using CMSExpress.AppServices.Mvc.Easyui;

namespace CMSExpress.AppServices.Mvc.Controllers
{
    [HandleError]
    public abstract class WebDataController<TModel> : WebController where TModel : DbEntity, new()
    {
        protected abstract IDbRepository<TModel> ModelRepository { get; }
                        
        // 首页.
        public ActionResult Index()
        {
            return View();
        }

        // 首页数据源.
        public ActionResult IndexJson(TModel model, FormCollection forms, int page = 1, int rows = 20)
        {
            Pagination pagination = new Pagination() { PageIndex = page, PageSize = rows };
            this.OnBeforeLoad(model, forms, pagination);
            int total = 0;
            IList<TModel> entities = null;
            EasyGridSource<TModel> source = new EasyGridSource<TModel>();
            try
            {
                if (pagination.PageIndex == -1)
                {
                    entities = this.ModelRepository.GetEntities(model);
                    total = entities == null ? 0 : entities.Count;
                }
                else
                {
                    entities = this.ModelRepository.GetEntities(model, pagination, ref total);
                }
            }
            catch (Exception ex)
            {
                source.message = this.LocalizeCode("webdata_load_failure", ex.Message);
            }
            source.total = total;
            source.rows = entities;
            return Json(source, JsonRequestBehavior.AllowGet);
        }

        // 新增\修改.
        public ActionResult Edit(string id)
        {
            TModel model = new TModel();
            if (this.OnBeforeEdit(model, id))
            {
                ViewData.Model = this.ModelRepository.GetEntity(model);
            }
            else
            {
                ViewData.Model = model;
            }
            return View();
        }

        // 保存修改.
        [HttpPost]
        public ActionResult Edit(string id, TModel model, FormCollection forms)
        {
            try
            {
                if (this.OnBeforeEdit(model, id))
                {
                    this.ModelRepository.Update(model);
                }
                else
                {
                    this.ModelRepository.Create(model);
                }
                this.OnShowMessage(this.LocalizeCode("webdata_save_success"));
            }
            catch (Exception ex)
            {
                this.OnShowMessage(this.LocalizeCode("webdata_save_failure", ex.Message), false);
            }
            return View();
        }

        // 删除.
        public ActionResult DeleteJson(string ids)
        {
            ServiceResult<int> result = new ServiceResult<int>(false);
            try
            {
                int affected = 0;
                if (!string.IsNullOrEmpty(ids))
                {
                    affected = this.ModelRepository.Delete(ids.Split(','));
                }
                result.Succeed = true;
                result.Message = this.LocalizeCode("webdata_delete_success");
                result.Data = affected;
            }
            catch (Exception ex)
            {
                result.Message = this.LocalizeCode("webdata_delete_failure", ex.Message);
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        
        #region override

        /// <summary>
        /// 加载数据时的处理.
        /// </summary>
        /// <param name="model"></param>
        /// <param name="forms"></param>
        /// <param name="pagination"></param>
        protected virtual void OnBeforeLoad(TModel model, FormCollection forms, Pagination pagination)
        { }

        [NonAction]
        protected abstract bool OnBeforeEdit(TModel model, string id);

        [NonAction]
        protected abstract bool OnBeforeSave(TModel model, string id, FormCollection forms);

        #endregion
    }
}
