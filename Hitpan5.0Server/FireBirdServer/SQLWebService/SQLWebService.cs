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
        #region 실행계획 조회
        public String GetSQLPlan(string query, string serviceURL) 
        {
            DataTable dt = DBController.getInstance().GetPlan(serviceURL, query);
            string json = JsonConvert.SerializeObject(dt);
            return json;
        }        
        #endregion
        #region 타임서버
        public DateTime GetTime() 
        {
            return DateTime.Now;
        }
        #endregion
    }
}
