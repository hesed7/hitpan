using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using libHitpan5.Model.DocumentModel;
namespace libHitpan5.Controller.Common.DocumentController.Printer
{
    public class PrintController
    {
        private PrinterModel printerModel { get; set; }
        public PrintController()
        {
            printerModel = new PrinterModel();            
        }
        public System.Drawing.Printing.PrinterSettings.StringCollection GetPrinterList() 
        {
            return printerModel.GetPrinterNameList();
        }
        public string GetDefaultPrinter() 
        {
            return printerModel.GetDefaultPrinterName();
        }
    }
}
