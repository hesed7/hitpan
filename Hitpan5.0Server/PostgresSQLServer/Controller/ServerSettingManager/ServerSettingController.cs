using PostgresSQLServer.Controller.DBManager;
using PostgresSQLServer.Model.Common;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.Win32;
namespace PostgresSQLServer.Controller.ServerSettingManager
{
    public class ServerSettingController
    {
        internal bool CheckSQLEngine() 
        {
            //postgresSQL이 설치되었는지 검증
            try
            {
                RegistryKey reg = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\PostgreSQL\Services");
                string[] subkeys = reg.GetSubKeyNames();
                //이미 설치가 된 경우
                if (subkeys.Length > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {               
                return false;
            }
        }

        /// <summary>
        /// PostgresSQL설치
        /// </summary>
        public  void InstallSQLEngine(string database_superuser_password )
        {

            //자세한 옵션은 http://www.enterprisedb.com/docs/en/9.3/pginstguide/PostgreSQL_Installation_Guide-11.htm#P319_19425 참조
            //원본 설치파일 경로
            string OriginalFile = "";
            if (Environment.Is64BitOperatingSystem)
            {
                OriginalFile = string.Format("{0}\\lib/PostgresSQLEngineX64\\postgresqlx64.exe", Environment.CurrentDirectory);
            }
            else
            {
                OriginalFile = string.Format("{0}\\lib/PostgresSQLEngineX86\\postgresqlx86.exe", Environment.CurrentDirectory);
            }
            

            //설치파일이 있는 경로에 한글이 있으면 안되므로 현재 디렉토리의 루트에 폴더 하나 만들어서 거기에 설치파일 이동시킨 후에 설치
            string rootDIR=Directory.GetDirectoryRoot(Environment.CurrentDirectory);
            string DIR = string.Format("{0}PostgresSQL", rootDIR);
            if (!Directory.Exists(DIR))
            {
                Directory.CreateDirectory(DIR);
            }            
            string MovedFilePath=string.Format("{0}\\postgresql.exe", DIR);
            File.Copy(OriginalFile, MovedFilePath,true);
            new FileExecuter().Exec(MovedFilePath, string.Format("--mode unattended  --superpassword {0}", database_superuser_password));

            string ProgramFilesDIR = string.Format("{0}Program Files", Directory.GetDirectoryRoot(Environment.GetFolderPath(Environment.SpecialFolder.Windows)));
            File.Copy(string.Format("{0}\\lib\\pg_hba.conf", Environment.CurrentDirectory), string.Format(@"{0}\PostgreSQL\9.4\data\pg_hba.conf", ProgramFilesDIR), true);
        }



        internal void AutoBackup(TimeSpan Interval, string BackupFolder)
        {

        }



        private IDictionary<string, int> MirrorIDStorage = new Dictionary<string, int>();
        internal void SetMirroring(string key, string MirrorPath, bool UseAlram)
        {
            //미러링 id 초기화 필요하면 초기화 한다
            if (MirrorIDStorage[key] == 0)
            {
                MirrorIDStorage[key] = 1;
            }

            StringBuilder sbShadow = new StringBuilder();
            sbShadow.Append("Create Shadow ");
            sbShadow.Append(MirrorIDStorage[key]);
            sbShadow.Append(" ");
            if (UseAlram)
            {
                sbShadow.Append("AUTO ");
            }
            else
            {
                sbShadow.Append("MANUAL ");
            }
            sbShadow.AppendFormat("'{0}' ", MirrorPath);

            StringCollection sc = new StringCollection();
            sc.Add(sbShadow.ToString());
            if (DBController.getInstance().SetData(key, sc) != null)
            {
                MirrorIDStorage[key]++;
            }
            else
            {
                throw new Exception("미러링(쉐도잉) 을 세팅하지 못했습니다");
            }

        }
    }
}
