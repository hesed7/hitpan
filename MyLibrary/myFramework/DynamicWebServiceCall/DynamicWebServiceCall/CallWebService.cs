using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Security.Permissions;
using System.ServiceModel;
using System.ServiceModel.Description;
using SQLiteManager.WebService;
namespace DynamicWebServiceCall
{
    /// <summary>
    /// 웹서비스 동적 호출
    /// </summary>
    public class CallWebService
    {
        public CallWebService()
        {
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="webServiceUrl"></param>
        /// <param name="ClientCallback">
        /// IWebServiceCallback을 구현한 클라이언트 측의 객체를 래핑한 InstanceContext객체
        /// EX)
        /// WebServiceCallback callback = new WebServiceCallback();
        /// InstanceContext ctx = new InstanceContext(callback); 에서 ctx 
        /// </param>
        /// <returns>
        /// 채널이 연결된 웹서비스객체
        /// </returns>
        public SQLWebService CallWebserviceUsingCallback(string webServiceUrl, InstanceContext ClientCallback)
        {
            DuplexChannelFactory<SQLWebService> channel = new DuplexChannelFactory<SQLWebService>
                (
                    ClientCallback, 
                    new ServiceEndpoint(ContractDescription.GetContract(typeof(SQLWebService)),new WSDualHttpBinding(WSDualHttpSecurityMode.Message),new EndpointAddress(webServiceUrl))
                );
            SQLWebService webservice = channel.CreateChannel();
            return webservice;
        }
    }
}
