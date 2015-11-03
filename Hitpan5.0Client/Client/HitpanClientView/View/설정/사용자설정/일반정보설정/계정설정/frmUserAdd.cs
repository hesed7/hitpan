using libHitpan5.Controller.CommandController;
using libHitpan5.enums;
using libHitpan5.Model.DataModel;
using libHitpan5.VO;
using System;
using System.Data;
using System.Windows.Forms;
using Newtonsoft.Json;
using libHitpan5.Controller.SelectController.Users.SelectUser;
using System.Collections.Generic;
using libHitpan5.VO.CommonVO;
namespace HitpanClientView.View.설정.사용자설정.일반정보설정.계정설정
{
    public partial class frmUserAdd : Form
    {
        public DataTable userInfoTable { get; set; }
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
        public frmUserAdd()
        {
            InitializeComponent();
        }

        private void pnAddUser_MouseDown(object sender, MouseEventArgs e)
        {
            MoveControl(this);
        }

        private void frmUserAdd_Load(object sender, EventArgs e)
        {
            SetView();
            linkInsertMode.Visible = false;
        }

        /// <summary>
        ///뷰단을 세팅
        /// </summary>
        private void SetView()
        {
            //드롭다운리스트의 데이터 바운딩
            ddlUserType.DataSource = Enum.GetNames(typeof(사용자등급));
            ddl견적관리.DataSource = Enum.GetNames(typeof(사용자권한));
            ddl계정관리.DataSource = Enum.GetNames(typeof(사용자권한));
            ddl고객정보.DataSource = Enum.GetNames(typeof(사용자권한));
            ddl나의정보관리.DataSource = Enum.GetNames(typeof(사용자권한));
            ddl데이터관리.DataSource = Enum.GetNames(typeof(사용자권한));
            ddl매입관리.DataSource = Enum.GetNames(typeof(사용자권한));
            ddl상품정보.DataSource = Enum.GetNames(typeof(사용자권한));
            ddl세금계산서관리.DataSource = Enum.GetNames(typeof(사용자권한));
            ddl양식정보.DataSource = Enum.GetNames(typeof(사용자권한));
            ddl에프터서비스관리.DataSource = Enum.GetNames(typeof(사용자권한));
            ddl인사관리.DataSource = Enum.GetNames(typeof(사용자권한));
            ddl일정정보.DataSource = Enum.GetNames(typeof(사용자권한));
            ddl재고관리.DataSource = Enum.GetNames(typeof(사용자권한));
            ddl판매관리.DataSource = Enum.GetNames(typeof(사용자권한));
            ddl표준관리.DataSource = Enum.GetNames(typeof(사용자권한));
            ddl회계관리.DataSource = Enum.GetNames(typeof(사용자권한));


            //유저정보 목록 보여주기
            lvUserList.Items.Clear();
            object dt = null;
            IList<UserInfo> userList=  (IList<UserInfo>)new SelectUser(null).GetData();
            if (dt != null)
            {
                userInfoTable = (DataTable)dt;
                foreach (DataRow dr in userInfoTable.Rows)
                {
                    string id = dr["userID"].ToString();
                    사용자등급 userType = ((사용자등급)Convert.ToInt32(dr["userType"]));
                    string strUserType = Enum.GetName(typeof(사용자등급), userType);
                    string[] strData = new string[] { id, strUserType };
                    lvUserList.Items.Add(new ListViewItem(strData));
                }
            }
        }

        /// <summary>
        /// 현재 입력된 내용을 바탕으로 UserInfo객체 생성
        /// </summary>
        /// <returns></returns>
        private UserInfo GetUserInfo() 
        {
            UserAuth ua = new UserAuth();
            ua.견적관리         = (사용자권한)Enum.Parse(typeof(사용자권한), ddl견적관리.Text);
            ua.계정관리         = (사용자권한)Enum.Parse(typeof(사용자권한), ddl계정관리.Text);
            ua.고객정보         = (사용자권한)Enum.Parse(typeof(사용자권한), ddl고객정보.Text);
            ua.나의정보관리     = (사용자권한)Enum.Parse(typeof(사용자권한), ddl나의정보관리.Text);
            ua.데이터관리       = (사용자권한)Enum.Parse(typeof(사용자권한), ddl데이터관리.Text);
            ua.매입관리         = (사용자권한)Enum.Parse(typeof(사용자권한), ddl매입관리.Text);
            ua.상품정보         = (사용자권한)Enum.Parse(typeof(사용자권한), ddl상품정보.Text);
            ua.세금계산서관리   = (사용자권한)Enum.Parse(typeof(사용자권한), ddl세금계산서관리.Text);
            ua.양식정보         = (사용자권한)Enum.Parse(typeof(사용자권한), ddl양식정보.Text);
            ua.에프터서비스관리 = (사용자권한)Enum.Parse(typeof(사용자권한), ddl에프터서비스관리.Text);
            ua.인사관리         = (사용자권한)Enum.Parse(typeof(사용자권한), ddl인사관리.Text);
            ua.일정관리         = (사용자권한)Enum.Parse(typeof(사용자권한), ddl일정정보.Text);
            ua.재고관리         = (사용자권한)Enum.Parse(typeof(사용자권한), ddl재고관리.Text);
            ua.판매관리         = (사용자권한)Enum.Parse(typeof(사용자권한), ddl판매관리.Text);
            ua.표준관리         = (사용자권한)Enum.Parse(typeof(사용자권한), ddl표준관리.Text);
            ua.회계관리         = (사용자권한)Enum.Parse(typeof(사용자권한), ddl회계관리.Text);

            UserInfo ui = new UserInfo();
            ui.id               = txtID.Text;
            ui.password         = txtPassword.Text;
            ui.userAuth         = JsonConvert.SerializeObject(ua);
            ui.userType         =  (사용자등급)Enum.Parse(typeof(사용자등급), ddlUserType.Text);

            return ui;
        }


        private void btnInsertUpdate_Click(object sender, EventArgs e)
        {
            //[1] 사용자정보 VO객체 생성
            UserInfo ui = GetUserInfo();
            //[2] 업데이트 인지 인서트 인지 구분하여 명령어 객체 생성
            ICMD cmd = null;            
            if (!txtID.Enabled)
            {
                //업데이트 하는 경우   
                cmd = new libHitpan5.Controller.CommandController.User.Update((UserInfo)(new SelectUser(txtID.Text).GetData()),ui,string.Format("{0} 유저의 정보를 업데이트"));
                linkInsertMode.Visible = true;
            }
            else
            {
                //인서트 하는 경우
                //[1] id겹치는지 점검
                bool isDuplicated = false;
                foreach (DataRow dr in userInfoTable.Rows)
                {
                    if (dr["userID"].ToString()==ui.id)
                    {
                        isDuplicated = true;
                        break;
                    }
                }
                //[2] id안겹치면 인서트
                if (isDuplicated)
                {
                    MessageBox.Show("입력하고자 하는 아이디가 이미 존재합니다");
                    txtID.Text = string.Empty;
                    return;
                }
                else
                {
                    cmd = new libHitpan5.Controller.CommandController.User.Insert(ui);
                }               
            }

            try
            {
                frmMain.htpClientLib.Do(cmd);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            SetView();
        }

        private void lvUserList_MouseClick(object sender, MouseEventArgs e)
        {
            string id = lvUserList.SelectedItems[0].SubItems[0].Text;
            foreach (DataRow dr in userInfoTable.Rows)
            {
                if (dr["userID"].ToString().Replace(" ",string.Empty)==id.Replace(" ",string.Empty))
                {
                    txtID.Enabled = false;
                    txtID.Text = id;
                    txtPassword.Text = dr["userPassword"].ToString();
                    UserAuth user_auth = (UserAuth)JsonConvert.DeserializeObject(dr["userAuth"].ToString(),typeof(UserAuth));
                    ddlUserType.Text = Enum.GetName(typeof(사용자등급), ((사용자등급)Convert.ToInt32(dr["userType"])));
                    ddl견적관리.Text = Enum.GetName(typeof(사용자권한), user_auth.견적관리);
                    ddl계정관리.Text = Enum.GetName(typeof(사용자권한), user_auth.계정관리);
                    ddl고객정보.Text = Enum.GetName(typeof(사용자권한), user_auth.고객정보);
                    ddl나의정보관리.Text = Enum.GetName(typeof(사용자권한), user_auth.나의정보관리);
                    ddl데이터관리.Text = Enum.GetName(typeof(사용자권한), user_auth.데이터관리);
                    ddl매입관리.Text = Enum.GetName(typeof(사용자권한), user_auth.매입관리);
                    ddl상품정보.Text = Enum.GetName(typeof(사용자권한), user_auth.상품정보);
                    ddl세금계산서관리.Text = Enum.GetName(typeof(사용자권한), user_auth.세금계산서관리);
                    ddl양식정보.Text = Enum.GetName(typeof(사용자권한), user_auth.양식정보);
                    ddl에프터서비스관리.Text = Enum.GetName(typeof(사용자권한), user_auth.에프터서비스관리);
                    ddl인사관리.Text = Enum.GetName(typeof(사용자권한), user_auth.인사관리);
                    ddl일정정보.Text = Enum.GetName(typeof(사용자권한), user_auth.일정관리);
                    ddl재고관리.Text = Enum.GetName(typeof(사용자권한), user_auth.재고관리);
                    ddl판매관리.Text = Enum.GetName(typeof(사용자권한), user_auth.판매관리);
                    ddl표준관리.Text = Enum.GetName(typeof(사용자권한), user_auth.표준관리);
                    ddl회계관리.Text = Enum.GetName(typeof(사용자권한), user_auth.회계관리);
                    break;
                }
            }//End of Foreach
        }

        private void linkInsertMode_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            txtID.Text = "";
            txtID.Enabled = true;
            linkInsertMode.Visible = false;
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            this.Dispose(true);
        }//End of lvUserList_MouseClick
    }
}
