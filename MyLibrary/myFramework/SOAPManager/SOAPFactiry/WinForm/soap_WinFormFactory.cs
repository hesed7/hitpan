using SOAP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using SOAP.Conf;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Configuration;
using System.ServiceModel.Security;
using System.Security.Cryptography;
using System.IO;
using System.ServiceModel.Dispatcher;
using System.Security.Cryptography.X509Certificates;
namespace SOAP.SOAPFactiry.WinForm 
{
    internal class soap_WinFormFactory : abSOAPFactory
    {
        private ServiceHost server = null;
        #region ctor
        /// <summary>
        /// 윈폼 상에서 웹서비스 구축
        /// </summary>
        /// <param name="bindType">바인드 타입</param>
        /// <param name="service">웹서비스로 제공할 객체의 타입 : 싱글톤 타입 안됨</param>
        public soap_WinFormFactory
            (
            ref ServiceHost server,
            Uri server_url,
            string NameSpace,
            Type serviceType,
            Type ServiceInterfaceType,
            ServiceBindingType bindType,
            deleErrReporter errReporter
            )
        {
            this.server = server;
            this.bindType = bindType;
            this.service = null;
            this.serviceType = serviceType;
            this.errReporter = errReporter;
            server.Faulted += delegate
            {
                this.server.Abort();
                this.server = new ServiceHost(serviceType);
                CreateService(server_url, NameSpace, ServiceInterfaceType);
            };
            CreateService(server_url, NameSpace, ServiceInterfaceType);
            server = this.server;
        }

        public soap_WinFormFactory
            (
            ref ServiceHost server,
            Uri server_url,
            string NameSpace,
            Type serviceType,
            Type ServiceInterfaceType,
            ServiceBindingType bindType,
            MessageCredentialType MessageCredentialType,
            string certificatePath,
            string certificatePassword,
            deleErrReporter errReporter
            )
        {
            this.server = server;
            // 인증서 설정
            SetCertificate(certificatePath,certificatePassword);
            this.bindType = bindType;
            this.service = null;
            this.serviceType = serviceType;
            this.errReporter = errReporter;
            server.Faulted += delegate
            {
                this.server.Abort();
                this.server = new ServiceHost(serviceType);
                CreateService(server_url, NameSpace, ServiceInterfaceType, MessageCredentialType);
            };
            CreateService(server_url, NameSpace, ServiceInterfaceType, MessageCredentialType);
            server = this.server;
        }


        /// <summary>
        /// 윈폼 상에서 웹서비스 구축
        /// </summary>
        /// <param name="bindType">바인드 타입</param>
        /// <param name="service">웹서비스로 제공할 싱글톤 객체</param>
        public soap_WinFormFactory
            (
            ref ServiceHost server,
            Uri server_url,
            string NameSpace,
            object service,
            ServiceBindingType bindType,
            deleErrReporter errReporter
            )
        {
            this.server = server;
            this.bindType = bindType;
            this.service = service;
            this.errReporter = errReporter;
            server.Faulted += delegate
            {
                this.server.Abort();
                this.server = new ServiceHost(service);
                CreateService(server_url, NameSpace);
            };
            CreateService(server_url, NameSpace);
            server = this.server;
        }

        /// <summary>
        /// 윈폼 상에서 웹서비스 구축
        /// </summary>
        /// <param name="bindType">바인드 타입</param>
        /// <param name="service">웹서비스로 제공할 싱글톤 객체</param>
        public soap_WinFormFactory
            (
            ref ServiceHost server,
            Uri server_url,
            string NameSpace,
            object service,
            ServiceBindingType bindType,
            MessageCredentialType MessageCredentialType,
            string certificatePath,
            string certificatePassword,
            deleErrReporter errReporter
            )
        {
            this.server = server;
            // 인증서 설정
            SetCertificate(certificatePath,certificatePassword);
            this.bindType = bindType;
            this.service = service;
            this.errReporter = errReporter;
            server.Faulted += delegate
            {
                this.server.Abort();
                this.server = new ServiceHost(service);
                CreateService(server_url, NameSpace, MessageCredentialType);
            };
            CreateService(server_url, NameSpace, MessageCredentialType);
            server = this.server;
        } 
        #endregion

        #region 서비스 생성
        /// <summary>
        /// 싱글턴 어트리뷰트를 사용하는 서비스를 wcf서버에 등록하기
        /// </summary>
        /// <param name="server_url"></param>
        /// <param name="NameSpace"></param>
        override protected void CreateService(Uri server_url, string NameSpace, MessageCredentialType MessageCredentialType)
        {
            //서버가 null일 경우는 그 즉시 생성하여 작업
            if (server == null)
            {
                server = new ServiceHost(service);
            }

            //URL중복 방지
            foreach (Uri url in server.BaseAddresses)
            {
                if (url == server_url)
                {
                    return;
                }
            }

            //HTTPS프로토콜 사용한 URL인지 판단
            bool useHTTPS = false;
            if (((server_url.AbsoluteUri).Replace(" ", string.Empty).Substring(0, 5).ToLower()).Contains("https"))
            {
                useHTTPS = true;
            }
            //웹서비스 오픈 준비
            try
            {
                //바인딩 설정
                Binding bind = SetBinding(base.bindType, MessageCredentialType);
                //메타데이터 작성 
                setMetaData(server, NameSpace, server_url, useHTTPS);
                //Address(A:server_url)Binding(B:bind)Contract(C:service) 설정()
                bind.Namespace = NameSpace;
                server.AddServiceEndpoint(this.service.GetType(), bind, server_url);
                //SetCertificate(CertificationPath);
                server.BeginOpen(new AsyncCallback(ServiceBeginOpen_Callback), server);
            }
            catch (Exception ex)
            {
                server.Close();
                server = null;
                throw ex;
            }
        }

        /// <summary>
        /// 싱글턴 어트리뷰트를 사용하는 서비스를 wcf서버에 등록하기
        /// </summary>
        /// <param name="server_url"></param>
        /// <param name="NameSpace"></param>
        override protected void CreateService(Uri server_url, string NameSpace)
        {
            //서버가 null일 경우는 그 즉시 생성하여 작업
            if (server == null)
            {
                server = new ServiceHost(service);
            }

            //URL중복 방지
            foreach (Uri url in server.BaseAddresses)
            {
                if (url == server_url)
                {
                    return;
                }
            }

            //HTTPS프로토콜 사용한 URL인지 판단
            bool useHTTPS = false;
            if (((server_url.AbsoluteUri).Replace(" ", string.Empty).Substring(0, 5).ToLower()).Contains("https"))
            {
                useHTTPS = true;
            }
            //웹서비스 오픈 준비
            try
            {
                //바인딩 설정
                Binding bind = base.SetBinding(base.bindType);

                //메타데이터 작성 
                setMetaData(server, NameSpace, server_url, useHTTPS);
                //Address(A:server_url)Binding(B:bind)Contract(C:service) 설정()
                bind.Namespace = NameSpace;
                server.AddServiceEndpoint(this.service.GetType(), bind, server_url);
                server.BeginOpen(new AsyncCallback(ServiceBeginOpen_Callback), server);
            }
            catch (Exception ex)
            {
                server.Close();
                server = null;
                throw ex;
            }
        }

        /// <summary>
        /// 인터페이스 타입으로 wcf서버에 서비스 등록하기
        /// 사용자ID정보로 인증되는 서비스 만든다
        /// </summary>
        /// <param name="server_url">서비스 주소</param>
        /// <param name="NameSpace">서비스 네임스페이스</param>
        /// <param name="ServiceInterfaceType">서비스 인터페이스의 타입</param>
        /// <param name="messageSecurityType">보안타입</param>
        override protected void CreateService(Uri server_url, string NameSpace, Type ServiceInterfaceType, MessageCredentialType MessageCredentialType)
        {
            //서버가 null일 경우는 그 즉시 생성하여 작업
            if (server == null)
            {
                server = new ServiceHost(this.serviceType);
            }

            //URL중복 방지
            foreach (Uri url in server.BaseAddresses)
            {
                if (url == server_url)
                {
                    return;
                }
            }

            //HTTPS프로토콜 사용한 URL인지 판단
            bool useHTTPS = false;
            if (((server_url.AbsoluteUri).Replace(" ", string.Empty).Substring(0, 5).ToLower()).Contains("https"))
            {
                useHTTPS = true;
            }
            //웹서비스 오픈 준비
            try
            {
                //바인딩 설정
                Binding bind = base.SetBinding(base.bindType, MessageCredentialType);
                //메타데이터 작성 
                setMetaData(server, NameSpace, server_url, useHTTPS);
                //Address(A:server_url)Binding(B:bind)Contract(C:service) 설정()
                bind.Namespace = NameSpace;
                server.AddServiceEndpoint(ServiceInterfaceType, bind, server_url);
                server.BeginOpen(new AsyncCallback(ServiceBeginOpen_Callback), server);
            }
            catch (Exception ex)
            {
                server.Close();
                server = null;
                throw ex;
            }
        } 

        /// <summary>
        /// 인터페이스 타입으로 wcf서버에 서비스 등록하기
        /// </summary>
        /// <param name="server_url">서비스 주소</param>
        /// <param name="NameSpace">서비스 네임스페이스</param>
        /// <param name="ServiceInterfaceType">서비스 인터페이스의 타입</param>
        /// <param name="messageSecurityType">보안타입</param>
        override protected void CreateService(Uri server_url, string NameSpace, Type ServiceInterfaceType)
        {
            //서버가 null일 경우는 그 즉시 생성하여 작업
            if (server == null)
            {
                server = new ServiceHost(this.serviceType);
            }

            //URL중복 방지
            foreach (Uri url in server.BaseAddresses)
            {
                if (url == server_url)
                {
                    return;
                }
            }

            //HTTPS프로토콜 사용한 URL인지 판단
            bool useHTTPS = false;
            if (((server_url.AbsoluteUri).Replace(" ", string.Empty).Substring(0, 5).ToLower()).Contains("https"))
            {
                useHTTPS = true;
            }
            //웹서비스 오픈 준비
            try
            {
                //바인딩 설정
                Binding bind = base.SetBinding(base.bindType);
                //메타데이터 작성 
                setMetaData(server, NameSpace, server_url, useHTTPS);
                //Address(A:server_url)Binding(B:bind)Contract(C:service) 설정()
                bind.Namespace = NameSpace;
                server.AddServiceEndpoint(ServiceInterfaceType, bind, server_url);
                server.BeginOpen(new AsyncCallback(ServiceBeginOpen_Callback), server);
            }
            catch (Exception ex)
            {
                server.Close();
                server = null;
                throw ex;
            }
        } 
        #endregion

        /// <summary>
        /// WSDL정보 생성 및 내보내기
        /// </summary>
        /// <param name="server"></param>
        /// <param name="UseHTTPS"></param>
        override protected void setMetaData(ServiceHost server, string NameSpace, Uri server_url, Boolean UseHTTPS)
        {
            server.Description.Namespace = NameSpace;
            ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
            smb.HttpGetEnabled = !UseHTTPS;
            smb.HttpsGetEnabled = UseHTTPS;
            smb.HttpGetUrl = server_url;
            smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
            try
            {
                server.Description.Behaviors.Add(smb);
            }
            catch (ArgumentException)
            {
                return;
            }
            catch (Exception)
            {
                throw;
            }

        }
        #region 콜백함수
        override protected void ServiceBeginOpen_Callback(IAsyncResult result)
        {
            try
            {
                ((ServiceHost)result.AsyncState).EndOpen(result);
            }
            catch (AddressAlreadyInUseException ae)
            {
                if (((ServiceHost)result.AsyncState).State == CommunicationState.Opening || ((ServiceHost)result.AsyncState).State == CommunicationState.Opened)
                {
                    ((ServiceHost)result.AsyncState).Close();
                }
                this.errReporter(ae);
                return;
            }
            catch (Exception ex)
            {
                this.errReporter(ex);
            }
        }

        #endregion 
        #region 서비스 변경
        override public void ChangeService(Uri server_url, string NameSpace, ServiceBindingType bindType, Type serviceType, Type InterfaceType)
        {
            //서버가 null일 경우는 그 즉시 생성하여 작업
            if (server == null)
            {
                server = new ServiceHost(serviceType);
            }
            else
            {
                server.Close();
                server = new ServiceHost(serviceType);
            }

            //URL중복 방지
            foreach (Uri url in server.BaseAddresses)
            {
                if (url == server_url)
                {
                    return;
                }
            }

            //HTTPS프로토콜 사용한 URL인지 판단
            bool useHTTPS = false;
            if (((server_url.AbsoluteUri).Replace(" ", string.Empty).Substring(0, 5).ToLower()).Contains("https"))
            {
                useHTTPS = true;
            }

            //웹서비스 Open준비
            try
            {
                //바인딩 설정
                Binding bind = base.SetBinding(bindType);

                //메타데이터 작성 
                setMetaData(server, NameSpace, server_url, useHTTPS);
                //Address(A:server_url)Binding(B:bind)Contract(C:service) 설정()
                bind.Namespace = NameSpace;
                server.AddServiceEndpoint(InterfaceType, bind, server_url);
                server.BeginOpen(new AsyncCallback(ServiceBeginOpen_Callback), server);
            }
            catch (Exception ex)
            {
                server.Close();
                server = null;
                throw ex;
            }
        }
        override public void ChangeService(Uri server_url, string NameSpace, ServiceBindingType bindType, object service)
        {
            //서버가 null일 경우는 그 즉시 생성하여 작업
            if (server == null)
            {
                server = new ServiceHost(service);
            }
            else
            {
                server.Close();
                server = new ServiceHost(service);
            }

            //URL중복 방지
            foreach (Uri url in server.BaseAddresses)
            {
                if (url == server_url)
                {
                    return;
                }
            }

            //HTTPS프로토콜 사용한 URL인지 판단
            bool useHTTPS = false;
            if (((server_url.AbsoluteUri).Replace(" ", string.Empty).Substring(0, 5).ToLower()).Contains("https"))
            {
                useHTTPS = true;
            }

            //웹서비스 Open준비
            try
            {
                //바인딩 설정
                Binding bind = base.SetBinding(bindType);
                //메타데이터 작성 
                setMetaData(server, NameSpace, server_url, useHTTPS);
                //Address(A:server_url)Binding(B:bind)Contract(C:service) 설정()
                bind.Namespace = NameSpace;
                server.AddServiceEndpoint(service.GetType(), bind, server_url);
                server.BeginOpen(new AsyncCallback(ServiceBeginOpen_Callback), server);
            }
            catch (Exception ex)
            {
                server.Close();
                server = null;
                throw ex;
            }
        } 
        #endregion
        override public void Dispose()
        {
            try
            {
                if (server != null)
                {
                    server.Close();
                    server = null;
                }
            }
            catch (CommunicationObjectFaultedException)
            {
                server = null;
            }
            catch (CommunicationObjectAbortedException)
            {
                server = null;
            }
            catch (ObjectDisposedException)
            {
                server = null;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public override void Dispose(ref ServiceHost server)
        {
            Dispose();
            if (server!=null)
            {
                server.Close();
            }
        }


        #region 인증문제
        /// <summary>
        /// 인증서를 읽어서 그 정보를 객체화 하여 서비스에 적용한다
        /// </summary>
        /// <param name="CertificationPath">인증서 경로</param>
        /// <param name="cerPassword">인증서 암호</param>
        protected override void SetCertificate(string CertificationPath, string cerPassword)
        {
            X509Certificate2 cer = new X509Certificate2(File.ReadAllBytes(CertificationPath), cerPassword);
            server.Credentials.ServiceCertificate.Certificate = cer;
        }
        #endregion









    }
    /// <summary>
    /// 유저의 권한을 확인하는 메서드를 담을 델리게이트
    /// </summary>
    /// <param name="id"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    public delegate bool CheckClientAuth(string id,string password);
}
