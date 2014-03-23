using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Reflection;
using System.Text;

using XQH.EasyUi.Access;
using XQH.EasyUi.Entity;

namespace XQH.EasyUi.Web.Service
{
    public class EasyUiService : IHttpHandler, IRequiresSessionState
    {
        HttpRequest Request;
        HttpResponse Response;
        HttpSessionState Session;
        HttpServerUtility Server;
        HttpCookie Cookie;

        public void ProcessRequest(HttpContext context)
        {
            //不让浏览器缓存
            context.Response.Buffer = true;
            context.Response.ExpiresAbsolute = DateTime.Now.AddDays(-1);
            context.Response.AddHeader("pragma", "no-cache");
            context.Response.AddHeader("cache-control", "");
            context.Response.CacheControl = "no-cache";
            context.Response.ContentType = "text/plain";

            Request = context.Request;
            Response = context.Response;
            Session = context.Session;
            Server = context.Server;

            string method = Request["Method"].ToString();
            MethodInfo methodInfo = this.GetType().GetMethod(method);
            methodInfo.Invoke(this, null);
        }

        /// <summary>
        /// 获取系统管理树
        /// </summary>
        public void GetSysManageTree()
        {
            //SetModuleType("01");
            SetModulePermission("01");
        }

        /// <summary>
        /// 工作管理树
        /// </summary>
        public void GetWorkManageTree()
        {
            SetModulePermission("02");
        }

        /// <summary>
        /// 日常管理
        /// </summary>
        public void GetDailyManageTree()
        {
            SetModulePermission("03");
        }

        /// <summary>
        /// 其他事项
        /// </summary>
        public void GetOtherTree()
        {
            SetModulePermission("04");
        }

        /// <summary>
        /// 设置模块类型(现在只支持数据库修改)
        /// </summary>
        /// <param name="pid"></param>
        private void SetModuleType(string pid)
        {
            List<FunctionItemEntity> lsC = FunctionItemAccess.GetInstance().GetFunctionItemByPid(pid);
            List<FunctionItemEntity> lsP = FunctionItemAccess.GetInstance().GetFunctionNameById(pid);
            JsonConvert<FunctionItemEntity> jc = new JsonConvert<FunctionItemEntity>();
            Response.Write(jc.ToTreeNode(lsC, lsP));
        }

        /// <summary>
        /// 设置权限树
        /// </summary>
        public void SetPermissionTree()
        {
            int roleId = Convert.ToInt32(Server.UrlDecode(Request["RoleId"].ToString()));
            string resultStr = string.Empty;

            List<string> lsP = new List<string>();
            lsP = PermissionAccess.GetInstance().GetParentPermission();
            //此处省略得到数据列表的代码
            resultStr = "";
            resultStr += "[";
            foreach (string item in lsP)
            {
                resultStr += "{";

                List<PermissionEntity> lsC = new List<PermissionEntity>();
                lsC = PermissionAccess.GetInstance().GetChildPermission(item);
                //如果某变电站下有线路
                if (lsC.Count > 0)
                {
                    resultStr += string.Format("\"id\": \"{0}\", \"text\": \"{1}\", \"state\": \"closed\"", item, item);
                    resultStr += ",\"children\":[";

                    for (int i = 0; i < lsC.Count; i++)
                    {
                        resultStr += "{";
                        resultStr += string.Format("\"id\": \"{0}\", \"text\": \"{1}\",\"checked\":{2} ", lsC[i].PermissionId, lsC[i].OperationName, RolePermissionAccess.GetInstance().IsPermissionOn(roleId,lsC[i].PermissionId) == null ? "false" : "true");
                        resultStr += "},";
                    }
                    resultStr = resultStr.Substring(0, resultStr.Length - 1);
                    resultStr += "]";
                }
                else
                {
                    resultStr += string.Format("\"id\": \"{0}\", \"text\": \"{1}\" ", item, item);
                }
                resultStr += "},";
            }

            resultStr = resultStr.Substring(0, resultStr.Length - 1);
            resultStr += "]";

            Response.Write(resultStr);      
        }

        /// <summary>
        /// 设置模块操作权限
        /// </summary>
        /// <param name="pid">父ID</param>
        private void SetModulePermission(string pid)
        {
            int roleId = Convert.ToInt32(Request.QueryString["RoleId"].ToString());

            List<FunctionItemEntity> lsC = FunctionItemAccess.GetInstance().GetOperationPermission(pid, roleId);
            List<FunctionItemEntity> lsP = FunctionItemAccess.GetInstance().GetFunctionNameById(pid);
            JsonConvert<FunctionItemEntity> jc = new JsonConvert<FunctionItemEntity>();
            Response.Write(jc.ToTreeNode(lsC, lsP));
        }

        /// <summary>
        /// 获取角色信息
        /// </summary>
        public void GetRoleInfo()
        {
            List<RoleEntity> ls = RoleAccess.GetInstance().GetRoleInfo();
            JsonConvert<RoleEntity> jc = new JsonConvert<RoleEntity>();
            Response.Write(jc.ToDataGrid(ls, ls.Count));
        }

        /// <summary>
        /// 获取账号信息
        /// </summary>
        public void GetUserInfo()
        {
            List<UserEntity> ls = UserAccess.GetInstance().GetUserInfo();
            JsonConvert<UserEntity> jc = new JsonConvert<UserEntity>();
            Response.Write(jc.ToDataGrid(ls,ls.Count));
        }

        /// <summary>
        /// 登陆
        /// </summary>
        public void Login()
        {
            string username = Request["username"].ToString();
            string password = Request["password"].ToString();

            int flag = UserAccess.GetInstance().Login(username, password);
            int? roleId = RoleAccess.GetInstance().GetRoleIdByUsername(username);

            Cookie = new HttpCookie("RoleInfo");
            Cookie["roleId"] = roleId.ToString();
            Cookie.Expires = DateTime.Now.AddMonths(1);
            Response.Cookies.Add(Cookie);

            JsonConvert<object> jc = new JsonConvert<object>();
            Response.Write(jc.ToStatus(flag));
        }

        /// <summary>
        /// 设置权限
        /// </summary>
        public void SetPermission()
        {
            string isChecked = Request["IsChecked"].ToString();
            int roleId = Convert.ToInt32(Request["RoleId"].ToString());
            string permissionId = Request["PermissionId"].ToString();

            //如果为true,则添加权限
            if (isChecked == "true")
            {
                RolePermissionAccess.GetInstance().AddPermission(roleId, permissionId);
            }
            else
            {
                RolePermissionAccess.GetInstance().DeletePermission(roleId, permissionId);
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
