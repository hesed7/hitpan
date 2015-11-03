using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using libHitpan5.Model.DataModel;
using System.Data;
using libHitpan5.VO;
using libHitpan5.enums;
namespace libHitpan5.Controller.CommandListener
{
    /// <summary>
    /// 사용자 입력, 로그인, 정보수정
    /// </summary>
    class UserListener
    {
        private Model.DataModel.IDataModel dataModel;
        public SQLDataQueryRepository QueryHouse { get; set; }
        public UserListener(Model.DataModel.IDataModel dataModel)
        {
            // TODO: Complete member initialization
            this.dataModel = dataModel;
            this.QueryHouse = new SQLDataQueryRepository();
        }
        internal void Insert(VO.UserInfo userInfo)
        {
            string query = QueryHouse.InsertUserInfo(userInfo.id,userInfo.password,userInfo.userAuth,userInfo.userType);
            this.dataModel.SetData(query);
        }

        internal void Delete(VO.UserInfo userInfo)
        {
            string query = QueryHouse.DeleteUserInfo(userInfo.id);
            this.dataModel.SetData(query);
        }

        /// <summary>
        /// 아이디는 변경금지
        /// </summary>
        /// <param name="userinfo"></param>
        internal void Update(VO.UserInfo userinfo)
        {
            string query = QueryHouse.UpdateUserInfo(userinfo.id,userinfo.password,userinfo.id,userinfo.userAuth,userinfo.userType);
            this.dataModel.SetData(query);
        }

        internal object Login(string id, string password)
        {
            string query = QueryHouse.SelectUserInfo(id);
            DataTable tblUser = this.dataModel.GetData(query);
            UserInfo ui= ConvertDataRow_To_UserInfo(tblUser.Rows[0]);
            string _password = tblUser.Rows[0]["UserPassword"].ToString();
            if (password == _password)
            {
                return ui;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 모든 사용자계정의 정보를 반환
        /// </summary>
        /// <returns></returns>
        internal object GetUserInfo()
        {
            string query = QueryHouse.SelectUserInfo();
            DataTable tblUsers = this.dataModel.GetData(query);
            this.DocumentData = tblUsers;

            IList<UserInfo> userList = new List<UserInfo>();
            foreach (DataRow row in tblUsers.Rows)
            {
                UserInfo ui= ConvertDataRow_To_UserInfo(row);
                userList.Add(ui);
            }
            return userList;
        }

        internal object GetUserInfo(string id)
        {
            string query = QueryHouse.SelectUserInfo(id);
            DataTable tblUsers = this.dataModel.GetData(query);
            this.DocumentData = tblUsers;
            return ConvertDataRow_To_UserInfo(tblUsers.Rows[0]);
        }


        private UserInfo ConvertDataRow_To_UserInfo(DataRow DataRow)
        {
            UserInfo ui = new UserInfo();
            ui.id = DataRow["UserID"].ToString();
            ui.userAuth = DataRow["userAuth"].ToString();
            ui.userType = (사용자등급)Enum.ToObject(typeof(사용자등급), Convert.ToInt32(DataRow["userType"]));
            return ui;
        } 
        public  System.Data.DataTable DocumentData { get; set; }
    }
}
