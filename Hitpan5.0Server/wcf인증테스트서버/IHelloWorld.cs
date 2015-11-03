using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace wcf인증테스트서버
{
    [ServiceContract]
    interface IHelloWorld
    {
        [OperationContract]
        string SayHello();
    }
}
