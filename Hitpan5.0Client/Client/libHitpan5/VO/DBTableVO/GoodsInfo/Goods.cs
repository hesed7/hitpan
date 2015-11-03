using libHitpan5.VO.DBTableVO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace libHitpan5.VO.DBTableVO.GoodsInfo
{
    /// <summary>
    /// DB테이블(Goods)에 입력하기 위한 VO클래스
    /// DB테이블(Goods)의 컬럼명과 프로퍼티의 이름이 동일해야 한다
    /// </summary>
    public class Goods : IDBTableVO
    {
        /// <summary>
        /// Goods테이블의 해당 프라이머리 키
        /// </summary>
        public int? GoodPK { get; set; }
        /// <summary>
        /// 품명
        /// </summary>
        public string GoodName { get; set; }
        /// <summary>
        /// 규격
        /// </summary>
        public string GoodSubName { get; set; }
        /// <summary>
        /// 메이커
        /// </summary>
        public string GoodMaker { get; set; }
        /// <summary>
        /// 관리코드
        /// </summary>
        public string GoodNickName { get; set; }
        /// <summary>
        /// 단위
        /// </summary>
        public string GoodUnit { get; set; }

        /// <summary>
        /// 적정재고
        /// </summary>
        public string ProperStock { get; set; }
        /// <summary>
        /// 사양 및 참고
        /// </summary>
        public string ETCInfo { get; set; }

        /// <summary>
        /// 상품의 이미지
        /// </summary>
        public string Image { get; set; }
        /// <summary>
        /// 상품의 상태(페기,사용,단종)
        /// </summary>
        public string Status { get; set; }

        #region 정렬과 데이터 부분범위 처리
        /// <summary>
        /// 현재페이지
        /// </summary>
        public int Page { get; set; }
        /// <summary>
        /// 1페이지당 로우수
        /// </summary>
        public int RowCount { get; set; }
        /// <summary>
        /// 정렬
        /// </summary>
        public string orderby { get; set; } 
        #endregion

        public object this[string key]
        {
            get 
            {
                object ReturnValue = null;
                switch (key)
                {
                    case "GoodPK"       : { ReturnValue = this.GoodPK;          break; }
                    case "GoodName"     : { ReturnValue = this.GoodName;        break; }
                    case "GoodSubName"  : { ReturnValue = this.GoodSubName;     break; }
                    case "GoodMaker"    : { ReturnValue = this.GoodMaker;       break; }
                    case "GoodNickName" : { ReturnValue = this.GoodNickName;    break; }
                    case "GoodUnit"     : { ReturnValue = this.GoodUnit;        break; }
                    case "ProperStock"  : { ReturnValue = this.ProperStock;     break; }
                    case "ETCInfo"      : { ReturnValue = this.ETCInfo;         break; }
                    case "Status"       : { ReturnValue = this.Status;          break; }
                    case "Page"         : { ReturnValue = this.Page;            break; }
                    case "RowCount"     : { ReturnValue = this.RowCount;        break; }
                    case "orderby"      : { ReturnValue = this.orderby;         break; }
                    default:
                        break;
                }
                return ReturnValue;
            }
            set 
            {
                switch (key)
                {
                    case "GoodPK"       : {this.GoodPK      = Convert.ToInt32(value);break;}
                    case "GoodName"     : {this.GoodName    = Convert.ToString(value);break;}
                    case "GoodSubName"  : {this.GoodSubName = Convert.ToString(value);break;}
                    case "GoodMaker"    : {this.GoodMaker   = Convert.ToString(value);break;}
                    case "GoodNickName" : {this.GoodNickName= Convert.ToString(value);break;}
                    case "GoodUnit"     : {this.GoodUnit    = Convert.ToString(value);break;}
                    case "ProperStock"  : {this.ProperStock = Convert.ToString(value);break;}
                    case "ETCInfo"      : {this.ETCInfo     = Convert.ToString(value);break;}
                    case "Status"       : { this.Status     = Convert.ToString(value);break;}
                    case "Page"         : { this.Page       = Convert.ToInt32(value); break;}
                    case "RowCount"     : { this.RowCount   = Convert.ToInt32(value); break;}
                    case "orderby"      : { this.orderby    = Convert.ToString(value); break;}
                    default:
                        break;
                }
            }
        }
    }
}
