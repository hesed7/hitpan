using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebServiceServer.Enums;
using WebServiceServer.WebServiceVO.Users;
namespace libHitpan5.VO
{
    public class UserInfoProxyVO
    {
        public UsersVO UsersVO { get; set; }
        public UserInfoProxyVO()
        {
            this.UsersVO = new UsersVO();
            this.UsersVO.UserAuth = new UserAuth();
        }
        public object this[string key]
        {
            get
            {
                object val = null;
                switch (key)
                {
                    case "UserID"  : { val = UsersVO.UserID; break; }
                    case "UserPassword": { val = UsersVO.UserPassword; break; }
                    case "UserType": { val = UsersVO.UserType; break; }
                    case "설정관리": { val = UsersVO.UserAuth.설정관리; break; }
                    case "계정관리": { val = UsersVO.UserAuth.계정관리; break; }
                    case "표준관리": { val = UsersVO.UserAuth.표준관리; break; }
                    case "양식정보": { val = UsersVO.UserAuth.양식정보; break; }
                    case "고객정보": { val = UsersVO.UserAuth.고객정보; break; }
                    case "상품정보": { val = UsersVO.UserAuth.상품정보; break; }
                    case "일정관리": { val = UsersVO.UserAuth.일정관리; break; }
                    case "견적관리": { val = UsersVO.UserAuth.견적관리; break; }
                    case "매입관리": { val = UsersVO.UserAuth.매입관리; break; }
                    case "판매관리": { val = UsersVO.UserAuth.판매관리; break; }
                    case "재고관리": { val = UsersVO.UserAuth.재고관리; break; }
                    case "회계관리": { val = UsersVO.UserAuth.회계관리; break; }
                    case "인사관리": { val = UsersVO.UserAuth.인사관리; break; }
                    case "데이터관리": { val = UsersVO.UserAuth.데이터관리; break; }
                    case "나의정보관리": { val = UsersVO.UserAuth.나의정보관리; break; }
                    case "세금계산서관리": { val = UsersVO.UserAuth.세금계산서관리; break; }
                    case "에프터서비스관리": { val = UsersVO.UserAuth.에프터서비스관리; break; }
                    default:
                        break;
                }//End of switch
                return val;
            }
            set
            {
                switch (key)
                {
                    case "UserID": { UsersVO.UserID = (string)value; break; }
                    case "UserPassword": { UsersVO.UserPassword = (string)value; break; }
                    case "UserType": { UsersVO.UserType = (사용자등급)value; break; }
                    case "설정관리": { UsersVO.UserAuth.설정관리 = (사용자권한)value; break; }
                    case "계정관리": { UsersVO.UserAuth.계정관리 = (사용자권한)value; break; }
                    case "표준관리": { UsersVO.UserAuth.표준관리 = (사용자권한)value; break; }
                    case "양식정보": { UsersVO.UserAuth.양식정보 = (사용자권한)value; break; }
                    case "고객정보": { UsersVO.UserAuth.고객정보 = (사용자권한)value; break; }
                    case "상품정보": { UsersVO.UserAuth.상품정보 = (사용자권한)value; break; }
                    case "일정관리": { UsersVO.UserAuth.일정관리 = (사용자권한)value; break; }
                    case "견적관리": { UsersVO.UserAuth.견적관리 = (사용자권한)value; break; }
                    case "매입관리": { UsersVO.UserAuth.매입관리 = (사용자권한)value; break; }
                    case "판매관리": { UsersVO.UserAuth.판매관리 = (사용자권한)value; break; }
                    case "재고관리": { UsersVO.UserAuth.재고관리 = (사용자권한)value; break; }
                    case "회계관리": { UsersVO.UserAuth.회계관리 = (사용자권한)value; break; }
                    case "인사관리": { UsersVO.UserAuth.인사관리 = (사용자권한)value; break; }
                    case "데이터관리": { UsersVO.UserAuth.데이터관리 = (사용자권한)value; break; }
                    case "나의정보관리": { UsersVO.UserAuth.나의정보관리 = (사용자권한)value; break; }
                    case "세금계산서관리": { UsersVO.UserAuth.세금계산서관리 = (사용자권한)value; break; }
                    case "에프터서비스관리": { UsersVO.UserAuth.에프터서비스관리 = (사용자권한)value; break; }
                    default:
                        break;
                }//End of switch            
            }
        }
    }
}
