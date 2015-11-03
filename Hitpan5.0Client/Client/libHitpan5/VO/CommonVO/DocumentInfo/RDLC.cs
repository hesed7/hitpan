using Microsoft.Reporting.WinForms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Drawing;
namespace libHitpan5.VO.DocumentInfo
{
    public class RDLC
    {
        public RDLC()
        {
            isMainReport = true;
        }
        public RDLC(string RDLCName, string DataSetName)
        {
            isMainReport = true;
            this.RDLCName = RDLCName;
            this.DataSetName = DataSetName;           
        }
        #region RDLC정보
        /// <summary>
        /// 가장 상위리포트인지 아닌지 구분하는 값
        /// 디폴트는 true
        /// </summary>
        private bool isMainReport { get; set; }
        //보고서를 만들 RDLC파일 경로
        public string RDLCName { get; set; }
        /// <summary>
        /// RDLC파일에 등록되어 있는 데이터셋 이름
        /// 리포트뷰어의 데이터가 바인딩 되기 위해서는 RDLC파일에 등록된 데이터셋 이름과 
        /// 등록된 ReportDataSource 객체의 이름이 일치해야 한다
        /// </summary>
        public string DataSetName { get; set; }
        /// <summary>
        /// 바인딩시킬 데이터
        /// </summary>
        public object Data { get; set; }
        /// <summary>
        /// 직속하위보고서 정보 리스트
        /// </summary>
        public RDLC[] SubReportList { get; set; } 
        #endregion
        #region 개별 프린트영역 정보
        #endregion
        #region 페이지 세팅
        public Margins margin { get; set; }
        public bool Landscape { get; set; }
        public bool GetMultiPage { get; set; }
        #endregion
        #region 프린터 세팅
        /// <summary>
        /// 프린터 세팅
        /// </summary>
        public string PrinterName { get; set; }
        #endregion




        /// <summary>
        /// 페이지 세팅, 프린터 세팅,데이터바인딩 작업
        /// </summary>
        /// <param name="reporter"></param>
        public void SetReport(ref ReportViewer reporter) 
        {
            #region 페이지,프린터세팅
            PageSettings pageSetting = new PageSettings();
            pageSetting.Margins = this.margin;
            pageSetting.Landscape = this.Landscape;
            PrinterSettings printerSetting = new PrinterSettings();
            printerSetting.PrinterName = this.PrinterName;
            try
            {
                reporter.SetPageSettings(pageSetting);
            }
            catch (NullReferenceException) { }
            try
            {
                reporter.PrinterSettings = printerSetting;
            }
            catch (NullReferenceException) { }            
            #endregion
            //데이터 바인딩
            SetDataBinding(ref reporter);
            reporter.RefreshReport();
        }



        /// <summary>
        /// 하위리포트객체의 데이터까지 전부 해당되는 바인더와 바인딩시킴
        /// </summary>
        private void SetDataBinding(ref ReportViewer reporter) 
        {
            if (isMainReport && Data!=null)
            {
                reporter.LocalReport.DataSources.Add(new ReportDataSource(DataSetName, Data));
            }
           
            if (SubReportList==null || SubReportList.Length<=0 )
            {
                return;
            }
            foreach (RDLC r in SubReportList)
            {
                isMainReport = false;
                r.SetDataBinding(ref reporter);
            }            
            reporter.LocalReport.SubreportProcessing += LocalReport_SubreportProcessing;
            reporter.RefreshReport();
        }
        void LocalReport_SubreportProcessing(object sender, SubreportProcessingEventArgs e)
        {
            foreach (RDLC r in SubReportList)
            {
                e.DataSources.Add(new ReportDataSource(r.DataSetName, r.Data));
            }            
        }
    }
}
