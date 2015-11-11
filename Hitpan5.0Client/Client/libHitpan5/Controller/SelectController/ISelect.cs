using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using libHitpan5.Controller.Common.Loger;
using libHitpan5.Controller.Common.DocumentController;
using System.Data;
using libHitpan5.VO.CommonVO;
using libHitpan5.VO.CommonVO.UserInfo;
namespace libHitpan5.Controller.SelectController
{
    public interface ISelect
    {
        object GetData();
        void GetDocument();

        UserAuthProxyVO RequiredAuth { get; set; }
    }
}
