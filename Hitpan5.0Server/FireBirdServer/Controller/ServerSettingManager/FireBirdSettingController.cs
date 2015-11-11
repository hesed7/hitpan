using WebServiceServer.Controller.DBManager;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using WebServiceServer;

namespace WebServiceServer.Controller.ServerSettingManager
{
    internal class FireBirdSettingController : ISettingManager
    {
        public void SetServerEngine() 
        {
            //복사할 원본파일경로를 저장
            StringCollection sc = new StringCollection();
            //64비트,32비트에 따른 서버구성파일의 루트경로 정하기
            string rootPath = "";
            if (Environment.Is64BitOperatingSystem)
            {
                rootPath = string.Format("{0}\\lib\\Firebird2.5.4X64", Environment.CurrentDirectory);
            }
            else //32비트
            {
                rootPath = string.Format("{0}\\lib\\Firebird2.5.4X86", Environment.CurrentDirectory);
            }

            //원본파일경로를 컬렉션에 로드 
            foreach (string FilePath in Directory.GetFiles(rootPath))
            {
                sc.Add(FilePath);
            }
            sc.Add(string.Format("{0}\\udf\\fbudf.dll", rootPath));
            sc.Add(string.Format("{0}\\intl\\fbintl.dll", rootPath));

            //컬렉션에 있는 파일경로에 따라 원본파일을 복사
            foreach (string SourceFile in sc)
            {
                string destFileName = string.Format("{0}\\{1}", Environment.CurrentDirectory, SourceFile.Substring(SourceFile.LastIndexOf("\\") + 1));
                File.Copy(SourceFile, destFileName,true);
            }                    
        }

        public void AutoBackup(TimeSpan Interval, string BackupFolder)
        {

        }



        private IDictionary<string, int> MirrorIDStorage = new Dictionary<string, int>();
        public void SetMirroring(string key, string MirrorPath, bool UseAlram)
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
            try 
            {
                DBController.getInstance().SetData(key, sc);
                MirrorIDStorage[key]++;
	        }
	        catch (Exception)
	        {		
		        throw new Exception("미러링(쉐도잉) 을 세팅하지 못했습니다");;
	        }
        }

        public bool CheckServerEngine()
        {
            throw new NotImplementedException();
        }
    }
}
