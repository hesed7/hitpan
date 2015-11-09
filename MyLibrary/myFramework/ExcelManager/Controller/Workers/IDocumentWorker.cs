using System;
namespace DocumentManager.Controller.Workers
{
    public interface IDocumentWorker
    {
         void Dispose(object obj);
         System.Data.DataTable ReadDocument(string DocumentPath);
         void WriteDocument(System.Data.DataTable data, string DocumentPath);
    }
}
