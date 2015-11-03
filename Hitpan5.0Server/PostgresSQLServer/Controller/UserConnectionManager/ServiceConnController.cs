using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using PostgresSQLServer.Model.SOAPService;
using System.ServiceModel;
using PostgresSQLServer.Delegate;
using PostgresSQLServer.WebService;
using SOAP;
using PostgresSQLServer.Controller.UserConnectionManager.Validators;
namespace PostgresSQLServer.Controller.UserConnectionManager
{
    class ServiceConnController
    {
        internal IDictionary<string,WCFModel> ServiceDic { get; set; }

        #region ctor
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
            this.ServiceType = typeof(SQLWebService);
            this.ServiceInterface = typeof(ISQLWebService);
            this.errReporter = errReporter;
        }
        private ServiceConnController(deleErrReporter errReporter)
        {
            this.ServiceDic = new Dictionary<string, WCFModel>();
            this.serviceNameSpace = "http://GISHitpanWebService.org";
            this.ServiceType = typeof(SQLWebService);
            this.ServiceInterface = typeof(ISQLWebService);
            this.errReporter = errReporter;
            this.MessageCredentialType = MessageCredentialType.None;
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
        public static ServiceConnController getInstance()
        {
            if (instance == null)
            {
                throw new Exception("서비스컨트롤러가 초기화되지 않았습니다");
            }
            return instance;
        } 
        #endregion


        internal void AddServiceURL(string ServiceURL ) 
        {
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
        }
    }
}
