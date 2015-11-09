using libHitpan5.Controller.CommandListener;
using libHitpan5.Controller.Common.DocumentController;
using libHitpan5.enums;
using libHitpan5.Model.DataModel;
using libHitpan5.VO.CommonVO;
using libHitpan5.VO.CommonVO.GoodInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace libHitpan5.Controller.SelectController.Goods
{
    public class SelectGoodList :abSelect
    {
        private SQLDataServiceModel dbModel { get; set; }
        private GoodsList param { get; set; }
        public SelectGoodList(IDocController doc, GoodsList param)
            :base("상품정보 검색",Hitpan5ClientLibrary.SQLDataServiceModel)
        {
            this.dbModel = Hitpan5ClientLibrary.SQLDataServiceModel;
            this.param = param;

            UserAuth ua = new UserAuth();   //실행에 필요한 권한
            ua.상품정보 = 사용자권한.조회만가능;
            ua.표준관리 = 사용자권한.조회만가능;
            base.RequiredAuth = ua;

            base.docController = new libHitpan5.Controller.Common.DocumentController.GoodListDocument();//문서작성용 컨트롤러
        }
        public override object GetData()
        {
            GoodsListener goodsListener= new GoodsListener(this.dbModel);
            GoodsList GoodList = goodsListener.GetGoodsList(param);
            base.DocumentData = goodsListener.DocumentData;//문서작성용 데이터
            return GoodList;
        }

        

        
    }
}
