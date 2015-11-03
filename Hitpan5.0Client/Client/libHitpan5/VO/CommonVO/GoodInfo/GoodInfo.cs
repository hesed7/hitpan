using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using libHitpan5.VO.DBTableVO.GoodsInfo;
namespace libHitpan5.VO.CommonVO.GoodInfo
{
    public class GoodInfo
    {
        public Goods goodInfo { get; set; }
        public GoodSeller GoodSeller { get; set; }
        public Parts Parts { get; set; }
        public UnitCost UnitCost { get; set; }
        public GoodInfo()
        {
            goodInfo = new Goods();
            GoodSeller = new GoodSeller();
            Parts = new Parts();
            UnitCost = new UnitCost();
        }
    }
}
