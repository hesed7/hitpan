using HitPanSQLServicesServer.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using HitPanSQLServicesServer.Properties;
namespace HitPanSQLServicesServer.Controller.SettingInfo
{
    class CommonSettingsController
    {
        //저장
        public void InsertSettings(CommonSettingsVO vo) 
        {
            string plainJson = JsonConvert.SerializeObject(vo);
            string Encryptedjson = WebServiceServer.ServerMain.getInstance().GetEncryptedString(plainJson);
            Settings.Default.CommonSettingsVO = Encryptedjson;
            Settings.Default.Save();
        }
        //삭제
        public void DeleteSettings()
        {
            Settings.Default.CommonSettingsVO = null;
            Settings.Default.Save();
        }
        //가져오기
        public CommonSettingsVO SelectSettings()
        {
            CommonSettingsVO settingData = null;
            try
            {
                string Encryptedjson = Settings.Default.CommonSettingsVO;
                string plainJson = WebServiceServer.ServerMain.getInstance().GetDecryptedString(Encryptedjson);
                settingData = JsonConvert.DeserializeObject<CommonSettingsVO>(plainJson);
            }
            catch (Exception)
            {
                settingData = null;
            }
            return settingData;
        }
        //수정
        public void UpdateSettings(CommonSettingsVO vo)
        {
            CommonSettingsVO originVO = SelectSettings();
            foreach (var prop in typeof(CommonSettingsVO).GetProperties())
            {
                if (vo[prop.Name]!=null)
                {
                    if (originVO[prop.Name]!=vo[prop.Name])
                    {
                        originVO[prop.Name] = vo[prop.Name];
                    }
                }
            }

            string plainJson = JsonConvert.SerializeObject(originVO);
            string Encryptedjson = WebServiceServer.ServerMain.getInstance().GetEncryptedString(plainJson);
            Settings.Default.CommonSettingsVO = Encryptedjson;
            Settings.Default.Save();
        }
    }
}
