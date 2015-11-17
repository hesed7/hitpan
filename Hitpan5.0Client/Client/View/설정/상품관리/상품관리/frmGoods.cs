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
using libHitpan5.VO.CommonVO.GoodInfo;
using libHitpan5.Controller.SelectController.Goods;
using libHitpan5.Controller.SelectController;
using Newtonsoft.Json;
using System.IO;
namespace HitpanClientView.View.설정.상품관리.상품관리
{
    public partial class frmGoods : frmAb리스트뷰
    {
        //public int RowCount { get; set; }
        public frmGoods()
        {
            base.RowCountPerPage = 10;            
            InitializeComponent();
        }

        private void frmGoods_Load(object sender, EventArgs e)
        {
            //

            //델리게이트 삽입
            base.GetData = new deleGetData(GetData);
            base.SetListView = new deleSetListView(SetListView);
            base.GetTotalPageCount = new deleGetTotalPageCount(GetTotalPageCount);
            base.SetDetailView = new deleSetDetailView(SetGoodDetailView);
            base.pageSetPageCount = 10;
            Search();
        }





        #region 부모폼 구성
        new private IList<object> GetData(int page, int RowCount) 
        {
            ISelect cmd = new SelectGoodList(page,RowCount,new GoodsListProxyVO());

            IList<object> Data = new List<object>();
            foreach (GoodsListProxyVO proxy in (IList<GoodsListProxyVO>)frmMain.htpClientLib.Select(cmd))
            {
                Data.Add(proxy);
            }
                
            return Data;
        }
        new private int GetTotalPageCount(int RowCount) 
        {
            long TotalRows =  ((GoodsListProxyVO)base.PageRowsData[0]).TotalRowCount;
            int TotalPage = Convert.ToInt32(TotalRows / RowCount);
            if (TotalRows % RowCount>0)
            {
                TotalPage += 1;
            }
            return TotalPage;
        }
        new private void SetListView(IList<object> data) 
        {
            base.lvList.Columns.Clear();
            base.lvList.Columns.Add("품목번호");
            base.lvList.Columns.Add("품목",150);
            base.lvList.Columns.Add("규격",150);
            base.lvList.Columns.Add("별칭", 150);
            base.lvList.Width = 350;

            foreach (object objProxy in data)
            {
                GoodsListProxyVO goodListProxy = (GoodsListProxyVO)objProxy;
                string[] arrData = new string[] 
                { 
                    goodListProxy["good_pk"].ToString(),
                    goodListProxy["good_name"].ToString(),
                    goodListProxy["good_subname"].ToString(),
                    goodListProxy["good_nickname"].ToString()
                };
                lvList.Items.Add(new ListViewItem(arrData));
            }
        }
        private void SetGoodDetailView(object data) 
        {
            // 리스트뷰 등 초기화
            lstbSeller.Items.Clear();

            //[1] 데이터 구하기
            GoodsListProxyVO GoodData = (GoodsListProxyVO)data;
            GoodDetailProxyVO vo = new GoodDetailProxyVO();
            vo.GoodsDetail.good_pk = GoodData.GoodsListVO.good_pk;
            ISelect selectDetail = new SelectGoodDetail(vo);
            GoodDetailProxyVO DetailData = (GoodDetailProxyVO)frmMain.htpClientLib.Select(selectDetail);

            //[2] 뷰 세팅           
            if (DetailData.GoodsDetail.good_image!=null)
            {
                byte[] image = JsonConvert.DeserializeObject<byte[]>(DetailData.GoodsDetail.good_image);
                Image img = (Image)new ImageConverter().ConvertFrom(image);
                picGood.Image = img;
            }
            txtGoodName.Text = DetailData.GoodsDetail.good_name;
            txtSubname.Text = DetailData.GoodsDetail.good_subname;
            txtNickName.Text = DetailData.GoodsDetail.good_nickname;
            txtMaker.Text = DetailData.GoodsDetail.good_maker;
            ddlStatus.Text = DetailData.GoodsDetail.status;
            txtETC.Text = DetailData.GoodsDetail.etc_info;
            txtProperStock.Text = DetailData.GoodsDetail.properstock.ToString();
            foreach (var SellerData in DetailData.GoodsDetail.goodsellerList)
            {
                string strSellerData = string.Format("업체번호: {0} || 상호: {1} || 전화번호: {2} || 업무시간: {3} ", SellerData.seller_idx, SellerData.company_name, SellerData.company_phone,SellerData.company_worktime);
                lstbSeller.Items.Add(strSellerData);
            }
            foreach (var unitCostData in DetailData.GoodsDetail.unitcostList)
            {
                string strUnitCostData = string.Format
                    (
                    "적용업체 업체번호 :{0} || 적용업체 상호 :{1} || 구분: {2} || 단위 :{3} || 단가 :{4} || 면세여부 {5} 부과세 포함여부 {6}",
                    unitCostData.company_idx,
                    "상호",
                    unitCostData.cost_type,
                    unitCostData.unit,
                    unitCostData.cost,
                    unitCostData.is_free_tax,
                    unitCostData.contain_tax
                    );
                lstbUnitCost.Items.Add(strUnitCostData);
            }
        }
        #endregion

        private void btnOut_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
