using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IdentityModel;
using System.ServiceModel;
namespace wcf인증테스트서버
{
    [ServiceBehavior(
        IncludeExceptionDetailInFaults=true
        )]
    class HelloWorld : IHelloWorld
    {       
        public string SayHello()
        {
            return "Hello "+ OperationContext.Current.ServiceSecurityContext.PrimaryIdentity.Name;
        }
    }
}
