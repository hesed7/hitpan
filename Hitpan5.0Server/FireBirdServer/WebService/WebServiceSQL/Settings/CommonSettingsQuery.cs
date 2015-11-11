using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebServiceServer.WebServiceVO.Settings;
using Newtonsoft.Json;
namespace WebServiceServer.webService.WebServiceSQL.Settings
{
    class CommonSettingsQuery
    {
        internal string GetCommonSettings() 
        {
            return "select jsonsettinginfodata from commonsetting";
        }
        internal string SetCommonSettings(CommonSettings commonSettings,bool Exist) 
        {
            string val = JsonConvert.SerializeObject(commonSettings);
            if (Exist)
            {
                return string.Format("update commonsetting set jsonsettinginfodata='{0}'", val);               
            }
            else
            {
                return string.Format("insert into commonsetting(jsonsettinginfodata) values('{0}')", val);
            }
        }
    }
}
