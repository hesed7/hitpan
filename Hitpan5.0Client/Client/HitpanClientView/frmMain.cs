using System;
using System.Windows.Forms;
using HitpanClientView.View.설정.사용자설정.전자세금계산서;
using libHitpan5;
using libHitpan5.VO;
using HitpanClientView.Properties;
using System.Configuration;
using HitpanClientView.View.설정.상품관리.상품관리;
using HitpanClientView.View.설정.사용자설정.일반정보설정;
using HitpanClientView.View.설정.사용자설정.관리정보설정;
using WebServiceServer.WebServiceVO.Settings;
using System.Collections.Generic;
namespace HitpanClientView
{
    public partial class frmMain : Form
    {
        #region CommonProperties
        /// <summary>
        /// 히트판 클라이언트의 모든 작업을 담당할 라이브러리
        /// </summary>
        internal static Hitpan5ClientLibrary htpClientLib { get; set; }
        private IList<object> MainMenuCollection { get; set; }
        #endregion
        #region ctor
        private static frmMain instance { get; set; }
        private frmMain()
        {           
            InitializeComponent();
        }
        internal static frmMain getInstance()
        {
            if (instance == null)
            {
                instance = new frmMain();
            }
            return instance;
        }
        #endregion

        private void frmMain_Load(object sender, EventArgs e)
        {
            tstxtPassword.TextBox.PasswordChar = '*';
            tstxtID.Text = Settings.Default.UserID;                
        }

        private void 일반정보설정ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frm일반정보설정().Show();
        }
        private void 관리정보설정ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frm관리정보설정().ShowDialog();
        }

        private void 양식정보설정ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 전자세금계산서설정ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm전자세금계산서환경설정 frmETaxSetting = new frm전자세금계산서환경설정();
            frmETaxSetting.ShowDialog();
        }

        private void 상품관리ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new frmGoods().Show();
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (frmMain.htpClientLib!=null)
            {
                frmMain.htpClientLib.Dispose();                
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            // 로그인에 필요한 값을 가져오기
            #region 로그인에 필요한 값들 가져오기
            bool useSecurityMode = Settings.Default.UseSecurityMode;
            string ServiceURL = Settings.Default.serviceURL;
            string SecurityTokenSeed = Settings.Default.SecurityTokenSeed;
            string id = Settings.Default.UserID;
            if (id == null || id == string.Empty)
            {
                id = tstxtID.Text;
            }
            string password = tstxtPassword.Text; 
            #endregion

            //각 값들에 대한 유효성 검사
            #region 각 값들에 대한 유효성 검사
            if (ServiceURL == null || !ServiceURL.Contains("http://"))
            {
                MessageBox.Show("접속할 서버 주소가 없습니다");
                return;
            }
            if (SecurityTokenSeed == null || SecurityTokenSeed.Replace(" ", string.Empty) == string.Empty)
            {
                MessageBox.Show("서버에서 사용자를 인증할 보안토큰이 설정되지 않았습니다");
                return;
            }
            if (id == null || id.Replace(" ", string.Empty) == string.Empty)
            {
                MessageBox.Show("아이디가 없습니다");
                return;
            }
            if (password == null || password.Replace(" ", string.Empty) == string.Empty)
            {
                MessageBox.Show("패스워드가 없습니다");
                return;
            } 
            #endregion

            try
            {
                //로그인 하기
                #region 로그인과 그에 따른 뷰단조정
                htpClientLib = Hitpan5ClientLibrary.getInstance(useSecurityMode, ServiceURL, SecurityTokenSeed, id, password);
                menuMain.Enabled = true;

                this.MainMenuCollection = new List<object>();
                foreach (ToolStripItem tsi in tstripLogin.Items)
                {
                    MainMenuCollection.Add(tsi);
                }

                tstripLogin.Items.Clear();
                string welcome = string.Format("   사용자 : {0} 님  ", id);
                tstripLogin.Items.Add(welcome);
                tstripLogin.Items.Add("                 ");
                tstripLogin.Items.Add("| 로그아웃 |");  
                #endregion              
                #region 로그아웃 이벤트 핸들러 등록
                tstripLogin.Items[2].Click += delegate
                {
                    //로그아웃한 경우의 이벤트 핸들러
                    htpClientLib.Dispose();
                    htpClientLib = null;
                    menuMain.Enabled = false;
                    tstripLogin.Items.Clear();
                    foreach (ToolStripItem tsi in this.MainMenuCollection)
                    {
                        tstripLogin.Items.Add(tsi);
                    }
                    tstxtPassword.Text = "";
                }; 
                #endregion
                #region 현재 사용자의 정보 패널 보여주기(나의 권한 조회,나의 비밀번호 변경)
                tstripLogin.Items[0].Click += delegate
                {
                    MessageBox.Show("사용자정보 조회");
                }; 
                #endregion
                
            }
            catch (Exception)
            {
                #region 로그인 실패시
                htpClientLib = null;
                menuMain.Enabled = false;
                return;   
                #endregion             
            }
            #region 로컬 저장소에 저장된 설정들 가져와서 세팅하기
            foreach (var prop in typeof(CommonSettings).GetProperties())
            {

                try
                {
                    object val = htpClientLib.settingInfo[prop.Name];
                    if (val != null && Convert.ToInt32(val) != 0)
                    {
                        continue;
                    }
                    htpClientLib.settingInfo[prop.Name] = (Enum)Enum.Parse(prop.ReflectedType, Settings.Default[prop.Name].ToString());
                }
                catch (NullReferenceException)
                {
                    continue;
                }
                catch (SettingsPropertyNotFoundException)
                {
                    continue;
                }
            } 
            #endregion
            //id 저장
            #region ID저장
            Settings.Default.UserID = id;
            Settings.Default.Save(); 
            #endregion
        }

        private void tsbtnSetting_Click(object sender, EventArgs e)
        {
            new frmNetwork().ShowDialog();
        }


    }
}
