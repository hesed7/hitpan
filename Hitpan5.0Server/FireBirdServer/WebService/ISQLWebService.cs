using System;
using System.ServiceModel;
using System.Collections.Generic;
using System.Collections.Specialized;
using WebService.WebServiceVO.Users;
namespace WebService.WebService
{
    [ServiceContract] 
    public interface ISQLWebService
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
    }
}
