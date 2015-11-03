using WebService.VO;
using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using WebService.Controller.LogManager;
using System.Data;
using WebService.Model.DB;
using WebService.Enum;
namespace WebService.Controller.DBManager
{
    class DBController
    {
        /// <summary>
        /// DB커넥션 을 키값과 함께 저장
        /// </summary>
        private IDictionary<string, IDBService> ConnDic { get; set; }
        public StringCollection ActiveDBKeyList { get; set; }

        #region 싱글톤
        private static DBController instance { get; set; }
        private DBController()
        {
            if (ConnDic == null)
            {
                ConnDic = new Dictionary<string, IDBService>();
                ActiveDBKeyList = new StringCollection();

            }
        }//End of ctor
        public static DBController getInstance()
        {
            if (instance == null)
            {
                instance = new DBController();
            }
            return instance;
        }

        #endregion
        internal static void CreateDB(ConnectionVO connVO,string scriptPath) 
        {
            FirebirdDBService.CreateDB(connVO, scriptPath);            
        }
        internal static void RestoreDB(string BackupFilePath, ConnectionVO connVO)
        {
            FirebirdDBService.Restore(connVO.DataBasePath,BackupFilePath, connVO.DBID,connVO.DBPassword);            
        }
        internal void BackupDB(string ServiceURL, string BackupFolderPath) 
        {
            ConnDic[ServiceURL].Backup(ServiceURL, BackupFolderPath);
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

        internal void Dispose()
        {
            foreach (var key in ConnDic.Keys)
            {
                if (ConnDic[key]!=null)
                {
                    ConnDic[key].Dispose();
                }
            }
            ActiveDBKeyList.Clear();
            ConnDic.Clear();
            this.ActiveDBKeyList = new StringCollection();
        }
        internal void Dispose(string url)
        {
            //잘못된 URL형식 걸러내기
            if (!(url.Contains("http://")) || (url.Replace("http://", string.Empty).Length == 0))
            {
                return;
            }
            if (ConnDic[url] != null)
            {
                ConnDic[url].Dispose();
                ConnDic.Remove(url);
            }            
            ActiveDBKeyList.Remove(url);
        }

        internal void AddDBConnection(ConnectionVO connVO)
        {
            //잘못된 URL형식 걸러내기
            if (!(connVO.ServiceURL.Contains("http://")) || (connVO.ServiceURL.Replace("http://", string.Empty).Length == 0))
            {
                return;
            }

            try
            {
                IDBService DBModel = new FirebirdDBService(connVO);               
                ConnDic.Add(connVO.ServiceURL, DBModel);
                ActiveDBKeyList.Add(connVO.ServiceURL);
            }
            catch (Exception ex)
            {
                LogController.getInstance().WriteLogFile(ex.Message);
            }
        }

        internal void AddDBConnection(IList<ConnectionVO> connVOList)
        {
            foreach (ConnectionVO connVO in connVOList)
            {
                //잘못된 URL형식 걸러내기
                if (!(connVO.ServiceURL.Contains("http://")) || (connVO.ServiceURL.Replace("http://", string.Empty).Length == 0))
                {
                    return;
                }

                try
                {
                    IDBService DBModel = new FirebirdDBService(connVO);
                    ConnDic.Add(connVO.ServiceURL, DBModel);
                    ActiveDBKeyList.Add(connVO.ServiceURL);
                }
                catch (Exception ex)
                {
                    LogController.getInstance().WriteLogFile(ex.Message);
                    continue;
                }
            }//End of Foreach
        }
    }
}