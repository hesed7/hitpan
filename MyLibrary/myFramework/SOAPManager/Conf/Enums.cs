using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOAP.Conf
{
    public enum SOAPServerType { winform,WAS,iis}
    public enum ServiceBindingType { BasicHttpBinding, WSHttpBinding, WSDualHttpBinding, NetTcpBinding }
}
