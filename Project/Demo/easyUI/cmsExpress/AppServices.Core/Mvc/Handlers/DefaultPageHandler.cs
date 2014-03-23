using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace CMSExpress.AppServices.Mvc.Handlers
{
    public class DefaultPageHandler : System.Web.UI.Page
    {
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.OnRewriteMvc();
        }

        protected virtual void OnRewriteMvc()
        {
            //string originalPath = Request.Path;
            //HttpContext.Current.RewritePath(Request.ApplicationPath, false);
            //IHttpHandler httpHandler = new MvcHttpHandler();
            //httpHandler.ProcessRequest(HttpContext.Current);
            //HttpContext.Current.RewritePath(originalPath, false);

            HttpContext.Current.RewritePath(Request.ApplicationPath, false);
            IHttpHandler handler = new MvcHttpHandler();
            handler.ProcessRequest(HttpContext.Current);
        }
    }
}
