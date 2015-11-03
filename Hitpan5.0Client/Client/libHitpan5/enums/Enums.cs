using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace libHitpan5.enums
{
    public enum LogType                     
    {
        히트판시작,
        히트판종료,
        히트판세팅,
        히트판표준세팅,
        유저정보,
        로그인_로그아웃,
        에러
    }
    #region 히트판 작업설정
    public enum 사용자권한 { 관리불가=0, 조회만가능=1, 모두허용=2 }
    public enum 재고액평가법 { 설정안됨, 이동평균법, 표준단가, 최종매입싯가법, 표준비교안함 }
    public enum 창고관리 { 설정안됨, 관리안함, 관리함 }
    public enum 사원판매관리 { 설정안됨, 업체담당자로, 판매시마다입력 }
    public enum 사원매입관리 { 설정안됨, 업체담당자로, 판매시마다입력 }
    public enum 판매처리시_점검 { 설정안됨, 미수금_자동출고정지, 확인후_출고정지, 관리안함 }
    public enum 기본단가 { 설정안됨, 최종단가, 표준단가, 적용단가 }
    public enum 상품등록_안된_품목처리 { 설정안됨, 가능, 불가능 }
    /// <summary>
    /// 로컬파일관리
    /// </summary>
    public enum 상품조회창에_매입가_표시 { 설정안됨, 표시, 표시안함 }
    public enum 판매시_세트자료_조립해체 { 설정안됨, 이행, 미이행 }
    public enum 판매_매입분의_회계처리 { 설정안됨, 해당업체로, 본사가_있는_경우_본사로 }
    /// <summary>
    /// 상품별,업체별로 관리
    /// 기본은 상품정보에서 관리
    /// 개별은 업체정보에서, 또는 거래명세서등 작성시에
    /// </summary>
    public enum 부가세포함단가처리 { 설정안됨, 순단가로, 포함단가로, 부가세자동조정안함 }
    public enum 반품처리시_수발주정리 { 설정안됨, 처리여부선택, 수량합계표시 }
    public enum 가용재고관리 { 설정안됨, 관리함, 관리안함 }
    /// <summary>
    /// 로컬파일관리
    /// </summary>
    public enum 재고부족분_경고 { 설정안됨, 경고, 경고안함, 품명조회창에_재고표기 }
    /// <summary>
    /// 로컬파일관리
    /// </summary>
    public enum 조회창크기 { 설정안됨, 보통, 크게 }
    /// <summary>
    /// 로컬파일관리
    /// </summary>
    public enum 기본작업메뉴 { 설정안됨, 거래명세서, 견적서, 견적의뢰서, 발주서 } 
    #endregion
    #region 사용자계정
    public enum 사용자등급 { 페기=0, 관리자=1, 일반사용자=2 } 
    #endregion

    #region 문서
    public enum RDLC데이터종류
    {
        업체정보,
        상품정보,
        거래정보,
        견적정보
    }
    public enum 호환파일형식 { Excel,PDF,Word,Image}
    #endregion

}
