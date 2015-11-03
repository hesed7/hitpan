using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace wcf인증테스트
{
    // 참고: "리팩터링" 메뉴에서 "이름 바꾸기" 명령을 사용하여 코드 및 config 파일에서 인터페이스 이름 "IService1"을 변경할 수 있습니다.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        string GetData(int value);

        [OperationContract]
        string SayHello();
    }

    [ServiceBehavior]
    class Service1 : IService1
    {

        public string GetData(int value)
        {
            throw new NotImplementedException();
        }

        public string SayHello()
        {
            return "Hello";
        }
    }
}
