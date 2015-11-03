using SOAP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Security;
using System.Text;
using System.Threading;
using wcf인증테스트서버.UserID;
using System.ServiceModel.Description;
using System.IO;
using System.Security.Cryptography.X509Certificates;
namespace wcf인증테스트서버
{
    class Program
    {
        static SOAPManager soaper { get; set; }
        static void Main(string[] args)
        {
            int i = 0;
            ServiceHost host = new ServiceHost(typeof(HelloWorld));
            host.Credentials.UserNameAuthentication.UserNamePasswordValidationMode = UserNamePasswordValidationMode.Custom;
            host.Credentials.UserNameAuthentication.CustomUserNamePasswordValidator = new UserValidator();

            //X509Certificate2 certificate = new X509Certificate2(File.ReadAllBytes(@"F:\\test.pfx"),"1108");
            //host.Credentials.ServiceCertificate.Certificate = certificate;
            SettingSoap(ref host);
 

            Console.Read();
            soaper.EndSOAPService(ref host);
        }

        private static void SettingSoap(ref ServiceHost host)
        {
            soaper = new SOAPManager
                (
                ref host,
                SOAP.Conf.SOAPServerType.winform,
                new Uri("http://127.0.0.1:8080"),
                "http://모듈테스트.org",
                SOAP.Conf.ServiceBindingType.WSHttpBinding,
                MessageCredentialType.UserName,
                @"F:\프로그래밍관련\프로젝트\차세대 히트판\Hitpan5.0Server\HitPanSQLServicesServer\bin\Debug\HTPServer.pfx",
                "1108",
                typeof(HelloWorld),
                typeof(IHelloWorld),
                new deleErrReporter(GetErr) 
                );





            //soaper.SetServer(
            //    ref host,
            //    SOAP.Conf.SOAPServerType.winform,
            //    new Uri("http://127.0.0.1:9090"),
            //            "http://127.0.0.1:9090",
            //            "http://test.org",
            //    SOAP.Conf.ServiceBindingType.WSHttpBinding,
            //    MessageCredentialType.UserName,
            //    typeof(wcf인증테스트서버.HelloWorld),
            //    typeof(wcf인증테스트서버.IHelloWorld),
            //    new deleErrReporter(GetErr)                                                                                                                                           
            //    );
            while (true)
            {
                try
                {
                    Console.WriteLine("server..." + host.State);
                    if (host.State == CommunicationState.Opened || host.State == CommunicationState.Closed)
                    {
                        break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error :..." + ex.Message);
                    break;
                }
                Thread.Sleep(1000);
            }
            if (host!=null && host.State == CommunicationState.Opened)
            {
                Console.WriteLine("soapTestServer Act...Press Any key To Exit");
            }           
        }

        public static void GetErr(Exception ex) 
        {
            Console.WriteLine("\r\n{0}",ex.Message);
        }
    }
}
