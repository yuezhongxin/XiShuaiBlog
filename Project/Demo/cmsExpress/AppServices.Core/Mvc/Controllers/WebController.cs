using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using CMSExpress.AppServices.Mvc.Extensions;

namespace CMSExpress.AppServices.Mvc.Controllers
{
    [HandleError]
    public abstract class WebController : System.Web.Mvc.Controller
    {
        private string _username;

        protected string CurrentName
        {
            get
            {
                if (_username == null)
                    _username = HttpContext.User.Identity.Name;
                return _username;
            }
        }

        protected virtual string ControllerName
        {
            get { return string.Empty; }
        }

        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);

            // 当不需要验证身份时，不绑定身份数据到页面.
            if (!requestContext.HttpContext.SkipAuthorization)
            {
                this.OnInitializeAuthorization(requestContext);
            }
        }

        /// <summary>
        /// 初始化登陆账号信息.
        /// </summary>
        /// <param name="requestContext"></param>
        [NonAction]
        protected virtual void OnInitializeAuthorization(RequestContext requestContext)
        {
            if (User.Identity.IsAuthenticated)
            {
                base.ViewData["UserId"] = User.Identity.Name;
            }
        }

        [NonAction]
        protected void OnLog(Exception error, string message = null)
        {

        }

        [NonAction]
        protected ActionResult OnContextDependentView()
        {
            string actionName = ControllerContext.RouteData.GetRequiredString("action");
            if (Request.QueryString["content"] != null)
            {
                ViewBag.FormAction = "Json" + actionName;
                return PartialView();
            }
            else
            {
                ViewBag.FormAction = actionName;
                return View();
            }
        }

        [NonAction]
        protected IEnumerable<string> GetErrorsFromModelState()
        {
            return ModelState.SelectMany(x => x.Value.Errors.Select(error => error.ErrorMessage));
        }

        #region Message

        [NonAction]
        protected string LocalizeCode(string code, string message = null)
        {
            return this.Localize(code, this.ControllerName, message);
        }

        [NonAction]
        protected void OnShowMessage(Exception eror, string message, bool autoClose = true)
        {
            this.OnShowMessage(message, autoClose);
        }

        [NonAction]
        protected void OnShowMessage(string message, bool autoClose = true)
        {
            if (message == null)
                return;
            ViewData["Message_Content"] = message.IndexOf('_') > -1 ? this.LocalizeCode(message) : message;
            ViewData["Message_AutoClose"] = autoClose;
        }

        #endregion
    }
}
