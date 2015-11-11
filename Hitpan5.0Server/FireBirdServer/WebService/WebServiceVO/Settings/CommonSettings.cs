using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Runtime.Serialization;
using WebServiceServer.Enums;
namespace WebServiceServer.WebServiceVO.Settings
{
    [DataContract]
    public class CommonSettings
    {
        //로컬파일에서 입력받는 세팅정보
        [DataMember]
        public 재고부족분_경고 재고부족분_경고 { get; set; }
        [DataMember]
        public 조회창크기 조회창크기 { get; set; }
        [DataMember]
        public 기본작업메뉴 기본작업메뉴 { get; set; }
        [DataMember]
        public 상품조회창에_매입가_표시 상품조회창에_매입가_표시 { get; set; }

        //DB에서 입력받는 세팅정보
        [DataMember]
        public 재고액평가법 재고액평가법 { get; set; }
        [DataMember]
        public 창고관리 창고관리 { get; set; }
        [DataMember]
        public 사원판매관리 사원판매관리 { get; set; }
        [DataMember]
        public 사원매입관리 사원매입관리 { get; set; }
        [DataMember]
        public 판매처리시_점검 판매처리시_점검 { get; set; }
        [DataMember]
        public 기본단가 기본단가 { get; set; }
        [DataMember]
        public 상품등록_안된_품목처리 상품등록_안된_품목처리 { get; set; }
        [DataMember]
        public 판매시_세트자료_조립해체 판매시_세트자료_조립해체 { get; set; }
        [DataMember]
        public 판매_매입분의_회계처리 판매_매입분의_회계처리 { get; set; }
        [DataMember]
        public 반품처리시_수발주정리 반품처리시_수발주정리 { get; set; }
        [DataMember]
        public 가용재고관리 가용재고관리 { get; set; }
        public int? this[string key]
        {
            get
            {
                int? i = null;
                switch (key)
                {
                    case "재고액평가법": { i = (int)this.재고액평가법; break; }
                    case "창고관리": { i = (int)this.창고관리; break; }
                    case "사원판매관리": { i = (int)this.사원판매관리; break; }
                    case "사원매입관리": { i = (int)this.사원매입관리; break; }
                    case "판매처리시_점검": { i = (int)this.판매처리시_점검; break; }
                    case "기본단가": { i = (int)this.기본단가; break; }
                    case "상품등록_안된_품목처리": { i = (int)this.상품등록_안된_품목처리; break; }
                    case "판매시_세트자료_조립해체": { i = (int)this.판매시_세트자료_조립해체; break; }
                    case "판매_매입분의_회계처리": { i = (int)this.판매_매입분의_회계처리; break; }
                    case "반품처리시_수발주정리": { i = (int)this.반품처리시_수발주정리; break; }
                    case "가용재고관리": { i = (int)this.가용재고관리; break; }

                    case "상품조회창에_매입가_표시": { i = (int)this.상품조회창에_매입가_표시; break; };
                    case "재고부족분_경고": { i = (int)this.재고부족분_경고; break; }
                    case "조회창크기": { i = (int)this.조회창크기; break; }
                    case "기본작업메뉴": { i = (int)this.기본작업메뉴; break; }

                    default:
                        break;
                }//End if Switch
                return i;
            }//End of get
            set
            {
                if (value == null)
                {
                    return;
                }
                switch (key)
                {
                    case "재고액평가법": { this.재고액평가법 = (재고액평가법)value; break; }
                    case "창고관리": { this.창고관리 = (창고관리)value; break; }
                    case "사원판매관리": { this.사원판매관리 = (사원판매관리)value; break; }
                    case "사원매입관리": { this.사원매입관리 = (사원매입관리)value; break; }
                    case "판매처리시_점검": { this.판매처리시_점검 = (판매처리시_점검)value; break; }
                    case "기본단가": { this.기본단가 = (기본단가)value; break; }
                    case "상품등록_안된_품목처리": { this.상품등록_안된_품목처리 = (상품등록_안된_품목처리)value; break; }
                    case "판매시_세트자료_조립해체": { this.판매시_세트자료_조립해체 = (판매시_세트자료_조립해체)value; break; }
                    case "판매_매입분의_회계처리": { this.판매_매입분의_회계처리 = (판매_매입분의_회계처리)value; break; }
                    case "반품처리시_수발주정리": { this.반품처리시_수발주정리 = (반품처리시_수발주정리)value; break; }
                    case "가용재고관리": { this.가용재고관리 = (가용재고관리)value; break; }

                    case "상품조회창에_매입가_표시": { this.상품조회창에_매입가_표시 = (상품조회창에_매입가_표시)value; break; }
                    case "재고부족분_경고": { this.재고부족분_경고 = (재고부족분_경고)value; break; }
                    case "조회창크기": { this.조회창크기 = (조회창크기)value; break; }
                    case "기본작업메뉴": { this.기본작업메뉴 = (기본작업메뉴)value; break; }
                    default:
                        break;
                }
            }
        }
    }
}
