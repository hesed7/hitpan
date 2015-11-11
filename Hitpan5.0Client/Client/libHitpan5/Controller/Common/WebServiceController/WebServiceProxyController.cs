using libHitpan5.Model.WebServiceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace libHitpan5.Controller.Common.WebServiceController
{
    public class WebServiceProxyController
    {
        private SQLWebServiceModel webserviceModel { get; set; }
        internal IWebService proxy { get; set; }

        public WebServiceProxyController(string serviceURL)
        {
            webserviceModel = new SQLWebServiceModel(serviceURL);
            proxy = webserviceModel.GetWebServiceProxy();
        }
        public WebServiceProxyController(string id,string password, string serviceURL)
        {
            SetSecuredProxy(MessageCredentialType.UserName, serviceURL,new object[]{id,password});
        }


        public void DisposeWebService() 
        {
            webserviceModel.Dispose();
        }


        /// <summary>
        /// 보안 적용된 웹서비스 프록시를 세팅
        /// </summary>
        /// <param name="MessageCredentialType"></param>
        /// <param name="serviceURL"></param>
        /// <param name="param"></param>
        private void SetSecuredProxy(MessageCredentialType MessageCredentialType, string serviceURL, object[] param) 
        {
            webserviceModel = new SQLWebServiceModel(MessageCredentialType, serviceURL);
            this.proxy = null;
            switch (MessageCredentialType)
            {
                case MessageCredentialType.Certificate:
                    break;
                case MessageCredentialType.IssuedToken:
                    break;
                case MessageCredentialType.UserName:
                    this.proxy = webserviceModel.GetWebServiceProxy(param[0].ToString(), param[1].ToString());
                    break;
                default:
                    break;
            } 
             
        }
        
        
    }
}
