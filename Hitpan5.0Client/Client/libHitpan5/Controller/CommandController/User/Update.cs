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
    public class Update :abCMD
    {
        private UserInfo post_userinfo { get; set; }
        private UserInfo userinfo { get; set; }
        private IDataModel dbModel { get; set; }
        public Update(UserInfo post_userinfo, UserInfo userinfo, string comment)
            : base(comment,Hitpan5ClientLibrary.SQLDataServiceModel)
        {
            this.dbModel = Hitpan5ClientLibrary.SQLDataServiceModel;
            this.userinfo = userinfo;
            this.post_userinfo = post_userinfo;

            UserAuth ua = new UserAuth();
            ua.계정관리 = 사용자권한.모두허용;
            base.RequiredAuth = ua;
        }
        public override void Do()
        {
            base.WriteDoLog();
            try
            {
                new UserListener(this.dbModel).Update(userinfo);
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
                new UserListener(this.dbModel).Update(post_userinfo);
                base.WriteUnDoSuccLog();
            }
            catch (Exception e)
            {
                base.WriteUnDoFailureLog(e);
            }
        }
    }
}
