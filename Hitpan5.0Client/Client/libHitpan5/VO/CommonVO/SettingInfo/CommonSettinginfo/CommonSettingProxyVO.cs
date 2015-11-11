using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebServiceServer.WebServiceVO.Settings;
using WebServiceServer.Enums;
namespace libHitpan5.VO
{
    public class CommonSettingProxyVO
    {
        //로컬파일에서 입력받는 세팅정보
        public CommonSettings CommonSettings { get; set; }
        public IDictionary<string,Type> EnumTypeDic { get; set; }
        public CommonSettingProxyVO()
        {
            //CommonSettings 객체 초기화
            this.CommonSettings = new CommonSettings();
            //Enum 타입 등록
            EnumTypeDic= new Dictionary<string,Type>();
            EnumTypeDic.Add("재고액평가법",typeof(재고액평가법));
            EnumTypeDic.Add("창고관리",typeof(창고관리));
            EnumTypeDic.Add("사원판매관리",typeof(사원판매관리));
            EnumTypeDic.Add("사원매입관리",typeof(사원매입관리));
            EnumTypeDic.Add("판매처리시_점검",typeof(판매처리시_점검));
            EnumTypeDic.Add("기본단가",typeof(기본단가));
            EnumTypeDic.Add("상품등록_안된_품목처리",typeof(상품등록_안된_품목처리));
            EnumTypeDic.Add("판매시_세트자료_조립해체",typeof(판매시_세트자료_조립해체));
            EnumTypeDic.Add("판매_매입분의_회계처리",typeof(판매_매입분의_회계처리));
            EnumTypeDic.Add("반품처리시_수발주정리",typeof(반품처리시_수발주정리));
            EnumTypeDic.Add("가용재고관리", typeof(가용재고관리));
            EnumTypeDic.Add("상품조회창에_매입가_표시", typeof(상품조회창에_매입가_표시));           
            EnumTypeDic.Add("재고부족분_경고",typeof(재고부족분_경고));
            EnumTypeDic.Add("조회창크기",typeof(조회창크기));
            EnumTypeDic.Add("기본작업메뉴", typeof(기본작업메뉴));
        }
        public Enum this[string key]
        {
            get
            {
                Enum i = null;
                switch (key)
                {
                    case "재고액평가법": { i = CommonSettings.재고액평가법; break; }
                    case "창고관리": { i = CommonSettings.창고관리; break; }
                    case "사원판매관리": { i = CommonSettings.사원판매관리; break; }
                    case "사원매입관리": { i = CommonSettings.사원매입관리; break; }
                    case "판매처리시_점검": { i = CommonSettings.판매처리시_점검; break; }
                    case "기본단가": { i = CommonSettings.기본단가; break; }
                    case "상품등록_안된_품목처리": { i = CommonSettings.상품등록_안된_품목처리; break; }
                    case "판매시_세트자료_조립해체": { i = CommonSettings.판매시_세트자료_조립해체; break; }
                    case "판매_매입분의_회계처리": { i = CommonSettings.판매_매입분의_회계처리; break; }
                    case "반품처리시_수발주정리": { i = CommonSettings.반품처리시_수발주정리; break; }
                    case "가용재고관리": { i = CommonSettings.가용재고관리; break; }

                    case "상품조회창에_매입가_표시": { i = CommonSettings.상품조회창에_매입가_표시; break; };
                    case "재고부족분_경고": { i = CommonSettings.재고부족분_경고; break; }
                    case "조회창크기": { i = CommonSettings.조회창크기; break; }
                    case "기본작업메뉴": { i = CommonSettings.기본작업메뉴; break; }

                    default:
                        break;
                }//End if Switch
                return i;
            }//End of get
            set
            {
                if (value==null)
                {
                    return;
                }

                //객체 생성후 this.CommonSettings객체가 null로 초기화된 경우에는 객체 다시 생성
                if (this.CommonSettings==null)
                {
                    this.CommonSettings = new CommonSettings();
                }
                switch (key)
                {
                    case "재고액평가법": { CommonSettings.재고액평가법 = (재고액평가법)value; break; }
                    case "창고관리": { CommonSettings.창고관리 = (창고관리)value; break; }
                    case "사원판매관리": { CommonSettings.사원판매관리 = (사원판매관리)value; break; }
                    case "사원매입관리": { CommonSettings.사원매입관리 = (사원매입관리)value; break; }
                    case "판매처리시_점검": { CommonSettings.판매처리시_점검 = (판매처리시_점검)value; break; }
                    case "기본단가": { CommonSettings.기본단가 = (기본단가)value; break; }
                    case "상품등록_안된_품목처리": { CommonSettings.상품등록_안된_품목처리 = (상품등록_안된_품목처리)value; break; }
                    case "판매시_세트자료_조립해체": { CommonSettings.판매시_세트자료_조립해체 = (판매시_세트자료_조립해체)value; break; }
                    case "판매_매입분의_회계처리": { CommonSettings.판매_매입분의_회계처리 = (판매_매입분의_회계처리)value; break; }
                    case "반품처리시_수발주정리": { CommonSettings.반품처리시_수발주정리 = (반품처리시_수발주정리)value; break; }
                    case "가용재고관리": { CommonSettings.가용재고관리 = (가용재고관리)value; break; }

                    case "상품조회창에_매입가_표시": { CommonSettings.상품조회창에_매입가_표시 = (상품조회창에_매입가_표시)value; break; }
                    case "재고부족분_경고": { CommonSettings.재고부족분_경고 = (재고부족분_경고)value; break; }
                    case "조회창크기": { CommonSettings.조회창크기 = (조회창크기)value; break; }
                    case "기본작업메뉴": { CommonSettings.기본작업메뉴 = (기본작업메뉴)value; break; }
                    default:
                        break;
                }
            }
        }


    }
}
