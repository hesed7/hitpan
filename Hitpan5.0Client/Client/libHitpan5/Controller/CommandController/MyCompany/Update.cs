using libHitpan5.Controller.CommandListener;
using libHitpan5.enums;
using libHitpan5.Model.DataModel;
using libHitpan5.VO;
using libHitpan5.VO.CommonVO;
using libHitpan5.VO.CommonVO.UserInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace libHitpan5.Controller.CommandController.MyCompany
{
    public class Update :abCMD
    {
        private MyCompanyProxyVO myCompany { get; set; }
        private MyCompanyProxyVO pre_myCompany { get; set; }
        private SQLDataServiceModel dbModel { get; set; }
        public Update(MyCompanyProxyVO myCompany, MyCompanyProxyVO pre_myCompany)
            : base("자신의 회사정보  변경", Hitpan5ClientLibrary.SQLDataServiceModel)
        {
            this.myCompany = myCompany;
            this.pre_myCompany = pre_myCompany;
            this.dbModel = Hitpan5ClientLibrary.SQLDataServiceModel;

            UserAuthProxyVO ua = new UserAuthProxyVO();
            ua["나의정보관리"] = 사용자권한.모두허용;
            base.RequiredAuth = ua;
        }
        public override void Do()
        {
            try
            {
                base.WriteDoLog();
                new MyCompanyListener(this.dbModel).Update(myCompany);
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
                new MyCompanyListener(this.dbModel).Insert(pre_myCompany);
                base.WriteUnDoSuccLog();
            }
            catch (Exception e)
            {

                base.WriteUnDoFailureLog(e);
            }
        }
    }
}
