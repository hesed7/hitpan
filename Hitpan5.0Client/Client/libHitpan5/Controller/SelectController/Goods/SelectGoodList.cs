using libHitpan5.Controller.CommandListener;
using libHitpan5.Controller.Common.DocumentController;
using libHitpan5.enums;
using libHitpan5.Model.DataModel;
using libHitpan5.VO.CommonVO;
using libHitpan5.VO.CommonVO.GoodInfo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using libHitpan5.VO.DBTableVO.GoodsInfo;
namespace libHitpan5.Controller.SelectController.Goods
{
    public class SelectGoodList :abSelect
    {
        private IDataModel dbModel { get; set; }
        private int Page { get; set; }
        private int RowCount { get; set; }
        public libHitpan5.VO.DBTableVO.GoodsInfo.Goods param { get; set; }
        public SelectGoodList(int Page,int RowCount)
            :base("상품정보 검색",Hitpan5ClientLibrary.SQLDataServiceModel)
        {
            this.dbModel = Hitpan5ClientLibrary.SQLDataServiceModel;
            this.Page = Page;
            this.RowCount = RowCount;

            UserAuth ua = new UserAuth();   //실행에 필요한 권한
            ua.상품정보 = 사용자권한.조회만가능;
            ua.표준관리 = 사용자권한.조회만가능;
            base.RequiredAuth = ua;

            base.docController = new libHitpan5.Controller.Common.DocumentController.GoodListDocument();//문서작성용 컨트롤러
        }
        public override object GetData()
        {
            GoodsListener goodsListener= new GoodsListener(this.dbModel);
            GoodsList GoodsList = null;
            if (this.param==null)
            {
                GoodsList = goodsListener.GetGoodsList(this.Page, this.RowCount);
            }
            else
            {
                GoodsList = goodsListener.GetGoodsList(this.Page, this.RowCount, this.param);
            }
            base.DocumentData = goodsListener.DocumentData;//문서작성용 데이터
            return GoodsList;
        }        
    }
}
