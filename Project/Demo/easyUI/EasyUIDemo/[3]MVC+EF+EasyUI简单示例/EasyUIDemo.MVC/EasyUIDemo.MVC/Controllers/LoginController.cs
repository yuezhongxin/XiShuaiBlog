using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using EasyUIDemo.Model;

namespace EasyUIDemo.MVC.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Login()
        {
            //获取到Cookie中的值传递给前台显示
            var UserName = Request.Cookies["UserName"] == null ? "" : Request.Cookies["UserName"].Value;
            ViewBag.UserName = UserName;
            return View();
        }

        /// <summary>
        /// 处理登录的信息
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        public JsonResult CheckUserLogin(UserInfo userInfo)
        {
            using (EasyUIDemoDBEntities db = new EasyUIDemoDBEntities())
            {
                //linq查询
                var users = from p in db.UserInfo
                            where p.Name == userInfo.Name && p.Password == userInfo.Password && p.Enable == true
                            select p;
                if (users.Count() > 0)
                {
                    userInfo = users.FirstOrDefault();
                    Response.Cookies["UserName"].Value = userInfo.Name;
                    Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(7);
                    return Json(new { result = "success", content = "" });
                }
                else
                {
                    return Json(new { result = "error", content = "用户名密码错误，请您检查" });
                }
            }
        }
    }
}
