using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Microsoft.Reporting.WinForms;
using System.IO;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.Drawing;
using System;
using libHitpan5.VO.DocumentInfo;
namespace libHitpan5.Model.DocumentModel
{
    /**
     * 
     * 이 클래스는 
     * 리포트를 생성해서 보여주고 
     * PDF변환을 하고, 엑셀변환을 하고
     * 해당 보고서를 프린터출력및 미리보기를 제공 하는 클래스이다
     * 이를 위해서 ReportViewer를 이용한다
     * 
     * **/
    public class ReportService
    {
        #region ReportViewer 생성 또는 세팅
        /// <summary>
        /// 외부에서 주입받은 ReportViewer 즉, Viewer 객체를 세팅한다
        /// </summary>
        /// <param name="RDLCPath">리포트 정의파일의 경로</param>
        /// <param name="data">리포트 작성에 사용될 데이터테이블</param>
        public ReportViewer GetReportViewer(RDLC report)
        {
            ReportViewer Viewer = new ReportViewer();
            string DIRPath = string.Format("{0}\\rdlc", Environment.CurrentDirectory);
            if (!Directory.Exists(DIRPath))
            {
                Directory.CreateDirectory(DIRPath);
            }
            Viewer.LocalReport.ReportPath = string.Format("{0}\\{1}", DIRPath, report.RDLCName);
            report.SetReport(ref Viewer);
            return Viewer;
        }

        /// <summary>
        /// 외부에서 주입받은 ReportViewer 즉, Viewer 객체를 세팅한다
        /// </summary>
        /// <param name="RDLCPath">리포트 정의파일의 경로</param>
        /// <param name="data">리포트 작성에 사용될 데이터테이블</param>
        public ReportViewer GetReportViewer(ref ReportViewer Viewer, RDLC report)
        {
            Viewer.LocalReport.ReportPath = string.Format("{0}\\{1}", Environment.CurrentDirectory, report.RDLCName); ;
            report.SetReport(ref Viewer);
            return Viewer;
        } 
        #endregion
        #region PDF,Excel,Word로 보고서를 변환
        public void PDFWriter(string FilePath,ReportViewer Viewer)
        {
            byte[] byteListData = Viewer.LocalReport.Render("PDF");
            using (FileStream fs = File.Create(FilePath))
            {
                fs.Write(byteListData, 0, byteListData.Length);
            }
        }

        public void PDFWriter(string FilePath, RDLC report)
        {
            ReportViewer Viewer = GetReportViewer(report);
            byte[] byteListData = Viewer.LocalReport.Render("PDF");
            using (FileStream fs = File.Create(FilePath))
            {
                fs.Write(byteListData, 0, byteListData.Length);
            }
        }
        public void ExcelWriter(string FilePath, ReportViewer Viewer)
        {
            byte[] byteListData = Viewer.LocalReport.Render("EXCEL");
            using (FileStream fs = File.Create(FilePath))
            {
                fs.Write(byteListData, 0, byteListData.Length);
            }
        }
        public void ExcelWriter(string FilePath, RDLC report)
        {
            ReportViewer Viewer = GetReportViewer(report);
            byte[] byteListData = Viewer.LocalReport.Render("EXCEL");
            using (FileStream fs = File.Create(FilePath))
            {
                fs.Write(byteListData, 0, byteListData.Length);
            }
        }

        public void WordWriter(string FilePath, ReportViewer Viewer)
        {
            byte[] byteListData = Viewer.LocalReport.Render("WORD");
            using (FileStream fs = File.Create(FilePath))
            {
                fs.Write(byteListData, 0, byteListData.Length);
            }
        }
        public void WordWriter(string FilePath, RDLC report)
        {
            ReportViewer Viewer = GetReportViewer(report);
            byte[] byteListData = Viewer.LocalReport.Render("WORD");
            using (FileStream fs = File.Create(FilePath))
            {
                fs.Write(byteListData, 0, byteListData.Length);
            }
        }

        public void ImageWriter(string FilePath, ReportViewer Viewer)
        {
            byte[] byteListData = Viewer.LocalReport.Render("IMAGE");
            using (FileStream fs = File.Create(FilePath))
            {
                fs.Write(byteListData, 0, byteListData.Length);
            }
        }
        public void ImageWriter(string FilePath, RDLC report)
        {
            ReportViewer Viewer = GetReportViewer(report);
            byte[] byteListData = Viewer.LocalReport.Render("IMAGE");
            using (FileStream fs = File.Create(FilePath))
            {
                fs.Write(byteListData, 0, byteListData.Length);
            }
        }
        #endregion
        #region 프린터출력
        /// <summary>
        /// 프린트할 내용이 이미지화 되어서 잠시 저장될 프로퍼티
        /// </summary>
        private Image imgForPrint { get; set; }
        /// <summary>
        /// 이미지 프린트하기
        /// </summary>
        /// <param name="data">
        /// 프린트할 이미지객체 
        /// </param>
        /// <param name="printerName">
        /// 작동할 프린터의 이름   
        /// </param> 
        public void Print(Image data,string printerName)
        {
            imgForPrint = data;
            //[1] 프린트할 페이지 세팅
            PrintDocument printDoc = new PrintDocument();
            printDoc.PrinterSettings.PrinterName = printerName;
            printDoc.PrintPage += printDoc_PrintPage;
            printDoc.Print();
        }
        /// <summary>
        /// 프린트작업 시도 이벤트 핸들러
        /// 실질적인 프린트 작업은 여기서 이루어진다
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void printDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(imgForPrint, new Point(0, 0));
        }

        /// <summary>
        /// 프린트할 내용을 가지고 있는 리포트뷰어객체 에서
        /// 그 내용을 바로 프린트한다
        /// </summary>
        /// <param name="reporter">
        /// 프린트할 내용을 가지고 있는 리포트뷰어객체    
        /// </param>
        /// <param name="printerName">
        /// 작동할 프린터의 이름   
        /// </param>               
        public void Print(ReportViewer reporter, string printerName)
        {
            byte[] byteListData = reporter.LocalReport.Render("IMAGE");
            using (MemoryStream ms = new MemoryStream(byteListData))
            {
                string filePath = System.Environment.CurrentDirectory + "\\" + DateTime.Now.Ticks + ".jpg";
                ImageWriter(filePath, reporter);
                Image img = Image.FromStream(ms);
                Print(img, printerName);
            }           
        }


        #endregion
    }
}
