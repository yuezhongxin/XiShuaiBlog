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
            string hash = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile("624541997@qq.com", "md5");
            string imageUrl = string.Format(@"http://www.gravatar.com/avatar/{0}?s={1}&d=mm&r=g", hash.ToLower(), "100");
            Image1.ImageUrl = imageUrl;

            //http://www.gravatar.com/avatar/aae1e25f99469f5c616f77b2c7682e9d?s=100&d=mm&r=g
            //http://1.gravatar.com/avatar/f3bafb4990ba5236b0655b182be0a334?s=40&d=wavatar&r=G
            //http://0.gravatar.com/avatar/?d=wavatar&s=40      缺省图片地址
            //http://en.gravatar.com/site/implement/images/     参数地址
        }
    }
}