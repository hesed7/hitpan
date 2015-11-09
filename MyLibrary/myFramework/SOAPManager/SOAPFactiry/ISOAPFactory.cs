using SOAP.Conf;
using System;
using System.ServiceModel;
namespace SOAP.SOAPFactiry
{
    /// <summary>
    /// 웹서비스 만드는 객체
    /// 웹서비스로 제공될 객체클래스는
    /// [ServiceContract],[OperationContract] 어트리뷰트가 반드시 붙어 있어야 한다
    /// [ServiceContract] : 클래스
    /// [OperationContract] : 메서드
    /// </summary>
    interface ISOAPFactory
    {
        void Dispose(ref ServiceHost host);
        void Dispose();
        /// <summary>
        /// 팩토리객체 생성시에 입력한 정보를 전부 리셋하고 새로운 정보로 웹서비스 생성
        /// </summary>
        /// <param name="server_url">웹서비스(WSDL) 접근 URL</param>
        /// <param name="NameSpace">웹서비스 구분 네임스페이스</param>
        /// <param name="bindType">웹서비스 바인딩 타입</param>
        /// <param name="service">웹서비스로 제공될 객체의 타입(싱글톤 객체이면 안됨)</param>
        void ChangeService(Uri server_url, string NameSpace,ServiceBindingType bindType, Type service,Type InterfaceType);
        /// <summary>
        /// 팩토리객체 생성시에 입력한 정보를 전부 리셋하고 새로운 정보로 웹서비스 생성
        /// </summary>
        /// <param name="server_url">웹서비스(WSDL) 접근 URL</param>
        /// <param name="NameSpace">웹서비스 구분 네임스페이스</param>
        /// <param name="bindType">웹서비스 바인딩 타입</param>
        /// <param name="service">웹서비스로 제공될 객체(싱글톤 객체만 가능)</param>
        void ChangeService(Uri server_url, string NameSpace, ServiceBindingType bindType, object service);
    }
}
