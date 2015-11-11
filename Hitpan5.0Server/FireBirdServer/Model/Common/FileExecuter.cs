using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.IO;
namespace WebServiceServer.Model.Common
{
    class FileExecuter
    {
        internal void Exec(string FilePath,string args) 
        {
            using (Process p = new Process())
	        {
                p.StartInfo = new ProcessStartInfo(FilePath,args);
                p.Start();
                p.WaitForExit();
	        }
        }
        internal string ExecWithReturnValue(string FilePath, string args)
        {
            string ReturnValue = "";
            using (Process p = new Process())
            {
                p.StartInfo = new ProcessStartInfo(FilePath, args);
                p.Start();
                using (StreamReader sr=p.StandardOutput)
                {
                    ReturnValue = sr.ReadToEnd();
                }
            }
            return ReturnValue;
        }
    }
}
