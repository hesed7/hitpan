using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
namespace libHitpan5.Model.DocumentModel
{
    public class PrinterModel
    {
        public System.Drawing.Printing.PrinterSettings.StringCollection GetPrinterNameList()
        {
            System.Drawing.Printing.PrinterSettings.StringCollection sc = PrinterSettings.InstalledPrinters;
            return sc;
        }

        public string GetDefaultPrinterName()
        {
            string defaultPrinter = string.Empty;
            PrinterSettings setting = new PrinterSettings();
            foreach (string printer in GetPrinterNameList())
            {
                setting.PrinterName = printer;
                if (setting.IsDefaultPrinter)
                {
                    defaultPrinter = printer;
                    break;
                }
            }//End of Foreach
            return defaultPrinter;
        }
    }
}
