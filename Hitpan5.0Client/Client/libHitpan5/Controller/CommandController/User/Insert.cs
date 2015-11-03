using libHitpan5.Controller.CommandListener;
using libHitpan5.enums;
using libHitpan5.Model.DataModel;
using libHitpan5.VO;
using libHitpan5.VO.CommonVO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace libHitpan5.Controller.CommandController.User
{
    public class Insert : abCMD
    {

        public UserInfo userinfo { get; set; }
        private IDataModel dbModel { get; set; }
        public Insert(UserInfo userinfo)
            : base(string.Format("아이디 {0} 입력"), Hitpan5ClientLibrary.SQLDataServiceModel)
        {
            this.userinfo = userinfo;
            this.dbModel = Hitpan5ClientLibrary.SQLDataServiceModel;

            UserAuth ua = new UserAuth();
            ua.계정관리 = 사용자권한.모두허용;
            base.RequiredAuth = ua;
        }
        public override void Do()
        {
            base.WriteDoLog();
            try
            {
                new UserListener(this.dbModel).Insert(this.userinfo);
                base.WriteDoSuccLog();
            }
            catch (Exception e)
            {
                base.WriteDoFailureLog(e);
            }
        }

        public override void UnDo()
        {
            base.WriteUnDoLog();
            try
            {
                new UserListener(this.dbModel).Delete(this.userinfo);
                WriteUnDoSuccLog();
            }
            catch (Exception e)
            {
                base.WriteUnDoFailureLog(e);
            }
        }
    }
}
