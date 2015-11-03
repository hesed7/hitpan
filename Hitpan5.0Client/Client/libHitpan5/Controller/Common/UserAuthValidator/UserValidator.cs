using libHitpan5.VO.CommonVO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using libHitpan5.enums;
using Newtonsoft.Json;
namespace libHitpan5.Controller.Common.UserAuthValidator
{
    /// <summary>
    /// 사용자의 권한,사용자 유형 등과 파라미터로 주어진 '필요한 권한'을 비교
    /// </summary>
    class UserValidator
    {
        private VO.UserInfo userInfo;

        /// <summary>
        /// 사용자정보 객체
        /// </summary>
        /// <param name="userInfo"></param>
        public UserValidator(VO.UserInfo userInfo)
        {
            // TODO: Complete member initialization
            this.userInfo = userInfo;
        }
        internal bool CheckAuth(UserAuth RequiredAuth)
        {                      
            if (userInfo.userType==사용자등급.관리자)
            {
                return true;
            }

            //사용자의 권한
            UserAuth userAuth=JsonConvert.DeserializeObject<UserAuth>(userInfo.userAuth);

            bool isValid = true;
            foreach (var prop in typeof(UserAuth).GetProperties())
            {
                try
                {
                    if (RequiredAuth[prop.Name] > userAuth[prop.Name])
                    {
                        isValid = false;
                        break;
                    }
                }
                catch (Exception)
                {
                    continue;
                }
            }//End of foreach
            return isValid;
        }
    }
}
