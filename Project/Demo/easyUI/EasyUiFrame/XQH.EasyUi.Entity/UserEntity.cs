using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XQH.EasyUi.Entity
{
    /// <summary>
    /// 账号信息
    /// </summary>
    public class UserEntity
    {
        /// <summary>
        /// 账户ID
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 真实名
        /// </summary>
        public string RealName { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public string Sex { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }

        public UserEntity(int userId,string username,string password,string realname,string sex,string address)
        {
            this.UserId = userId;
            this.Username = username;
            this.Password = password;
            this.RealName = realname;
            this.Sex = sex;
            this.Address = address;
        }
    }
}
