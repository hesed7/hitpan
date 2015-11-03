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
    public partial class frmAb리스트뷰 : Form
    {
        /// <summary>
        /// 데이터 구하기
        /// </summary>
        /// <param name="page">현재 페이지</param>
        /// <param name="RowCount">한 체이지에 들어갈 로우수</param>
        /// <returns></returns>
        protected delegate DataTable deleGetData(int page, int RowCount);
        /// <summary>
        /// 특정조건을 만족하는 검색시에 나오는 전체 페이지 수
        /// </summary>
        /// <param name="RowCount">한 페이지당 로우수</param>
        /// <returns></returns>
        protected delegate int deleGetTotalPageCount(int RowCount);
        /// <summary>
        /// 리스트뷰 세팅
        /// </summary>
        /// <param name="data">검색된 데이터가 들어있는 데이터테이블</param>
        protected delegate void deleSetListView(DataTable data);

        #region 델리게이트
        /// <summary>
        /// 데이터를 실질적으로 구하는 델리게이트
        /// </summary>
        protected deleGetData GetData { get; set; }
        /// <summary>
        /// 특정 검색조건을 만족하는 전체 페이지수 구하기
        /// </summary>
        protected deleGetTotalPageCount GetTotalPageCount { get; set; }
        /// <summary>
        /// 리스트뷰 세팅하는 델리게이트
        /// </summary>
        protected deleSetListView SetListView { get; set; }
        #endregion
        #region 데이터 프로퍼티
        //현재 검색조건으로 구할수 있는 전체 페이지수
        protected int TotalPageCount { get; set; }
        //한 페이지셋당 들어갈 페이지수
        protected int pageSetPageCount { get; set; }
        //페이지가 로딩되면서 구한 한 페이지 안의 로우들 데이터
        protected DataTable PageRowsData { get; set; }
        /// <summary>
        /// 리스트뷰에서 선택한 로우에 해당하는 데이터로우
        /// </summary>
        protected DataRow drDetail { get; set; } 
        #endregion
        public frmAb리스트뷰()
        {
            InitializeComponent();
        }

        private void lvList_SelectedIndexChanged(object sender, EventArgs e)
        {
            drDetail = GetDetail();
        }

        #region 페이징
        /// <summary>
        /// 페이지를 나타낼 링크라벨을 동적생성
        /// </summary>
        /// <param name="TotalPage">전체페이지</param>
        /// <param name="page">현재페이지</param>
        /// <param name="pageSetPageCount">페이지 셋당 나타낼 페이지수</param>
        protected void SetPageLink(int TotalPage,int page,int pageSetPageCount,int rowCount) 
        {
            //라벨 또는 링크를 작성할 Left위치
            int leftPoint = 0;
            #region 현재 페이지셋 정보 구하기
            int currentPageSet = (page / pageSetPageCount) + 1;
            int FirstPage = ((currentPageSet - 1) * pageSetPageCount) + 1;
            int LastPage = ((currentPageSet) * pageSetPageCount); 
            #endregion
            #region 이전 페이지셋의 첫번째 페이지로 이동하는 링크 작성(◁)
            Label linkLeft = null;
            if (page < pageSetPageCount)
            {
                linkLeft = new Label();
                linkLeft.Text = "||◁ ";
            }
            else
            {
                linkLeft = new LinkLabel();
                linkLeft.Text = "◁ ";
                int PrePage = FirstPage - pageSetPageCount;//이전 페이지셋의 첫번째 페이지
                //클릭이벤트 설정
                linkLeft.MouseClick += delegate
                {
                    this.PageRowsData = GetData(PrePage, rowCount);
                    SetListView(this.PageRowsData);
                    SetPageLink(TotalPage, PrePage, pageSetPageCount,rowCount);
                };
            }
            linkLeft.Parent = pnPageLink;
            linkLeft.AutoSize = true;
            leftPoint = linkLeft.Right; 
            #endregion
            #region 현재페이지의 페이지셋 나타내기
            for (int i = FirstPage; i <= LastPage; i++)
            {
                LinkLabel pageLink = new LinkLabel();
                pageLink.Left = leftPoint;
                pageLink.Text = i.ToString();                
                pageLink.AutoSize = true;
                pageLink.Parent = pnPageLink;
                pageLink.MouseClick += delegate 
                {
                    this.PageRowsData = GetData(i, rowCount);
                    SetListView(this.PageRowsData);
                };
                leftPoint = pageLink.Right;                
                if (i<LastPage)
                {
                    Label lblSeparator = new Label();
                    lblSeparator.Left = leftPoint;
                    lblSeparator.AutoSize = true;
                    lblSeparator.Text = "|";
                    lblSeparator.Parent = pnPageLink;
                    leftPoint = lblSeparator.Right;                    
                }               
            }                        
            #endregion
            #region 다음 페이지셋의 첫번째 페이지로 이동하는 링크작성 (▷)
            Label linkRight = null;
            if (((Convert.ToInt32(page / pageSetPageCount)) * pageSetPageCount) - TotalPage >= 0)
            {
                linkRight = new Label();
                linkRight.Text = " ▷||";
                linkRight.Tag = TotalPage;
            }
            else
            {
                linkRight = new LinkLabel();
                linkRight.Text = " ▷";
                int NextPage = FirstPage + pageSetPageCount;//다음 페이지셋의 첫번째 페이지
                linkRight.MouseClick += delegate 
                {
                    this.PageRowsData = GetData(NextPage, rowCount);
                    SetListView(this.PageRowsData);
                    SetPageLink(TotalPage, NextPage, pageSetPageCount, rowCount);
                };
                //클릭이벤트 설정
            }
            linkRight.Parent = pnPageLink;
            linkRight.Left = leftPoint; 
            #endregion
        }
        #endregion
        #region 검색
        /// <summary>
        /// 검색버튼을 눌렀을 때의 작동을 정의한다
        /// 조건에 맞게 데이터를 구하는것 자체는 여기가 아니고 GetData메서드에서 정의
        /// </summary>
        /// <param name="RowCount">한 페이지에 들어갈 로우의 수</param>
        protected void Search(int RowCount) 
        {
            this.TotalPageCount = GetTotalPageCount(RowCount);
            this.PageRowsData = GetData(1, RowCount);
            SetListView(this.PageRowsData);
            this.drDetail= GetDetail();
            SetPageLink(this.TotalPageCount, 1, this.pageSetPageCount, RowCount);
        }

        /// <summary>
        /// 리스트뷰에서 선택한 항목에 해당하는 데이터로우를 반환
        /// 리스트뷰 선택이벤트핸들러에서 이미 사용
        /// </summary>
        /// <returns></returns>
        private DataRow GetDetail() 
        {
            //리스트뷰에서 선택한 항목의 idx값은 DataTable의 동일한 내용에 해당하는 로우의idx값과 같다

            //선택한 항목의 idx 가져오기
            int idx= lvList.SelectedIndices[0];
            DataRow dr = this.PageRowsData.Rows[idx];
            return dr;
        }
        private DataRow GetDetail(int idx)
        {
            //리스트뷰에서 선택한 항목의 idx값은 DataTable의 동일한 내용에 해당하는 로우의idx값과 같다

            //첫번째 항목의 idx 가져오기
            DataRow dr = this.PageRowsData.Rows[idx];
            return dr;
        }
        #endregion


    }
}
