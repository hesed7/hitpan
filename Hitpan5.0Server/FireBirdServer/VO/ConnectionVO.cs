using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebServiceServer.VO
{
    public class ConnectionVO
    {
        public ConnectionVO(string ServiceURL, string DataBaseName)
        {
            this.ServiceURL = ServiceURL;
            //this.DataBasePath = DataBasePath;
            this.DataBaseName = DataBaseName;
        }
        public string ServiceURL { get; set; }
        //public string DataBasePath { get; set; }
        public string DBID = "postgres";
        public string DBPassword = "postgres";
        public string Charset = "UTF8";
        public int port = 5432;
        public string DataBaseName { get; set; }
        public string TableSpace { get; set; }
        public string HostURL = "127.0.0.1";
    }
}
