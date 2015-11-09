using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Microsoft.Win32;
using System.Diagnostics;
using PostgresSqlManager.Properties;
namespace PostgresSqlManager.Model.Install
{
    class InstallModel
    {       
        internal bool InstallChecker(string FileDIR,RegistryKey Reg) 
        {
            bool isInstalled = true;
            //파일시스템에서 검색
            if (!(Directory.GetFiles(FileDIR, "psql").Length > 0))
            {
                isInstalled = false;
            }
            //레지스트리에서 검색
            if (Reg.GetValueNames().Length ==0)
	        {
                isInstalled = false;
	        }  
          
            // 설치된 경우는 true반환
            if (isInstalled)
	        {
		        return true;
	        }
            else
            {
                return false;
            }
        }





        /// <summary>
        /// postgresSQL무인설치
        /// </summary>
        /// <param name="confFilePath"></param>
        internal void InstallPostgresSql(string confFilePath) 
        {            
            string filePath = string.Format("{0}\\lib\\postgresql-9.4.4-3-windows.exe", Environment.CurrentDirectory);
            Process p = new Process();
            p.StartInfo = new ProcessStartInfo(filePath, string.Format("--mode unattended --optionfile {0}", confFilePath));            
            p.StartInfo.CreateNoWindow=true;
            p.Start();
            // 설치를 수동모드로 했는지 자동모드로 했는지 저장 
            Settings.Default.IsAutoInstall = true;
        }

        /// <summary>
        /// postgresSQL설치
        /// </summary>
        internal void InstallPostgresSql() 
        {
            //자동설치가 아닌 경우는 각각 프로세스에 맞게 설치
            string filePath = string.Format("{0}\\lib", Environment.CurrentDirectory);
            if (Environment.Is64BitOperatingSystem)
            {
                filePath = string.Format("{0}\\postgresql-9.4.4-3-windows-x64.exe", filePath);
            }
            else
            {
                filePath = string.Format("{0}\\postgresql-9.4.4-3-windows.exe", filePath);
            }
            Process p = new Process();
            p.StartInfo = new ProcessStartInfo(filePath);
            p.StartInfo.CreateNoWindow = true;
            p.Start();
            // 설치를 수동모드로 했는지 자동모드로 했는지 저장 
            Settings.Default.IsAutoInstall = false;
        }

    }
}
