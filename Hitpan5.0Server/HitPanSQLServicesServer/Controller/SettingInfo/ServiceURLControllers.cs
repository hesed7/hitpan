using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections;
using HitPanSQLServicesServer.VO;
namespace HitPanSQLServicesServer.Controller.SettingInfo
{
    class ServiceURLControllers
    {
        private IList<ServiceInfo> ServiceList { get; set; }
        //서버 설정 저장파일
        string infoFilePath = string.Format("{0}\\ServiceInfo.info", Environment.CurrentDirectory);

        //가져오기
        public IList<ServiceInfo> SelectServiceInfo()
        {
            IList<ServiceInfo> OriginalData = null;
            //파일이 있으면 기존 파일을 이용한다
            if (File.Exists(infoFilePath))
            {
                string originalJson = File.ReadAllText(infoFilePath, Encoding.UTF8);
                OriginalData = JsonConvert.DeserializeObject<IList<ServiceInfo>>(originalJson);
                
            }
            this.ServiceList = OriginalData;
            return OriginalData;
        }
        //추가
        public void InsertServiceInfo(string url, string DBName) 
        {
            //서비스 정보가 들어갈 객체
            IList<ServiceInfo> OriginalData = null;
            try
            {
                //유효성 검사
                if (url == null || url == string.Empty || url == "http://")
                {
                    throw new Exception("접속할 URL을 입력하십시오");
                }
                else if (DBName == null || DBName == string.Empty)
                {
                    throw new Exception("사용할 DB의 이름 입력하십시오");
                }
                //파일이 있으면 기존 정보외의 충돌 검사
                if (File.Exists(this.infoFilePath))
                {
                    if (ServiceList == null)
                    {
                        SelectServiceInfo();
                    }
                    foreach (ServiceInfo si in this.ServiceList)
                    {
                        if (si.ServiceURL == url)
                        {
                            throw new Exception("기존의 URL과 중복됩니다.");
                        }
                        else if (si.DBName == DBName)
                        {
                            throw new Exception("입력된 데이터베이스는 이미 서비스 되고 있습니다.");
                        }
                    }
                    //기존의 입력된 내용을 바탕으로 VO객체를 다시 생성해서 거기에 데이터 입력처리 
                    string originalJson = File.ReadAllText(infoFilePath, Encoding.UTF8);
                    OriginalData = JsonConvert.DeserializeObject<IList<ServiceInfo>>(originalJson);                    
                }
                else
                {
                    //파일이 없으면 새로 객체 만들어서 처리
                    OriginalData = new List<ServiceInfo>();
                }
                //내용 삽입
                OriginalData.Add(new ServiceInfo(url, DBName));
                //객체를 문자열(Json)으로 변환
                String jsonData = JsonConvert.SerializeObject(OriginalData);
                //파일 삭제
                File.Delete(infoFilePath);
                //파일작성
                File.AppendAllText(infoFilePath, jsonData);

                this.ServiceList = OriginalData;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        //삭제
        public void DeleteServiceInfo(string url) 
        {
            try
            {
                //1 유효성 검사
                if (ServiceList == null)
                {
                    SelectServiceInfo();
                }
                bool Duplicate = false;
                foreach (ServiceInfo si in ServiceList)
                {
                    if (si.ServiceURL==url)
                    {
                        Duplicate = true;
                        break;
                    }
                }
                if (!Duplicate)
                {
                    throw new Exception("삭제하고자 하는 서비스가 존재하지 않습니다");
                }

                //2 서비스 삭제
                IList<ServiceInfo> OriginalData = null;
                //파일이 있으면 기존 파일을 이용하고 없으면 객체를 새로 만든다
                if (File.Exists(infoFilePath))
                {
                    string originalJson = File.ReadAllText(infoFilePath, Encoding.UTF8);
                    OriginalData = JsonConvert.DeserializeObject<IList<ServiceInfo>>(originalJson);
                }
                else
                {
                    OriginalData = new List<ServiceInfo>();
                }
                //내용 삭제
                IList<ServiceInfo> _OriginalData = new List<ServiceInfo>();
                foreach (ServiceInfo si in OriginalData)
                {
                    if (si.ServiceURL != url)
                    {
                        _OriginalData.Add(si);
                    }
                }
                //객체를 문자열(Json)으로 변환
                String jsonData = JsonConvert.SerializeObject(_OriginalData);
                //파일 삭제
                File.Delete(infoFilePath);
                //파일작성
                File.AppendAllText(infoFilePath, jsonData);
            }
            catch (Exception)
            {
                
                throw;
            }       
        }
        //전체삭제
        public void DeleteServiceInfoFile()
        {
            //파일 삭제
            File.Delete(infoFilePath);
        }
    }
}
