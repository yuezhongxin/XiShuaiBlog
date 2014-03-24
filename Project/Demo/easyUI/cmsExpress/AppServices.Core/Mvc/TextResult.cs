using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMSExpress.AppServices.Mvc
{
    public class TextResult : System.Web.Mvc.ActionResult
    {
        public string Text { get; set; }

        public string ContentType { get; set; }

        public TextResult()
        { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="contentType">application/json</param>
        public TextResult(string text, string contentType = "text/plain")
        {
            this.Text = text;
            this.ContentType = contentType;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            HttpResponseBase response = context.HttpContext.Response;
            response.ContentType = this.ContentType;
            response.ContentEncoding = System.Text.Encoding.UTF8;
            response.Write(this.Text);
        }
    }
}