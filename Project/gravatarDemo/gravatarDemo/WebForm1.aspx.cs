using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace gravatarDemo
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string hash = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile("624541997@qq.com", "MD5");
            string imageUrl = string.Format(@"<img src=""http://www.gravatar.com/avatar/{0}?s={1}&d=mm&r=g"" />", hash, "100");
            Image1.ImageUrl = imageUrl;

            //http://1.gravatar.com/avatar/f3bafb4990ba5236b0655b182be0a334?s=40&d=wavatar&r=G
            //http://0.gravatar.com/avatar/?d=wavatar&s=40
        }
    }
}