using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PostgresSqlManager.Model.Install;
using System.IO;
using Microsoft.Win32;
namespace PostgresSqlManager.Controller.InstallController
{
    class InstallManager
    {       
        /// <summary>
        /// 설치관리 모델
        /// </summary>
        public InstallModel installer { get; set; }
        /// <summary>
        /// 64비트 os인 경우 Wow6432Node를 사용하는지 여부
        /// </summary>
        public bool UseWow6432Node { get; set; }
        public InstallManager()
        {
            installer = new InstallModel();
        }

        /// <summary>
        /// 설치 되었는지 체크하고 설치 안되어 있으면 설치한다
        /// </summary>
        /// <param name="Settings">세팅정보가 들어있는 딕셔너리</param>
        /// <returns>설치된 서버가 있는지 여부(설치 성공여부가 아님)</returns>
        internal bool CheckInstall(IDictionary<string,string> Settings) 
        {
            UseWow6432Node = false;//64비트 os에서 32비트 서버를 돌리는지 여부
            //이미 설치됐는지 아직 설치되지 않았는지 체크
            if (!(installer.InstallChecker(PostgresSQLManager.getInstance().FilePath, PostgresSQLManager.getInstance().RegistryPath)) && !(installer.InstallChecker(PostgresSQLManager.getInstance().FilePathWow6432Node, PostgresSQLManager.getInstance().RegistryPathWow6432Node)))
            {
                //설치 안된 경우
                string ServerConfFile = string.Format("{0}\\PostgresSQLConf.gedit", Environment.CurrentDirectory);                
                //세팅파일 만들기
                foreach (string key in Settings.Keys)
                {
                    File.AppendAllText(ServerConfFile, string.Format("{0}={1}\r\n", key, Settings[key]));
                }
                //설치하기
                installer.InstallPostgresSql(ServerConfFile);

                if (Environment.Is64BitOperatingSystem)
                {
                    UseWow6432Node = true;
                }
                return false;
            }
            else
            {
                //설치된 경우                
                if (Environment.Is64BitOperatingSystem)
                {
                    if (!(installer.InstallChecker(PostgresSQLManager.getInstance().FilePath, PostgresSQLManager.getInstance().RegistryPath)))
                    {
                        UseWow6432Node = true;
                    }
                }
                return true;
            }
        }
    }
}
