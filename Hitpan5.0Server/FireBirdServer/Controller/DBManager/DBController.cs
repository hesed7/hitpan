using WebServiceServer.VO;
using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using WebServiceServer.Controller.LogManager;
using System.Data;
using WebServiceServer.Model.DB;
using WebServiceServer.Enums;
namespace WebServiceServer.Controller.DBManager
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
        #region Create/Drop DB
        internal void CreateDB(ConnectionVO connVO)
        {
            try
            {
                //db가 이미 존재하는지 검증
                IDBService ds = new PostgresSQLDBServicecs(connVO);
                ds.Dispose();
                return;
            }
            catch (Exception)
            {
                //DB가 없으면 DB를 만든다
                PostgresSQLDBServicecs.CreateDB(connVO);
                PostgresSQLDBServicecs.ExecScript(string.Format("{0}\\lib\\htpDBSchema.sql", Environment.CurrentDirectory), connVO);
            }

        }
        internal void DropDB(ConnectionVO connVO)
        {
            try
            {
                //db가  존재하는지 검증
                IDBService ds = new PostgresSQLDBServicecs(connVO);
                ds.Dispose();
            }
            catch (Exception)
            {
                return; //DB가 없는 경우는 그냥 나간다                
            }
            try
            {
                //DB에 연결되어 있는 경우는 연결 종료한다
                ConnDic[connVO.ServiceURL].Dispose();
            }
            catch (Exception) { }
            PostgresSQLDBServicecs.DropDB(connVO);
        } 
        #endregion
        #region Restore/Backup DB
        internal static void RestoreDB(string BackupFilePath, ConnectionVO connVO, bool makeNewDB)
        {
            PostgresSQLDBServicecs.Restore(BackupFilePath, connVO, makeNewDB);
        }
        internal void BackupDB(string ServiceURL, string BackupFolderPath)
        {
            ConnDic[ServiceURL].Backup(ServiceURL, BackupFolderPath);
        } 
        #endregion
        #region Data Setter/Getter
        internal int SetData(string key, string Query)
        {
            StringCollection sc = new StringCollection();
            sc.Add(Query);
            return ConnDic[key].SetData(sc);
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
            DataTable planTable = ConnDic[key].GetData(sbQuery.ToString());
            return planTable;
        }
        #endregion
        #region Add/Dispose DBConnection
        internal void Dispose()
        {
            foreach (var key in ConnDic.Keys)
            {
                if (ConnDic[key] != null)
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
                IDBService DBModel = new PostgresSQLDBServicecs(connVO);
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
                    IDBService DBModel = new PostgresSQLDBServicecs(connVO);
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
        #endregion
    }
}