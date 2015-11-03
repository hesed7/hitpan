using libHitpan5.Controller.CommandController;
using libHitpan5.enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using libHitpan5.Controller.SelectController.Goods;
using libHitpan5.Controller.SelectController;
using libHitpan5.VO.CommonVO.GoodInfo;
namespace HitpanClientView.View.설정.상품관리.상품관리
{
    public partial class frmGoods : frmAb리스트뷰
    {
        public int RowCount { get; set; }
        public frmGoods()
        {
            this.RowCount = 10;
            base.pageSetPageCount = 10;
            InitializeComponent();
        }

        private void frmGoods_Load(object sender, EventArgs e)
        {
            //델리게이트 삽입
            base.GetData = new deleGetData(GetData);
            base.SetListView = new deleSetListView(SetListView);
            base.GetTotalPageCount = new deleGetTotalPageCount(GetTotalPageCount);
            Search(RowCount);
        }





        #region 부모폼 구성

        /// <summary>
        /// 아무런 조건 없이 상품 검색
        /// </summary>
        /// <param name="page"></param>
        /// <param name="RowCount"></param>
        /// <returns></returns>
        new private DataTable GetData(int page, int RowCount) 
        {
            //데이터 구하기
            ISelect GetGoodListVO = new SelectGoodList(page,RowCount);
            GoodsList GoodsListVO = (GoodsList)frmMain.htpClientLib.Select(GetGoodListVO);

            //데이터 분리
            //[1] 데이터테이블
            DataTable dtGoods = GoodsListVO.GoodList;
            //[2] 전체 로우수
            base.TotalRowsCount = GoodsListVO.TotalRowCount;
            //데이터 테이블 반환
            return dtGoods;
        }

        /// <summary>
        /// 어떤 조건 아래서 상품을 검색
        /// </summary>
        /// <param name="page"></param>
        /// <param name="RowCount"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        new private DataTable GetData(int page, int RowCount,GoodInfo param) 
        {
            //데이터 구하기
            ISelect GetGoodListVO = new SelectGoodList(page,RowCount);
            ((SelectGoodList)GetGoodListVO).param = param.goodInfo;
            GoodsList GoodsListVO = (GoodsList)frmMain.htpClientLib.Select(GetGoodListVO);

            //데이터 분리
            //[1] 데이터테이블
            DataTable dtGoods = GoodsListVO.GoodList;
            //[2] 전체 로우수
            base.TotalRowsCount = GoodsListVO.TotalRowCount;
            //데이터 테이블 반환
            return dtGoods;
        }
        new private int GetTotalPageCount(int RowCount,int TotalRowCount) 
        {
            int totalPageCount=Convert.ToInt32(TotalRowCount / RowCount);
            if (totalPageCount<1)
	        {
                totalPageCount = 1;
	        }
            return totalPageCount; 
        }
        new private void SetListView(DataTable data) 
        {
            
        }
        #endregion
    }
}
