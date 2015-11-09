using SOAP;
using SOAP.Conf;
using SOAP.SOAPFactiry;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Security;
using System.Text;

namespace SOAP.SOAPFactiry
{
    abstract internal class abSOAPFactory :ISOAPFactory
    {
        protected ServiceBindingType bindType { get; set; }
        protected object service { get; set; }
        protected Type serviceType { get; set; }
        protected deleErrReporter errReporter { get; set; }


        #region 인증문제
        /// <summary>
        /// 경로에 있는 인증서를 읽어서 세팅
        /// </summary>
        /// <param name="CertificationPath"></param>
        abstract protected void SetCertificate(string CertificationPath, string cerPassword);
        #endregion
        #region 메시지 보안이 적용된 바인딩을 제공
        /// <summary>
        /// 바인딩을 세팅
        /// </summary>
        /// <param name="messageSecurityType"></param>
        /// <returns></returns>
        protected Binding SetBinding(ServiceBindingType bindType, MessageCredentialType MessageCredentialType)
        {
            Binding bind = null;
            switch (bindType)
            {
                case ServiceBindingType.BasicHttpBinding:
                    BasicHttpBinding Basic = new BasicHttpBinding(BasicHttpSecurityMode.Message);
                    Basic.Security.Message.ClientCredentialType = BasicHttpMessageCredentialType.UserName;
                    Basic.MaxBufferPoolSize = long.MaxValue;
                    Basic.MaxBufferSize = int.MaxValue;
                    Basic.MaxReceivedMessageSize = int.MaxValue;
                    bind = Basic;
                    break;
                case ServiceBindingType.WSHttpBinding:
                    WSHttpBinding WSHttp = new WSHttpBinding(SecurityMode.Message);
                    WSHttp.Security.Message.ClientCredentialType = MessageCredentialType;
                    WSHttp.MaxBufferPoolSize = int.MaxValue;
                    WSHttp.MaxReceivedMessageSize = int.MaxValue;
                    bind = WSHttp;
                    break;
                case ServiceBindingType.WSDualHttpBinding:
                    WSDualHttpBinding WSDualHttp = new WSDualHttpBinding(WSDualHttpSecurityMode.Message);
                    WSDualHttp.Security.Message.ClientCredentialType = MessageCredentialType;
                    WSDualHttp.MaxBufferPoolSize = int.MaxValue;
                    WSDualHttp.MaxReceivedMessageSize = int.MaxValue;
                    bind = WSDualHttp;
                    break;
                case ServiceBindingType.NetTcpBinding:
                    NetTcpBinding NetTcp = new NetTcpBinding(SecurityMode.Message);
                    NetTcp.Security.Message.ClientCredentialType = MessageCredentialType;
                    NetTcp.MaxBufferPoolSize = int.MaxValue;
                    NetTcp.MaxBufferSize = int.MaxValue;
                    NetTcp.MaxReceivedMessageSize = int.MaxValue;
                    bind = NetTcp;
                    break;
                default:
                    BasicHttpBinding tmpBind = new BasicHttpBinding(BasicHttpSecurityMode.Message);
                    tmpBind.Security.Message.ClientCredentialType = BasicHttpMessageCredentialType.UserName;
                    tmpBind.MaxBufferPoolSize = int.MaxValue;
                    tmpBind.MaxBufferSize = int.MaxValue;
                    tmpBind.MaxReceivedMessageSize = int.MaxValue;
                    bind = tmpBind;
                    break;
            }
            return bind;
        }
        #endregion
        #region 메시지 보안이 적용되지 않은 바인딩을 제공
        /// <summary>
        /// 바인딩을 세팅
        /// </summary>
        /// <param name="messageSecurityType"></param>
        /// <returns></returns>
        protected Binding SetBinding(ServiceBindingType bindType)
        {
            Binding bind = null;
            switch (bindType)
            {
                case ServiceBindingType.BasicHttpBinding:
                    BasicHttpBinding Basic = new BasicHttpBinding(BasicHttpSecurityMode.None);
                    Basic.MaxBufferPoolSize = long.MaxValue;
                    Basic.MaxBufferSize = int.MaxValue;
                    Basic.MaxReceivedMessageSize = long.MaxValue;
                    bind = Basic;
                    break;
                case ServiceBindingType.WSHttpBinding:
                    WSHttpBinding WSHttp = new WSHttpBinding(SecurityMode.None);
                    WSHttp.MaxBufferPoolSize = int.MaxValue;
                    WSHttp.MaxReceivedMessageSize = int.MaxValue;
                    bind = WSHttp;
                    break;
                case ServiceBindingType.WSDualHttpBinding:
                    WSDualHttpBinding WSDualHttp = new WSDualHttpBinding(WSDualHttpSecurityMode.None);
                    WSDualHttp.MaxBufferPoolSize = int.MaxValue;
                    WSDualHttp.MaxReceivedMessageSize = int.MaxValue;
                    bind = WSDualHttp;
                    break;
                case ServiceBindingType.NetTcpBinding:
                    NetTcpBinding NetTcp = new NetTcpBinding(SecurityMode.None);
                    NetTcp.MaxBufferPoolSize = int.MaxValue;
                    NetTcp.MaxBufferSize = int.MaxValue;
                    NetTcp.MaxReceivedMessageSize = int.MaxValue;
                    bind = NetTcp;
                    break;
                default:
                    BasicHttpBinding tmpBind = new BasicHttpBinding(BasicHttpSecurityMode.None);
                    tmpBind.MaxBufferPoolSize = int.MaxValue;
                    tmpBind.MaxBufferSize = int.MaxValue;
                    tmpBind.MaxReceivedMessageSize = int.MaxValue;
                    bind = tmpBind;
                    break;
            }
            return bind;
        } 
        #endregion
        #region 서비스 구성
        /// <summary>
        /// 서비스의 인터페이스 타입으로 서비스 구성
        /// </summary>
        /// <param name="server_url"></param>
        /// <param name="NameSpace"></param>
        /// <param name="ServiceInterfaceType"></param>
        abstract protected void CreateService(Uri server_url, string NameSpace, Type ServiceInterfaceType);
        abstract protected void CreateService(Uri server_url, string NameSpace, Type ServiceInterfaceType, MessageCredentialType MessageCredentialType);
        /// <summary>
        /// 서비스의 인스턴스로 서비스 구성
        /// </summary>
        /// <param name="server_url"></param>
        /// <param name="NameSpace"></param>
        abstract protected void CreateService(Uri server_url, string NameSpace);
        abstract protected void CreateService(Uri server_url, string NameSpace, MessageCredentialType MessageCredentialType); 
        #endregion
        #region 서비스 변경
        abstract public void ChangeService(Uri server_url, string NameSpace, SOAP.Conf.ServiceBindingType bindType, Type service, Type InterfaceType);
        abstract public void ChangeService(Uri server_url, string NameSpace, SOAP.Conf.ServiceBindingType bindType, object service);    
        #endregion     
        #region 서비스 정보문서(WSDL) 구성
        abstract protected void setMetaData(ServiceHost server, string NameSpace, Uri server_url, Boolean UseHTTPS); 
        #endregion

        /// <summary>
        /// 서비스 비동기 시작시 콜백함수
        /// </summary>
        /// <param name="result"></param>
        abstract protected void ServiceBeginOpen_Callback(IAsyncResult result);
        #region 서비스 해제
        abstract public void Dispose();
        abstract public void Dispose(ref ServiceHost server); 
        #endregion
    }
}
