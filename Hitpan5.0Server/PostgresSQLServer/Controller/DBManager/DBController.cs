using PostgresSQLServer.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using PostgresSQLServer.Controller.LogManager;
using System.Data;
using PostgresSQLServer.Model.Common;
using PostgresSQLServer.Model.DB;
using System.IO;
namespace PostgresSQLServer.Controller.DBManager
{
    class DBController
    {
        /// <summary>
        /// DB커넥션 을 키값과 함께 저장
        /// </summary>
        private IDictionary<string, DBService> ConnDic { get; set; }
        public StringCollection ActiveDBKeyList { get; set; }
        #region 싱글톤
        private static DBController instance { get; set; }
        private DBController(IList<ConnectionVO> connInfoList)
        {
            LoadDBTools();
            if (ConnDic == null)
            {
                ConnDic = new Dictionary<string, DBService>();
                ActiveDBKeyList = new StringCollection();

            }
            foreach (ConnectionVO connVO in connInfoList)
            {
                try
                {
                    DBService DBModel = new DBService(connVO);
                    ConnDic.Add(connVO.ServiceURL, DBModel);
                    ActiveDBKeyList.Add(connVO.ServiceURL);
                }
                catch (Exception ex)
                {
                    LogController.getInstance().WriteLogFile(ex.Message);
                    continue;
                }
            }//End of Foreach
        }//End of ctor
        public static DBController getInstance(IList<ConnectionVO> connInfoList)
        {
            if (instance == null)
            {
                instance = new DBController(connInfoList);
            }
            return instance;
        }
        public static DBController getInstance()
        {
            if (instance == null)
            {
                throw new Exception("DBController가 초기화 되지 않은 상태입니다");
            }
            return instance;
        } 
        #endregion
        internal static void RestoreDB(string BackupFilePath, ConnectionVO connVO)
        {
          //  DBService.Restore(connVO.DataBasePath, BackupFilePath,connVO.DBID,connVO.DBPassword);
        }
        internal void BackupDB(string ServiceURL, string BackupFolderPath) 
        {
           // ConnDic[ServiceURL].Backup(BackupFolderPath);
        }
        internal int SetData(string key, StringCollection QueryBlock) 
        {
            return ConnDic[key].SetData(QueryBlock);
        }
        internal DataTable GetData(string key, string Query) 
        {
            return ConnDic[key].GetData(Query);
        }
        internal DataTable GetPlan(string key, string Query) 
        {
            StringBuilder sbQuery = new StringBuilder();
            sbQuery.Append("SET PLANONLY ON ");
            sbQuery.Append(Query);
            sbQuery.Append(" SET PLANONLY OFF");
            DataTable planTable= ConnDic[key].GetData(sbQuery.ToString());
            return planTable;
        }


        private void AddDB(ConnectionVO connVO) { }
        private bool CheckDB(ConnectionVO connVO) 
        {
            //string DBList = new FileExecuter().ExecWithReturnValue("psql.exe", @"\list");
            //if (DBList)
            //{
                
            //}
            return true;
        }
        private void LoadDBTools()
        {
            string pg_restore = "";
            string psql = "";
            string pg_dumpPath = "";
            if (Environment.Is64BitOperatingSystem && Environment.Is64BitProcess)
            {
                pg_restore = string.Format("{0}\\lib\\PostgresSQLEngineX64\\pg_restore.exe", Environment.CurrentDirectory);
                psql = string.Format("{0}\\lib\\PostgresSQLEngineX64\\psql.exe", Environment.CurrentDirectory);
                pg_dumpPath = string.Format("{0}\\lib\\PostgresSQLEngineX64\\pg_dump.exe", Environment.CurrentDirectory);
            }
            else if (!Environment.Is64BitOperatingSystem && !Environment.Is64BitProcess)
            {
                pg_restore = string.Format("{0}\\lib\\PostgresSQLEngineX86\\pg_restore.exe", Environment.CurrentDirectory);
                psql = string.Format("{0}\\lib\\PostgresSQLEngineX86\\psql.exe", Environment.CurrentDirectory);
                pg_dumpPath = string.Format("{0}\\lib\\PostgresSQLEngineX86\\pg_dump.exe", Environment.CurrentDirectory);
            }
            else
            {
                throw new Exception("프로세서와 운영체제간에 아키텍쳐가 불일치 합니다. 백업이 불가능 합니다");
            }
            //pg_restore 파일 복사
            File.Copy(pg_restore, string.Format("{0}\\pg_restore.exe", Environment.CurrentDirectory));
            File.Copy(pg_restore, string.Format("{0}\\psql.exe", Environment.CurrentDirectory));
            File.Copy(pg_restore, string.Format("{0}\\pg_dump.exe", Environment.CurrentDirectory));
        }
        internal void Dispose()
        {
            foreach (var key in ConnDic.Keys)
            {
                if (ConnDic[key]!=null)
                {
                    ConnDic[key].Dispose();
                }
            }
        }
        internal void Dispose(string url)
        {
            if (ConnDic[url] != null)
            {
                ConnDic[url].Dispose();
            }
            ConnDic.Remove(url);
            ActiveDBKeyList.Remove(url);
        }
    }
}
