using System;
using System.Windows.Forms;
using libHitpan5;
using libHitpan5.VO;
using System.Collections.Generic;
using libHitpan5.enums;
using libHitpan5.Controller.CommandController;
namespace HitpanClientView.View.설정.사용자설정.관리정보설정
{
    public partial class frm관리정보설정 : Form
    {
        /// <summary>
        /// pnSettings안의 라벨리스트
        /// </summary>
        IList<Label> lblList = new List<Label>();
        IList<ComboBox> ddlList = new List<ComboBox>();
        /// <summary>
        /// 히트판 클라이언트의 모든 작업을 담당할 라이브러리
        /// </summary>
        private Hitpan5ClientLibrary htpClientLib { get; set; }
        /// <summary>
        /// 설정정보를 담고있는 VO
        /// </summary>
        private CommonSettinginfo commonSettings { get; set; }
        public frm관리정보설정()
        {
            InitializeComponent();
        }

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
        private void pnConfig_MouseDown(object sender, MouseEventArgs e)
        {
            MoveControl(this);
        }









        private void frm관리정보설정_Load(object sender, EventArgs e)
        {          
            //세팅정보 채우기
            this.commonSettings = frmMain.htpClientLib.settingInfo;

            #region pnSettings 채우기
            // 세팅정보 설정 콤보박스 하나하나의 높이
            double height = pnSettings.Height / (typeof(CommonSettinginfo).GetProperties().Length);
            // 세팅정보 설정 콤보박스 하나하나의 top
            double top = height;
            // 세팅정보 설정 라벨중 넓이가 가장 큰 라벨의 넓이(줄세울려고)
            double width = 0;

            //일단 라벨쓰고
            foreach (var prop in typeof(CommonSettinginfo).GetProperties())
            {
                if (prop.Name=="Item")
                {
                    continue;
                }
                Label lbl = new Label();
                lbl.AutoSize = true;
                lbl.Name = string.Format("lbl{0}", prop.Name);
                lbl.Text = string.Format("{0} : ", prop.Name);
                lbl.Top = Convert.ToInt32(top);                
                lbl.Left = 35;
                lbl.Parent = pnSettings;
                //제일 큰 라벨의 Width 구하기(넓이 통일 하기 위해)
                if (width < lbl.Width)
                {
                    width = lbl.Width;
                }
                lblList.Add(lbl);

                top += height;
            } 
            //라벨크기 재정렬 및 콤보박스 삽입
            foreach (Label lbl in lblList)
            {
                lbl.AutoSize = false;
                lbl.Width = Convert.ToInt32(width);

                string enumName = lbl.Name.Replace("lbl", "");
                Type _enumType = typeof(CommonSettinginfo).GetProperty(enumName).PropertyType;
                ComboBox ddl = new ComboBox();
                         ddl.Name = "ddl" + enumName;
                         ddl.DataSource = Enum.GetNames(_enumType);                              
                         ddl.Parent = lbl.Parent;
                         ddl.Left = Convert.ToInt32(lbl.Right);
                         ddl.Top = lbl.Top;    
               
                //선택된 데이터 구하기
                if (this.commonSettings!=null)
                {
                    int i = 0;
                    foreach (string name in Enum.GetNames(_enumType))
                    {
                        if (i == (Int32)this.commonSettings[enumName])
                        {
                            ddl.Text = name;
                            break;
                        }
                        i++;
                    } 
                }
                ddlList.Add(ddl);
            }
            #endregion
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            foreach (ComboBox ddl in ddlList)
            {
                string enumName = ddl.Name.Replace("ddl", "");
                this.commonSettings[enumName] = ddl.SelectedIndex;
            }
            ICMD cmd = null;
            if (this.commonSettings!=null)
            {
                cmd = new libHitpan5.Controller.CommandController.CommonSetting.Update(this.commonSettings,frmMain.htpClientLib.settingInfo);
            }
            else
            {
                cmd = new libHitpan5.Controller.CommandController.CommonSetting.Insert(this.commonSettings);
            }
            frmMain.htpClientLib.Do(cmd);
            frmMain.htpClientLib.settingInfo = this.commonSettings;
        }

        private void linkClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Dispose();
        }


       
    }
}
