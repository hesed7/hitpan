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
    class Insert : abCMD
    {
        private GoodInfo GoodInfo { get; set; }
        public SQLDataServiceModel dbModel { get; set; }
        public Insert(GoodInfo GoodInfo)
            : base(string.Format("이름:{0} 규격{1}인 상품 정보 입력", GoodInfo.goodInfo.GoodName, GoodInfo.goodInfo.GoodSubName), Hitpan5ClientLibrary.SQLDataServiceModel)
        {
            this.GoodInfo = GoodInfo;
            this.dbModel = Hitpan5ClientLibrary.SQLDataServiceModel;

            UserAuthProxyVO ua = new UserAuthProxyVO();
            ua["상품정보"] = 사용자권한.모두허용;
            ua["표준관리"] = 사용자권한.모두허용;
            base.RequiredAuth = ua;
        }
        public override void Do()
        {
            try
            {
                base.WriteDoLog();
                new GoodsListener(this.dbModel).Insert(this.GoodInfo);
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
                new GoodsListener(this.dbModel).Delete();
                base.WriteDoSuccLog();
            }
            catch (Exception e)
            {

                base.WriteUnDoFailureLog(e);
            }
        }
    }
}
