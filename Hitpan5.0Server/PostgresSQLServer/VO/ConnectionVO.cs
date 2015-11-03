using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PostgresSQLServer.VO
{
    public class ConnectionVO
    {
        public string ServiceURL { get; set; }
        public string DataBasePath { get; set; }
        public string DBPassword = "postgres";//string.Empty;
        public string Charset = "UTF8";
        public string DataBaseName { get; set; }
        public int DBPort { get; set; }
    }
}
