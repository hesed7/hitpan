using libHitpan5.Controller.CommandListener;
using libHitpan5.enums;
using libHitpan5.Model.DataModel;
using libHitpan5.VO;
using libHitpan5.VO.CommonVO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace libHitpan5.Controller.CommandController.MyCompany
{
    public class Insert :abCMD
    {
        private myInfo myCompany { get; set; }
        private SQLDataServiceModel dbModel { get; set; }
        public Insert(myInfo myCompany)
            : base("자신의 회사정보 입력", Hitpan5ClientLibrary.SQLDataServiceModel)
        {
            this.myCompany = myCompany;
            this.dbModel = Hitpan5ClientLibrary.SQLDataServiceModel;
            UserAuth ua = new UserAuth();
            ua.나의정보관리 = 사용자권한.모두허용;
            base.RequiredAuth = ua;
        }
        public override void Do()
        {
            try
            {
                base.WriteDoLog();
                new MyCompanyListener(this.dbModel).Insert(this.myCompany);
                base.WriteDoSuccLog();
            }
            catch (Exception e)
            {

                base.WriteDoFailureLog(e);
            }
        }

        public override void UnDo()
        {
            try
            {
                base.WriteUnDoLog();
                new MyCompanyListener(this.dbModel).Delete();
                base.WriteDoSuccLog();
            }
            catch (Exception e)
            {

                base.WriteUnDoFailureLog(e);
            }
        }
    }
}
