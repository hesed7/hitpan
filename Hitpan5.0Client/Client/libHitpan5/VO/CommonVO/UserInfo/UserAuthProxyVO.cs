using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebServiceServer.Enums;
using WebServiceServer.WebServiceVO.Users;
namespace libHitpan5.VO.CommonVO.UserInfo
{
    public class UserAuthProxyVO
    {
        public UserAuth UserAuth { get; set; }
        public UserAuthProxyVO()
        {
            this.UserAuth = new UserAuth();
        }
        public object this[string key]
        {
            get
            {
                object val = null;
                switch (key)
                {
                    case "설정관리": { val = UserAuth.설정관리; break; }
                    case "계정관리": { val = UserAuth.계정관리; break; }
                    case "표준관리": { val = UserAuth.표준관리; break; }
                    case "양식정보": { val = UserAuth.양식정보; break; }
                    case "고객정보": { val = UserAuth.고객정보; break; }
                    case "상품정보": { val = UserAuth.상품정보; break; }
                    case "일정관리": { val = UserAuth.일정관리; break; }
                    case "견적관리": { val = UserAuth.견적관리; break; }
                    case "매입관리": { val = UserAuth.매입관리; break; }
                    case "판매관리": { val = UserAuth.판매관리; break; }
                    case "재고관리": { val = UserAuth.재고관리; break; }
                    case "회계관리": { val = UserAuth.회계관리; break; }
                    case "인사관리": { val = UserAuth.인사관리; break; }
                    case "데이터관리": { val = UserAuth.데이터관리; break; }
                    case "나의정보관리": { val = UserAuth.나의정보관리; break; }
                    case "세금계산서관리": { val = UserAuth.세금계산서관리; break; }
                    case "에프터서비스관리": { val = UserAuth.에프터서비스관리; break; }
                    default:
                        break;
                }//End of switch
                return val;
            }
            set
            {
                switch (key)
                {
                    case "설정관리": { UserAuth.설정관리 = (사용자권한)value; break; }
                    case "계정관리": { UserAuth.계정관리 = (사용자권한)value; break; }
                    case "표준관리": { UserAuth.표준관리 = (사용자권한)value; break; }
                    case "양식정보": { UserAuth.양식정보 = (사용자권한)value; break; }
                    case "고객정보": { UserAuth.고객정보 = (사용자권한)value; break; }
                    case "상품정보": { UserAuth.상품정보 = (사용자권한)value; break; }
                    case "일정관리": { UserAuth.일정관리 = (사용자권한)value; break; }
                    case "견적관리": { UserAuth.견적관리 = (사용자권한)value; break; }
                    case "매입관리": { UserAuth.매입관리 = (사용자권한)value; break; }
                    case "판매관리": { UserAuth.판매관리 = (사용자권한)value; break; }
                    case "재고관리": { UserAuth.재고관리 = (사용자권한)value; break; }
                    case "회계관리": { UserAuth.회계관리 = (사용자권한)value; break; }
                    case "인사관리": { UserAuth.인사관리 = (사용자권한)value; break; }
                    case "데이터관리": { UserAuth.데이터관리 = (사용자권한)value; break; }
                    case "나의정보관리": { UserAuth.나의정보관리 = (사용자권한)value; break; }
                    case "세금계산서관리": { UserAuth.세금계산서관리 = (사용자권한)value; break; }
                    case "에프터서비스관리": { UserAuth.에프터서비스관리 = (사용자권한)value; break; }
                    default:
                        break;
                }//End of switch            
            }
        }
    }
}
