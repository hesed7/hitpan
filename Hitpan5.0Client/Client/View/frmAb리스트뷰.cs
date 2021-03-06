﻿using System;
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

        protected int RowCountPerPage { get; set; }
        /// <summary>
        /// 데이터 구하기
        /// </summary>
        /// <param name="page">현재 페이지</param>
        /// <param name="RowCount">한 체이지에 들어갈 로우수</param>
        /// <returns></returns>
        protected delegate IList<object> deleGetData(int page, int RowCount);
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
        protected delegate void deleSetListView(IList<object> data);

        protected delegate void deleSetDetailView(object Data);

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
        /// <summary>
        /// 디테일뷰 세팅하는 델리게이트
        /// 파라미터로 주어지는 오브젝트는 리스트데이터 오브젝트에서 오는 것
        /// </summary>
        protected deleSetDetailView SetDetailView { get; set; }
        #endregion
        #region 데이터 프로퍼티
        //현재 검색조건으로 구할수 있는 전체 페이지수
        protected int TotalPageCount { get; set; }
        //한 페이지셋당 들어갈 페이지수
        protected int pageSetPageCount { get; set; }
        //페이지가 로딩되면서 구한 한 페이지 안의 로우들 데이터
        protected IList<object> PageRowsData { get; set; }
        #endregion
        public frmAb리스트뷰()
        {
            InitializeComponent();
        }

        private void lvList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idx = lvList.FocusedItem.Index;
            object Data = GetDetail(idx);
            SetDetailView(Data);
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
            pnPageLink.Controls.Clear();
            //라벨 또는 링크를 작성할 Left위치
            int leftPoint = 0;
            #region 현재 페이지셋 정보 구하기
            int currentPageSet = 0;
            if (page % pageSetPageCount ==0)
            {
                currentPageSet = (page / pageSetPageCount);
            }
            else
            {
                currentPageSet = (page / pageSetPageCount) + 1;
            }

            int FirstPage = ((currentPageSet - 1) * pageSetPageCount) + 1;

            int LastPage = 0;
            if (TotalPage<((currentPageSet) * pageSetPageCount))
            {
                LastPage = TotalPage;
            }
            else
            {
                LastPage = ((currentPageSet) * pageSetPageCount);
            }
            
            #endregion
            #region 이전 페이지셋의 첫번째 페이지로 이동하는 링크 작성(◁)
            Label linkLeft = null;
            if (currentPageSet ==1)
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
                    lvList.Clear();
                    this.PageRowsData = GetData(PrePage, rowCount);
                    SetListView(this.PageRowsData);
                    SetDetailView(GetDetail(1));
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
                    lvList.Clear();
                    this.PageRowsData = GetData(i-1, rowCount);
                    SetDetailView(GetDetail(1));
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
            if (((currentPageSet) * pageSetPageCount)  >= TotalPage)
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
                if (NextPage > TotalPage)
                {
                    NextPage = TotalPage;
                }
                linkRight.MouseClick += delegate 
                {
                    lvList.Clear();
                    this.PageRowsData = GetData(NextPage, rowCount);
                    SetDetailView(GetDetail(1));
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
        protected void Search() 
        {
            lvList.Clear();
            this.PageRowsData = (IList<object>)GetData(1, this.RowCountPerPage);
            this.TotalPageCount = GetTotalPageCount(this.RowCountPerPage);
            SetListView(this.PageRowsData);
            SetPageLink(this.TotalPageCount, 1, this.pageSetPageCount, this.RowCountPerPage);
            SetDetailView(GetDetail(1));
        }

        /// <summary>
        /// 리스트뷰를 구성하는 데이터에서 선택한 디테일뷰에 해당하는 데이터 가져온다
        /// 리스트데이터보다 자세한 데이터를 가져오려면 SetDetailView(deleSetDetailView 타입) 에서 현재 리스트데이터를 이용해서 다시 구해야 한다
        /// </summary>
        /// <param name="idx">리스트뷰에서 선택한 행의 idx</param>
        /// <returns></returns>
        private object GetDetail(int idx)
        {
            //첫번째 항목의 idx 가져오기
            object dr = this.PageRowsData[idx];
            return dr;
        }
        #endregion


    }
}
