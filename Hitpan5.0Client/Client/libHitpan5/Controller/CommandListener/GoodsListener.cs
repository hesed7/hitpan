using libHitpan5.Model.DataModel;
using libHitpan5.VO.CommonVO.GoodInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace libHitpan5.Controller.CommandListener
{
    /// <summary>
    /// 상품정보 입력,수정,삭제
    /// </summary>
    class GoodsListener
    {
        public System.Data.DataTable DocumentData { get; set; }
        private SQLDataServiceModel dataModel;

        public GoodsListener(SQLDataServiceModel dataModel)
        {
            // TODO: Complete member initialization
            this.dataModel = dataModel;
        }
        internal void Insert(VO.CommonVO.GoodInfo.GoodInfo goodInfo)
        {
            throw new NotImplementedException();
        }

        internal void Delete()
        {
            throw new NotImplementedException();
        }

        internal void Update(VO.CommonVO.GoodInfo.GoodInfo userinfo)
        {
            throw new NotImplementedException();
        }

        internal GoodsList GetGoodsList(VO.CommonVO.GoodInfo.GoodsList param)
        {
            throw new NotImplementedException();
        }

        

        internal GoodInfo GetGoodDetail(GoodInfo param)
        {
            throw new NotImplementedException();
        }
    }
}
