﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebService;
using HitPanSQLServicesServer.VO;
using WebService.VO;
namespace HitPanSQLServicesServer.Controller.WebServices
{
    class WebServiceManager
    {
        public bool  ServerReady { get; set; }
        private ServerMain ServerConsole { get; set; }
        private CommonSettingsVO CommonSetting { get; set; }
        public WebServiceManager(CommonSettingsVO CommonSetting)
        {
            SetCommonSetting(CommonSetting);
        }

        public void SetCommonSetting(CommonSettingsVO CommonSetting) 
        {
            this.CommonSetting = CommonSetting;
            ServerConsole = ServerMain.getInstance();
            ServerConsole.certPassword = CommonSetting.certPassword;
            ServerConsole.certPath = CommonSetting.certPath;
            ServerConsole.MessageCredentialType = CommonSetting.MessageCredentialType;
            ServerConsole.UseMirrorAlram = CommonSetting.UseMirrorAlram;
            ServerConsole.SetSecurityToken(CommonSetting.SecurityTokenSeed);
        }

        public void ServerOn(bool UseSecurityMode) 
        {
            ServerConsole.ServerOn(UseSecurityMode);
            ServerReady = true;
        }
        public void ServerOFF()
        {
            ServerConsole.ServerOFF();
            ServerReady = false;
        }

        #region 서비스URL추가,삭제
        public void AddService(ConnectionVO connVO)
        {
            if (!this.ServerReady)
            {
                throw new Exception("서버가 준비되지 않았습니다");
            }
            //중복된 URL골라내기
            bool isDuplicate = false;
            IDictionary<string,bool> serviceDic=WebService.ServerMain.getInstance().ActiveServiceDic;
            ICollection<string> urlList = serviceDic.Keys;
            foreach (string url in urlList)
            {
                if (connVO.ServiceURL==url)
	            {
                    isDuplicate = true;
                    break;
	            }
            }
            if (!isDuplicate)
            {
                ServerConsole.AddService(connVO);                
            }
            
        }
        public void AddService(IList<ConnectionVO> connVOList)
        {
            if (!this.ServerReady)
            {
                throw new Exception("서버가 준비되지 않았습니다");
            }
            //중복된 URL골라내기
            IList<ConnectionVO> _connVOList = new List<ConnectionVO>();
            if (WebService.ServerMain.getInstance().ActiveServiceDic !=null && WebService.ServerMain.getInstance().ActiveServiceDic.Count>0)
            {
                //이미 활성화된 서비스가 있는경우 URL등 중복방지
                foreach (ConnectionVO connVO in connVOList)
                {
                    bool isDuplicate = false;
                    foreach (string url in WebService.ServerMain.getInstance().ActiveServiceDic.Keys)
                    {
                        if (connVO.ServiceURL == url)
                        {
                            isDuplicate = true;
                            break;
                        }
                    }
                    if (!isDuplicate)
                    {
                        _connVOList.Add(connVO);
                    }                  
                } 
            }
            else
            {
                //이미 활성화된 서비스가 하나도 없을때
                foreach (ConnectionVO connVO in connVOList)
                {
                    _connVOList.Add(connVO);                 
                }
            }
            ServerConsole.AddService(_connVOList);
        }

        public void DeleteService(string ServiceURL)
        {
            if (!this.ServerReady)
            {
                throw new Exception("서버가 준비되지 않았습니다");
            }
            foreach (string url in WebService.ServerMain.getInstance().ActiveServiceDic.Keys)
            {
                if (ServiceURL == url)
                {
                    ServerConsole.DeleteService(ServiceURL);
                    break;
                }
            }           
        }

        public void DeleteService()
        {
            if (!this.ServerReady)
            {
                throw new Exception("서버가 준비되지 않았습니다");
            }
            foreach (string url in WebService.ServerMain.getInstance().ActiveServiceDic.Keys)
            {
                ServerConsole.DeleteService(url);               
            }
        }

        public void StartService(ConnectionVO connVO)
        {
            if (!this.ServerReady)
            {
                throw new Exception("서버가 준비되지 않았습니다");
            }
            if (ServerConsole.ActiveServiceDic[connVO.ServiceURL])
            {
                throw new Exception("이미 활성화된 서비스 입니다");
            }
            ServerConsole.AddService(connVO);            
        }
        #endregion
    }
}