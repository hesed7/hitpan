using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using libHitpan5.Model.EncryptionModel;
using System.Data;
using Newtonsoft.Json;
using System.Xml.Serialization;
using libHitpan5.Model.WebServiceModel;
using WebServiceServer.WebServiceVO.Users;
using WebServiceServer.WebServiceVO.Settings;
using libHitpan5._Exception;
using libHitpan5.VO;
using WebServiceServer.WebServiceVO.Goods;
using libHitpan5.VO.CommonVO.GoodInfo;
namespace libHitpan5.Model.DataModel
{
    /// <summary>
    /// 웹서비스프록시 로부터 데이터 얻음
    /// </summary>
    public class SQLDataServiceModel
    {
        internal string EncryptionSeed { get; set; }
        internal string ServiceURL { get; set; }
        internal IWebService sqlProxy { get; set; }

        /// <summary>
        /// sql 쿼리를 서버에 보낸다
        /// </summary>
        /// <param name="EncryptionSeed">서버보안문자(seed)</param>
        /// <param name="sqlService">sql웹서비스 프록시객체</param>
        public SQLDataServiceModel(string EncryptionSeed, string ServiceURL, IWebService sqlService)
        {
            //[1] 웹서비스 동적 추가
            this.sqlProxy = sqlService;
            this.ServiceURL = ServiceURL;
            //[2] 암호화키 
            this.EncryptionSeed = EncryptionSeed;
        }


        public DataTable GetData(string query)
        {            
            DataTable dt = null;
            try
            {
                string jsonData = this.sqlProxy.GetData(new EncryptionService().GetEncryptedKey(this.EncryptionSeed, DateTime.Now), query,this.ServiceURL);
                object returnValue = JsonConvert.DeserializeObject(jsonData, typeof(DataTable));

                dt = (DataTable)returnValue;
            }
            catch (ArgumentNullException)
            {

            }
            catch (Exception) 
            {
                throw;
            }
            return dt;
        }

        public void SetData(string query)
        {
            sqlProxy.RegistQuery(new EncryptionService().GetEncryptedKey(this.EncryptionSeed, this.sqlProxy.GetTime()), query, this.ServiceURL);
        }

        public void SetData(string[] queryList)
        {
            this.sqlProxy.RegistQueryBlock(new EncryptionService().GetEncryptedKey(this.EncryptionSeed, this.sqlProxy.GetTime()), queryList, this.ServiceURL);
        }


        #region User
        public IList<UserInfoProxyVO> GetUserInfo()
        {
            try
            {
                UsersVO[] arrUV = sqlProxy.GetUsersInfo
                (
                new EncryptionService().GetEncryptedKey(this.EncryptionSeed, this.sqlProxy.GetTime()),
                this.ServiceURL
                );
                IList<UserInfoProxyVO> upList = new List<UserInfoProxyVO>();
                foreach (UsersVO uv in arrUV)
                {
                    UserInfoProxyVO up = new UserInfoProxyVO();
                    up.UsersVO = uv;
                    upList.Add(up);
                }
                return upList;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public UserInfoProxyVO GetUserInfo(string id)
        {
            try
            {
                UsersVO uv = sqlProxy.GetUserInfo
                (
                new EncryptionService().GetEncryptedKey(this.EncryptionSeed, this.sqlProxy.GetTime()),
                this.ServiceURL,
                id
                );
                UserInfoProxyVO up = new UserInfoProxyVO();
                up.UsersVO = uv;
                return up;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public UserInfoProxyVO GetUserInfo(string id, string password)
        {
            try
            {
                UsersVO uv = sqlProxy.UserLogIn
                (
                new EncryptionService().GetEncryptedKey(this.EncryptionSeed, this.sqlProxy.GetTime()),
                this.ServiceURL,
                id,
                password
                );
                if (uv == null)
                {
                    throw new InvalidLogin();
                }
                else
                {
                    UserInfoProxyVO up = new UserInfoProxyVO();
                    up.UsersVO = uv;
                    return up;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        internal void InsertUserInfo(UserInfoProxyVO userInfo)
        {
            try
            {
                sqlProxy.InsertUserInfo
                (
                new EncryptionService().GetEncryptedKey(this.EncryptionSeed, this.sqlProxy.GetTime()),
                this.ServiceURL,
                userInfo.UsersVO
                );
            }
            catch (Exception)
            {

                throw;
            }
        }
        internal void UpdateUserInfo(UserInfoProxyVO userInfo)
        {
            try
            {
                sqlProxy.UpdateUserInfo
                (
                new EncryptionService().GetEncryptedKey(this.EncryptionSeed, this.sqlProxy.GetTime()),
                this.ServiceURL,
                userInfo.UsersVO
                );
            }
            catch (Exception)
            {
                throw;
            }
        } 
        #endregion
        #region SettingInfo & MyCompanyInfo
        public CommonSettingProxyVO GetCommonSettings() 
        {
            CommonSettingProxyVO cpv= new CommonSettingProxyVO();
            cpv.CommonSettings = sqlProxy.GetCommonSettingInfo(new EncryptionService().GetEncryptedKey(this.EncryptionSeed, DateTime.Now),this.ServiceURL);
            return cpv;
        }
        public bool SetCommonSettings(CommonSettingProxyVO CommonSettingProxyVO) 
        {
            try
            {
                int i = sqlProxy.SetCommonSettingInfo(new EncryptionService().GetEncryptedKey(this.EncryptionSeed, DateTime.Now), this.ServiceURL, CommonSettingProxyVO.CommonSettings);
                if (i == 0)
                {
                    throw new Exception();
                }
                else
                {
                    return true;
                }
            }
            catch (Exception)
            {
                
                return false;
            }
        }

        public MyCompanyProxyVO GetMyCompanyInfo()
        {
            MyCompanyProxyVO mpv = new MyCompanyProxyVO();
            mpv.MyCompany = sqlProxy.GetMyCompanyInfo(new EncryptionService().GetEncryptedKey(this.EncryptionSeed, DateTime.Now), this.ServiceURL);
            return mpv;
        }
        public bool SetMyCompanyInfo(MyCompanyProxyVO MyCompanyProxyVO)
        {
            try
            {
                int i = sqlProxy.SetMyCompanyInfo(new EncryptionService().GetEncryptedKey(this.EncryptionSeed, DateTime.Now), this.ServiceURL, MyCompanyProxyVO.MyCompany);
                if (i == 0)
                {
                    throw new Exception();
                }
                else
                {
                    return true;
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        #endregion
        #region Goods
        internal IList<GoodsListProxyVO> GetGoodList
            (
            int page,
            int rowCount,
            string goodName,
            string goodSubName,
            string goodNickName,
            string goodMaker
            ) 
        {
            IList<GoodsListProxyVO> GoodsListProxy = new List<GoodsListProxyVO>();
            IList<GoodsListVO> GoodsList =
                sqlProxy.GetGoodsList
                (
                new EncryptionService().GetEncryptedKey(this.EncryptionSeed,sqlProxy.GetTime()),
                this.ServiceURL,
                page,
                rowCount,
                goodName,
                goodSubName,
                goodNickName,
                goodMaker
                );
            long TotalRowCount = 
            this.sqlProxy.GetGoodsCount
                (
                new EncryptionService().GetEncryptedKey(this.EncryptionSeed,sqlProxy.GetTime()),
                this.ServiceURL,
                goodName,
                goodSubName,
                goodNickName,
                goodMaker                                                                                                           
                );
            foreach (GoodsListVO vo in GoodsList)
            {
                GoodsListProxyVO ProxyVO = new GoodsListProxyVO();
                ProxyVO.GoodsListVO = vo;
                ProxyVO.TotalRowCount = TotalRowCount;
                GoodsListProxy.Add(ProxyVO);
            }
            return GoodsListProxy;
        }//End of GetGoodList


        internal GoodDetailProxyVO GetGoodDetail(string goodPK) 
        {
            Int64 lngGoodPK = Convert.ToInt64(goodPK);
            GoodsDetail detail =  sqlProxy.GetGoodDetail(new EncryptionService().GetEncryptedKey(this.EncryptionSeed,sqlProxy.GetTime()),this.ServiceURL,lngGoodPK);

            GoodDetailProxyVO detailProxy = new GoodDetailProxyVO();
            detailProxy.GoodsDetail = detail;

            return detailProxy;
        }//End of GetGoodDetail
        #endregion
    }
}
