using System;
using System.ServiceModel;
using System.Collections.Generic;
using System.Collections.Specialized;
using WebServiceServer.WebServiceVO.Users;
using WebServiceServer.WebServiceVO.Settings;
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
    }
}
