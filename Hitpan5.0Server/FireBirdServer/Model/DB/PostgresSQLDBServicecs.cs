using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Text;
using Npgsql;
using WebService.VO;
namespace WebService.Model.DB
{
    class PostgresSQLDBServicecs :IDBService
    {
        /// <summary>
        /// DB커넥션
        /// </summary>
        private NpgsqlConnection NpgConn { get; set; }        
        public PostgresSQLDBServicecs(ConnectionVO connVO)
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

        public PostgresSQLDBServicecs(ConnectionVO connVO, string HostURL)
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

        public void Backup(string ServiceURL, string BackupFolderPath)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
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
        public static void CreateDB(string scriptPath) { }
        public static void Restore(string BackupFilePath, ConnectionVO connVO) { }
    }
}
