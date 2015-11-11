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
namespace HitpanClientView
{
    public partial class frmMain : Form
    {
        #region CommonProperties
        /// <summary>
        /// 히트판 클라이언트의 모든 작업을 담당할 라이브러리
        /// </summary>
        internal static Hitpan5ClientLibrary htpClientLib { get; set; }
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
            //로컬파일에 저장된 세팅정보를 클라이언트 라이브러리에 올리기
            if (new frmLogin().ShowDialog()==DialogResult.OK)
            {
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
                
            }
            else
            {
                MessageBox.Show("아이디가 없거나 패스워드가 틀렸습니다");
                this.Dispose();
            }
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
            frmMain.htpClientLib.Dispose();
        }


    }
}
