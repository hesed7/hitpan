using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using PostgresSqlManager.Controller.InstallController;
namespace PostgresSqlManager
{
    public class PostgresSQLManager
    {
        #region 레지스트리 및 설치경로
       internal  string FilePath = @"C:\Program Files\PostgreSQL\9.4\bin";
       internal  string FilePathWow6432Node = @"C:\Program Files (x86)\PostgreSQL\9.4\bin";
       internal  RegistryKey RegistryPath = Registry.LocalMachine.OpenSubKey(@"\SOFTWARE\PostgreSQL\Installations\postgresql-9.4\postgresql-9.4");
       internal  RegistryKey RegistryPathWow6432Node = Registry.LocalMachine.OpenSubKey(@"\SOFTWARE\Wow6432Node\PostgreSQL\Installations\postgresql-9.4\postgresql-9.4");
        #endregion

        /// <summary>
       /// Wow6432Node를 사용하는지
        /// </summary>
        public bool UseWow6432Node { get; set; }
        private static PostgresSQLManager instance { get; set; }
        private PostgresSQLManager()
        {

        }
        public static PostgresSQLManager getInstance()
        {
            if (instance==null)
            {
                instance = new PostgresSQLManager();
            }
            return instance;
        }
        /// <summary>
        /// 설치 되었는지 체크하고 설치 안되어 있으면 설치한다
        /// </summary>
        /// <param name="Settings"></param>
        internal void CheckServer(IDictionary<string, string> Settings)
        {


            //이미 설치됐는지 아직 설치되지 않았는지 체크
            InstallManager im= new InstallManager();
            bool UseServer= im.CheckInstall(Settings);
            this.UseWow6432Node = im.UseWow6432Node;
            if (UseServer)
            {
                //이미 설치된 경우 레지스트리 세팅을 통한 서버세팅
                if (UseWow6432Node)
                {
                    
                }
                else
                {

                }
            }


        }        
        
        
        
    }
}
