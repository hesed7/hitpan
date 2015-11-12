using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using WebServiceServer.Enums;
namespace WebServiceServer.Enums
{
    [DataContract]
    public enum LogType 
    {
        [EnumMember]
        히트판시작,
        [EnumMember]
        히트판종료,
        [EnumMember]
        히트판세팅,
        [EnumMember]
        히트판표준세팅,
        [EnumMember]
        유저정보,
        [EnumMember]
        로그인_로그아웃,
        [EnumMember]
        에러
    }

    [DataContract]
    public enum UnitCostType 
    {
        [EnumMember]
        매입,
        [EnumMember]
        매출
    }
    #region 히트판 작업설정
    [DataContract]
    public enum 사용자권한 
    {
        [EnumMember]
        관리불가=0,
        [EnumMember]
        조회만가능=1,
        [EnumMember]
        모두허용=2 
    }
    [DataContract]
    public enum 재고액평가법 
    {
        [EnumMember]
        설정안됨,
        [EnumMember]
        이동평균법,
        [EnumMember]
        표준단가,
        [EnumMember]
        최종매입싯가법,
        [EnumMember]
        표준비교안함
    }
    [DataContract]
    public enum 창고관리 
    {
        [EnumMember]
        설정안됨,
        [EnumMember]
        관리안함,
        [EnumMember]
        관리함 
    }
    [DataContract]
    public enum 사원판매관리 
    {
        [EnumMember]
        설정안됨,
        [EnumMember]
        업체담당자로,
        [EnumMember]
        판매시마다입력
    }
    [DataContract]
    public enum 사원매입관리 
    {
        [EnumMember]
        설정안됨,
        [EnumMember]
        업체담당자로,
        [EnumMember]
        판매시마다입력
    }
    [DataContract]
    public enum 판매처리시_점검
    {
        [EnumMember]
        설정안됨,
        [EnumMember]
        미수금_자동출고정지,
        [EnumMember]
        확인후_출고정지,
        [EnumMember]
        관리안함
    }
    [DataContract]
    public enum 기본단가 
    {
        [EnumMember]
        설정안됨,
        [EnumMember]
        최종단가,
        [EnumMember]
        표준단가,
        [EnumMember]
        적용단가
    }
    [DataContract]
    public enum 상품등록_안된_품목처리
    {
        [EnumMember]
        설정안됨,
        [EnumMember]
        가능,
        [EnumMember]
        불가능
    }
    /// <summary>
    /// 로컬파일관리
    /// </summary>
    [DataContract]
    public enum 상품조회창에_매입가_표시 
    {
        [EnumMember]
        설정안됨,
        [EnumMember]
        표시,
        [EnumMember]
        표시안함
    }
    [DataContract]
    public enum 판매시_세트자료_조립해체
    {
        [EnumMember]
        설정안됨,
        [EnumMember]
        이행,
        [EnumMember]
        미이행
    }
    [DataContract]
    public enum 판매_매입분의_회계처리 
    {
        [EnumMember]
        설정안됨,
        [EnumMember]
        해당업체로,
        [EnumMember]
        본사가_있는_경우_본사로
    }
    /// <summary>
    /// 상품별,업체별로 관리
    /// 기본은 상품정보에서 관리
    /// 개별은 업체정보에서, 또는 거래명세서등 작성시에
    /// </summary>
    [DataContract]
    public enum 부가세포함단가처리 
    {
        [EnumMember]
        설정안됨,
        [EnumMember]
        순단가로,
        [EnumMember]
        포함단가로,
        [EnumMember]
        부가세자동조정안함
    }
    [DataContract]
    public enum 반품처리시_수발주정리 
    {
        [EnumMember]
        설정안됨,
        [EnumMember]
        처리여부선택,
        [EnumMember]
        수량합계표시
    }
    [DataContract]
    public enum 가용재고관리 
    {
        [EnumMember]
        설정안됨,
        [EnumMember]
        관리함,
        [EnumMember]
        관리안함
    }
    /// <summary>
    /// 로컬파일관리
    /// </summary>
    [DataContract]
    public enum 재고부족분_경고 
    {
        [EnumMember]
        설정안됨,
        [EnumMember]
        경고,
        [EnumMember]
        경고안함,
        [EnumMember]
        품명조회창에_재고표기
    }
    /// <summary>
    /// 로컬파일관리
    /// </summary>
    [DataContract]
    public enum 조회창크기 
    {
        [EnumMember]
        설정안됨,
        [EnumMember]
        보통,
        [EnumMember]
        크게
    }
    /// <summary>
    /// 로컬파일관리
    /// </summary>
    [DataContract]
    public enum 기본작업메뉴 
    {
        [EnumMember]
        설정안됨,
        [EnumMember]
        거래명세서,
        [EnumMember]
        견적서,
        [EnumMember]
        견적의뢰서,
        [EnumMember]
        발주서
    } 
    #endregion
    #region 사용자계정
    [DataContract]
    public enum 사용자등급 
    {
        [EnumMember]
        페기 = 0,
        [EnumMember]
        관리자 = 1,
        [EnumMember]
        일반사용자 = 2
    } 
    #endregion
}
