using System;
using System.ServiceModel;
using System.Data;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using WebServiceServer.Controller.SecurityManager;
using WebServiceServer.Controller.DBManager;
using Newtonsoft.Json;
using WebServiceServer.WebServiceVO.Users;
using WebServiceServer.WebServiceSQL.Users;
using WebServiceServer.WebServiceVO.Settings;
using WebServiceServer.webService.WebServiceSQL.Settings;
using WebServiceServer.Enums;
using WebServiceServer.WebServiceVO.Goods;
using WebServiceServer.WebServiceSQL.Goods;
using WebServiceServer.WebServiceVO.Goods.GoodDetail_Sub;
namespace WebServiceServer.webService
{
    
    [ServiceBehavior
        (
        InstanceContextMode = InstanceContextMode.PerCall, 
        IncludeExceptionDetailInFaults = true,
        ConcurrencyMode=ConcurrencyMode.Single
        )]
    public class WebService : IWebService 
    {
        private SecurityController securityManager { get; set; }
        public WebService()
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
                uvo.UserAuth = JsonConvert.DeserializeObject<UserAuth>(dtUser.Rows[0]["UserAuth"].ToString());
                uvo.UserType = (사용자등급)Enum.Parse(typeof(사용자등급), dtUser.Rows[0]["usertype"].ToString());
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
                uvo.UserAuth = JsonConvert.DeserializeObject<UserAuth>(dtUser.Rows[0]["UserAuth"].ToString());
                uvo.UserType = (사용자등급)Enum.Parse(typeof(사용자등급), dtUser.Rows[0]["usertype"].ToString());
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
                uvo.UserID = dtUser.Rows[i]["userid"].ToString();
                uvo.UserPassword = dtUser.Rows[i]["userpassword"].ToString();
                uvo.UserAuth = JsonConvert.DeserializeObject<UserAuth>(dtUser.Rows[0]["userauth"].ToString());
                uvo.UserType = (사용자등급)Enum.Parse(typeof(사용자등급),dtUser.Rows[0]["usertype"].ToString());
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
        #region 설정정보 및 나의 회사정보
        public MyCompany GetMyCompanyInfo(string AuthKey, string serviceURL) 
        {
            if (!securityManager.CheckSecurityToken(AuthKey))
            {
                throw new Exception("인증된 사용자가 아닙니다");
            }
            String Query = new MyCompanyQuery().GetMyCompanyInfo();
            DataTable dt = DBController.getInstance().GetData(serviceURL,Query);
            MyCompany my_company = JsonConvert.DeserializeObject<MyCompany>(dt.Rows[0]["jsonmyinfo"].ToString());
            return my_company;
        }
        public int SetMyCompanyInfo(string AuthKey, string serviceURL,MyCompany myCompanyInfo)
        {
            if (!securityManager.CheckSecurityToken(AuthKey))
            {
                throw new Exception("인증된 사용자가 아닙니다");
            } 
            //기존 정보가 있는지 검증
            bool Exist = false;
            DataTable dt = DBController.getInstance().GetData(serviceURL, new MyCompanyQuery().GetMyCompanyInfo());
            if (dt!=null && dt.Rows.Count>0)
            {
                Exist = true;
            }
            string Query = new MyCompanyQuery().SetMyCompanyInfo(myCompanyInfo,Exist);
            return DBController.getInstance().SetData(serviceURL,Query);
        }

        public CommonSettings GetCommonSettingInfo(string AuthKey, string serviceURL)
        {
            if (!securityManager.CheckSecurityToken(AuthKey))
            {
                throw new Exception("인증된 사용자가 아닙니다");
            }
            String Query = new CommonSettingsQuery().GetCommonSettings();
            DataTable dt = DBController.getInstance().GetData(serviceURL, Query);
            CommonSettings CommonSettings = JsonConvert.DeserializeObject<CommonSettings>(dt.Rows[0]["jsonsettinginfodata"].ToString());
            return CommonSettings;
        }
        public int SetCommonSettingInfo(string AuthKey, string serviceURL, CommonSettings CommonSettings)
        {
            if (!securityManager.CheckSecurityToken(AuthKey))
            {
                throw new Exception("인증된 사용자가 아닙니다");
            }
            //기존 정보가 있는지 검증
            bool Exist = false;
            DataTable dt = DBController.getInstance().GetData(serviceURL, new CommonSettingsQuery().GetCommonSettings());
            if (dt != null && dt.Rows.Count > 0)
            {
                Exist = true;
            }
            string Query = new CommonSettingsQuery().SetCommonSettings(CommonSettings, Exist);
            return DBController.getInstance().SetData(serviceURL, Query);
        }
        #endregion
        #region 상품표준정보
        public long GetGoodsCount
            (
            string AuthKey,
            string serviceURL,
            string good_name,
            string good_subName,
            string good_NickName,
            string good_maker            
            ) 
        {
            if (!securityManager.CheckSecurityToken(AuthKey))
            {
                throw new Exception("인증된 사용자가 아닙니다");
            }
            string CountQuery = new GoodsQuery().GetGoodsCount(good_name, good_subName, good_NickName, good_maker);
            DataTable dt = DBController.getInstance().GetData(serviceURL, CountQuery);    
            long count =   Convert.ToInt64(dt.Rows[0][0]);
            return count;
        }
        //C
        public IList<GoodsListVO> GetGoodsList
            (
            string AuthKey, 
            string serviceURL,
            int page,
            int rowCount,
            string good_name,
            string good_subName,
            string good_NickName,
            string good_maker
            )
        {
            if (!securityManager.CheckSecurityToken(AuthKey))
            {
                throw new Exception("인증된 사용자가 아닙니다");
            }
            IList<GoodsListVO> GoodsVOList = new List<GoodsListVO>();
            //쿼리 작성
            string Query = new GoodsQuery().SelectGoodsList(page,rowCount,good_name,good_subName,good_NickName,good_maker);
            //데이터 구하기
            DataTable dt = DBController.getInstance().GetData(serviceURL, Query);
            //구한 데이터 가공하기
            foreach (DataRow dr in dt.Rows)
            {
                GoodsListVO goodsVO = new GoodsListVO();
                foreach (var prop in typeof(GoodsListVO).GetProperties())
                {
                    if (prop.Name=="Item")
                    {
                        continue;
                    }
                    goodsVO[prop.Name] = dr[prop.Name];
                }
                GoodsVOList.Add(goodsVO);
            }
            return GoodsVOList;
        }
        public GoodsDetail GetGoodDetail(string AuthKey,string serviceURL,long good_pk)
        {
            if (!securityManager.CheckSecurityToken(AuthKey))
            {
                throw new Exception("인증된 사용자가 아닙니다");
            }
            //쿼리 작성
            string Query = new GoodsQuery().GoodDetails(good_pk);
            //데이터 구하기
            DataTable dt =  DBController.getInstance().GetData(serviceURL,Query);
            //데이터 가공
            GoodsDetail  detailMaster =          new GoodsDetail();
            detailMaster .unitcostList =         new List<unitcost>();
            detailMaster .good_unit_infoList =   new List<good_unit_info>();
            detailMaster .goodpartList =         new List<goodpart>();
            detailMaster .goodsellerList =       new List<goodseller>();

            foreach (DataRow dr in dt.Rows)
            {
                foreach (var prop in typeof(GoodsDetail).GetProperties())
                {
                    if (prop.Name=="Item")
                    {
                        continue;
                    }
                    if (prop.Name.Contains("List"))
                    {
                        continue;
                    }
                    if (dr[prop.Name].GetType()==typeof(DBNull))
                    {
                        continue;
                    }
                    detailMaster[prop.Name] = dr[prop.Name];
                }//End of Foreach
                unitcost unitcost = new unitcost();
                good_unit_info good_unit_info = new good_unit_info();
                goodpart goodpart = new goodpart();
                goodseller goodseller = new goodseller();
                foreach (var prop in typeof(unitcost).GetProperties())
                {
                    if (prop.Name == "Item")
                    {
                        continue;
                    }
                    if (dr[prop.Name].GetType() == typeof(DBNull))
                    {
                        continue;
                    }
                    unitcost[prop.Name] = dr[prop.Name];
                }
                foreach (var prop in typeof(good_unit_info).GetProperties())
                {
                    if (prop.Name == "Item")
                    {
                        continue;
                    }
                    if (dr[prop.Name].GetType() == typeof(DBNull))
                    {
                        continue;
                    }
                    good_unit_info[prop.Name] = dr[prop.Name];
                }
                foreach (var prop in typeof(goodpart).GetProperties())
                {
                    if (prop.Name == "Item")
                    {
                        continue;
                    }
                    if (dr[prop.Name].GetType() == typeof(DBNull))
                    {
                        continue;
                    }
                    goodpart[prop.Name] = dr[prop.Name];
                }
                foreach (var prop in typeof(goodseller).GetProperties())
                {
                    if (prop.Name == "Item")
                    {
                        continue;
                    }
                    if (dr[prop.Name].GetType() == typeof(DBNull))
                    {
                        continue;
                    }
                    goodseller[prop.Name] = dr[prop.Name];
                }
                detailMaster.unitcostList.Add(unitcost);
                detailMaster.good_unit_infoList.Add(good_unit_info);
                detailMaster.goodpartList.Add(goodpart);
                detailMaster.goodsellerList.Add(goodseller);
            }//End of Outer Foreach

            return detailMaster;
        }
        //R
        public int InsertGood(string AuthKey, string serviceURL,GoodsDetail goodInfo)
        {
            if (!securityManager.CheckSecurityToken(AuthKey))
            {
                throw new Exception("인증된 사용자가 아닙니다");
            }
            return 0;
        }
        //U
        public int UpdateGood(string AuthKey, string query, string serviceURL, GoodsDetail goodInfo)
        {
            if (!securityManager.CheckSecurityToken(AuthKey))
            {
                throw new Exception("인증된 사용자가 아닙니다");
            }
            return 0;
        }
        //D
        public int DeleteGood(string AuthKey, string query, string serviceURL,long goodIDX)
        {
            if (!securityManager.CheckSecurityToken(AuthKey))
            {
                throw new Exception("인증된 사용자가 아닙니다");
            }
            return 0;
        }
        #endregion
    }
}
