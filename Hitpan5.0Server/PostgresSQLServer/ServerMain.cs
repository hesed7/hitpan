using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PostgresSQLServer.Controller.DBManager;
using PostgresSQLServer.Controller.UserConnectionManager;
using PostgresSQLServer.VO;
using System.ServiceModel;
using PostgresSQLServer.Delegate;
using SOAP;
using System.Collections.Specialized;
using System.Data;
using System.Windows.Forms;
using System.IO;
using PostgresSQLServer.Controller.ServerSettingManager;
using PostgresSQLServer.Controller.SecurityManager;
using PostgresSQLServer.Controller.UserConnectionManager.Validators.UserName;
using System.ServiceModel.Security;
using PostgresSQLServer.Controller.UserConnectionManager.Validators;
using System.Collections;
namespace PostgresSQLServer
{
    public class ServerMain
    {
        /// <summary>
        /// 세팅값들을 받아서 저장하는 해쉬테이블
        /// </summary>
        internal Hashtable SettingsValue { get; set; }

        /// <summary>
        /// 보안토큰을 제외한 모든 암호화에 사용할 값
        /// </summary>
        internal string EncryptionPassword = "!@#$gissoft1108ok$#@!@#$)(*&";
        /// <summary>
        /// 현재 서비스 활성화 되어있는 서비스의 URL
        /// </summary>
        public StringCollection ActiveServiceList { get; set; }
        /// <summary>
        /// 미러링 실패시에 사용자에게 알려줄 것인지 여부
        /// 미러링 실패가 해결될 때까지 사용자는 DB접속 못한다
        /// </summary>
        public bool UseMirrorAlram { get; set; }
        
        #region 보안설정관련 프로퍼티
        public MessageCredentialType MessageCredentialType { get; set; }
        public string certPath { get; set; }
        public string certPassword { get; set; }
        private deleErrReporter SOAPErrReporter { get; set; } 
        #endregion
        #region 보안시드키값 입력
        
        public void SetSecuritySeed(string seed) 
        {
             SecurityController.SetSecurityTokenSeed(seed);
        }
        #endregion

        #region ctor (싱글톤)
        private static ServerMain instance { get; set; }
        private ServerMain(Hashtable SettingsValue)
        {
            this.SettingsValue = SettingsValue;
            this.SOAPErrReporter = new deleErrReporter(GetErrMessage);
            new ServerSettingController().CheckSQLEngine();
        }
        private ServerMain()
        {
            this.SOAPErrReporter = new deleErrReporter(GetErrMessage);
            new ServerSettingController().CheckSQLEngine();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="SettingsValue">
        /// 서버작동에 필요한 세팅값들을 담고 있는 해쉬테이블
        /// 1.서버의 파일을 이용한 사용자인증시 사용자 목록(MessageCredentialType.Username 사용시)
        ///  key:users value:IDic_string(id),string(password)
        /// 2.MessageCredentialType.Username 사용시에 히트판 DB를 사용자인증에 사용할 것인지 여부
        ///  key:UseHitpanDB value: boolean타입 (true=히트판 DB 사용)
        /// 3.sqㅣEngine에서 사용할 포트(미러링에 사용)
        ///  key:SQLPort value:int형
        ///  
        /// </param>
        /// <returns></returns>
        public static ServerMain getInstance(Hashtable SettingsValue) 
        {
            if (instance == null)
            {
                instance = new ServerMain(SettingsValue);
            }
            return instance;        
        }
        public static ServerMain getInstance()
        {
            if (instance == null)
            {
                instance = new ServerMain();
            }
            return instance;
        }
        #endregion
        #region 서비스 온/오프
        public void ServerOn(IList<ConnectionVO> ConnInfoList, bool UseMessageSecurity)
        {

            ServiceConnController scc = null; //SOAP서비스 컨트롤러
            DBController dc = null;//DB서비스 컨트롤러
            #region WCF 서비스 켜기(SOAP 활성)
            if (UseMessageSecurity && this.MessageCredentialType != MessageCredentialType.None && this.MessageCredentialType != null)
            {
                scc = ServiceConnController.getInstance(SOAPErrReporter, this.MessageCredentialType, this.certPath, this.certPassword);
            }
            else
            {
                scc = ServiceConnController.getInstance(SOAPErrReporter);
            }
            foreach (ConnectionVO connVO in ConnInfoList)
            {
                scc.AddServiceURL(connVO.ServiceURL);
            }
            #endregion
            #region DB커넥션 활성
            dc = DBController.getInstance(ConnInfoList);
            #endregion

            #region DB커낵션과 SOAP 중 하나라도 활성안된 서비스는 둘다 죽인다
            StringCollection DeActivedURL = new StringCollection();
            foreach (string url in scc.ServiceDic.Keys)
            {
                if (!dc.ActiveDBKeyList.Contains(url))
                {
                    DeActivedURL.Add(url);
                }
            }
            foreach (string url in dc.ActiveDBKeyList)
            {
                if (!scc.ServiceDic.Keys.Contains(url))
                {
                    DeActivedURL.Add(url);
                }
            }
            foreach (string url in DeActivedURL)
            {
                scc.ServiceDic[url].Dispose();
                scc.ServiceDic.Remove(url);
                dc.Dispose(url);
            }
            #endregion
            ActiveServiceList = dc.ActiveDBKeyList;
        }
        public void ServerOFF()
        {
            DBController.getInstance().Dispose();
            ServiceConnController.getInstance().Dispose();
        } 
        #endregion
        #region 미러링,백업,복구
        public void DBBackup(string serviceURL, string BackupFolderPath)
        {
            DBController.getInstance().BackupDB(serviceURL, BackupFolderPath);
        }
        public void SetMirror(string ServiceURL, string MirrorPath)
        {
            new ServerSettingController().SetMirroring(ServiceURL, MirrorPath, this.UseMirrorAlram);
        }
        public void RestoreDB(string BackupFilePath, ConnectionVO connVO)
        {
            DBController.RestoreDB(BackupFilePath, connVO);
        } 
        #endregion
        #region DB만들기
        public void CreateDB(ConnectionVO connVO)
        {
         //   DBController.CreateDB(connVO);
        } 
        #endregion

        #region 로컬계정으로 DB쿼리
        public int SetData(string ServiceURL, StringCollection QueryBlock)
        {
            return DBController.getInstance().SetData(ServiceURL, QueryBlock);
        }
        public DataTable GetLocalData(string ServiceURL, string Query)
        {
            return DBController.getInstance().GetData(ServiceURL, Query);
        }
        public DataTable GetPlan(string ServiceURL, string Query)
        {
            return DBController.getInstance().GetPlan(ServiceURL, Query);
        } 
        #endregion




        internal void GetErrMessage(Exception ex) 
        {                      
            MessageBox.Show(ex.Message);
        }


    }
}
