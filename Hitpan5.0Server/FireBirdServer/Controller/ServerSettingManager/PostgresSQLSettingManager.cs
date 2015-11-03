using WebService.Controller.ServerSettingManager;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using WebService.Model.Common;

namespace WebService.Controller.ServerSettingManager
{
    class PostgresSQLSettingManager:ISettingManager
    {
        public bool CheckServerEngine()
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

        public void AutoBackup(TimeSpan Interval, string BackupFolder)
        {
            throw new NotImplementedException();
        }

        public void SetMirroring(string key, string MirrorPath, bool UseAlram)
        {
            throw new NotImplementedException();
        }

        public void SetServerEngine()
        {
            database_superuser_password = "postgres";
            //자세한 옵션은 http://www.enterprisedb.com/docs/en/9.3/pginstguide/PostgreSQL_Installation_Guide-11.htm#P319_19425 참조
            //원본 설치파일 경로
            string OriginalFile = "";
            if (Environment.Is64BitOperatingSystem)
            {
                OriginalFile = string.Format("{0}\\lib\\PostgresSQLEngineX64\\postgresqlx64.exe", Environment.CurrentDirectory);
            }
            else
            {
                OriginalFile = string.Format("{0}\\lib\\PostgresSQLEngineX86\\postgresqlx86.exe", Environment.CurrentDirectory);
            }


            //설치파일이 있는 경로에 한글이 있으면 안되므로 현재 디렉토리의 루트에 폴더 하나 만들어서 거기에 설치파일 이동시킨 후에 설치
            string rootDIR = Directory.GetDirectoryRoot(Environment.CurrentDirectory);
            string DIR = string.Format("{0}PostgresSQL", rootDIR);
            if (!Directory.Exists(DIR))
            {
                Directory.CreateDirectory(DIR);
            }
            string MovedFilePath = string.Format("{0}\\postgresql.exe", DIR);
            File.Copy(OriginalFile, MovedFilePath, true);
            new FileExecuter().Exec(MovedFilePath, string.Format("--mode unattended  --superpassword {0}", database_superuser_password));

            string ProgramFilesDIR = string.Format("{0}Program Files", Directory.GetDirectoryRoot(Environment.GetFolderPath(Environment.SpecialFolder.Windows)));
            File.Copy(string.Format("{0}\\lib\\pg_hba.conf", Environment.CurrentDirectory), string.Format(@"{0}\PostgreSQL\9.4\data\pg_hba.conf", ProgramFilesDIR), true);
        }
        public string database_superuser_password { get; set; }
    }
}
