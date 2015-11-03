using libHitpan5.Controller.Common.DocumentController;
using libHitpan5.Model.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using libHitpan5.Controller.CommandListener;
using libHitpan5.VO.CommonVO;
using libHitpan5.enums;
namespace libHitpan5.Controller.SelectController.MyCompany
{
    public class SelectMyCompany :abSelect
    {
        public IDataModel dbModel { get; set; }
        public SelectMyCompany()
            : base("나의 회사 정보 검색", Hitpan5ClientLibrary.SQLDataServiceModel)
        {
            this.dbModel = Hitpan5ClientLibrary.SQLDataServiceModel;

            UserAuth ua = new UserAuth();   //실행에 필요한 권한
            ua.나의정보관리 = 사용자권한.조회만가능;
            base.RequiredAuth = ua;

            base.docController = new libHitpan5.Controller.Common.DocumentController.MyCompanyDocument();//문서작성용 컨트롤러
        }
        public override object GetData()
        {
            try
            {
                base.WriteDoLog();
                MyCompanyListener MyCompanyListener = new MyCompanyListener(this.dbModel);
                base.DocumentData = MyCompanyListener.DocumentData; //문서작성용 데이터
                object returnValue = MyCompanyListener.GetMyCompanyInfo();
                base.WriteDoSuccLog();
                return returnValue;
            }
            catch (Exception e)
            {
                base.WriteDoFailureLog(e);
                return null;
            }
        }

        
    }
}
