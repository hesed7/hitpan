using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace libHitpan5.VO.DBTableVO
{
    public interface IDBTableVO
    {
        int Page { get; set; }
        int RowCount { get; set; }
        string orderby { get; set; }
    }
}
