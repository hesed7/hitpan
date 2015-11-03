using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IdentityModel;
using System.IdentityModel.Selectors;
using System.ServiceModel;
namespace wcf인증테스트서버.UserID
{
    class UserValidator :UserNamePasswordValidator
    {

        public override void Validate(string userName, string password)
        {
            if (userName!="test" || password!="test")
            {
                throw new FaultException("아이디나 패스워드는 test만 가능!!!");
            }
        }
    }
}
