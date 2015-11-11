using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Runtime.Serialization;
using WebServiceServer.Enums;
namespace WebServiceServer.WebServiceVO.Users
{
    [DataContract]
    public class UserAuth
    {
        [DataMember]
        public 사용자권한 설정관리 { get; set; }
        [DataMember]
        public 사용자권한 계정관리 { get; set; }
        [DataMember]
        public 사용자권한 표준관리 { get; set; }
        [DataMember]
        public 사용자권한 양식정보 { get; set; }
        [DataMember]
        public 사용자권한 고객정보 { get; set; }
        [DataMember]
        public 사용자권한 상품정보 { get; set; }
        [DataMember]
        public 사용자권한 일정관리 { get; set; }
        [DataMember]
        public 사용자권한 견적관리 { get; set; }
        [DataMember]
        public 사용자권한 매입관리 { get; set; }
        [DataMember]
        public 사용자권한 판매관리 { get; set; }
        [DataMember]
        public 사용자권한 재고관리 { get; set; }
        [DataMember]
        public 사용자권한 회계관리 { get; set; }
        [DataMember]
        public 사용자권한 인사관리 { get; set; }
        [DataMember]
        public 사용자권한 데이터관리 { get; set; }
        [DataMember]
        public 사용자권한 나의정보관리 { get; set; }
        [DataMember]
        public 사용자권한 세금계산서관리 { get; set; }
        [DataMember]
        public 사용자권한 에프터서비스관리 { get; set; }

        public 사용자권한 this[string key]
        {
            get
            {
                사용자권한 val = 사용자권한.관리불가;
                switch (key)
                {
                    case "설정관리": { val = this.설정관리; break; }
                    case "계정관리": { val = this.계정관리; break; }
                    case "표준관리": { val = this.표준관리; break; }
                    case "양식정보": { val = this.양식정보; break; }
                    case "고객정보": { val = this.고객정보; break; }
                    case "상품정보": { val = this.상품정보; break; }
                    case "일정관리": { val = this.일정관리; break; }
                    case "견적관리": { val = this.견적관리; break; }
                    case "매입관리": { val = this.매입관리; break; }
                    case "판매관리": { val = this.판매관리; break; }
                    case "재고관리": { val = this.재고관리; break; }
                    case "회계관리": { val = this.회계관리; break; }
                    case "인사관리": { val = this.인사관리; break; }
                    case "데이터관리": { val = this.데이터관리; break; }
                    case "나의정보관리": { val = this.나의정보관리; break; }
                    case "세금계산서관리": { val = this.세금계산서관리; break; }
                    case "에프터서비스관리": { val = this.에프터서비스관리; break; }
                    default:
                        break;
                }//End of switch
                return val;
            }
            set
            {
                switch (key)
                {
                    case "설정관리": { this.설정관리 = value; break; }
                    case "계정관리": { this.계정관리 = value; break; }
                    case "표준관리": { this.표준관리 = value; break; }
                    case "양식정보": { this.양식정보 = value; break; }
                    case "고객정보": { this.고객정보 = value; break; }
                    case "상품정보": { this.상품정보 = value; break; }
                    case "일정관리": { this.일정관리 = value; break; }
                    case "견적관리": { this.견적관리 = value; break; }
                    case "매입관리": { this.매입관리 = value; break; }
                    case "판매관리": { this.판매관리 = value; break; }
                    case "재고관리": { this.재고관리 = value; break; }
                    case "회계관리": { this.회계관리 = value; break; }
                    case "인사관리": { this.인사관리 = value; break; }
                    case "데이터관리": { this.데이터관리 = value; break; }
                    case "나의정보관리": { this.나의정보관리 = value; break; }
                    case "세금계산서관리": { this.세금계산서관리 = value; break; }
                    case "에프터서비스관리": { this.에프터서비스관리 = value; break; }
                    default:
                        break;
                }//End of switch            
            }
        }
    }
}
