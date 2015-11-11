using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebServiceServer.Controller.DBManager;
using WebServiceServer.Controller.UserConnectionManager;
using WebServiceServer.VO;
using System.ServiceModel;
using WebServiceServer.Delegate;
using SOAP;
using System.Collections.Specialized;
using System.Data;
using System.Windows.Forms;
using System.IO;
using WebServiceServer.Controller.ServerSettingManager;
using WebServiceServer.Controller.SecurityManager;
using WebServiceServer.Controller.UserConnectionManager.Validators.UserName;
using System.ServiceModel.Security;
using WebServiceServer.Controller.UserConnectionManager.Validators;
using System.Collections;
using System.Net.NetworkInformation;
using WebServiceServer.Model.DB;
using WebServiceServer.Enums;
namespace WebServiceServer
{
    public class ServerMain
    {
        private ServiceConnController ServiceConnController { get; set; }
        private ISettingManager settingManager { get; set; }
        private DBController dbConn { get; set; }
        /// <summary>
        /// 모든 암호화에 사용할 값
        /// 맥어드레스
        /// </summary>
        internal string EncryptionPassword { get; set; }
        /// <summary>
        /// key:서비스 시도 했던 URL, value: 서비스 시도 성공여부
        /// </summary>
        public IDictionary<string,bool> ActiveServiceDic { get; set; }
        /// <summary>
        /// 미러링 실패시에 사용자에게 알려줄 것인지 여부
        /// 미러링 실패가 해결될 때까지 사용자는 DB접속 못한다
        /// </summary>
        public bool UseMirrorAlram { get; set; }
        
        #region 보안설정관련 프로퍼티
        internal string SecurityTokenSeed { get; set; }
        public MessageCredentialType MessageCredentialType { get; set; }
        public string certPath { get; set; }
        public string certPassword { get; set; }
        private deleErrReporter SOAPErrReporter { get; set; }

        #endregion

        #region 문자열 암호화 하기
        public String GetEncryptedString(string plainText) 
        {
            return SecurityController.GetEncryptedString(plainText);
        }

        public String GetDecryptedString(string EncryptedText)
        {
            return SecurityController.GetDecryptedString(EncryptedText);
        }
        #endregion
        #region ctor (싱글톤)
        private static ServerMain instance { get; set; }
        private ServerMain()
        {
            settingManager = new PostgresSQLSettingManager();
            if (!settingManager.CheckServerEngine())
            {
                settingManager.SetServerEngine();
            }

            this.SOAPErrReporter = new deleErrReporter(GetErrMessage);            
            this.ActiveServiceDic = new Dictionary<string, bool>();
            this.EncryptionPassword= this.GetMacAddr();
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
        #region 보안토큰시드 입력
        public void SetSecurityToken(string tokenSeed) 
        {
            this.SecurityTokenSeed = tokenSeed;
        }
        #endregion
        #region 서비스 온/오프

        /// <summary>
        /// 서비스 준비
        /// </summary>
        /// <param name="UseMessageSecurity"></param>
        public void ServerOn(bool UseMessageSecurity)
        {
            EncryptionPassword = GetMacAddr();
            this.ActiveServiceDic = new Dictionary<string, bool>();
            if (UseMessageSecurity && this.MessageCredentialType != MessageCredentialType.None)
            {
                this.ServiceConnController = ServiceConnController.getInstance(SOAPErrReporter, this.MessageCredentialType, this.certPath, this.certPassword);
            }
            else
            {
                this.ServiceConnController = ServiceConnController.getInstance(SOAPErrReporter);
            }
            if (this.dbConn == null)
            {
                this.dbConn = DBController.getInstance();
            }
        }

        public void ServerOFF()
        {
            
            if (dbConn!=null)
            {
                dbConn.Dispose();
            }
            if (this.ServiceConnController!=null)
            {
                if (this.ServiceConnController.Activity)
                {
                    this.ServiceConnController.Dispose();
                } 
            }
            ActiveServiceDic.Clear();
        } 
        #endregion
        #region 서비스URL추가,삭제
        public void AddService(ConnectionVO connVO) 
        {
            this.ServiceConnController.AddServiceURL(connVO.ServiceURL);
            dbConn.AddDBConnection(connVO);
            CheckServices();
        }
        public void AddService(IList<ConnectionVO> connVOList)
        {
            foreach (ConnectionVO connVO in connVOList)
            {
                this.ServiceConnController.AddServiceURL(connVO.ServiceURL);
                dbConn.AddDBConnection(connVO); 
            }
            CheckServices();
        }
        public void DeleteService(string ServiceURL) 
        {
            this.ServiceConnController.Dispose(ServiceURL);
            dbConn.Dispose(ServiceURL);
            this.ActiveServiceDic[ServiceURL] = false;
        }
        #endregion
        #region 미러링,백업,복구
        public void DBBackup(string serviceURL, string BackupFolderPath)
        {
            if (dbConn==null)
            {
                throw new Exception("서버가 아직 활성화 되지 않았습니다");
            }
            dbConn.BackupDB(serviceURL, BackupFolderPath);
        }
        public void SetMirror(string ServiceURL, string MirrorPath)
        {
            settingManager.SetMirroring(ServiceURL, MirrorPath, this.UseMirrorAlram);
        }
        public void RestoreDB(string BackupFilePath, ConnectionVO connVO,bool makeNewDB)
        {
            DBController.RestoreDB(BackupFilePath, connVO, makeNewDB);
        } 
        #endregion
        #region DB만들기
        public void CreateDB(ConnectionVO connVO)
        {
            DBController.getInstance().CreateDB(connVO);
        } 
        #endregion
        #region DB삭제
        public void DropDB(ConnectionVO connVO)
        {
            DBController.getInstance().DropDB(connVO);
        }
        #endregion
        #region 로컬계정으로 DB쿼리
        public int SetData(string ServiceURL, StringCollection QueryBlock)
        {
            if (dbConn == null)
            {
                throw new Exception("서버가 아직 활성화 되지 않았습니다");
            }
            return dbConn.SetData(ServiceURL, QueryBlock);
        }
        public DataTable GetLocalData(string ServiceURL, string Query)
        {
            if (dbConn == null)
            {
                throw new Exception("서버가 아직 활성화 되지 않았습니다");
            }
            return dbConn.GetData(ServiceURL, Query);
        }
        public DataTable GetPlan(string ServiceURL, string Query)
        {
            if (dbConn == null)
            {
                throw new Exception("서버가 아직 활성화 되지 않았습니다");
            }
            return dbConn.GetPlan(ServiceURL, Query);
        } 
        #endregion
        #region 내부 사용만 하는 메서드
        internal void GetErrMessage(Exception ex)
        {
            MessageBox.Show(ex.Message);
        }


        private string GetMacAddr()
        {
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            string mac = "";
            foreach (NetworkInterface adapter in nics)
            {
                if (mac == "")
                {
                    IPInterfaceProperties ipProp = adapter.GetIPProperties();
                    mac = adapter.GetPhysicalAddress().ToString();
                    break;
                }
            }
            return mac;
        }
        /// <summary>
        /// 서비스 활성 체크해서 문제있으면 그에 따르는 조치 취하고
        /// 서비스 활성도 체크하는 ActiveServiceDic을 자동으로 갱신하다
        /// </summary>
        /// <param name="scc"></param>
        private void CheckServices()
        {
            #region DB커낵션과 SOAP 중 하나라도 활성안된 서비스는 둘다 죽인다
            //웹서비스 wcf 점검
            try
            {
                IList<string> ServiceURLList = new List<string>();
                IList<string> DBConnURLList = new List<string>();
                foreach (string url in this.ServiceConnController.ServiceDic.Keys)
                {
                    ServiceURLList.Add(url);
                }
                foreach (string url in dbConn.ActiveDBKeyList)
                {
                    DBConnURLList.Add(url);
                }
                foreach (string wcf_url in ServiceURLList)
                {
                    bool isExist = false;
                    foreach (string dbConn_url in dbConn.ActiveDBKeyList)
                    {
                        if (wcf_url == dbConn_url)
                        {
                            isExist = true;
                            break;
                        }
                    }
                    if (!isExist)
                    {
                        this.ServiceConnController.Dispose(wcf_url);
                        ActiveServiceDic[wcf_url] = false;
                    }
                    else
                    {
                        ActiveServiceDic[wcf_url] = true;
                    }
                }
                //웹서비스 DB연결 점검
                foreach (string dbConn_url in DBConnURLList)
                {
                    bool isExist = false;
                    foreach (string wcf_url in ServiceURLList)
                    {
                        if (dbConn_url == wcf_url)
                        {
                            isExist = true;
                            break;
                        }
                    }
                    if (!isExist)
                    {
                        dbConn.Dispose(dbConn_url);
                        ActiveServiceDic[dbConn_url] = false;
                    }
                    else
                    {
                        ActiveServiceDic[dbConn_url] = true;
                    }
                }
            }
            catch (Exception)
            {
                
                throw;
            }
            #endregion
        } 
        #endregion

    }
}
