using System;
using System.ServiceModel;
using System.Collections.Generic;
using System.Collections.Specialized;
namespace WebService.WebService
{
    [ServiceContract] 
    public interface ISQLWebService
    {
        [OperationContract]
        string GetData(string AuthKey, string query, string serviceURL);
        [OperationContract]
        string GetSQLPlan(string query, string serviceURL);
        [OperationContract]
        DateTime GetTime();
        [OperationContract(IsOneWay = true)]
        void RegistQuery(string AuthKey, string query, string serviceURL);
        [OperationContract(IsOneWay=true)]
        void RegistQueryBlock(string AuthKey, StringCollection QueryBlock, string serviceURL);
    }
}
