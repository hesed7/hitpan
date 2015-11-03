using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using libHitpan5.Model.DataModel;
using System.Data;
using libHitpan5.VO;
using Newtonsoft.Json;
namespace libHitpan5.Controller.CommandListener
{
    //나의 정보 입력,수정,삭제
    class MyCompanyListener
    {
        private IDataModel dataModel;
        private SQLDataQueryRepository QueryHouse { get; set; }
        public MyCompanyListener(Model.DataModel.IDataModel dataModel)
        {
            // TODO: Complete member initialization
            this.dataModel = dataModel;
            QueryHouse = new SQLDataQueryRepository();
        }
        internal void Insert(VO.myInfo myInfo)
        {
            string query = QueryHouse.InsertMyInfo(myInfo);
            dataModel.SetData(query);
        }

        internal void Delete()
        {
            string query = QueryHouse.DeleteMyInfo();
            dataModel.SetData(query);
        }

        internal object GetMyCompanyInfo()
        {
            string query = QueryHouse.GetMyInfo();
            DataTable dt= dataModel.GetData(query);
            this.DocumentData = dt;
            myInfo mi = JsonConvert.DeserializeObject<myInfo>(dt.Rows[0]["JSONMYINFO"].ToString());
            return mi;
        }

        public  System.Data.DataTable DocumentData { get; set; }
    }
}
