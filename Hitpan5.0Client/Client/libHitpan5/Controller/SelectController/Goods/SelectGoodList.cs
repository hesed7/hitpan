using libHitpan5.Controller.CommandListener;
using libHitpan5.Controller.Common.DocumentController;
using libHitpan5.enums;
using libHitpan5.Model.DataModel;
using libHitpan5.VO.CommonVO;
using libHitpan5.VO.CommonVO.GoodInfo;
using libHitpan5.VO.CommonVO.UserInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace libHitpan5.Controller.SelectController.Goods
{
    public class SelectGoodList :abSelect
    {
        private int page { get; set; }
        private int rowCount { get; set; }

        private SQLDataServiceModel dbModel { get; set; }
        private GoodsListProxyVO param { get; set; }
        public SelectGoodList(int page,int rowCount, GoodsListProxyVO param)
            :base("상품정보 검색",Hitpan5ClientLibrary.SQLDataServiceModel)
        {
            this.page = page;
            this.rowCount = rowCount;
            this.dbModel = Hitpan5ClientLibrary.SQLDataServiceModel;
            this.param = param;

            UserAuthProxyVO ua = new UserAuthProxyVO();   //실행에 필요한 권한
            ua["상품정보"] = 사용자권한.조회만가능;
            ua["표준관리"] = 사용자권한.조회만가능;
            base.RequiredAuth = ua;

            base.docController = new libHitpan5.Controller.Common.DocumentController.GoodListDocument();//문서작성용 컨트롤러
        }
        public override object GetData()
        {
            GoodsListener goodsListener= new GoodsListener(this.dbModel);
            IList<GoodsListProxyVO> GoodList = goodsListener.GetGoodsList(this.page,this.rowCount,param);
            base.DocumentData = goodsListener.DocumentData;//문서작성용 데이터
            return GoodList;
        }

        

        
    }
}
