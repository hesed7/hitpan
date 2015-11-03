using libHitpan5.VO.DocumentInfo;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using libHitpan5.Model.DocumentModel;
using System.Data;
using libHitpan5.enums;
using System.IO;
using Newtonsoft.Json;
using System.Drawing.Printing;
namespace libHitpan5.Controller.Common.DocumentController
{
    public class abDocController
    {
        #region 관련 프로퍼티
        /// <summary>
        /// 리포트 작업 관련한 모델객체
        /// </summary>
        internal ReportService reportModel { get; set; }
        #endregion
        #region ctor
        /// <summary>
        /// ResetReport 메서드 수행시에만 사용한다
        /// </summary>
        public abDocController()
        {
            this.reportModel = new ReportService();
        } 
        #endregion
        #region ReportViewer에 리포트 객체 생성 및 적용
  
        public void SetReporter(ref ReportViewer viewer, string DocumentInfoPath, object Data)
        {
            //DocumentVO객체변환
            string jsonData = File.ReadAllText(DocumentInfoPath, Encoding.UTF8);
            DocumentVO dv = JsonConvert.DeserializeObject<DocumentVO>(jsonData);
            //리포트 생성
            SetReporter(ref viewer,dv.DefaultRDLC,Data);
        }       
        /// <summary>
        /// 리포트뷰어에 기본 RDLC의 페이지세팅을 적용해서 리포트를 보여준다
        /// </summary>
        /// <param name="viewer"></param>
        /// <param name="dv"></param>
        /// <param name="RDLCFileName"></param>
        /// <param name="Data"></param>
        public void SetReporter(ref ReportViewer viewer,DocumentVO dv, string RDLCFileName, object Data)
        {
            //리포트 생성
            SetReporter(ref viewer,dv.DefaultRDLC,Data);
        }
        /// <summary>
        /// 리포트뷰어에 매개변수의 RDLC를 가지고 리포트를 보여준다
        /// </summary>
        /// <param name="viewer"></param>
        /// <param name="rdlc"></param>
        /// <param name="Data"></param>
        public void SetReporter(ref ReportViewer viewer, RDLC rdlc, object Data)
        {
            rdlc.Data = Data;
            reportModel.GetReportViewer(ref viewer, rdlc);
        }
        #endregion
        #region 파일변환
        /// <summary>
        /// 정해진 보고서 형식에 따라 
        /// 호환파일형식으로 
        /// 파일을 만든다
        /// </summary>
        /// <param name="FileType"></param>
        /// <param name="FilePath"></param>
        public void Converter(호환파일형식 FileType, string FilePath,RDLC ReportInfo,object data)
        {
            ReportInfo.Data = data;
            switch (FileType)
            {
                case 호환파일형식.Excel:
                    reportModel.ExcelWriter(FilePath, ReportInfo);
                    break;
                case 호환파일형식.PDF:
                    reportModel.PDFWriter(FilePath, ReportInfo);
                    break;
                case 호환파일형식.Word:
                    reportModel.WordWriter(FilePath, ReportInfo);
                    break;
                case 호환파일형식.Image:
                    reportModel.ImageWriter(FilePath, ReportInfo);
                    break;
                default:
                    break;
            }
        }
        public void Converter(호환파일형식 FileType, string FilePath, RDLC ReportInfo)
        {
            ReportInfo.Data = null;
            switch (FileType)
            {
                case 호환파일형식.Excel:
                    reportModel.ExcelWriter(FilePath, ReportInfo);
                    break;
                case 호환파일형식.PDF:
                    reportModel.PDFWriter(FilePath, ReportInfo);
                    break;
                case 호환파일형식.Word:
                    reportModel.WordWriter(FilePath, ReportInfo);
                    break;
                case 호환파일형식.Image:
                    reportModel.ImageWriter(FilePath, ReportInfo);
                    break;
                default:
                    break;
            }
        } 
        #endregion
        #region 프린트
        public void Print(ReportViewer viewer,string PrinterName)
        {
            if (PrinterName==string.Empty)
            {
                PrinterName = new libHitpan5.Controller.Common.DocumentController.Printer.PrintController().GetDefaultPrinter();
            }
            reportModel.Print(viewer, PrinterName);
        } 
        #endregion

        #region 도큐먼트 정보 가져오기

        /// <summary>
        /// 도큐먼트 파일 리스트 구하기
        /// </summary>
        /// <returns></returns>
        public string[] GetDocumentFileList()
        {
            string[] FileList = Directory.GetFiles(Environment.CurrentDirectory, "*.docInfo");
            return FileList;
        }
        /// <summary>
        /// 도큐먼트정보객체를 도큐먼트정보파일로부터 생성
        /// </summary>
        /// <param name="FilePath"></param>
        /// <returns></returns>
        public DocumentVO GetDocumentVO(string FilePath)
        {
            if (!FilePath.Contains(".docInfo"))
            {
                return null;
            }
            string strJsonData = File.ReadAllText(FilePath, Encoding.UTF8);
            DocumentVO dv = JsonConvert.DeserializeObject<DocumentVO>(strJsonData);
            return dv;
        }
        #endregion
        #region 도큐먼트정보객체 생성
        public DocumentVO MakeDocumentVO(RDLC defaultRDLC, string printerName)
        {
            DocumentVO documentVO = new DocumentVO();
            IList<RDLC> RDLCList = new List<RDLC>();
            RDLCList.Add(defaultRDLC);
            documentVO = new DocumentVO();
            documentVO.RDLCList = RDLCList;
            documentVO.DefaultRDLC = defaultRDLC;
            documentVO.DefaultRDLC.PrinterName = printerName;
            return documentVO;
        }
        public DocumentVO MakeDocumentVO(string RDLCName, string DataSetName, string printerName)
        {
            DocumentVO documentVO = new DocumentVO();
            IList<RDLC> RDLCList = new List<RDLC>();
            RDLC defaultRDLC = new RDLC(RDLCName, DataSetName);
            RDLCList.Add(defaultRDLC);
            documentVO = new DocumentVO();
            documentVO.RDLCList = RDLCList;
            documentVO.DefaultRDLC = defaultRDLC;
            return documentVO;
        }
        #endregion
        #region 도큐먼트정보파일 생성
        public void MakeDocumentInfoFile(string path, DocumentVO documentVO)
        {
            string jsonData = JsonConvert.SerializeObject(documentVO);
            using (StreamWriter sw = File.CreateText(path))
            {
                sw.Write(jsonData);
            }
        }
        public void MakeDocumentInfoFile(string path, string printerName, string RDLCPath, string DataSetName)
        {
            DocumentVO documentVO = MakeDocumentVO(RDLCPath, DataSetName, printerName);
            string jsonData = JsonConvert.SerializeObject(documentVO);
            using (StreamWriter sw = File.CreateText(path))
            {
                sw.Write(jsonData);
            }
        }
        #endregion
        #region 도큐먼트정보파일 수정하기
        public void ModifyDocumentInfoFile_DefaultRDLC(string DocumentFilePath, RDLC DefaultRDLC)
        {
            DocumentVO dv = JsonConvert.DeserializeObject<DocumentVO>(File.ReadAllText(DocumentFilePath, Encoding.UTF8));
            dv.DefaultRDLC = DefaultRDLC;
            ModifyDocumentVO_ChangeRDLC(DefaultRDLC, ref dv);
            File.WriteAllText(DocumentFilePath, JsonConvert.SerializeObject(dv), Encoding.UTF8);
        }
        public void ModifyDocumentInfoFile_RDLC(string DocumentFilePath, RDLC RDLC)
        {
            DocumentVO dv = JsonConvert.DeserializeObject<DocumentVO>(File.ReadAllText(DocumentFilePath, Encoding.UTF8));
            ModifyDocumentVO_ChangeRDLC(RDLC, ref dv);
            File.WriteAllText(DocumentFilePath, JsonConvert.SerializeObject(dv), Encoding.UTF8);
        }
        public void ModifyDocumentInfoFile_Printer(string DocumentFilePath, string printerName)
        {
            DocumentVO dv = JsonConvert.DeserializeObject<DocumentVO>(File.ReadAllText(DocumentFilePath, Encoding.UTF8));
            dv.DefaultRDLC.PrinterName = printerName;
            File.WriteAllText(DocumentFilePath, JsonConvert.SerializeObject(dv), Encoding.UTF8);
        }
        public void ModifyDocumentInfoFile_DocumentDetailInfo(string DocumentFilePath, object DocumentDetailInfo)
        {
            DocumentVO dv = JsonConvert.DeserializeObject<DocumentVO>(File.ReadAllText(DocumentFilePath, Encoding.UTF8));
            dv.DocumentDetailInfo = DocumentDetailInfo;
            File.WriteAllText(DocumentFilePath, JsonConvert.SerializeObject(dv), Encoding.UTF8);
        }
        public void ModifyDocumentInfoFile_StampImagePath(string DocumentFilePath, string StampImagePath)
        {
            DocumentVO dv = JsonConvert.DeserializeObject<DocumentVO>(File.ReadAllText(DocumentFilePath, Encoding.UTF8));
            dv.StampImagePath = StampImagePath;
            File.WriteAllText(DocumentFilePath, JsonConvert.SerializeObject(dv), Encoding.UTF8);
        }
        /// <summary>
        /// DocumentVO 에서 리스트에 등록된 RDLC 변경
        /// </summary>
        /// <param name="rdlc"></param>
        /// <param name="dv"></param>
        private void ModifyDocumentVO_ChangeRDLC(RDLC rdlc, ref DocumentVO dv)
        {
            IList<RDLC> newRDLCList = new List<RDLC>();
            foreach (RDLC r in dv.RDLCList)
            {
                if (r.RDLCName != rdlc.RDLCName)
                {
                    newRDLCList.Add(r);
                }
            }
            newRDLCList.Add(rdlc);
            dv.RDLCList = newRDLCList;
        } 
        #endregion
        #region RDLC정보를 도큐먼트정보객체(파일)에 추가하기
        public void AddRDLC(ref DocumentVO documentVO, string RDLCPath, string DataSetName, RDLC[] SubReportList)
        {
            RDLC r = new RDLC();
            r.DataSetName = DataSetName;
            r.RDLCName = RDLCPath;
            r.SubReportList = SubReportList;
            documentVO.RDLCList.Add(r);
        }
        public void AddRDLC(ref DocumentVO documentVO, string RDLCPath, string DataSetName)
        {
            RDLC r = new RDLC();
            r.DataSetName = DataSetName;
            r.RDLCName = RDLCPath;
            documentVO.RDLCList.Add(r);
        }
        public void AddRDLC(string documentVOPath, string RDLCPath, string DataSetName)
        {
            string jsonData = File.ReadAllText(documentVOPath, Encoding.UTF8);
            DocumentVO dVO = JsonConvert.DeserializeObject<DocumentVO>(jsonData);
            AddRDLC(ref dVO, RDLCPath, DataSetName);
            jsonData = JsonConvert.SerializeObject(dVO);
            File.WriteAllText(documentVOPath, jsonData);
        }
        public void AddRDLC(string documentVOPath, string RDLCPath, string DataSetName, RDLC[] SubReportList)
        {
            string jsonData = File.ReadAllText(documentVOPath, Encoding.UTF8);
            DocumentVO dVO = JsonConvert.DeserializeObject<DocumentVO>(jsonData);
            AddRDLC(ref dVO, RDLCPath, DataSetName, SubReportList);
            jsonData = JsonConvert.SerializeObject(dVO);
            File.WriteAllText(documentVOPath, jsonData);
        }
        #endregion
        #region RDLC정보를 도큐먼트정보객체(파일)에서 제거하기
        public void RemoveRDLC(ref DocumentVO documentVO, string RDLCFileName)
        {
            IList<RDLC> rdlcList = new List<RDLC>();
            foreach (RDLC rdlc in documentVO.RDLCList)
            {
                if (rdlc.RDLCName != RDLCFileName)
                {
                    rdlcList.Add(rdlc);
                }   
            }
            documentVO.RDLCList = rdlcList;
        }
        public void RemoveRDLC(string documentVOPath, string RDLCPath, string DataSetName)
        {
            string jsonData = File.ReadAllText(documentVOPath, Encoding.UTF8);
            DocumentVO dVO = JsonConvert.DeserializeObject<DocumentVO>(jsonData);
            RemoveRDLC(ref dVO, RDLCPath);
            jsonData = JsonConvert.SerializeObject(dVO);
            File.WriteAllText(documentVOPath, jsonData);
        }
        #endregion
    }
}
