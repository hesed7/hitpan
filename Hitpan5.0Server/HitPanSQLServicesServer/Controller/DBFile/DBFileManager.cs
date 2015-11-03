using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebService;
using WebService.VO;
namespace HitPanSQLServicesServer.Controller.DBFile
{
    class DBFileManager
    {
        internal void BackupNow(string URL,string BackupPath)
        {
            ServerMain.getInstance().DBBackup(URL, BackupPath);
        }
        internal string RestoreDB(string URL, string BackupPath,string DBFolder) 
        {
            string DBName = URL.Replace("http://", string.Empty);
            DBName = DBName.Replace(":", "Port");
            DBName = DBName + ".fdb";
            string DBPath = string.Format("{0}\\{1}", DBFolder,DBName);
            ConnectionVO cvo = new ConnectionVO(URL,DBPath);
            WebService.ServerMain.getInstance().RestoreDB(BackupPath,cvo);
            return DBPath;
        }

        internal string CreateDBFile(string URL, string DBFolder) 
        {
            string DBName = URL.Replace("http://", string.Empty);
            DBName = DBName.Replace(":", "Port");
            DBName = DBName + ".fdb";
            string DBPath = string.Format("{0}\\{1}", DBFolder, DBName);
            ConnectionVO cvo = new ConnectionVO(URL, DBPath);
            WebService.ServerMain.getInstance().CreateDB(cvo);
            return DBPath;            
        }
    }
}
