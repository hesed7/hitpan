using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using libHitpan5.Model.DataModel;
using System.Data;
using libHitpan5.VO;
using Newtonsoft.Json;
using WebServiceServer.WebServiceVO.Settings;
namespace libHitpan5.Controller.CommandListener
{
    //나의 정보 입력,수정,삭제
    class MyCompanyListener
    {
        private SQLDataServiceModel dataModel;
        public MyCompanyListener(SQLDataServiceModel dataModel)
        {
            // TODO: Complete member initialization
            this.dataModel = dataModel;
        }
        internal void Insert(MyCompanyProxyVO MyCompany)
        {
            dataModel.SetMyCompanyInfo(MyCompany);
        }
        internal void Update(MyCompanyProxyVO MyCompany)
        {
            dataModel.SetMyCompanyInfo(MyCompany);
        }

        internal object GetMyCompanyInfo()
        {
            MyCompanyProxyVO mc = dataModel.GetMyCompanyInfo();
            return mc;
        }

        public  System.Data.DataTable DocumentData { get; set; }
    }
}
