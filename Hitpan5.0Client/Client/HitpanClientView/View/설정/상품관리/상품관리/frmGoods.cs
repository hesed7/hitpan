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
            base.pageSetPageCount = 1;
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
        #endregion
    }
}
