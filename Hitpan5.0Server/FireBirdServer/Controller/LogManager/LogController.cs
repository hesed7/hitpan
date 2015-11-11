using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WebServiceServer.Controller.LogManager
{
    class LogController
    {
        private static LogController instance { get; set; }
        private LogController()
        {

        }
        public static LogController getInstance() 
        {
            if (instance==null)
            {
                instance = new LogController();
            }
            return instance;
        }

        internal void WriteLogFile(string Log)
        {
            MessageBox.Show(Log);
        }
    }
}
