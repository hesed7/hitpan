using libHitpan5.Controller.CommandListener;
using libHitpan5.enums;
using libHitpan5.Model.DataModel;
using libHitpan5.VO.CommonVO;
using libHitpan5.VO.CommonVO.GoodInfo;
using libHitpan5.VO.CommonVO.UserInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace libHitpan5.Controller.CommandController.Goods
{
    class Update :abCMD
    {
        private GoodDetailProxyVO post_GoodInfo { get; set; }
        private GoodDetailProxyVO GoodInfo { get; set; }
        private SQLDataServiceModel dbModel { get; set; }
        public Update(GoodDetailProxyVO post_GoodInfo, GoodDetailProxyVO GoodInfo, string comment)
            : base(comment, Hitpan5ClientLibrary.SQLDataServiceModel)
        {
            this.GoodInfo = GoodInfo;
            this.post_GoodInfo = post_GoodInfo;
            this.dbModel = Hitpan5ClientLibrary.SQLDataServiceModel;

            UserAuthProxyVO ua = new UserAuthProxyVO();
            ua["상품정보"] = 사용자권한.모두허용;
            ua["표준관리"] = 사용자권한.모두허용;
            base.RequiredAuth = ua;
        }
        public override void Do()
        {
            base.WriteDoLog();
            try
            {
                new GoodsListener(this.dbModel).Update(GoodInfo);
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
                new GoodsListener(this.dbModel).Update(post_GoodInfo);
                base.WriteUnDoSuccLog();
            }
            catch (Exception e)
            {
                base.WriteUnDoFailureLog(e);
            }
        }
    }
}
