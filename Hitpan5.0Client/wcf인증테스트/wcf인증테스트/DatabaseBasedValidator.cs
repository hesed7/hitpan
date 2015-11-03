using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IdentityModel.Selectors;
namespace wcf인증테스트
{
    class DatabaseBasedValidator :UserNamePasswordValidator
    {
        public override void Validate(string userName, string password)
        {
            if (userName == string.Empty || password==string.Empty)
            {
                throw new Exception("아놔...");
            }
        }
    }
}
