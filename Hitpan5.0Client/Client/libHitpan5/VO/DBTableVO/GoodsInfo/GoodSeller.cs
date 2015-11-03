using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace libHitpan5.VO.DBTableVO.GoodsInfo
{
    public class GoodSeller
    {
        public long? SellerIDX { get; set; }
        public long? GoodIDX { get; set; }
        public long? this[string key]
        {
            get 
            {
                long? returnValue = null;
                switch (key)
                {
                    case "SellerIDX": { returnValue = this.SellerIDX; break; }
                    case "GoodIDX"  : { returnValue = this.GoodIDX; break; }
                    default:
                        break;
                }
                return returnValue;
            }
            set 
            {
                switch (key)
                {
                    case "SellerIDX": { this.SellerIDX = value; break; }
                    case "GoodIDX"  : { this.GoodIDX = value; break; }
                    default:
                        break;
                }
            }
        }
    }
}
