using libHitpan5.Controller.CommandListener;
using libHitpan5.enums;
using libHitpan5.Model.DataModel;
using libHitpan5.VO.CommonVO;
using libHitpan5.VO.CommonVO.GoodInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace libHitpan5.Controller.CommandController.Goods
{
    class Update :abCMD
    {
        private GoodInfo post_userinfo { get; set; }
        private GoodInfo userinfo { get; set; }
        private SQLDataServiceModel dbModel { get; set; }
        public Update(GoodInfo post_GoodInfo, GoodInfo GoodInfo, string comment)
            : base(comment, Hitpan5ClientLibrary.SQLDataServiceModel)
        {
            this.userinfo = userinfo;
            this.post_userinfo = post_userinfo;
            this.dbModel = Hitpan5ClientLibrary.SQLDataServiceModel;

            UserAuth ua = new UserAuth();
            ua.상품정보 = 사용자권한.모두허용;
            ua.표준관리 = 사용자권한.모두허용;
            base.RequiredAuth = ua;
        }
        public override void Do()
        {
            base.WriteDoLog();
            try
            {
                new GoodsListener(this.dbModel).Update(userinfo);
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
                new GoodsListener(this.dbModel).Update(post_userinfo);
                base.WriteUnDoSuccLog();
            }
            catch (Exception e)
            {
                base.WriteUnDoFailureLog(e);
            }
        }
    }
}
