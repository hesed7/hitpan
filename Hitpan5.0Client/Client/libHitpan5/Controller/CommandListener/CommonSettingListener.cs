using libHitpan5.Model.DataModel;
using libHitpan5.VO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
namespace libHitpan5.Controller.CommandListener
{
    //관리정보 설정 등 설정정보 입력,수정,삭제
    class CommonSettingListener
    {
        private IDataModel dataModel;
        public SQLDataQueryRepository QueryHouse { get; set; }
        public CommonSettingListener(Model.DataModel.IDataModel dataModel)
        {
            // TODO: Complete member initialization
            this.dataModel = dataModel;
            this.QueryHouse = new SQLDataQueryRepository();
        }
        internal void Insert(VO.CommonSettinginfo CommonSettinginfo)
        {
            string query = QueryHouse.insertSettingInfo(CommonSettinginfo);
            this.dataModel.SetData(query);
        }



        internal void Delete()
        {
            string query = QueryHouse.DeleteSettingInfo();
            this.dataModel.SetData(query);
        }

        internal void Update(VO.CommonSettinginfo CommonSettinginfo)
        {
            string query = QueryHouse.updateSettingInfo(CommonSettinginfo);
            this.dataModel.SetData(query);
        }

        internal object GetData()
        {
             string query = QueryHouse.selectSettingInfo();
            DataTable dt= this.dataModel.GetData(query);
            this.DocumentData = dt;
            CommonSettinginfo CommonSettinginfo = JsonConvert.DeserializeObject<CommonSettinginfo>(dt.Rows[0]["JSONSETTINGINFODATA"].ToString());
            return CommonSettinginfo;
        }

        public  System.Data.DataTable DocumentData { get; set; }
    }
}
