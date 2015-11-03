using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace PostgresSQLServer.Delegate
{
    /// <summary>
    /// ServiceHost에 메시지보안 적용시 기본값은 윈도우 인증값을 사용한다
    /// 기본값을 변경하여 사용자인증 방법을 사용할수 있도록 한다
    /// </summary>
    /// <param name="host"></param>
    /// <returns></returns>
    public delegate ServiceHost deleSecurityCustomizer(ServiceHost host);
}
