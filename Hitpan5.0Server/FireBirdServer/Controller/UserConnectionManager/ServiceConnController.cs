using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using WebServiceServer.Model.SOAPService;
using System.ServiceModel;
using WebServiceServer.Delegate;
using WebServiceServer.webService;
using SOAP;
using WebServiceServer.Controller.UserConnectionManager.Validators;
namespace WebServiceServer.Controller.UserConnectionManager
{
    class ServiceConnController
    {
        internal IDictionary<string,WCFModel> ServiceDic { get; set; }

        #region ctor
        internal bool Activity { get; set; }
        private string serviceNameSpace { get; set; }
        private Type ServiceType { get; set; }
        private Type ServiceInterface { get; set; }
        private static ServiceConnController instance { get; set; }
        private deleErrReporter errReporter { get; set; }
        private MessageCredentialType MessageCredentialType { get; set; }
        private string certPath { get; set; }
        private string certPassword { get; set; }

        private ServiceConnController(deleErrReporter errReporter, MessageCredentialType MessageCredentialType, string certPath, string certPassword)
        {
            this.MessageCredentialType=MessageCredentialType;
            this.certPath=certPath;
            this.certPassword=certPassword;
            this.ServiceDic = new Dictionary<string, WCFModel>();
            this.serviceNameSpace = "http://GISHitpanWebService.org";
            this.ServiceType = typeof(WebService);
            this.ServiceInterface = typeof(IWebService);
            this.errReporter = errReporter;
            this.Activity = true;
        }
        private ServiceConnController(deleErrReporter errReporter)
        {
            this.ServiceDic = new Dictionary<string, WCFModel>();
            this.serviceNameSpace = "http://GISHitpanWebService.org";
            this.ServiceType = typeof(WebService);
            this.ServiceInterface = typeof(IWebService);
            this.errReporter = errReporter;
            this.MessageCredentialType = MessageCredentialType.None;
            this.Activity = true;
        }

        public static ServiceConnController getInstance(deleErrReporter errReporter, MessageCredentialType MessageSecurityType,string certPath, string certPassword)
        {
            if (instance == null)
            {
                instance = new ServiceConnController(errReporter, MessageSecurityType,certPath,certPassword);
            }
            return instance;
        }
        public static ServiceConnController getInstance(deleErrReporter errReporter)
        {
            if (instance == null)
            {
                instance = new ServiceConnController(errReporter);
            }
            return instance;
        }
        #endregion


        internal void AddServiceURL(string ServiceURL ) 
        {
            //잘못된 URL형식 걸러내기
            if (!(ServiceURL.Contains("http://")) || (ServiceURL.Replace("http://",string.Empty).Length==0))
            {
                return;
            }
            WCFModel wcf = null;
            if (this.MessageCredentialType==MessageCredentialType.None)
            {
                wcf = new WCFModel(this.errReporter, ServiceURL, this.serviceNameSpace,this.ServiceType, this.ServiceInterface);
            }
            else
            {
                deleSecurityCustomizer SecurityCustomizer = new ValidationManager(ServiceURL, this.MessageCredentialType).GetSecurityCustomizer();
                wcf = new WCFModel(this.errReporter,ServiceURL,this.serviceNameSpace,this.MessageCredentialType,this.certPath,this.certPassword,SecurityCustomizer,this.ServiceType,this.ServiceInterface);
            }
            ServiceDic.Add(ServiceURL, wcf);
        }
        internal void Dispose() 
        {
            foreach (string  ServiceURL in ServiceDic.Keys)
            {
                ServiceDic[ServiceURL].Dispose();
            }
            this.ServiceDic.Clear();
        }

        internal void Dispose(string ServiceURL)
        {
            //잘못된 URL형식 걸러내기
            if (!(ServiceURL.Contains("http://")) || (ServiceURL.Replace("http://", string.Empty).Length == 0))
            {
                return;
            }
            ServiceDic[ServiceURL].Dispose();
            ServiceDic.Remove(ServiceURL);
        }
    }
}
