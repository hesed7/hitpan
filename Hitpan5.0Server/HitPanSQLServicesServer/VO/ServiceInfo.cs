﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HitPanSQLServicesServer.VO
{
    class ServiceInfo
    {
        public ServiceInfo(string ServiceURL, string DBName)
        {
            this.ServiceURL = ServiceURL;
            this.DBName = DBName;
        }
        public string ServiceURL { get; set; }
        public string DBName { get; set; }
    }
}
