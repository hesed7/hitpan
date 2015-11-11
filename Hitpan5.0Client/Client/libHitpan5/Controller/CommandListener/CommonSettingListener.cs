using libHitpan5.Model.DataModel;
using libHitpan5.VO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using WebServiceServer.WebServiceVO.Settings;
namespace libHitpan5.Controller.CommandListener
{
    //관리정보 설정 등 설정정보 입력,수정,삭제
    class CommonSettingListener
    {
        private SQLDataServiceModel dataModel;
        public CommonSettingListener(SQLDataServiceModel dataModel)
        {
            // TODO: Complete member initialization
            this.dataModel = dataModel;
        }
        internal void Insert(CommonSettingProxyVO CommonSettinginfo)
        {
            dataModel.SetCommonSettings(CommonSettinginfo);
        }



        internal void Delete()
        {
            dataModel.SetCommonSettings(new CommonSettingProxyVO());
        }

        internal void Update(CommonSettingProxyVO CommonSettinginfo)
        {
            dataModel.SetCommonSettings(CommonSettinginfo);
        }

        internal object GetData()
        {
            return dataModel.GetCommonSettings();
        }

        public  System.Data.DataTable DocumentData { get; set; }
    }
}
