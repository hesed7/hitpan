using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebServiceServer.WebServiceVO.Users;
using Newtonsoft.Json;
using WebServiceServer.Enums;
namespace WebServiceServer.WebServiceSQL.Users
{
    class UserQuery
    {
        public string GetAllUsers() 
        {
            return "select * from users";
        }
        public string GetUserInfo(string id) 
        {
            return string.Format("select * from users where userid='{0}'",id);
        }
        public string insertUser(UsersVO userInfo) 
        {
            string UserAuth = JsonConvert.SerializeObject(userInfo.UserAuth);
            string UserType = Enum.GetName(typeof(사용자등급),userInfo.UserType);
            StringBuilder sbUser = new StringBuilder();
            sbUser.Append("insert into USERS(");
            sbUser.Append(" userid,");
            sbUser.Append("userpassword,");
            sbUser.Append("UserAuth,");
            sbUser.Append("UserType)");
            sbUser.Append(" values(");
            sbUser.Append("'");
            sbUser.Append(userInfo.UserID);
            sbUser.Append("','");
            sbUser.Append(userInfo.UserPassword);
            sbUser.Append("','");
            sbUser.Append(UserAuth);
            sbUser.Append("','");
            sbUser.Append(UserType);
            sbUser.Append("'");
            sbUser.Append(")");
            return sbUser.ToString();
        }
        public string UpdateUser(UsersVO userInfo)
        {
            string UserAuth = JsonConvert.SerializeObject(userInfo.UserAuth);
            string UserType = Enum.GetName(typeof(사용자등급), userInfo.UserType);
            StringBuilder sbUser = new StringBuilder();
            sbUser.Append("update Users set ");
            sbUser.Append("userid='");
            sbUser.Append(userInfo.UserID);
            sbUser.Append("',");
            sbUser.Append("userpassword = '");
            sbUser.Append(userInfo.UserPassword);
            sbUser.Append("',");
            sbUser.Append("UserAuth = '");
            sbUser.Append(UserAuth);
            sbUser.Append("',");
            sbUser.Append("UserType = '");
            sbUser.Append(UserType);
            sbUser.Append("' where ");
            sbUser.Append(" userid='");
            sbUser.Append(userInfo.UserID);
            sbUser.Append("'");
            return sbUser.ToString();
        }
    }
}
