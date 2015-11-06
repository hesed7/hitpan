using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace libHitpan5.VO.CommonVO.GoodInfo
{
    public class GoodsList
    {
        public int StartIDX { get; set; }
        public int RowCount { get; set; }
        public IList<GoodInfo> GoodList { get; set; }

    }
}
