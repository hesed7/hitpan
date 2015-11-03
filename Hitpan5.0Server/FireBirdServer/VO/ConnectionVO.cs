using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebService.VO
{
    public class ConnectionVO
    {
        public ConnectionVO(string ServiceURL, string DataBasePath)
        {
            this.ServiceURL = ServiceURL;
            this.DataBasePath = DataBasePath;
        }
        public string ServiceURL { get; set; }
        public string DataBasePath { get; set; }
        public string DBID = "SYSDBA";//string.Empty;
        public string DBPassword = "masterkey";//string.Empty;
        public string Charset = "UTF8";

        public string DataBaseName { get; set; }

        public string hostURL { get; set; }
    }
}
