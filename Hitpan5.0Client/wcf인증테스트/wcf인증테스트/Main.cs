using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace wcf인증테스트
{
    public class Main
    {
        public Main()
        {
            using (ServiceHost serviceHost = new ServiceHost(typeof(IService1))) 
            { 
                serviceHost.Open();
            }
        }
    }
}
