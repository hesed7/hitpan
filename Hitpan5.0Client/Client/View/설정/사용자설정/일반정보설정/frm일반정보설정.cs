using HitpanClientView.View.설정;
using HitpanClientView.View.설정.사용자설정.일반정보설정.계정설정;
using libHitpan5;
using libHitpan5._Exception;
using libHitpan5.Controller.CommandController;
using libHitpan5.Controller.SelectController.CommonSettings;
using libHitpan5.Controller.SelectController.MyCompany;
using libHitpan5.enums;
using libHitpan5.Model.DataModel;
using libHitpan5.VO;
using System;
using System.Windows.Forms;
using WebServiceServer.WebServiceVO.Settings;
namespace HitpanClientView.View.설정.사용자설정.일반정보설정
{
    public partial class frm일반정보설정 : Form
    {
        private MyCompanyProxyVO _myInfo { get; set; }
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

        public frm일반정보설정()
        {
            // TODO: Complete member initialization
            this._myInfo = frmMain.htpClientLib.myInfo;
            InitializeComponent();
        }

        private void linkUser_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new frmUserAdd().ShowDialog();
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            this.Dispose(true);
        }

        private void frm일반정보설정_MouseDown(object sender, MouseEventArgs e)
        {
            MoveControl(this);
        }

        private void frm일반정보설정_Load(object sender, EventArgs e)
        {
            MyCompany mc = this._myInfo.MyCompany;
            if (this._myInfo != null)
            {
                this.txtAddress.Text = mc.myDetailAddress;
                this.txtBusinessContents.Text = mc.subBusinessType;
                this.txtBusinessNumber.Text = mc.B_N;
                this.txtBusinessType.Text = mc.businessType;
                this.txtChairman.Text = mc.chairMan;
                this.txtEmail.Text = mc.email;
                this.txtFax.Text = mc.fax;
                this.txtHomePage.Text = mc.homePage;
                this.txtInitialDate.Text = mc.startDate;
                this.txtMyName.Text = mc.myName;
                this.txtPhone.Text = mc.phone;
                this.txtSocialRegistryNumber.Text = mc.RegistryNumber;
                this.txtSubBusinessNumber.Text = mc.subB_N;
                this.txtZipNumber.Text = mc.myPostNo;
                this.rtxtETC.Text = mc.etc;
            }

        }
        private MyCompanyProxyVO GetMyInfo()
        {
            return (MyCompanyProxyVO)new SelectMyCompany().GetData();//new SelectCommonSettings().GetData();
        }

        /// <summary>
        /// 현재 입력된 내용을 바탕으로 myInfo를 생성 및 반환
        /// </summary>
        private MyCompanyProxyVO SetMyInfo()
        {
            MyCompany mi = new MyCompany();
            mi.myDetailAddress = this.txtAddress.Text;
            mi.subBusinessType = this.txtBusinessContents.Text;
            mi.B_N = this.txtBusinessNumber.Text;
            mi.businessType = this.txtBusinessType.Text;
            mi.chairMan = this.txtChairman.Text;
            mi.email = this.txtEmail.Text;
            mi.fax = this.txtFax.Text;
            mi.homePage = this.txtHomePage.Text;
            mi.startDate = this.txtInitialDate.Text;
            mi.myName = this.txtMyName.Text;
            mi.phone = this.txtPhone.Text;
            mi.RegistryNumber = this.txtSocialRegistryNumber.Text;
            mi.subB_N = this.txtSubBusinessNumber.Text;
            mi.myPostNo = this.txtZipNumber.Text;
            mi.etc = this.rtxtETC.Text;

            MyCompanyProxyVO mpv = new MyCompanyProxyVO();
            mpv.MyCompany = mi;
            return mpv;
        }

        private void SetMyInfo(MyCompany _myInfo)
        {
            try
            {
                ICMD cmd = null;

                MyCompanyProxyVO preMyInfo = this._myInfo;
                if (this._myInfo != null)
                {
                    cmd = new libHitpan5.Controller.CommandController.MyCompany.Update(SetMyInfo(), preMyInfo);
                }
                else
                {
                    cmd = new libHitpan5.Controller.CommandController.MyCompany.Insert(SetMyInfo());
                }
                frmMain.htpClientLib.Do(cmd);
                frmMain.htpClientLib.myInfo = SetMyInfo();
            }
            catch (NotAuthException) { MessageBox.Show("나의 정보를 입력하거나 수정할 권한이 없습니다"); }
            catch (NotLoginException) { MessageBox.Show("로그인을 하지 않았습니다"); }
            catch (Exception)
            {
                throw;
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            try
            {
                MyCompany _myInfo = new MyCompany();
                _myInfo.B_N = txtBusinessNumber.Text;
                _myInfo.businessType = txtBusinessType.Text;
                _myInfo.chairMan = txtChairman.Text;
                _myInfo.email = txtEmail.Text;
                _myInfo.etc = rtxtETC.Text;
                _myInfo.fax = txtFax.Text;
                _myInfo.homePage = txtHomePage.Text;
                _myInfo.myDetailAddress = txtAddress.Text;
                _myInfo.myName = txtMyName.Text;
                _myInfo.myPostNo = txtZipNumber.Text;
                _myInfo.phone = txtPhone.Text;
                _myInfo.RegistryNumber = txtSocialRegistryNumber.Text;
                _myInfo.startDate = txtInitialDate.Text;
                _myInfo.subB_N = txtSubBusinessNumber.Text;
                _myInfo.subBusinessType = txtBusinessContents.Text;
                SetMyInfo(_myInfo);
            }
            catch (Exception)
            {


            }
        }
    }
}
