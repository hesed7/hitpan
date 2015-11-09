using System;
using System.Text;
using Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using System.Data.OleDb;
using System.IO;
namespace DocumentManager.Controller.Workers.ExcelWorker
{
    internal class ExcelWorker : IDocumentWorker
    {
        private Application  app { get; set; }
        private Workbook book { get; set; }
        private Worksheet sheet { get; set; }
        public ExcelWorker()
        {
            app = new Application();
            book = app.Workbooks.Add();
            sheet = book.Worksheets[1] as Worksheet;
        }


        /// <summary>
        /// 엑셀파일을 쓴다
        /// </summary>
        /// <param name="data">엑셀파일의 내용으로 쓰일 데이터테이블</param>
        /// <param name="DocumentPath">작성할 엑셀파일의 경로</param>
        public void WriteDocument(System.Data.DataTable data, string DocumentPath) 
        {
            try
            {
                int r = 0;
                foreach (System.Data.DataRow dr in data.Rows)
                {
                    int c = 0;
                    foreach (System.Data.DataColumn dc in data.Columns)
                    {
                        sheet.Cells[r+1, c+1] = data.Rows[r][c];
                        c++;
                    }
                    r++;
                }
                book.SaveAs(DocumentPath, XlFileFormat.xlWorkbookNormal);
                book.Close(true);
                app.Quit();
            }
            catch (Exception)
            {

                throw;
            }
            finally 
            {
                Dispose(sheet);
                Dispose(book);
                Dispose(app);
            }
        }
        /// <summary>
        /// 엑셀파일을 읽는다
        /// </summary>
        /// <param name="ExcelFilePath">엑셀파일의 경로</param>
        /// <returns></returns>
        public System.Data.DataTable ReadDocument(string ExcelFilePath) 
        {
            System.Data.DataTable data = new System.Data.DataTable();
            OleDbConnection conn = null;
            OleDbDataAdapter adapter = null;
            StringBuilder sbConn = new StringBuilder();
            sbConn.Append("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=");
            sbConn.Append(ExcelFilePath);
            try
            {
                using (conn = new OleDbConnection(sbConn.ToString()))
                {
                    using (adapter = new OleDbDataAdapter("SELECT * FROM [Sheet1$]", conn))
                    {
                        adapter.Fill(data);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally 
            {
                if (adapter!=null)
                {
                    adapter.Dispose();
                }
                if (conn.State.Equals("Open"))
                {
                    conn.Dispose();
                }
            }
            return data;
        }
        /// <summary>
        /// 엑셀 파일객체 해제
        /// </summary>
        /// <param name="obj"></param>
        public void Dispose(object obj)
        {
            try
            {
                if (obj != null)
                {
                    Marshal.ReleaseComObject(obj);
                    obj = null;
                }
            }
            catch (Exception ex)
            {
                obj = null;
                throw ex;
            }
            finally
            {
                GC.Collect();
            }
        }
    }
}
