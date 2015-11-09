using SOAP.Conf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using SOAP.SOAPFactiry;
using SOAP.SOAPFactiry.WinForm;
namespace SOAP
{
    /// <summary>
    /// 비동기 작업중 예외 발생시 이를 호출한 쪽에 알려주기 위함
    /// </summary>
    /// <param name="ex">예외객체</param>
    public delegate void deleErrReporter(Exception ex);
    public class SOAPManager
    {
        #region 생성자 및 초기화
        /// <summary>
        /// 비동기 작업중에 발생한 예외를 호출한 쪽에 알려줌
        /// </summary>
        private  deleErrReporter errReporter { get; set; }
        private ISOAPFactory SOAPFactory { get; set; }
        //private static SOAPManager instance { get; set; }
        #region 서비스할 객체를  객체로 받는 경우
        public SOAPManager
            (
            ref ServiceHost host,
            SOAPServerType soap_server,
            Uri ServiceURL,
            String NameSpace,
            ServiceBindingType bindType, 
            object service,             
            deleErrReporter errReporter)
        {
            this.errReporter = errReporter;
            switch (soap_server)
            {
                case SOAPServerType.winform:
                    SOAPFactory = new soap_WinFormFactory(ref host,ServiceURL,NameSpace, service,bindType, new deleErrReporter(ThrowErr));
                    break;
                case SOAPServerType.WAS:
                    break;
                case SOAPServerType.iis:
                    break;
                default:
                    break;
            }
        }
        public SOAPManager
            (
            ref ServiceHost host,
            SOAPServerType soap_server,
            Uri ServiceURL,
            String NameSpace,
            ServiceBindingType bindType,
            MessageCredentialType MessageCredentialType,
            string cerPath,
            string cerPassword,
            object service,
            deleErrReporter errReporter)
        {
            this.errReporter = errReporter;
            switch (soap_server)
            {
                case SOAPServerType.winform:
                    SOAPFactory = new soap_WinFormFactory(ref host,ServiceURL, NameSpace, service, bindType, MessageCredentialType, cerPath,cerPassword,new deleErrReporter(ThrowErr));
                    break;
                case SOAPServerType.WAS:
                    break;
                case SOAPServerType.iis:
                    break;
                default:
                    break;
            }
        }
        #endregion
        #region 서비스할 객체를 타입으로 받는 경우
        public SOAPManager
            (
            ref ServiceHost host,
            SOAPServerType soap_server,
            Uri ServiceURL,
            String NameSpace,
            ServiceBindingType bindType, 
            Type serviceType, 
            Type InterfaceType,
            deleErrReporter errReporter)
        {
            this.errReporter = errReporter;
            switch (soap_server)
            {
                case SOAPServerType.winform:
                    SOAPFactory = new soap_WinFormFactory(ref host,ServiceURL,NameSpace,serviceType,InterfaceType,bindType,new deleErrReporter(ThrowErr));
                    break;
                case SOAPServerType.WAS:
                    break;
                case SOAPServerType.iis:
                    break;
                default:
                    break;
            }
        }
        public SOAPManager
            (
            ref ServiceHost host,
            SOAPServerType soap_server,
            Uri ServiceURL,
            String NameSpace,
            ServiceBindingType bindType,
            MessageCredentialType MessageCredentialType,
            string cerPath,
            string cerPassword,
            Type serviceType,
            Type InterfaceType,
            deleErrReporter errReporter)
        {
            this.errReporter = errReporter;
            switch (soap_server)
            {
                case SOAPServerType.winform:
                    SOAPFactory = new soap_WinFormFactory(ref host,ServiceURL, NameSpace, serviceType, InterfaceType, bindType, MessageCredentialType,cerPath,cerPassword, new deleErrReporter(ThrowErr));
                    break;
                case SOAPServerType.WAS:
                    break;
                case SOAPServerType.iis:
                    break;
                default:
                    break;
            }
        }


        #endregion
        #endregion



        /// <summary>
        /// 현재 생성된 서비스를 삭제하고 서비스 다시 구성
        /// </summary>
        /// <param name="server_url">서비스 주소</param>
        /// <param name="NameSpace">네입스페이스</param>
        /// <param name="bindType">바인드 타입</param>
        /// <param name="serviceType">서비스 구상클래스의 타입</param>
        /// <param name="InterfaceType">서비스의 인터페이스 타입</param>
        public void ChangeService(Uri server_url, string NameSpace, ServiceBindingType bindType, Type serviceType,Type InterfaceType) 
        {
            SOAPFactory.ChangeService(server_url, NameSpace, bindType, serviceType, InterfaceType);
        }

        /// <summary>
        /// 현재 생성된 ServiceHost객체를 삭제하고
        /// 다시 생성
        /// </summary>
        /// <param name="server_url"></param>
        /// <param name="NameSpace"></param>
        /// <param name="bindType"></param>
        /// <param name="service">
        ///  서비스로 제공할 객체(싱글톤 객체)
        /// </param>
        public void ChangeService(Uri server_url, string NameSpace, ServiceBindingType bindType, object service)
        {
            SOAPFactory.ChangeService(server_url, NameSpace, bindType, service);
        }
        /// <summary>
        /// SOAP서비스 끝내기
        /// </summary>
        public  void EndSOAPService(ref ServiceHost host) 
        {
            if (SOAPFactory!=null)
            {
                SOAPFactory.Dispose(ref host);
            }          
        }
        public  void ThrowErr(Exception ex)
        {
            this.errReporter(ex);
        }
    }
}
