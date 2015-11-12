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
        internal void Insert(GoodDetailProxyVO goodInfo)
        {
            throw new NotImplementedException();
        }

        internal void Delete(Int64 pk)
        {
            throw new NotImplementedException();
        }

        internal void Update(GoodDetailProxyVO goodInfo)
        {
            throw new NotImplementedException();
        }

        internal IList<GoodsListProxyVO> GetGoodsList(int page,int rowCount,GoodsListProxyVO param)
        {
            try
            {
                return this.dataModel.GetGoodList(page, rowCount, param.GoodsListVO.good_name, param.GoodsListVO.good_subname, param.GoodsListVO.good_nickname, param.GoodsListVO.good_maker);
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }



        internal GoodDetailProxyVO GetGoodDetail(string  goodPK)
        {
            return this.dataModel.GetGoodDetail(goodPK);
        }
    }
}
