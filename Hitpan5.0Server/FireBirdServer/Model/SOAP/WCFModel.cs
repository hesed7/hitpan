using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SOAP;
using SOAP.Conf;
using System.ServiceModel;
using WebService.Delegate;
using WebService.WebService;
namespace WebService.Model.SOAPService
{
    internal class WCFModel
    {
        private SOAPManager soapService { get; set; }
        private string ServiceURL { get; set; }
        private string ServiceNameSpace { get; set; }
        private ServiceHost host = null;
        private deleErrReporter errReporter { get; set; }
        #region ctor
        /// <summary>
        /// 생성과 동시에 서비스생성
        /// </summary>
        /// <param name="errReporter"></param>
        /// <param name="ServiceURL"></param>
        /// <param name="ServiceNameSpace"></param>
        internal WCFModel
            (
            deleErrReporter errReporter,
            string ServiceURL,
            String ServiceNameSpace,
            MessageCredentialType MessageSecurityType,
            string certPath,
            string certPassword,
            deleSecurityCustomizer SecurityCustomizer,
            Type serviceType,
            Type InterfaceType
            )
        {
            this.errReporter = errReporter;
            this.ServiceURL = ServiceURL;
            this.ServiceNameSpace = ServiceNameSpace;
            this.host = new ServiceHost(serviceType);
            this.host = SecurityCustomizer(this.host);
            try
            {
                this.soapService = new SOAPManager
                    (
                    ref host,
                    SOAPServerType.winform,
                    new Uri(ServiceURL),
                    ServiceNameSpace,
                    ServiceBindingType.WSDualHttpBinding,
                    MessageSecurityType,
                    certPath,
                    certPassword,
                    serviceType,
                    InterfaceType,
                    errReporter
                    );
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// 생성과 동시에 서비스생성
        /// </summary>
        /// <param name="errReporter"></param>
        /// <param name="ServiceURL"></param>
        /// <param name="ServiceNameSpace"></param>
        internal WCFModel(deleErrReporter errReporter, string ServiceURL, String ServiceNameSpace, Type serviceType, Type InterfaceType)
        {
            this.errReporter = errReporter;
            this.ServiceURL = ServiceURL;
            this.ServiceNameSpace = ServiceNameSpace;

            this.host = new ServiceHost(typeof(SQLWebService));
            try
            {
                this.soapService = new SOAPManager
                    (
                    ref this.host,
                    SOAPServerType.winform,
                    new Uri(ServiceURL),
                    ServiceNameSpace,
                    ServiceBindingType.WSHttpBinding,
                    typeof(SQLWebService),
                    typeof(ISQLWebService),
                    errReporter
                    );
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// 생성과 동시에 서비스생성
        /// </summary>
        /// <param name="errReporter"></param>
        /// <param name="ServiceURL"></param>
        /// <param name="ServiceNameSpace"></param>
        internal WCFModel(deleErrReporter errReporter, string ServiceURL, String ServiceNameSpace, object serviceInstance)
        {
            this.errReporter = errReporter;
            this.ServiceURL = ServiceURL;
            this.ServiceNameSpace = ServiceNameSpace;
            this.host = new ServiceHost(serviceInstance);
            try
            {
                this.soapService = new SOAPManager
                    (
                    ref this.host,
                    SOAPServerType.winform,
                    new Uri(ServiceURL),
                    ServiceNameSpace,
                    ServiceBindingType.WSDualHttpBinding,
                    serviceInstance,
                    errReporter
                    );
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// 생성과 동시에 서비스생성
        /// </summary>
        /// <param name="errReporter"></param>
        /// <param name="ServiceURL"></param>
        /// <param name="ServiceNameSpace"></param>
        internal WCFModel
            (
            deleErrReporter errReporter,
            string ServiceURL,
            String ServiceNameSpace,
            MessageCredentialType MessageSecurityType,
            string certPath,
            string certPassword,
            deleSecurityCustomizer SecurityCustomizer,
            object serviceInstance
            )
        {
            this.errReporter = errReporter;
            this.ServiceURL = ServiceURL;
            this.ServiceNameSpace = ServiceNameSpace;
            this.host = new ServiceHost(serviceInstance);
            this.host = SecurityCustomizer(this.host);
            try
            {
                this.soapService = new SOAPManager
                    (
                    ref this.host,
                    SOAPServerType.winform,
                    new Uri(ServiceURL),
                    ServiceNameSpace,
                    ServiceBindingType.WSDualHttpBinding,
                    MessageSecurityType,
                    certPath,
                    certPassword,
                    serviceInstance,
                    errReporter
                    );
            }
            catch (Exception)
            {

                throw;
            }
        } 
        #endregion

        internal void Dispose() 
        {
            soapService.EndSOAPService(ref this.host);
            soapService = null;
        }
    }
}
