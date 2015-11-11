using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServiceServer;
using WebServiceServer.VO;
namespace HitPanSQLServicesServer.Controller.DB
{
    class DBManager
    {
        internal void BackupNow(string URL,string BackupPath)
        {
            ServerMain.getInstance().DBBackup(URL, BackupPath);
        }
        internal string RestoreDB(string URL, string BackupPath,bool makeNewDB) 
        {
            string DBName = GetDBNameFromURL(URL);
            ConnectionVO cvo = new ConnectionVO(URL, DBName);
            WebServiceServer.ServerMain.getInstance().RestoreDB(BackupPath, cvo, makeNewDB);
            return DBName;
        }

        internal string CreateDB(string URL) 
        {
            string DBName = GetDBNameFromURL(URL);
            ConnectionVO cvo = new ConnectionVO(URL, DBName);
            WebServiceServer.ServerMain.getInstance().CreateDB(cvo);
            return DBName;            
        }

        internal void DropDB(string URL) 
        {
            string DBName = GetDBNameFromURL(URL);
            ConnectionVO cvo = new ConnectionVO(URL, DBName);
            WebServiceServer.ServerMain.getInstance().DropDB(cvo);
        }

        internal string GetDBNameFromURL(string url)
        {
            string DBName = url.Replace(".", "_");
            DBName = DBName.Replace("http://", "");
            DBName = DBName.Replace(":", "Port");
            return DBName;
        }
    }
}
