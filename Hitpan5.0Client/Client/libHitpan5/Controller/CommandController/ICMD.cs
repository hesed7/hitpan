using libHitpan5.VO.CommonVO;
using libHitpan5.VO.CommonVO.UserInfo;
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

        UserAuthProxyVO RequiredAuth { get; set; }
    }
}
