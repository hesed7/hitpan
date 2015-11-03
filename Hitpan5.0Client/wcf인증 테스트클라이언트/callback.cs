using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using  wcf인증_테스트클라이언트.ServiceReference1;
namespace wcf인증_테스트클라이언트
{
    class callback :ISQLWebServiceCallback
    {
        public void OnJobEnd(string message)
        {
            Console.WriteLine(message);
        }
    }
}
