using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebServiceServer.WebServiceVO.Settings;
using Newtonsoft.Json;
namespace WebServiceServer.webService.WebServiceSQL.Settings
{
    class MyCompanyQuery
    {
        internal string GetMyCompanyInfo() 
        {
            return "select jsonmyinfo from commonsetting";
        }
        internal string SetMyCompanyInfo(MyCompany myCompany,bool Exist) 
        {
            string val = JsonConvert.SerializeObject(myCompany);
            if (Exist)
            {
                return string.Format("update commonsetting set jsonmyinfo='{0}'", val);
            }
            else
            {
                return string.Format("insert into commonsetting(jsonmyinfo) values('{0}')",val);
            }            
        }
    }
}
