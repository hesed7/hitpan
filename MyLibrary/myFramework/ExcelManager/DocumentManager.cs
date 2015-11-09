using System.Data;
using DocumentManager.enums;
using DocumentManager.Controller.Workers;
using DocumentManager.Controller.Workers.ExcelWorker;
namespace DocumentManager
{
    public class DocumentManager
    {
        private DocType docType { get; set; }
        private IDocumentWorker document { get; set; }
        public DocumentManager(DocType docType)
        {
            this.docType = docType;
            switch (docType)
            {
                case DocType.excel:
                    document = new ExcelWorker();
                    break;
                default:
                    break;
            }
        }//End of ctor

        public void WriteDocument(DataTable data,string DocumentPath) 
        {
            document.WriteDocument(data, DocumentPath);
        }
        public DataTable ReadDocument(string DocumentPath) 
        {
            DataTable data= document.ReadDocument(DocumentPath);
            return data;
        }

    }
}
