using libHitpan5.VO.CommonVO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using WebServiceServer.WebServiceVO.Users;
using WebServiceServer.Enums;
using libHitpan5.VO;
using libHitpan5.VO.CommonVO.UserInfo;
namespace libHitpan5.Controller.Common.UserAuthValidator
{
    /// <summary>
    /// 사용자의 권한,사용자 유형 등과 파라미터로 주어진 '필요한 권한'을 비교
    /// </summary>
    class UserValidator
    {
        private UserInfoProxyVO userInfo;

        /// <summary>
        /// 사용자정보 객체
        /// </summary>
        /// <param name="userInfo"></param>
        public UserValidator(UserInfoProxyVO userInfo)
        {
            // TODO: Complete member initialization
            this.userInfo = userInfo;
        }
        internal bool CheckAuth(UserAuthProxyVO RequiredAuth)
        {                      
            if (userInfo.UsersVO.UserType ==사용자등급.관리자)
            {
                return true;
            }
            UserAuthProxyVO userAuth = new UserAuthProxyVO();
            userAuth.UserAuth = this.userInfo.UsersVO.UserAuth;
            bool isValid = true;
            foreach (var prop in typeof(UserAuth).GetProperties())
            {
                try
                {
                    if ((int)RequiredAuth[prop.Name] > (int)userAuth[prop.Name])
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
