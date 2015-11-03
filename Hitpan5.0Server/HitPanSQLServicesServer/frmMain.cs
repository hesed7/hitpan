﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.ServiceModel;
using HitPanSQLServicesServer.VO;
using System.Collections.Specialized;
using System.Net;
using WebService.VO;
using HitPanSQLServicesServer.Controller.WebServices;
using HitPanSQLServicesServer.Controller.SettingInfo;
using System.Collections;
using HitPanSQLServicesServer.Controller.DBFile;
namespace HitPanSQLServicesServer
{
    public partial class frmMain : Form
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
        #region 싱글톤
        private static frmMain instance { get; set; }
        private frmMain() 
        {
            InitializeComponent();
        }
        public static frmMain getInstance()
        {
            if (instance == null)
            {
                instance = new frmMain();
            }
            return instance;
        } 
        #endregion
        #region 외부IP알기
        /// <summary>
        /// 외부IP 알려주기
        /// </summary>
        /// <returns></returns>
        private void GetExternalIPAsync()
        {
            WebClient wc = new WebClient();
            wc.DownloadStringAsync(new Uri("http://checkip.dyndns.org/"), null);
            wc.DownloadStringCompleted += wc_DownloadStringCompleted;
        }

        void wc_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            string plainText = e.Result.ToString();
            string exIP = plainText.Replace("<html><head><title>Current IP Check</title></head><body>Current IP Address: ", "");
            exIP = exIP.Replace("</body></html>", "");
            this.txtExternalIP.Text = exIP;
        }
        #endregion
        #region 메서드
        #region 개별 서비스 추가,삭제,시작,종료(뷰단까지 모두 통제)
        /// <summary>
        /// 서비스 추가(설정파일에도 추가)
        /// </summary>
        private void AddService(string ServiceURL,String DBPath)
        {
            try
            {
                ServiceURLControllers suc = new ServiceURLControllers();
                suc.InsertServiceInfo(ServiceURL, DBPath);
                this.WebServiceManager.AddService(new ConnectionVO(ServiceURL, DBPath));
                this.lvServiceList.Items.Clear();
                foreach (string url in WebService.ServerMain.getInstance().ActiveServiceDic.Keys)
                {
                    string[] data = new string[] { url, Convert.ToString(WebService.ServerMain.getInstance().ActiveServiceDic[url]) };
                    lvServiceList.Items.Add(new ListViewItem(data));
                }
            }
            catch (Exception _e)
            {

                MessageBox.Show(_e.Message);
            }
        }

        /// <summary>
        /// 서비스 시작(설정파일에 있는 서비스 시작)
        /// </summary>
        private void StartService(string ServiceURL,string DBPath)
        {
            try
            {
                this.WebServiceManager.StartService(new ConnectionVO(ServiceURL, DBPath));
                this.lvServiceList.Items.Clear();
                foreach (string url in WebService.ServerMain.getInstance().ActiveServiceDic.Keys)
                {
                    string[] data = new string[] { url, Convert.ToString(WebService.ServerMain.getInstance().ActiveServiceDic[url]) };
                    lvServiceList.Items.Add(new ListViewItem(data));
                }
            }
            catch (Exception _e)
            {

                MessageBox.Show(_e.Message);
            }
        }


        /// <summary>
        /// 서비스 삭제(설정파일에서도 삭제됨)
        /// </summary>
        private void DeleteService(string ServiceURL)
        {
            try
            {
                ServiceURLControllers suc = new ServiceURLControllers();
                suc.DeleteServiceInfo(ServiceURL);
                this.WebServiceManager.DeleteService(ServiceURL);
                this.lvServiceList.Items.Clear();
                foreach (string _url in WebService.ServerMain.getInstance().ActiveServiceDic.Keys)
                {
                    if (_url == ServiceURL)
                    {
                        //삭제된 URL은 목록에서 삭제
                        continue;
                    }
                    string[] data = new string[] { _url, Convert.ToString(WebService.ServerMain.getInstance().ActiveServiceDic[_url]) };
                    lvServiceList.Items.Add(new ListViewItem(data));
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void DeleteAllServices( )
        {
            try
            {
                ServiceURLControllers suc = new ServiceURLControllers();
                suc.DeleteServiceInfoFile();
                this.WebServiceManager.DeleteService();
                this.lvServiceList.Items.Clear();
            }
            catch (Exception)
            {

                throw;
            }
        }


        /// <summary>
        /// 서비스 종료(설정파일에는 서비스정보 남아있음)
        /// </summary>
        private void StopService(string ServiceURL)
        {
            try
            {
                this.WebServiceManager.DeleteService(ServiceURL);
                this.lvServiceList.Items.Clear();
                foreach (string _url in WebService.ServerMain.getInstance().ActiveServiceDic.Keys)
                {
                    string[] data = new string[] { _url, Convert.ToString(WebService.ServerMain.getInstance().ActiveServiceDic[_url]) };
                    lvServiceList.Items.Add(new ListViewItem(data));
                }
            }
            catch (KeyNotFoundException) 
            {
                MessageBox.Show("이미 중지된 서비스 입니다");
                return;
            }
            catch (Exception)
            {

                throw;
            }
        } 
        #endregion
        #region 모든 서비스 시작,재시작,종료
        //서버 재시작
        private void ResetServer()
        {
            this.CommonSettingsVO = null;
            this.DropServer();
            this.SetServer();
        }
        /// <summary>
        /// 설정을 가져와서 상황에 맞게 세팅(뷰단까지 모두 세팅)
        /// SetView,SetWebService에 종속
        /// </summary>
        private void SetServer()
        {
            //공통설정 가져오기
            this.CommonSettingsVO = new CommonSettingsController().SelectSettings();
            //서비스 정보 목록 가져오기
            IDictionary<string, string> serviceURLDic = new Dictionary<string, string>();
            IList<ServiceInfo> ServiceInfoList = new ServiceURLControllers().SelectServiceInfo();
            if (ServiceInfoList != null)
            {
                foreach (ServiceInfo si in ServiceInfoList)
                {
                    serviceURLDic.Add(si.ServiceURL, si.DBPath);
                }
            }

            //웹서비스 시작
            SetWebService(this.CommonSettingsVO, serviceURLDic);
            //뷰단 세팅
            SetView(this.CommonSettingsVO, serviceURLDic);
        }
        private void DropServer()
        {
            WebService.ServerMain.getInstance().ServerOFF();
            linkDeleteAllSettings.Visible = false;

            lvServiceList.Items.Clear();
            txtServiceURL.Enabled = false;
            linkExternalIP.Enabled = false;
            btnAdd.Enabled = false;
            btnDelete.Enabled = false;
        } 
        #endregion
        #region SetView,SetWebService
        /// <summary>
        /// 뷰단을 상황에 맞게 세팅
        /// </summary>
        /// <param name="CommonSettingsVO">
        /// 공통설정정보VO
        /// 없으면 null입력
        /// </param>
        /// <param name="serviceURLDic">
        /// 서비스 정보 리스트
        /// 없으면 null 입력
        /// </param>
        private void SetView(CommonSettingsVO CommonSettingsVO, IDictionary<string, string> serviceURLDic)
        {
            if (CommonSettingsVO == null)
            {
                //[1]공통설정정보가 없는 경우의 예외처리
                txtSecureKey.Enabled = true;
                rdNotSecurityMode.Enabled = true;
                rdSecurityMode.Enabled = true;
                linkBackupPath.Enabled = true;
                cbBackupSchedule.Enabled = true;
                linkSetMirrorPath.Enabled = true;
                linkDeleteMirrorPath.Enabled = true;
                btnSetCommonSettings.Text = "세팅완료";
                linkDeleteAllSettings.Visible = false;
                txtServiceURL.Enabled = false;
                linkExternalIP.Enabled = false;
            }
            else if (serviceURLDic == null || serviceURLDic.Count==0)
            {
                //[2]서비스 정보 목록이 없는경우 예외처리
                txtSecureKey.Enabled = false;
                rdNotSecurityMode.Enabled = false;
                rdSecurityMode.Enabled = false;
                linkBackupPath.Enabled = false;
                cbBackupSchedule.Enabled = false;
                linkSetMirrorPath.Enabled = false;
                linkDeleteMirrorPath.Enabled = false;
                btnSetCommonSettings.Text = "세팅시작하기";
                linkDeleteAllSettings.Visible = true;
                txtServiceURL.Enabled = true;
                linkExternalIP.Enabled = true;

                //공통 설정정보 입력
                txtSecureKey.Text = this.CommonSettingsVO.SecurityTokenSeed;
                if (this.CommonSettingsVO.MessageCredentialType!=MessageCredentialType.None)
                {
                    rdSecurityMode.Checked = true;
                }
                txtBackupPath.Text = this.CommonSettingsVO.BackupDIRPath;
                cbBackupSchedule.Text = this.CommonSettingsVO.BackupSchedule.Days.ToString();
                lbMirrorPaths.Items.Clear();
                foreach (string MirrorPath in this.CommonSettingsVO.MirrorDIRPath)
                {
                    lbMirrorPaths.Items.Add(MirrorPath);
                }
            }
            else
            {
                //[3] 정상적인 경우의 처리
                txtSecureKey.Enabled = false;
                rdNotSecurityMode.Enabled = false;
                rdSecurityMode.Enabled = false;
                linkBackupPath.Enabled = false;
                cbBackupSchedule.Enabled = false;
                linkSetMirrorPath.Enabled = false;
                linkDeleteMirrorPath.Enabled = false;
                btnSetCommonSettings.Text = "세팅시작하기";
                linkDeleteAllSettings.Visible = true;
                txtServiceURL.Enabled = true;
                linkExternalIP.Enabled = true;

                //공통 설정정보 입력
                txtSecureKey.Text = this.CommonSettingsVO.SecurityTokenSeed;
                if (this.CommonSettingsVO.MessageCredentialType != MessageCredentialType.None)
                {
                    rdSecurityMode.Checked = true;
                }
                txtBackupPath.Text = this.CommonSettingsVO.BackupDIRPath;
                cbBackupSchedule.Text = this.CommonSettingsVO.BackupSchedule.Days.ToString();
                lbMirrorPaths.Items.Clear();
                foreach (string MirrorPath in this.CommonSettingsVO.MirrorDIRPath)
                {
                    lbMirrorPaths.Items.Add(MirrorPath);
                }

                //서비스 주소 세팅
                foreach (string url in WebService.ServerMain.getInstance().ActiveServiceDic.Keys)
                {
                    string[] arrServiceStat = new string[] { url, Convert.ToString(WebService.ServerMain.getInstance().ActiveServiceDic[url]) };
                    lvServiceList.Items.Add(new ListViewItem(arrServiceStat));
                }
            }
        }

        /// <summary>
        /// 웹서비스를 상황에 맞게 세팅
        /// </summary>
        /// <param name="CommonSettingsVO">
        /// 공통설정정보VO
        /// 없으면 null입력
        /// </param>
        /// <param name="serviceURLDic">
        /// 서비스 정보 리스트
        /// key: url value:DBPath
        /// 없으면 null 입력
        /// </param>
        private void SetWebService(CommonSettingsVO CommonSettingsVO, IDictionary<string, string> serviceURLDic)
        {
            if (CommonSettingsVO == null)
            {
                //[1]공통설정정보가 없는 경우의 예외처리
                WebServiceManager = null;
                MessageBox.Show("서비스를 시작하지 못했습니다. 먼저 서버설정을 하여 주십시오");
                return;
            }
            else if (serviceURLDic == null || serviceURLDic.Count==0)
            {
                //[2]서비스 정보 목록이 없는경우 예외처리
                WebServiceManager = new WebServiceManager(CommonSettingsVO);
                if (!WebServiceManager.ServerReady)
                {
                    WebServiceManager.ServerOn(rdSecurityMode.Checked);
                }
            }
            else
            {
                //[3] 정상적인 경우의 처리
                WebServiceManager = new WebServiceManager(CommonSettingsVO);
                if (!WebServiceManager.ServerReady)
                {
                    bool UseSecurity = false;
                    if (CommonSettingsVO.MessageCredentialType!=MessageCredentialType.None)
                    {
                        UseSecurity = true;
                    }
                    WebServiceManager.ServerOn(UseSecurity);
                }

                IList<ConnectionVO> connList = new List<ConnectionVO>(); //웹서비스 Param
                foreach (string url in serviceURLDic.Keys)
                {
                    ConnectionVO cvo = new ConnectionVO(url,serviceURLDic[url]);
                    connList.Add(cvo);
                }
                WebServiceManager.AddService(connList);
            }
        }
        #endregion 
        #endregion




        #region 공통자원
        private WebServiceManager WebServiceManager { get; set; }
        private CommonSettingsVO CommonSettingsVO { get; set; }
        #endregion

        private void frmMain_Load(object sender, EventArgs e)
        {
            SetServer();
            linkWarning.Visible = false;
            GetExternalIPAsync();
        }

        private void linkWarning_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.ResetServer();
            linkWarning.Visible = false;
        }

        private void linkDeleteAllSettings_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new CommonSettingsController().DeleteSettings();
            this.CommonSettingsVO = null;
            linkWarning.Visible = true;
        }

        private void rdNotSecurityMode_CheckedChanged(object sender, EventArgs e)
        {
            rdSecurityMode.Checked = !rdNotSecurityMode.Checked;
        }

        private void rdSecurityMode_CheckedChanged(object sender, EventArgs e)
        {
            rdNotSecurityMode.Checked = !rdSecurityMode.Checked;
        }

        private void linkBackupPath_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FolderBrowserDialog fbd= new FolderBrowserDialog();
            if (fbd.ShowDialog()==DialogResult.OK)
            {
                txtBackupPath.Text = fbd.SelectedPath;
            }
        }

        private void linkSetMirrorPath_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog()==DialogResult.OK)
            {
                lbMirrorPaths.Items.Add(fbd.SelectedPath);
            }
        }

        private void linkDeleteMirrorPath_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            lbMirrorPaths.Items.RemoveAt(lbMirrorPaths.SelectedIndex);
        }

        private void btnSetCommonSettings_Click(object sender, EventArgs e)
        {
            CommonSettingsVO cvo = new CommonSettingsVO();
            cvo.SecurityTokenSeed = txtSecureKey.Text;
            if (rdSecurityMode.Checked)
            {
                cvo.MessageCredentialType = MessageCredentialType.UserName;
            }
            else
            {
                cvo.MessageCredentialType = MessageCredentialType.None;
            }
            cvo.BackupDIRPath = txtBackupPath.Text;
            cvo.BackupSchedule = new TimeSpan(Convert.ToInt32(cbBackupSchedule.Text), 0, 0, 0);
            cvo.certPassword = "1108";
            cvo.certPath = string.Format("{0}\\HTPServer.pfx",Environment.CurrentDirectory);
            cvo.UseMirrorAlram = true;
            cvo.MirrorDIRPath = new StringCollection();
            foreach (string mirror in lbMirrorPaths.Items)
            {
                cvo.MirrorDIRPath.Add(mirror);
            }
            new CommonSettingsController().DeleteSettings();
            new CommonSettingsController().InsertSettings(cvo);
            linkWarning.Visible = true;            
        }

        private void linkExternalIP_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            txtServiceURL.Text = string.Format("http://{0}",txtExternalIP.Text);
        }
        private void txtServiceURL_TextChanged(object sender, EventArgs e)
        {
            if (txtServiceURL.Text.Replace("http://",string.Empty).Length>0 && txtServiceURL.Text.Contains("http://"))
            {
                txtPort.Enabled = true;
            }
            else if (!txtServiceURL.Text.Contains("http://"))
            {
                txtServiceURL.Text = "http://";
            }
        }
        private void txtPort_TextChanged(object sender, EventArgs e)
        {
            string url = txtServiceURL.Text.Replace("http://", string.Empty);
            if (url.Contains(":") )
            {
                url = url.Substring(0, url.IndexOf(":"));
            }
           
            if (txtPort.Text!=string.Empty)
            {
                txtServiceURL.Text = string.Format("http://{0}:{1}", url, txtPort.Text);
            }
            else
            {
                txtServiceURL.Text = string.Format("http://{0}", url);
            }
        }

        private void linkDBFinder_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (rdDBFilePath.Checked)
            {
                OpenFileDialog ofd = new OpenFileDialog();
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    txtDBPath.Text = ofd.FileName;
                    btnAdd.Enabled = true;
                    btnDelete.Enabled = true;
                }                
            }
            else
            {
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    txtDBPath.Text = fbd.SelectedPath;
                    if (rdCreateDB.Checked)
                    {
                        btnAdd.Enabled = true;
                        btnDelete.Enabled = true;
                    }
                }
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (rdRestoreDB.Checked)
            {
                txtDBPath.Text = new DBFileManager().RestoreDB(txtServiceURL.Text,txtBackupFile.Text,txtDBPath.Text);
            }
            else if (rdCreateDB.Checked)
            {
                
            }
            AddService(txtServiceURL.Text,txtDBPath.Text);
        }



        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteService(lvServiceList.SelectedItems[0].SubItems[0].Text);
        }



        private void 서비스종료ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string url = lvServiceList.SelectedItems[0].SubItems[0].Text;
            this.StopService(url);
        }

        private void 서비스시작ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string url= lvServiceList.SelectedItems[0].SubItems[0].Text;
            IList<ServiceInfo> ServiceList= new ServiceURLControllers().SelectServiceInfo();
            foreach (ServiceInfo si in ServiceList)
	        {
		        if (si.ServiceURL==url)
	            {
		            this.StartService(si.ServiceURL,si.DBPath);
                    break;
	            }
	        }
            
        }

        private void 서비스재시작ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string url = lvServiceList.SelectedItems[0].SubItems[0].Text;
            IList<ServiceInfo> ServiceList = new ServiceURLControllers().SelectServiceInfo();
            this.StopService(url);
            foreach (ServiceInfo si in ServiceList)
            {
                if (si.ServiceURL == url)
                {
                    this.StartService(si.ServiceURL, si.DBPath);
                    break;
                }
            }
        }

        private void 서비스삭제ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string url = lvServiceList.SelectedItems[0].SubItems[0].Text;
            this.DeleteService(url);
        }

        private void 쿼리실행ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string url = lvServiceList.SelectedItems[0].SubItems[0].Text;
            new frmViewQuery(url).Show();
        }

        private void 즉시백업ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.CommonSettingsVO.BackupDIRPath==null || this.CommonSettingsVO.BackupDIRPath==string.Empty)
            {
                MessageBox.Show("백업할 디렉토리가 설정되지 않았습니다");
                return;
            }
            string url = lvServiceList.SelectedItems[0].SubItems[0].Text;
            new DBFileManager().BackupNow(url,this.CommonSettingsVO.BackupDIRPath);
        }

        private void 모든서비스종료ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvi in lvServiceList.Items)
            {
                if (lvi.SubItems[0].Text=="False")
                {
                    continue;
                }
                string url = lvi.SubItems[0].Text;
                this.StopService(url);
            }
        }

        private void 모든서비스재시작ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvi in lvServiceList.Items)
            {
                if (lvi.SubItems[0].Text == "False")
                {
                    continue;
                }
                string url = lvi.SubItems[0].Text;
                this.StopService(url);
            }
            IList<ServiceInfo> ServiceList = new ServiceURLControllers().SelectServiceInfo();
            foreach (ServiceInfo si in ServiceList)
            {
                try
                {
                    this.StartService(si.ServiceURL, si.DBPath);
                }
                catch (Exception) { }             
            }
        }

        private void 모든서비스삭제ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.DeleteAllServices();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Visible = false;
            notifyIcon1.Visible = true;
        }

        private void 서버콘솔보이기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notifyIcon1.Visible = false;
            this.Visible = true;
        }

        private void 서버종료하기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.WebServiceManager.ServerOFF();
                this.Dispose(true);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void rdDBFilePath_CheckedChanged(object sender, EventArgs e)
        {
            if (rdDBFilePath.Checked)
            {
                rdRestoreDB.Checked = false;
                rdCreateDB.Checked = false; 
            }
            txtBackupFile.Visible = false;
            LinkBackupFile.Visible = false;
        }

        private void rdRestoreDB_CheckedChanged(object sender, EventArgs e)
        {
            if (rdRestoreDB.Checked)
            {
                rdDBFilePath.Checked = false;
                rdCreateDB.Checked = false; 
            }
            txtBackupFile.Visible = true;
            LinkBackupFile.Visible = true;
            linkDBFinder.Text = "DB폴더입력";
        }

        private void rdCreateDB_CheckedChanged(object sender, EventArgs e)
        {
            if (rdCreateDB.Checked)
            {
                rdRestoreDB.Checked = false;
                rdDBFilePath.Checked = false; 
            }
            txtBackupFile.Visible = false;
            LinkBackupFile.Visible = false;
            linkDBFinder.Text = "DB폴더입력";
        }

        private void LinkBackupFile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtBackupFile.Text = ofd.FileName;
                btnAdd.Enabled = true;
                btnDelete.Enabled = true;
            } 
        }

        //private void btnRestore_Click(object sender, EventArgs e)
        //{

        //}

        //private void btnRefresh_Click(object sender, EventArgs e)
        //{             
        //}
    }
}