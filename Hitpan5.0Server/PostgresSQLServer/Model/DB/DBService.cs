using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PostgresSQLServer.VO;
using System.Collections.Specialized;
using System.IO;
using System.Data;
using System.Diagnostics;
using Npgsql;
using PostgresSQLServer.Enums;
using PostgresSQLServer.Model.Common;
namespace PostgresSQLServer.Model.DB
{
    public class DBService
    {
        /// <summary>
        /// DB커넥션
        /// </summary>
        private NpgsqlConnection NpgConn { get; set; }
        public DBService(ConnectionVO connVO)
        {
            try
            {
                NpgsqlConnectionStringBuilder nsb = new NpgsqlConnectionStringBuilder();
                nsb.Host = "127.0.0.1";
                nsb.Port = 5432;
                nsb.SSL = false;
                nsb.IntegratedSecurity = false;
                nsb.UserName = "postgres";
                nsb.Database = connVO.DataBaseName;
                nsb.Password = connVO.DBPassword;
                nsb.Pooling = false;
                NpgConn = new NpgsqlConnection(nsb.ToString());
                NpgConn.Open();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public DBService(ConnectionVO connVO,string HostURL)
        {
            try
            {
                NpgsqlConnectionStringBuilder nsb = new NpgsqlConnectionStringBuilder();
                nsb.Host = HostURL;
                nsb.Port = 5432;
                nsb.SSL = false;
                nsb.IntegratedSecurity = false;
                nsb.UserName = "postgres";
                nsb.Database = connVO.DataBaseName;
                nsb.Password = connVO.DBPassword;
                NpgConn = new NpgsqlConnection(nsb.ToString());
                NpgConn.Open();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private object SetDataThreadSafe = new object();
        public int SetData(StringCollection QueryBlock) 
        {
            int succCount = 0;
            Exception ex=null;
            bool querySucc = true;

            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                cmd.Connection = NpgConn;
                using (NpgsqlTransaction tran = this.NpgConn.BeginTransaction(IsolationLevel.ReadCommitted))
                {                   
                    cmd.Transaction = tran;                        
                    foreach (string query in QueryBlock)
                    {
                        try
                        {
                            lock (SetDataThreadSafe)
                            {
                                cmd.CommandText = query;
                                succCount += cmd.ExecuteNonQuery();
                            }
                        }
                        catch (Exception e)
                        {
                            querySucc = false;
                            ex = e;
                            break;
                        }
                    }

                    if (querySucc)
                    {
                        tran.Commit();
                        return succCount;
                    }
                    else
                    {
                        if (tran != null)
                        {
                            tran.Rollback();
                        }
                        throw ex;
                    }
                }//End of using(tran)                    
            }//End of Using(cmd)             
        }
        internal DataTable GetData(string Query) 
        {
            DataTable dt = new DataTable();
            try
            {
                using (NpgsqlDataAdapter nda = new NpgsqlDataAdapter(Query, NpgConn))
                {
                    nda.Fill(dt);
                }
            }
            catch (Exception)
            {                
                throw;
            }
            return dt;
        }

        internal void Backup(string BackupFolderPath,BackupFileType bkFileType,string backupServer,string BackupServerPost,string backupServerID,string backupServerPassword) 
        {                       
            try
            {
                //백업 경로 생성
                string DBName = NpgConn.Database;
                string BackupPath = string.Format
                (
                "{0}\\{1}_{2}{3}{4}{5}{6}.bk",
                BackupFolderPath,
                DBName,
                DateTime.Now.Year.ToString().Substring(2,2),
                DateTime.Now.Month.ToString().PadLeft(2, '0'),
                DateTime.Now.Day.ToString().PadLeft(2, '0'),
                DateTime.Now.Hour.ToString().PadLeft(2, '0'),
                DateTime.Now.Minute.ToString().PadLeft(2, '0')
                );


                //옵션 args작성
                StringBuilder sbArgs = new StringBuilder();
                //백업파일 형식
                switch (bkFileType)
                {
                    case BackupFileType.PlainText: { sbArgs.Append(" -F p "); }
                        break;
                    case BackupFileType.Binary: { sbArgs.Append(" -F c "); }
                        break;
                    case BackupFileType.tar: { sbArgs.Append(" -F t "); }
                        break;
                    default:
                        break;
                }
                //출력 파일명
                sbArgs.Append(" -f ");
                sbArgs.Append(BackupPath);
                //데이터베이스 생성구문까지 백업
                sbArgs.Append(" -C ");
                //복구할 데이터베이스
                sbArgs.Append(" -d ");
                sbArgs.Append(NpgConn.Database);
                sbArgs.Append(" -U  ");
                sbArgs.Append(backupServerID);
                sbArgs.Append(" -W ");
                sbArgs.Append(backupServerPassword);
                sbArgs.Append(" -h ");
                sbArgs.Append(backupServer);
                sbArgs.Append(" -p ");
                sbArgs.Append(BackupServerPost);
                new FileExecuter().Exec("pg_dump.exe", sbArgs.ToString());
            }
            catch (Exception)
            {                
                throw;
            }
        }
        internal static void Restore(string DBFilePath, string DBName,string BackupFilePath, BackupFileType bkFileType, string DbID, string DbPassword)
        {
            //db커낵션 확인후 커넥션 끊고 기존db파일 이름 바꿈          
            try
            {
                //원본 DB파일 이름 변경(원본파일 유지 해야 되니까)
                if (File.Exists(DBFilePath))
                {
                    string dbFolder = DBFilePath.Substring(DBFilePath.LastIndexOf("\\") - 1);
                    string oldDbPath = string.Format
                    (
                    "{0}\\{1}_{2}{3}{4}{5}{6}.OldDB",
                    dbFolder,
                    DBName,
                    DateTime.Now.Year.ToString().Substring(2, 2),
                    DateTime.Now.Month.ToString().PadLeft(2, '0'),
                    DateTime.Now.Day.ToString().PadLeft(2, '0'),
                    DateTime.Now.Hour.ToString().PadLeft(2, '0'),
                    DateTime.Now.Minute.ToString().PadLeft(2, '0')
                    );
                    File.Move(DBFilePath, oldDbPath);
                }


                if (bkFileType==BackupFileType.PlainText)
	            {
                    new FileExecuter().Exec("psql.exe", string.Format("{0} < {1}", DBName, BackupFilePath));
	            }
                else
	            {
                    new FileExecuter().Exec("psql.exe", string.Format("{0} < {1}", DBName, BackupFilePath));
	            }                              
            }
            catch (Exception)
            {

                throw;
            }
        }



        public void Dispose() 
        {
            if (NpgConn.State==ConnectionState.Open)
            {
                NpgConn.Dispose();
            }
        }
    }
}
