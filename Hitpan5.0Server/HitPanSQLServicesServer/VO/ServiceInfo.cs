using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HitPanSQLServicesServer.VO
{
    class ServiceInfo
    {
        public ServiceInfo(string ServiceURL, string DBPath)
        {
            this.ServiceURL = ServiceURL;
            this.DBPath = DBPath;
        }
        public string ServiceURL { get; set; }
        public string DBPath { get; set; }
    }
}
