using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
namespace WebServiceServer.Model.DB.DBEngine
{
    class DBEngineModel
    {
        /// <summary>
        /// PostgresSQLDB서버가 설치 됐는지 여부 반환
        /// </summary>
        /// <returns></returns>
        internal bool CheckServerEngine()
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
        }//End of CheckServerEngine

        /// <summary>
        /// 포스트그레스SQL의 유틸리티툴의 경로 반환
        /// </summary>
        /// <returns></returns>
        internal string GetPostSQLUtillPath() 
        {
            try
            {
                string serviceName = "";//service ID
                string baseDIR = ""; //postgresSQL이 설치된 기본폴더

                if (Environment.Is64BitOperatingSystem)
                {
                    serviceName="postgresql-x64-9.4";
                }
                else
                {
                    serviceName = "postgresql-x86-9.4";
                }
                RegistryKey reg = Registry.LocalMachine.OpenSubKey(string.Format(@"SOFTWARE\PostgreSQL\Installations\{0}", serviceName));
                baseDIR = reg.GetValue("Base Directory").ToString();
                if (baseDIR==null)
                {
                    throw new Exception("설치정보가 레지스트리에 없습니다. postgresSQL을 삭제후 다시 설치 하십시오");
                }
                if (!Directory.Exists(baseDIR))
                {
                    throw new Exception("설치폴더가 존재하지 않습니다. postgresSQL이 삭제되었습니다");
                }
                return string.Format("{0}/bin", baseDIR);

            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }
    }
}
