using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace libHitpan5.VO.DBTableVO.GoodsInfo
{
    public class Parts
    {
        /// <summary>
        /// 완성품PK
        /// </summary>
        public long? FinishedGoodIDX { get; set; }
        /// <summary>
        /// 부품 PK
        /// </summary>
        public long? PartIDX { get; set; }
        /// <summary>
        /// 해당부품이 필요한 량
        /// </summary>
        public long? amount { get; set; }

        public long? this[string key] 
        {
            get 
            {
                long? ReturnValue = null;
                switch (key)
                {
                    case "FinishedGoodIDX"  : {ReturnValue = this.FinishedGoodIDX; break; }
                    case "PartIDX"          : {ReturnValue = this.PartIDX; break; }
                    case "amount"           : { ReturnValue = this.amount; break; }
                    default:
                        break;
                }
                return ReturnValue;
            }
            set 
            {
                switch (key)
                {
                    case "FinishedGoodIDX"  : { this.FinishedGoodIDX = value; break; }
                    case "PartIDX"          : { this.PartIDX = value; break; }
                    case "amount"           : { this.amount = value; break; }
                    default:
                        break;
                }
            }
        }
    }
}
