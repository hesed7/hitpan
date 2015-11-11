using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Permissions;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Windows.Forms;
using libHitpan5.Model.EncryptionModel;
using System.ServiceModel.Security;
using System.ServiceModel.Channels;
using System.IdentityModel;
namespace libHitpan5.Model.WebServiceModel
{
    /// <summary>
    /// 웹서비스 프록시의 생성,해제,관리
    /// </summary>
    public class SQLWebServiceModel
    {
        /// <summary>
        /// 웹서비스 통신연결을 제공하는 객체
        /// </summary>
        private ChannelFactory<IWebService> WebServiceChannel { get; set; }
        public string ServiceURL { get; set; }
        public SQLWebServiceModel(string ServiceURL)
	    {
            this.ServiceURL = ServiceURL;

            WSHttpBinding binding = new WSHttpBinding(SecurityMode.None);
            WebServiceChannel = new ChannelFactory<IWebService>
            (
                new ServiceEndpoint(ContractDescription.GetContract(typeof(IWebService)),
                binding,
                new EndpointAddress(this.ServiceURL))
            );
	    }


        public SQLWebServiceModel(MessageCredentialType MessageCredentialType, string ServiceURL)
        {
            this.ServiceURL = ServiceURL;

            WSDualHttpBinding binding = new WSDualHttpBinding(WSDualHttpSecurityMode.Message);
            //끝점
            EndpointAddress EndpointURL = new EndpointAddress
                (
                new Uri(this.ServiceURL)
                );
            
            //보안설정
            binding.Security.Message.ClientCredentialType = MessageCredentialType;
            WebServiceChannel = new ChannelFactory<IWebService>
                (
                    new ServiceEndpoint
                        (
                        ContractDescription.GetContract(typeof(IWebService)),
                        binding,
                        EndpointURL
                        )
                );
            //인증서 유효성 검사 안하게 한다
            WebServiceChannel.Credentials.ServiceCertificate.Authentication.CertificateValidationMode =
                X509CertificateValidationMode.None;
        }
        internal IWebService GetWebServiceProxy() 
        {
            try
            {
                return CallWebservice(this.ServiceURL, this.WebServiceChannel);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        internal IWebService GetWebServiceProxy(string ServerID,String ServerPassword)
        {
            try
            {
                WebServiceChannel.Credentials.UserName.UserName = ServerID;
                WebServiceChannel.Credentials.UserName.Password = ServerPassword;
                return CallWebservice(this.ServiceURL, this.WebServiceChannel);
            }
            catch (Exception)
            {

                throw;
            }
        }


        internal void Dispose()
        {
            if (this.WebServiceChannel.State==CommunicationState.Opened || this.WebServiceChannel.State==CommunicationState.Opening || this.WebServiceChannel.State==CommunicationState.Created)
            {
                this.WebServiceChannel.Close();
            }            
        }


        /// <summary>
        /// 콜백객체를 사용할 경우의 웹서비스 프록시 반환
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
        private IWebService CallWebserviceUsingCallback(string webServiceUrl, DuplexChannelFactory<IWebService> WebServiceChannel, InstanceContext ClientCallback)
        {
            EndpointAddress epa = new EndpointAddress(
                    new Uri(webServiceUrl),
                    new DnsEndpointIdentity(System.IdentityModel.Claims.Claim.CreateDnsClaim("HTPSecureManager"))
                );

            IWebService webservice = WebServiceChannel.CreateChannel
                (
                ClientCallback,
                epa
                );           
            return webservice;
        }

        /// <summary>
        /// 콜백객체를 사용하지 않을 때의 웹서비스 프록시 반환
        /// </summary>
        /// <param name="p"></param>
        /// <param name="channelFactory"></param>
        /// <returns></returns>
        private IWebService CallWebservice(string webServiceUrl, ChannelFactory<IWebService> channelFactory)
        {
            EndpointAddress epa = new EndpointAddress(
                    new Uri(webServiceUrl),
                    new DnsEndpointIdentity(System.IdentityModel.Claims.Claim.CreateDnsClaim("HTPSecureManager"))
                );

            IWebService webservice = WebServiceChannel.CreateChannel
                (
                epa                
                );
            return webservice;
        }
    }
}
