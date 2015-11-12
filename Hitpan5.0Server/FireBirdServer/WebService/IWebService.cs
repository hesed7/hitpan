using System;
using System.ServiceModel;
using System.Collections.Generic;
using System.Collections.Specialized;
using WebServiceServer.WebServiceVO.Users;
using WebServiceServer.WebServiceVO.Settings;
using WebServiceServer.WebServiceVO.Goods;
namespace WebServiceServer.webService
{
    [ServiceContract] 
    public interface IWebService
    {
        [OperationContract]
        string GetData(string AuthKey, string query, string serviceURL);
        [OperationContract]
        DateTime GetTime();
        [OperationContract(IsOneWay = true)]
        void RegistQuery(string AuthKey, string query, string serviceURL);
        [OperationContract(IsOneWay=true)]
        void RegistQueryBlock(string AuthKey, StringCollection QueryBlock, string serviceURL);
        [OperationContract]
        UsersVO UserLogIn(string AuthKey, string serviceURL, string id, string password);
        [OperationContract]
        UsersVO GetUserInfo(string AuthKey, string serviceURL, string id);
        [OperationContract]
        UsersVO[] GetUsersInfo(string AuthKey, string serviceURL);
        [OperationContract]
        int UpdateUserInfo(string AuthKey, string serviceURL,UsersVO userInfo) ;
        [OperationContract]
        int InsertUserInfo(string AuthKey, string serviceURL, UsersVO userInfo);
        [OperationContract]
        MyCompany GetMyCompanyInfo(string AuthKey, string serviceURL);
        [OperationContract]
        int SetMyCompanyInfo(string AuthKey, string serviceURL,MyCompany myCompanyInfo);
        [OperationContract]
        CommonSettings GetCommonSettingInfo(string AuthKey, string serviceURL);
        [OperationContract]
        int SetCommonSettingInfo(string AuthKey, string serviceURL, CommonSettings CommonSettings);
        [OperationContract]
        long GetGoodsCount
                    (
                    string AuthKey,
                    string serviceURL,
                    string good_name,
                    string good_subName,
                    string good_NickName,
                    string good_maker
                    );
        [OperationContract]
        IList<GoodsListVO> GetGoodsList
            (
            string AuthKey,
            string serviceURL,
            int page,
            int rowCount,
            string good_name,
            string good_subName,
            string good_NickName,
            string good_maker
            );
        [OperationContract]
        GoodsDetail GetGoodDetail(string AuthKey, string serviceURL, long good_pk);
        [OperationContract]
        int InsertGood(string AuthKey, string serviceURL, GoodsDetail goodInfo);
        [OperationContract]
        int UpdateGood(string AuthKey, string query, string serviceURL, GoodsDetail goodInfo);
        [OperationContract]
        int DeleteGood(string AuthKey, string query, string serviceURL, long goodIDX);
    }
}
