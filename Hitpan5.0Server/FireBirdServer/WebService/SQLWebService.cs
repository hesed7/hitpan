using System;
using System.ServiceModel;
using System.Data;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using WebService.Controller.SecurityManager;
using WebService.Controller.DBManager;
using Newtonsoft.Json;
using WebService.WebServiceVO.Users;
using WebService.WebServiceSQL.Users;
namespace WebService.WebService
{
    
    [ServiceBehavior
        (
        InstanceContextMode = InstanceContextMode.PerCall, 
        IncludeExceptionDetailInFaults = true,
        ConcurrencyMode=ConcurrencyMode.Single
        )]
    public class SQLWebService : ISQLWebService 
    {
        private SecurityController securityManager { get; set; }
        public SQLWebService()
        {
            this.securityManager = new SecurityController();            
        }
        #region 입력,수정,삭제
        /// <summary>
        /// 데이터를 입력/수정/삭제한다
        /// </summary>
        /// <param name="query"></param>
        /// <param name="AuthKey"></param>
        /// <returns></returns>   
        public void RegistQuery(string AuthKey, string query, string serviceURL) 
        {
            if (!securityManager.CheckSecurityToken(AuthKey))
            {
                throw new Exception("인증된 사용자가 아닙니다");
            }
            try 
	        {	       
                StringCollection queryBlock= new StringCollection();
                queryBlock.Add(query);
                DBController.getInstance().SetData(serviceURL, queryBlock);
	        }
	        catch (Exception)
	        {		
		        throw;
	        }
        }

        /// <summary>
        /// 하나의 트랜잭션으로 처리할 쿼리구문을 블럭단위로 받아서 DataController의 트랜잭션 처리 Queue에 넣는다
        /// </summary>
        /// <param name="AuthKey">클라이언트 인증키</param>
        /// <param name="QueryBlock">하나의 트랜잭션 안에서 처리할 쿼리구문의 String배열</param> 
        public void RegistQueryBlock(string AuthKey, StringCollection QueryBlock, string serviceURL) 
        {
            if (!securityManager.CheckSecurityToken(AuthKey))
            {
                throw new Exception("인증된 사용자가 아닙니다");
            }
            //쿼리
            DBController.getInstance().SetData(serviceURL, QueryBlock);
        }
         
        #endregion
        #region 조회
        public string GetData(string AuthKey, string query, string serviceURL) 
        {
            if (!securityManager.CheckSecurityToken(AuthKey))
            {
                throw new Exception("인증된 사용자가 아닙니다");
            }

            //클라이언트콜백함수 가져오기
            string json = string.Empty;
            DataTable dt = DBController.getInstance().GetData(serviceURL, query);
            json = JsonConvert.SerializeObject(dt);
            return json;
        }
        #endregion
        #region 타임서버
        public DateTime GetTime() 
        {
            return DateTime.Now;
        }
        #endregion

        #region User
        /// <summary>
        /// 로그인
        /// </summary>
        /// <param name="AuthKey"></param>
        /// <param name="serviceURL"></param>
        /// <param name="id"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public UsersVO UserLogIn(string AuthKey, string serviceURL, string id, string password)
        {
            if (!securityManager.CheckSecurityToken(AuthKey))
            {
                throw new Exception("인증된 사용자가 아닙니다");
            }
            string query = new UserQuery().GetUserInfo(id);
            DataTable dtUser = DBController.getInstance().GetData(serviceURL, query);
            if (dtUser.Rows.Count > 0 && dtUser.Rows[0]["USERPASSWORD"].ToString() == password)
            {
                UsersVO uvo = new UsersVO();
                uvo.UserID = id;
                uvo.UserPassword = password;
                uvo.UserAuth = dtUser.Rows[0]["UserAuth"].ToString();
                uvo.UserType = Convert.ToInt32(dtUser.Rows[0]["UserType"]);
                return uvo;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 특정 id 유저정보 알아내기
        /// </summary>
        /// <param name="AuthKey"></param>
        /// <param name="serviceURL"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public UsersVO GetUserInfo(string AuthKey, string serviceURL, string id)
        {
            if (!securityManager.CheckSecurityToken(AuthKey))
            {
                throw new Exception("인증된 사용자가 아닙니다");
            }
            string query = new UserQuery().GetUserInfo(id);
            DataTable dtUser = DBController.getInstance().GetData(serviceURL, query);
            if (dtUser.Rows.Count > 0)
            {
                UsersVO uvo = new UsersVO();
                uvo.UserID = dtUser.Rows[0]["USERid"].ToString().Replace("{","");
                uvo.UserAuth = dtUser.Rows[0]["UserAuth"].ToString();
                uvo.UserType = Convert.ToInt32(dtUser.Rows[0]["UserType"]);
                return uvo;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 모든 유저의 정보 알아내기
        /// </summary>
        /// <param name="AuthKey"></param>
        /// <param name="serviceURL"></param>
        /// <returns></returns>
        public UsersVO[] GetUsersInfo(string AuthKey, string serviceURL)
        {
            if (!securityManager.CheckSecurityToken(AuthKey))
            {
                throw new Exception("인증된 사용자가 아닙니다");
            }
            string query = new UserQuery().GetAllUsers();
            DataTable dtUser = DBController.getInstance().GetData(serviceURL, query);

            IList<UsersVO> userList = new List<UsersVO>();
            for (int i = 0; i < dtUser.Rows.Count; i++)
            {
                UsersVO uvo = new UsersVO();
                uvo.UserID = dtUser.Rows[i]["USERid"].ToString();
                uvo.UserPassword = dtUser.Rows[i]["userpassword"].ToString();
                uvo.UserAuth = dtUser.Rows[i]["UserAuth"].ToString();
                uvo.UserType = Convert.ToInt32(dtUser.Rows[i]["UserType"]);
                userList.Add(uvo);                
            }

            UsersVO[] arrUV = new UsersVO[userList.Count];
            for (int i = 0; i < userList.Count; i++)
            {
                arrUV[i] = userList[i];
            }
            return arrUV;
        }
        /// <summary>
        /// 사용자 정보 업데이트
        /// 사용자ID는 바뀌지 않는다
        /// </summary>
        /// <param name="AuthKey"></param>
        /// <param name="serviceURL"></param>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        public int UpdateUserInfo(string AuthKey, string serviceURL,UsersVO userInfo) 
        {
            string query = new UserQuery().UpdateUser(userInfo);
            int EffectedRow = DBController.getInstance().SetData(serviceURL, query);
            return EffectedRow;
        }
        /// <summary>
        /// 사용자정보 인서트
        /// </summary>
        /// <param name="AuthKey"></param>
        /// <param name="serviceURL"></param>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        public int InsertUserInfo(string AuthKey, string serviceURL, UsersVO userInfo) 
        {
            string query = new UserQuery().insertUser(userInfo);
            int EffectedRow = DBController.getInstance().SetData(serviceURL, query);
            return EffectedRow;        
        }
        #endregion


    }
}
