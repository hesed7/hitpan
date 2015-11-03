using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using wcf인증_테스트클라이언트.ServiceReference1;
using System.ServiceModel;
namespace wcf인증_테스트클라이언트
{
    class Program
    {
        static void Main(string[] args)
        {
            using (DuplexChannelFactory<ISQLWebService> cfac = new DuplexChannelFactory<ISQLWebService>(new callback(), "WSDualHttpBinding_ISQLWebService"))
            {
                cfac.Credentials.UserName.UserName = "admin";
                cfac.Credentials.UserName.Password = "1234";
                
                
                ISQLWebService svc = cfac.CreateChannel();

                try
                {
                    Console.WriteLine(svc.GetTime());
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }



                Console.Read();
            }
        }
    }
}
