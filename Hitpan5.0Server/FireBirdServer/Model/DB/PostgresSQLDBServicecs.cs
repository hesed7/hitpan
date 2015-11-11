using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Text;
using Npgsql;
using WebServiceServer.VO;
using WebServiceServer.Model.Common;
using WebServiceServer.Model.DB.DBEngine;
using System.IO;
namespace WebServiceServer.Model.DB
{
    class PostgresSQLDBServicecs :IDBService
    {
        /// <summary>
        /// DB커넥션
        /// </summary>
        private NpgsqlConnection NpgConn { get; set; }
        public ConnectionVO myConnVO { get; set; }


        /// <summary>
        /// 서버전체를 백업할 것인지 여부
        /// </summary>
        public bool WholeBackup { get; set; }
        public PostgresSQLDBServicecs(ConnectionVO connVO)
        {
            try
            {
                this.myConnVO = connVO;
                NpgsqlConnectionStringBuilder nsb = new NpgsqlConnectionStringBuilder();
                nsb.Host = connVO.HostURL;
                nsb.Port = 5432;
                nsb.SSL = false;
                nsb.IntegratedSecurity = false;
                nsb.UserName = connVO.DBID;
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

        public PostgresSQLDBServicecs(ConnectionVO connVO, string HostURL)
        {
            try
            {
                this.myConnVO = connVO;
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




        

        public DataTable GetData(string Query)
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
        public DataTable GetData(string procedureName,IList<SQLProcedureParameterVO> ParameterList)
        {
            //저장프로시저와 커맨드 객체 연결
            NpgsqlCommand nCMD = new NpgsqlCommand(procedureName, this.NpgConn);
            nCMD.CommandType = CommandType.StoredProcedure;
            foreach (SQLProcedureParameterVO SQLProcedureParameterVO in ParameterList)
            {
                var parameter = nCMD.CreateParameter();
                parameter.ParameterName = SQLProcedureParameterVO.parameterName;
                parameter.DbType = SQLProcedureParameterVO.DBType;
                parameter.Value = SQLProcedureParameterVO.value;
                nCMD.Parameters.Add(parameter);
            }

            //커맨드객체와 데이터어댑터 연결 및 데이터테이블 Get
            DataTable dt = new DataTable();
            try
            {
                using (NpgsqlDataAdapter nda = new NpgsqlDataAdapter(nCMD))
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
        private object SetDataThreadSafe = new object();
        public int SetData(StringCollection QueryBlock)
        {
            int succCount = 0;
            Exception ex = null;
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

        public int SetData(string procedureName, IList<SQLProcedureParameterVO> ParameterList)
        {
            int succCount = 0;
            Exception ex = null;
            bool querySucc = true;

            //저장프로시저와 커맨드 객체 연결
            NpgsqlCommand nCMD = new NpgsqlCommand(procedureName, this.NpgConn);
            nCMD.CommandType = CommandType.StoredProcedure;
            foreach (SQLProcedureParameterVO SQLProcedureParameterVO in ParameterList)
            {
                var parameter = nCMD.CreateParameter();
                parameter.ParameterName = SQLProcedureParameterVO.parameterName;
                parameter.DbType = SQLProcedureParameterVO.DBType;
                parameter.Value = SQLProcedureParameterVO.value;
                nCMD.Parameters.Add(parameter);
            }


            using (nCMD)
            {
                using (NpgsqlTransaction tran = this.NpgConn.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    nCMD.Transaction = tran;
                    try
                    {
                        lock (SetDataThreadSafe)
                        {
                            succCount += nCMD.ExecuteNonQuery();
                        }
                    }
                    catch (Exception e)
                    {
                        querySucc = false;
                        ex = e;
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
        public void Dispose()
        {
            NpgConn.Dispose();
        }
        public static void CreateDB(ConnectionVO connVO) 
        {
            try
            {
                //[1] postgresSQL설치여부 검증
                if (!new DBEngineModel().CheckServerEngine())
                {
                    throw new Exception("PostgresSQL서버가 설치되어 있지 않습니다. 프로그램을 다시 시작하여 주십시오");
                }
                //[2] postgresSQL설치된 경로 가져오기
                string createdbPath = string.Format("{0}/createdb.exe", new DBEngineModel().GetPostSQLUtillPath());
                
                //[3] postgresSQL설치된 경로에서 createdb.exe 실행해서 DB생성
                string createdb_args = string.Format("-h 127.0.0.1 -p {0} -U {1}  -O {1} -E {2} {3}", connVO.port, connVO.DBID, connVO.Charset, connVO.DataBaseName);
                new FileExecuter().Exec(createdbPath, createdb_args);                               
            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }
        public static void ExecScript(string scriptPath, ConnectionVO connVO) 
        {
            if (!new DBEngineModel().CheckServerEngine())
            {
                throw new Exception("PostgresSQL서버가 설치되어 있지 않습니다. 프로그램을 다시 시작하여 주십시오");
            }
            string psqlPath = string.Format("{0}\\psql.exe", new DBEngineModel().GetPostSQLUtillPath());
            string psql_args = string.Format("-h {0} -p {1} -U {2} -d {3} -a -f {4}", connVO.HostURL,connVO.port,connVO.DBID, connVO.DataBaseName, scriptPath);
            new FileExecuter().Exec(psqlPath, psql_args);
        }
        public void Backup(string ServiceURL, string BackupFolderPath)
        {
            if (!new DBEngineModel().CheckServerEngine())
            {
                throw new Exception("PostgresSQL서버가 설치되어 있지 않습니다. 프로그램을 다시 시작하여 주십시오");
            }

            //[1] 백업파일 이름 작성
            BackupFolderPath = BackupFolderPath.Replace("\\", "/");

            StringBuilder sbBackupFile = new StringBuilder();
            sbBackupFile.Append(BackupFolderPath);
            sbBackupFile.Append("/");
            sbBackupFile.Append(DateTime.Now.Year.ToString().PadLeft(2));
            sbBackupFile.Append(DateTime.Now.Month.ToString().PadLeft(2, '0'));
            sbBackupFile.Append(DateTime.Now.Day.ToString().PadLeft(2, '0'));
            sbBackupFile.Append(DateTime.Now.Hour.ToString().PadLeft(2, '0'));
            sbBackupFile.Append(DateTime.Now.Minute.ToString().PadLeft(2, '0'));
            sbBackupFile.Append(DateTime.Now.Second.ToString().PadLeft(2, '0'));
            sbBackupFile.Append("_");
            sbBackupFile.Append(ServiceURL.Replace("http://", "").Replace(":", "Port").Replace(".", "_"));
            sbBackupFile.Append(".dump");

            string pg_dumpPath = "";
            string pg_dump_args =
                string.Format(
                "-h {0} -p {1} -U {2} -a -b  -d {3} -f {4}"
                , myConnVO.HostURL
                , myConnVO.port
                , myConnVO.DBID
                , myConnVO.DataBaseName
                , sbBackupFile.ToString()
                );
            if (WholeBackup)
            {
                pg_dumpPath = string.Format("{0}/pg_dumpall.exe", new DBEngineModel().GetPostSQLUtillPath());
            }
            else
            {
                pg_dumpPath = string.Format("{0}/pg_dump.exe", new DBEngineModel().GetPostSQLUtillPath());
            }
            new FileExecuter().Exec(pg_dumpPath, pg_dump_args);
            //백업파일 압축
            new ZIPManager().Zip(sbBackupFile.ToString(), sbBackupFile.ToString().Replace(".dump", ".gz"));
            if (File.Exists(sbBackupFile.ToString().Replace(".dump", ".gz")))
            {
                File.Delete(sbBackupFile.ToString());
            }
        }
        public static void Restore(string BackupFilePath, ConnectionVO connVO,bool makeNewDB) 
        {
            if (!new DBEngineModel().CheckServerEngine())
            {
                throw new Exception("PostgresSQL서버가 설치되어 있지 않습니다. 프로그램을 다시 시작하여 주십시오");
            }
            //[1] 백업파일 압축해제
            string tmpDump = string.Format("{0}\\tmpDump{1}.dump", BackupFilePath.Substring(0, BackupFilePath.LastIndexOf("\\")), DateTime.Now.Ticks);
            new ZIPManager().UnZip(tmpDump, BackupFilePath);
            if (!File.Exists(tmpDump))
            {
                return;
            }

            //DB생성
            if (makeNewDB)
            {
                CreateDB(connVO);
                ExecScript(string.Format("{0}\\lib\\htpDBSchema.sql", Environment.CurrentDirectory), connVO);
            }

            ExecScript(tmpDump, connVO);

            //임시 덤프파일 삭제
            File.Delete(tmpDump);
        }
        public static void DropDB( ConnectionVO connVO) 
        {
            if (!new DBEngineModel().CheckServerEngine())
            {
                throw new Exception("PostgresSQL서버가 설치되어 있지 않습니다. 프로그램을 다시 시작하여 주십시오");
            }
            string dropdbPath = string.Format("{0}\\dropdb.exe", new DBEngineModel().GetPostSQLUtillPath());
            string dropdb_args = string.Format("-h {0} -p {1} -U {2} {3}", connVO.HostURL, connVO.port, connVO.DBID, connVO.DataBaseName);
            new FileExecuter().Exec(dropdbPath, dropdb_args);            
        }
    }
}
