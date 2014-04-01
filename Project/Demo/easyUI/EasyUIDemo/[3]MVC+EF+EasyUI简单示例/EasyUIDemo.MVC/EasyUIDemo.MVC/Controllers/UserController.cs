using EasyUIDemo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasyUIDemo.MVC.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/
        public ActionResult User_List()
        {
            return View();
        }

        /// <summary>
        /// 获取用户的所有信息
        /// </summary>
        /// <returns></returns>
        public ActionResult GetAllUserInfo()
        {
            int pageIndex = Request["page"] == null ? 1 : int.Parse(Request["page"]);
            int pageSize = Request["rows"] == null ? 10 : int.Parse(Request["rows"]);
            int total = 0;
            using (EasyUIDemoDBEntities db = new EasyUIDemoDBEntities())
            {
                var temp = from u in db.UserInfo select u;
                total = temp.Count();
                var users = temp.OrderByDescending(s => s.ID)
                     .Skip<UserInfo>((pageIndex - 1) * pageSize).Take<UserInfo>(pageSize);
                var data = new
                {
                    total = total,
                    rows = users.ToList<UserInfo>()
                };
                return Json(data);
            }
        }

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="userinfo"></param>
        /// <returns></returns>
        public ActionResult AddUser(UserInfo userinfo)
        {
            userinfo.CreateTime = DateTime.Now;
            using (EasyUIDemoDBEntities db = new EasyUIDemoDBEntities())
            {
                db.UserInfo.Add(userinfo);
                db.SaveChanges();
            }
            return Content("OK");
        }

        /// <summary>
        /// 绑定用户数据
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public ActionResult GetBindDetails(int ID)
        {
            using (EasyUIDemoDBEntities db = new EasyUIDemoDBEntities())
            {
                var BindIDForUpdateTextBox = db.UserInfo.Where(u => u.ID == ID).FirstOrDefault();
                return Json(BindIDForUpdateTextBox, JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="deleteUserInfoID"></param>
        /// <returns></returns>
        public ActionResult DeleteUser(string deleteUserInfoID, string Name)
        {
            var UIdsName = Name.Split(',');
            List<string> deleteUName = new List<string>();
            foreach (var item in UIdsName)
            {
                deleteUName.Add(item);
            }
            if (deleteUName.Contains(Session["UserName"].ToString()))
            {
                return Content("含有正在使用的用户，禁止删除");
            }

            if (string.IsNullOrEmpty(deleteUserInfoID))
            {
                return Content("请选择您要删除的数据");
            }
            var idsStr = deleteUserInfoID.Split(',');
            List<int> deleteIDList = new List<int>();
            foreach (var ID in idsStr)
            {
                deleteIDList.Add(Convert.ToInt32(ID));
            }
            using (EasyUIDemoDBEntities db = new EasyUIDemoDBEntities())
            {
                foreach (var ID in deleteIDList)
                {
                    var users = db.UserInfo.Where(p => p.ID == ID).FirstOrDefault();
                    db.UserInfo.Remove(users);
                }
                db.SaveChanges();
            }
            return Content("OK");
        }
    }
}
