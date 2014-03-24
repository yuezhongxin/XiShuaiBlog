using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using XQH.EasyUi.Database;
using XQH.EasyUi.Database.EasyUiDataSetTableAdapters;
using XQH.EasyUi.Entity;

namespace XQH.EasyUi.Access
{
    /// <summary>
    /// 账号操作
    /// </summary>
    public class UserAccess
    {
        UserTableAdapter userAdp = new UserTableAdapter();
        private static UserAccess accessInstance = null;

        public static UserAccess GetInstance()
        {
            if (accessInstance == null)
            {
                accessInstance = new UserAccess();
            }

            return accessInstance;
        }

        /// <summary>
        /// 获取账号信息
        /// </summary>
        /// <returns></returns>
        public List<UserEntity> GetUserInfo()
        {
            List<UserEntity> ls = new List<UserEntity>();

            try
            {
                EasyUiDataSet.UserDataTable dt = userAdp.GetUserInfo();

                foreach (EasyUiDataSet.UserRow dr in dt.Rows)
                {
                    UserEntity entity = new UserEntity(
                        dr.UserId,
                        dr.Username,
                        dr.Password,
                        dr.RealName,
                        dr.Sex,
                        dr.Address
                        );
                    ls.Add(entity);
                }

                return ls;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 登陆操作
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>1成功|0失败</returns>
        public int Login(string username,string password)
        {
            try
            {
                EasyUiDataSet.UserDataTable dt = userAdp.GetUserByUsername(username,password);

                if (dt.Count == 1)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
