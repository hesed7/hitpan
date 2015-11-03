using libHitpan5.VO.CommonVO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace libHitpan5.Controller.CommandController
{
    public interface ICMD
    {
        void Do();
        void UnDo();

        UserAuth RequiredAuth { get; set; }
    }
}
