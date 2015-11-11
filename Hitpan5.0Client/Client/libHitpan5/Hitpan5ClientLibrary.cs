using System.Collections.Generic;
using libHitpan5.Model.DataModel;
using libHitpan5.VO;
using libHitpan5.Controller.Common.WebServiceController;
using libHitpan5.Controller.SelectController.Users.SelectUser;
using Newtonsoft.Json;
using libHitpan5.Controller.SelectController.Login;
using libHitpan5.Controller.SelectController.CommonSettings;
using libHitpan5.Controller.SelectController.MyCompany;
using libHitpan5.Controller.CommandController;
using libHitpan5.Controller.SelectController;
using System;
using libHitpan5.Controller.Common.UserAuthValidator;
using libHitpan5.VO.CommonVO;
using libHitpan5._Exception;
using WebServiceServer.WebServiceVO.Users;
using WebServiceServer.WebServiceVO.Settings;
using WebServiceServer.Enums;
namespace libHitpan5
{
    public class Hitpan5ClientLibrary
    {
        internal static SQLDataServiceModel SQLDataServiceModel { get; set; }
        private WebServiceProxyController proxyController { get; set; }
        #region 사용 기본 정보
        public CommonSettingProxyVO settingInfo { get; set; }
        private UserInfoProxyVO userInfo { get; set; }
        public MyCompanyProxyVO myInfo { get; set; } 
        #endregion
        #region 시작과 종료
        private static Hitpan5ClientLibrary instance { get; set; }
        /// <summary>
        /// 라이브러리 시작
        /// </summary>
        /// <param name="UseSecurityMode">wcf메시지 보안을 사용 할건지 말건지 </param>
        /// <param name="ServiceURL">접속 하고자 하는 주소</param>
        /// <param name="EncryptSeed">보안 시드키</param>
        /// <param name="id">로그인 id</param>
        /// <param name="password">로그인 패스워드</param>
        private Hitpan5ClientLibrary(bool UseSecurityMode, string ServiceURL, string EncryptSeed, string id, string password)
        {
            if (UseSecurityMode)
            {
                proxyController = new WebServiceProxyController(id, password, ServiceURL);
            }
            else
            {
                proxyController = new WebServiceProxyController(ServiceURL);
            }
            SQLDataServiceModel = new SQLDataServiceModel(EncryptSeed, ServiceURL, this.proxyController.proxy);
            //로그인 하기 (만약 아무것도 없으면 초기관리자 로서 모든 설정권한을 가짐: 빈 데이터 일 테니까 상관없다) 초기관리자는 계속 관리자 권한 갖는다
            SelectUser su = new SelectUser(null);
            su.work = "처음 사용자인지 검증";
            IList<UserInfoProxyVO> UserList = (IList<UserInfoProxyVO>)su.GetData();
            if (UserList == null || UserList.Count == 0)
            {
                this.userInfo = new UserInfoProxyVO();
                this.userInfo["UserID"] = "Admin";
                this.userInfo["UserType"] = 사용자등급.관리자;
                this.userInfo["견적관리"] = 사용자권한.모두허용;
                this.userInfo["계정관리"] = 사용자권한.모두허용;
                this.userInfo["고객정보"] = 사용자권한.모두허용;
                this.userInfo["나의정보관리"] = 사용자권한.모두허용;
                this.userInfo["데이터관리"] = 사용자권한.모두허용;
                this.userInfo["매입관리"] = 사용자권한.모두허용;
                this.userInfo["상품정보"] = 사용자권한.모두허용;
                this.userInfo["세금계산서관리"] = 사용자권한.모두허용;
                this.userInfo["양식정보"] = 사용자권한.모두허용;
                this.userInfo["에프터서비스관리"] = 사용자권한.모두허용;
                this.userInfo["인사관리"] = 사용자권한.모두허용;
                this.userInfo["일정관리"] = 사용자권한.모두허용;
                this.userInfo["재고관리"] = 사용자권한.모두허용;
                this.userInfo["판매관리"] = 사용자권한.모두허용;
                this.userInfo["표준관리"] = 사용자권한.모두허용;
                this.userInfo["회계관리"] = 사용자권한.모두허용;
            }
            else
            {
                object obj = new LogIn(id, password).GetData();
                try
                {
                    this.userInfo = (UserInfoProxyVO)obj;
                }
                catch (InvalidCastException) 
                {
                    throw new System.Exception("아이디가 존재하지 않거나 패스워드가 틀렸습니다");
                }
                catch (System.Exception ex)
                {
                    throw new System.Exception(string.Format("로그인을 실패하였습니다 ({0})", ex.Message));
                }
            }
            //설정정보 가져오기
            try
            {
                object obj = new SelectCommonSettings().GetData();
                this.settingInfo = (CommonSettingProxyVO)obj;
            }
            catch (System.Exception)
            {
               
            }
            //자기 자신의 정보 가져오기
            try
            {
                object obj = new SelectMyCompany().GetData();
                this.myInfo = (MyCompanyProxyVO)obj;
            }
            catch (System.Exception)
            {
                
            }
            if (this.myInfo == null)
            {
                this.myInfo = new MyCompanyProxyVO();
            }
            if (this.settingInfo ==null)
            {
                this.settingInfo = new CommonSettingProxyVO();
            }
        }
        public static Hitpan5ClientLibrary getInstance(bool UseSecurityMode, string ServiceURL, string EncryptSeed, string id, string password) 
        {
            if (instance==null)
            {
                instance = new Hitpan5ClientLibrary(UseSecurityMode, ServiceURL, EncryptSeed,id,password);
            }
            return instance;
        }
        public void Dispose()
        {
            this.proxyController.DisposeWebService();
        } 
        #endregion

        #region 명령객체 관리
        private Queue<ICMD> CommandQueue { get; set; }
        private Queue<ICMD> CalcleQueue { get; set; }
        public void Do(ICMD cmd) 
        {
            if (this.userInfo==null)
	        {
		        throw new  NotLoginException();
	        }
            if (!(new UserValidator(this.userInfo).CheckAuth(cmd.RequiredAuth)))
	        {
		        throw new  NotAuthException();
	        }
            if (CommandQueue==null)
            {
                CommandQueue = new Queue<ICMD>();
            }
            CommandQueue.Enqueue(cmd);
            cmd.Do();
        }
        public void UnDo() 
        {
            if (CalcleQueue == null)
            {
                CalcleQueue = new Queue<ICMD>();
            }
            ICMD cmd = CommandQueue.Dequeue();
            cmd.UnDo();
            CalcleQueue.Enqueue(cmd);
        }
        public void ReDo() 
        {
            ICMD cmd = CalcleQueue.Dequeue();
            cmd.Do();
            CommandQueue.Enqueue(cmd);        
        }

        public object Select(ISelect selectCMD) 
        {
            if (this.userInfo==null)
	        {
		        throw new  NotLoginException();
	        }
            if (!(new UserValidator(this.userInfo).CheckAuth(selectCMD.RequiredAuth)))
	        {
		        throw new  NotAuthException();
	        }
            return selectCMD.GetData();
        }
        public void SetDocument(ISelect selectCMD) 
        {
            if (this.userInfo == null)
            {
                throw new NotLoginException();
            }
            if (!(new UserValidator(this.userInfo).CheckAuth(selectCMD.RequiredAuth)))
            {
                throw new NotAuthException();
            }
            selectCMD.GetDocument();
        }
        #endregion
    }
    

}
