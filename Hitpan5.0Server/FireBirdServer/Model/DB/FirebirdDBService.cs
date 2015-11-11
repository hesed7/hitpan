using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FirebirdSql.Data.Client;
using FirebirdSql.Data.FirebirdClient;
using WebServiceServer.VO;
using System.Collections.Specialized;
using System.IO;
using System.Data;
using System.Diagnostics;
using FirebirdSql.Data.Services;
using WebServiceServer.Model.DB;
namespace WebServiceServer.Model.DB
{
    public class FirebirdDBService : IDBService
    {
        /// <summary>
        /// DB커넥션
        /// </summary>
        private FbConnection fbConn { get; set; }
        public FirebirdDBService(ConnectionVO connVO)
        {
            try
            {
                
                FbConnectionStringBuilder FbSb = new FbConnectionStringBuilder();
                FbSb.Charset = connVO.Charset;
                //FbSb.Database = connVO.DataBasePath;
                FbSb.UserID = connVO.DBID;
                FbSb.Password = connVO.DBPassword;
                FbSb.ServerType = FbServerType.Embedded;
                fbConn = new FbConnection(FbSb.ToString());
                fbConn.Open();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        /// <summary>
        /// DB파일 생성
        /// </summary>
        /// <param name="connVO">DB생성정보</param>
        public static void CreateDB(ConnectionVO connVO, string scriptFilePath) 
        {
            FbConnectionStringBuilder FbSb = new FbConnectionStringBuilder();
            FbSb.Charset = connVO.Charset;
            //FbSb.Database = connVO.DataBasePath;
            FbSb.DataSource = "localhost";
            FbSb.ServerType = FbServerType.Embedded;
            string connstr= FbSb.ToString();
            try
            {
                FbConnection.CreateDatabase(connstr);
                string script = File.ReadAllText(scriptFilePath);                
                
                using (FbConnection fbConn = new FbConnection(connstr))
                {
                    fbConn.Open();
                    using (FbCommand fcmd= new FbCommand(script,fbConn))
                    {
                        fcmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private object SetData_ThreadSafe = new object();
        public int SetData(StringCollection QueryBlock) 
        {
            int succCount = 0;
            Exception ex=null;
            lock (SetData_ThreadSafe)
            {
                using (FbTransaction fbt = fbConn.BeginTransaction())
                {
                    bool querySucc = true;
                    foreach (string query in QueryBlock)
                    {
                        using (FbCommand cmd = new FbCommand(query, fbConn, fbt))
                        {
                            try
                            {
                                succCount += cmd.ExecuteNonQuery();
                            }
                            catch (Exception e)
                            {
                                querySucc = false;
                                ex = e;
                                break;
                            }
                        }
                    }//End of Foreach
                    if (querySucc)
                    {
                        fbt.Commit();
                        return succCount;
                    }
                    else
                    {
                        if (fbt != null)
                        {
                            fbt.Rollback();
                        }
                        throw ex;
                    }
                }//End of Using(fbt) 
            }
        }
        public DataTable GetData(string Query) 
        {
            FbConnection Conn = this.fbConn;
            DataTable dt = new DataTable();
            try
            {
                using (FbDataAdapter fda = new FbDataAdapter(Query, Conn))
                {
                    fda.Fill(dt);
                }
            }
            catch (Exception)
            {                
                throw;
            }
            return dt;
        }

        public void Backup(string ServiceURL, string BackupFolderPath) 
        {                       
            try
            {
                //백업 경로 생성
                string DBPath=fbConn.Database;
                string BackupPath = string.Format
                (
                "{0}\\{1}{2}{3}{4}{5}{6}{7}.gbk",
                BackupFolderPath,
                (ServiceURL.Replace("http://",string.Empty)).Replace(":","_port"),
                "Date(YYMMDDHHmm)",
                DateTime.Now.Year.ToString().Substring(2),
                DateTime.Now.Month.ToString().PadLeft(2, '0'),
                DateTime.Now.Day.ToString().PadLeft(2, '0'),
                DateTime.Now.Hour.ToString().PadLeft(2, '0'),
                DateTime.Now.Minute.ToString().PadLeft(2, '0')
                );

                //백업 파일객체 생성
                FbBackupFile bkFile = new FbBackupFile(BackupPath);
                //백업하기
                FbBackup backup = new FbBackup();               
                backup.BackupFiles.Add(bkFile);
                backup.ConnectionString = fbConn.ConnectionString;
                backup.Execute();
            }
            catch (Exception)
            {                
                throw;
            }
        }
        public static void Restore(string DBFilePath, string BackupFilePath, string DbID, string DbPassword)
        {
            //db커낵션 확인후 커넥션 끊고 기존db파일 이름 바꿈          
            try
            {
                //커넥션 스트링 작성
                FbConnectionStringBuilder fsb = new FbConnectionStringBuilder();
                fsb.Database = DBFilePath;
                fsb.UserID = DbID;
                fsb.Password = DbPassword;
                fsb.ServerType = FbServerType.Embedded;
                //커넥션풀 클리어
                FbConnection.ClearAllPools();
                //원본 DB파일 이름 변경(원본파일 유지 해야 되니까)
                if (File.Exists(DBFilePath))
                {
                    string dbFolder= DBFilePath.Substring(DBFilePath.LastIndexOf("\\")+1);
                    string oldDbPath= string.Format
                    (
                    "{0}\\old_{1}{2}{3}{4}{5}{6}.fdb",
                    dbFolder,
                    DBFilePath.Substring(DBFilePath.LastIndexOf("\\") + 1).Replace(".fdb", string.Empty),
                    DateTime.Now.Year.ToString().Substring(2),
                    DateTime.Now.Month.ToString().PadLeft(2, '0'),
                    DateTime.Now.Day.ToString().PadLeft(2, '0'),
                    DateTime.Now.Hour.ToString().PadLeft(2, '0'),
                    DateTime.Now.Minute.ToString().PadLeft(2, '0')
                    );
                    File.Move(DBFilePath, oldDbPath);
                }
                
                //백업 파일 객체 생성
                FbBackupFile bkFile = new FbBackupFile(BackupFilePath);
                //위의 백업파일로부터 복구시작
                FbRestore restore= new FbRestore();
                restore.BackupFiles.Add(bkFile);
                restore.Options = FbRestoreFlags.Create;
                restore.ConnectionString = fsb.ToString();
                restore.Execute();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Dispose() 
        {
            if (fbConn.State==ConnectionState.Open)
            {
                fbConn.Dispose();
            }
        }
    }
}
