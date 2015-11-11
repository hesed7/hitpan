using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using libHitpan5.Model.DataModel;
using System.Data;
using libHitpan5.VO;
using libHitpan5.enums;
using WebServiceServer.WebServiceVO.Users;
namespace libHitpan5.Controller.CommandListener
{
    /// <summary>
    /// 사용자 입력, 로그인, 정보수정
    /// </summary>
    class UserListener
    {
        private SQLDataServiceModel dataModel;
        public UserListener(SQLDataServiceModel dataModel)
        {
            // TODO: Complete member initialization
            this.dataModel = dataModel;
        }
        internal void Insert(UserInfoProxyVO userInfo)
        {
            this.dataModel.InsertUserInfo(userInfo);
        }

        internal void Delete(UserInfoProxyVO userInfo)
        {
            userInfo.UsersVO.UserType = (int)사용자등급.페기;
            this.dataModel.UpdateUserInfo(userInfo);
        }

        /// <summary>
        /// 아이디는 변경금지
        /// </summary>
        /// <param name="userinfo"></param>
        internal void Update(UserInfoProxyVO userInfo)
        {
            this.dataModel.UpdateUserInfo(userInfo);
        }

        internal object Login(string id, string password)
        {
            
            try
            {
                UserInfoProxyVO uv = null;
                uv = this.dataModel.GetUserInfo(id, password);
                return uv;
            }
            catch (Exception)
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
            try
            {
                IList<UserInfoProxyVO> uvList = null;
                uvList = this.dataModel.GetUserInfo();
                return uvList;
            }
            catch (Exception)
            {
                return null;
            }
        }

        internal object GetUserInfo(string id)
        {
            try
            {
                UserInfoProxyVO uv = null;
                uv = this.dataModel.GetUserInfo(id);
                return uv;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public  System.Data.DataTable DocumentData { get; set; }
    }
}
