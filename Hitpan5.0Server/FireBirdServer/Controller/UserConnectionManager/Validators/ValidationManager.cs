using WebService.Controller.UserConnectionManager.Validators.UserName;
using WebService.Delegate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Security;
using System.Text;

namespace WebService.Controller.UserConnectionManager.Validators
{
    class ValidationManager
    {
        private string ServiceURL { get; set; }
        private MessageCredentialType messageCredentialType { get; set; }
        public ValidationManager(string ServiceURL, MessageCredentialType messageCredentialType)
        {
            this.messageCredentialType = messageCredentialType;
            this.ServiceURL = ServiceURL;
        }
        /// <summary>
        /// 웹서비스 open전에 서비스호스트 객체의 메시지보안을 커스터마이징 하는 deleServiceCustomizer 반환
        /// </summary>
        /// <param name="messageCredentialType">
        /// 웹서비스 보안타입
        /// </param>
        /// <returns></returns>
        internal deleSecurityCustomizer GetSecurityCustomizer()
        {
            deleSecurityCustomizer ServiceCustomizer = null;
            switch (this.messageCredentialType)
            {
                case MessageCredentialType.Certificate:
                    break;
                case MessageCredentialType.IssuedToken:
                    break;
                case MessageCredentialType.UserName:
                    ServiceCustomizer = new deleSecurityCustomizer(ValidateUserID);
                    break;
                default:
                    break;
            }
            return ServiceCustomizer;
        }
        /// <summary>
        /// 유저아이디로 validate하는 경우에 서비스호스트를 커스터마이징할 메서드
        /// </summary>
        /// <param name="host"></param>
        /// <returns></returns>
        private ServiceHost ValidateUserID(ServiceHost host)
        {
            host.Credentials.UserNameAuthentication.UserNamePasswordValidationMode = UserNamePasswordValidationMode.Custom;
            host.Credentials.UserNameAuthentication.CustomUserNamePasswordValidator = new ID_Password_Validator(this.ServiceURL);
            return host;
        }
    }
}
