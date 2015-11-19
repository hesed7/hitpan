using System;
using System.Windows.Forms;
using HitpanClientView.Properties;
using libHitpan5;
using System.Collections.Generic;
using System.ServiceModel;
namespace HitpanClientView
{
    public partial class frmNetwork : Form
    {
        #region 마으스 드래그로 컨트롤 이동하기
        //마우스 드래그로 이동의 선언부
        const int WM_SYSCOMMAND = 0x0112;
        const int SC_FORMMOVE = 0xF012;        
        [System.Runtime.InteropServices.DllImport("User32")]
        private static extern int ReleaseCapture();
        [System.Runtime.InteropServices.DllImport("User32")]
        private static extern int SendMessage(int hWnd, int hMsg, int wParam, int lParam);
        /// <summary>
        /// 사용법 : 
        /// 마우스 드래그로 이동시키고자 하는 컨트롤의 
        /// 마우스다운 이벤트에 넣고 
        /// 이동시키고자 하는 컨트롤객체를 매개변수로 준다 
        /// </summary>
        /// <param name="control"></param>
        private void MoveControl(Control control)
        {
            ReleaseCapture();
            SendMessage(control.Handle.ToInt32(), WM_SYSCOMMAND, SC_FORMMOVE, 0);
        }


        //사용 예:
        //private void frmREFFileDownloader_MouseDown(object sender, MouseEventArgs e)
        //{
        //    if (e.Button == MouseButtons.Left)
        //    {
        //        MoveControl(this);
        //    }
        //}
        #endregion
        private void frmLogin_MouseDown(object sender, MouseEventArgs e)
        {
            MoveControl(this);
        }
        private void pnLogin_MouseDown(object sender, MouseEventArgs e)
        {
            MoveControl(this);
        }


        public frmNetwork()
        {
            // TODO: Complete member initialization
            InitializeComponent();
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            //유효성 검증
            if (txtURL.Text==string.Empty)
            {
                MessageBox.Show("접속할 서버의 주소가 입력되지 않았습니다");
                return;
            }
            if (txtAuthKey.Text==string.Empty)
            {
                MessageBox.Show("접속을 인증할 보안키가 입력되지 않았습니다");
                return;
            }

            //아이디,주소,보안키,보안타입 저장
  
            Settings.Default.serviceURL = txtURL.Text;
            Settings.Default.SecurityTokenSeed = txtAuthKey.Text;
            Settings.Default.UseSecurityMode = chSecurityMode.Checked;
            Settings.Default.Save();
            
            this.Dispose();
        }



        private void frmLogin_Load(object sender, EventArgs e)
        {

            //전부다 string.empty로 초기화
            txtAuthKey.Text = string.Empty;
            txtURL.Text = string.Empty;

            if (Settings.Default.SecurityTokenSeed!=null && Settings.Default.SecurityTokenSeed!=string.Empty)
            {
                txtAuthKey.Text = Settings.Default.SecurityTokenSeed;
            }
            if (Settings.Default.serviceURL!=null && Settings.Default.serviceURL!=string.Empty)
            {
                txtURL.Text = Settings.Default.serviceURL;
            }
            chSecurityMode.Checked = Settings.Default.UseSecurityMode;
        }


    } 
}
