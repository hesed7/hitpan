using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace libHitpan5.VO.DBTableVO.GoodsInfo
{
    public class UnitCost
    {
        /// <summary>
        /// 가격
        /// </summary>
        public long? Cost { get; set; }
        /// <summary>
        /// 매입단가인지 매출단가인지
        /// </summary>
        public long? CostType { get; set; }
        /// <summary>
        /// 적용받는 상품의 idx
        /// </summary>
        public long? GoodIDX { get; set; }
        /// <summary>
        /// 적용받는 회사의idx
        /// </summary>
        public long? CompanyIDX { get; set; }
        /// <summary>
        /// 면세인지
        /// </summary>
        public long? IsFreeTax { get; set; }
        /// <summary>
        /// 부가세 포함 가격정책인지
        /// </summary>
        public long? ContainVAT { get; set; }
        public long? this[string key] 
        {
            get 
            {
                long? ReturnValue = null;
                switch (key)
                {
                    case "Cost"         : {ReturnValue=this.Cost; break; }
                    case "CostType"     : {ReturnValue=this.CostType ;break; }
                    case "GoodIDX"      : {ReturnValue=this.GoodIDX ;break; }
                    case "CompanyIDX"   : {ReturnValue=this.CompanyIDX ;break; }
                    case "IsFreeTax"    : {ReturnValue=this.IsFreeTax ;break; }
                    case "ContainVAT"   : { ReturnValue = this.ContainVAT; break; }
                    default:
                        break;
                }
                return ReturnValue;
            }
            set 
            {
                switch (key)
                {
                    case "Cost"         : { this.Cost =value; break; }
                    case "CostType"     : { this.CostType = value; break; }
                    case "GoodIDX"      : { this.GoodIDX = value; break; }
                    case "CompanyIDX"   : { this.CompanyIDX = value; break; }
                    case "IsFreeTax"    : { this.IsFreeTax = value; break; }
                    case "ContainVAT"   : { this.ContainVAT = value; break; }
                    default:
                        break;
                }
            }
        }
    }
}
