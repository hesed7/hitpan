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

namespace HitpanClientView.View.설정.상품관리.상품관리
{
    public partial class frmGoods : frmAb리스트뷰
    {
        public int RowCount { get; set; }
        public frmGoods()
        {
            this.RowCount = 10;
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
        new private DataTable GetData(int page, int RowCount) 
        {
            //libHitpan5.Hitpan5ClientLibrary htpLib= frmMain.getInstance().htpClientLib;
            //ICommandListener icl=htpLib.GetCommandListener(CommandListenerType.goods);
            //ICMD cmd= new 
            //DataTable dt = htpLib.
            //for (int i = 0; i < 10; i++)
            //{
                
            //}
            return null;
        }
        new private int GetTotalPageCount(int RowCount) {return 10; }
        new private void SetListView(DataTable data) { }
        #endregion
    }
}
