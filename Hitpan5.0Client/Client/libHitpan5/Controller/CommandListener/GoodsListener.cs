using libHitpan5.VO.CommonVO.GoodInfo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using libHitpan5.Model.DataModel;
using libHitpan5.VO.DBTableVO.GoodsInfo;
namespace libHitpan5.Controller.CommandListener
{
    /// <summary>
    /// 상품정보 입력,수정,삭제
    /// </summary>
    class GoodsListener
    {
        public System.Data.DataTable DocumentData { get; set; }
        private Model.DataModel.IDataModel dataModel;
        public SQLDataQueryRepository QueryHouse { get; set; }

        public GoodsListener(Model.DataModel.IDataModel dataModel)
        {
            // TODO: Complete member initialization
            this.dataModel = dataModel;
            this.QueryHouse = new SQLDataQueryRepository();
        }
        internal void Insert(GoodInfo goodInfo)
        {
            string[] queryBlock = new string[] {
                this.QueryHouse.InsertGoods(goodInfo.goodInfo),
                this.QueryHouse.InsertSeller(goodInfo.GoodSeller),
                this.QueryHouse.InsertParts(goodInfo.Parts),
                this.QueryHouse.InsertUnitCost(goodInfo.UnitCost)         
            };
            this.dataModel.SetData(queryBlock);            
        }

        internal void Delete(GoodInfo goodInfo)
        {
            string DeleteParts = this.QueryHouse.DeleteParts(goodInfo.goodInfo,false);
            //만약 삭제하려는 품목이 조립부품이 아니라 결과물 이라면 모든 파츠의 조립정보를 해제하는 쿼리를 등록
            if (goodInfo.Parts.FinishedGoodIDX==goodInfo.goodInfo.GoodPK)
            {
                DeleteParts =  this.QueryHouse.DeleteParts_With_FinalGoods(goodInfo.goodInfo,false);
            }

            string[] queryBlock = new string[] {
                this.QueryHouse.DeleteGoods(goodInfo.goodInfo,false),
                this.QueryHouse.DeleteSeller(goodInfo.goodInfo,null,false),
                DeleteParts,
                this.QueryHouse.DeleteUnitCost(goodInfo.goodInfo,null,false)         
            };
            this.dataModel.SetData(queryBlock);  
        }

        internal void Update(VO.CommonVO.GoodInfo.GoodInfo goodInfo)
        {
            string[] queryBlock = new string[] {
                this.QueryHouse.UpdateGoods(goodInfo.goodInfo),
                this.QueryHouse.UpdateSeller(goodInfo.GoodSeller),
                this.QueryHouse.UpdateParts(goodInfo.Parts),
                this.QueryHouse.UpdateUnitCost(goodInfo.UnitCost)         
            };
            this.dataModel.SetData(queryBlock);
        }

        internal GoodsList GetGoodsList(int page, int rowCount, Goods param)
        {
            GoodsList gl = new GoodsList();
            gl.GoodList = this.dataModel.GetData(this.QueryHouse.SelectGoods(param, true));
            gl.TotalRowCount = Convert.ToInt32(this.dataModel.GetData(this.QueryHouse.SelectGoodsTotalRowCount(param, true)).Rows[0]["rowcount"]);
            return gl;
        }
        internal GoodsList GetGoodsList(int page, int rowCount)
        {
            GoodsList gl = new GoodsList();
            gl.GoodList = this.dataModel.GetData(this.QueryHouse.SelectGoods(null, true));
            gl.TotalRowCount = Convert.ToInt32(this.dataModel.GetData(this.QueryHouse.SelectGoodsTotalRowCount(null, true)).Rows[0]["rowcount"]);
            return gl;
        }
        
        /// <summary>
        /// 키값을 가지고 상세 상품정보 열람
        /// </summary>
        /// <param name="GoodPK">
        /// 상품테이블의 키값
        /// </param>
        /// <returns>
        /// 단일 상품에 대한 모든 정보가 들어있는 VO
        /// </returns>
        internal GoodInfo GetGoodDetail(string GoodPK)
        {
            //데이터 테이블 구하기
            Goods param= new Goods();
            param.GoodPK = Convert.ToInt32(GoodPK);
            DataTable dt = this.dataModel.GetData(this.QueryHouse.SelectGoodDetails(param));
            DataRow drGood=dt.Rows[0];

            //Goods 객체 구하기
            Goods goods = new Goods();
            foreach (var prop in typeof(Goods).GetProperties())
	        {
                if (prop.Name=="item" || prop.Name.Replace(" ",string.Empty)==string.Empty)
                {
                    continue;
                }
                goods[prop.Name] = drGood[prop.Name];
	        }

            //매입자 정보 구하기
            GoodSeller goodSeller = new GoodSeller();
            foreach (var prop in typeof(GoodSeller).GetProperties())
            {
                if (prop.Name == "item" || prop.Name.Replace(" ", string.Empty) == string.Empty)
                {
                    continue;
                }
                goodSeller[prop.Name] = Convert.ToInt64(drGood[prop.Name]);
            }
            //조립,해체정보 구하기
            Parts parts = new Parts();
            foreach (var prop in typeof(Parts).GetProperties())
            {
                if (prop.Name == "item" || prop.Name.Replace(" ", string.Empty) == string.Empty)
                {
                    continue;
                }
                parts[prop.Name] = Convert.ToInt64(drGood[prop.Name]);
            }
            //단가정책 정보 구하기
            UnitCost unitCost = new UnitCost();
            foreach (var prop in typeof(UnitCost).GetProperties())
            {
                if (prop.Name == "item" || prop.Name.Replace(" ", string.Empty) == string.Empty)
                {
                    continue;
                }
                unitCost[prop.Name] = Convert.ToInt64(drGood[prop.Name]);
            }

            //각 정보를 GoodInfo타입 객체로 합치기
            GoodInfo gi = new GoodInfo();
            gi.goodInfo = goods;
            gi.GoodSeller = goodSeller;
            gi.Parts = parts;
            gi.UnitCost = unitCost;
            return gi;
        }

        /// <summary>
        /// 키값을 가지고 상세 상품정보 열람
        /// </summary>
        /// <param name="GoodPK">
        /// 상품정보를 검색할 때에 파라미터
        /// </param>
        /// <returns>
        /// 단일 상품에 대한 모든 정보가 들어있는 VO
        /// </returns>
        internal GoodInfo GetGoodDetail(Goods param)
        {
            //데이터 테이블 구하기
            DataTable dt = this.dataModel.GetData(this.QueryHouse.SelectGoodDetails(param));
            DataRow drGood = dt.Rows[0];

            //Goods 객체 구하기
            Goods goods = new Goods();
            foreach (var prop in typeof(Goods).GetProperties())
            {
                if (prop.Name == "item" || prop.Name.Replace(" ", string.Empty) == string.Empty)
                {
                    continue;
                }
                goods[prop.Name] = drGood[prop.Name];
            }

            //매입자 정보 구하기
            GoodSeller goodSeller = new GoodSeller();
            foreach (var prop in typeof(GoodSeller).GetProperties())
            {
                if (prop.Name == "item" || prop.Name.Replace(" ", string.Empty) == string.Empty)
                {
                    continue;
                }
                goodSeller[prop.Name] = Convert.ToInt64(drGood[prop.Name]);
            }
            //조립,해체정보 구하기
            Parts parts = new Parts();
            foreach (var prop in typeof(Parts).GetProperties())
            {
                if (prop.Name == "item" || prop.Name.Replace(" ", string.Empty) == string.Empty)
                {
                    continue;
                }
                parts[prop.Name] = Convert.ToInt64(drGood[prop.Name]);
            }
            //단가정책 정보 구하기
            UnitCost unitCost = new UnitCost();
            foreach (var prop in typeof(UnitCost).GetProperties())
            {
                if (prop.Name == "item" || prop.Name.Replace(" ", string.Empty) == string.Empty)
                {
                    continue;
                }
                unitCost[prop.Name] = Convert.ToInt64(drGood[prop.Name]);
            }

            //각 정보를 GoodInfo타입 객체로 합치기
            GoodInfo gi = new GoodInfo();
            gi.goodInfo = goods;
            gi.GoodSeller = goodSeller;
            gi.Parts = parts;
            gi.UnitCost = unitCost;
            return gi;
        }
    }
}
