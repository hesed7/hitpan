namespace HitPanSQLServicesServer
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.panel2 = new System.Windows.Forms.Panel();
            this.linkPortTest = new System.Windows.Forms.LinkLabel();
            this.linkDBFinder = new System.Windows.Forms.LinkLabel();
            this.linkExternalIP = new System.Windows.Forms.LinkLabel();
            this.pnCommonSettingView = new System.Windows.Forms.Panel();
            this.linkDeleteAllSettings = new System.Windows.Forms.LinkLabel();
            this.linkWarning = new System.Windows.Forms.LinkLabel();
            this.label6 = new System.Windows.Forms.Label();
            this.linkSetMirrorPath = new System.Windows.Forms.LinkLabel();
            this.linkBackupPath = new System.Windows.Forms.LinkLabel();
            this.cbBackupSchedule = new System.Windows.Forms.ComboBox();
            this.btnSetCommonSettings = new System.Windows.Forms.Button();
            this.rdSecurityMode = new System.Windows.Forms.RadioButton();
            this.rdNotSecurityMode = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSecureKey = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.linkDeleteMirrorPath = new System.Windows.Forms.LinkLabel();
            this.lbMirrorPaths = new System.Windows.Forms.ListBox();
            this.txtBackupPath = new System.Windows.Forms.TextBox();
            this.txtExternalIP = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblExternalIP = new System.Windows.Forms.Label();
            this.txtDBPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtServiceURL = new System.Windows.Forms.TextBox();
            this.lblCurrServiceURL = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEnd = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lvServiceList = new System.Windows.Forms.ListView();
            this.colURL = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colActivity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmsServiceActive = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.서비스시작ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.서비스종료ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.서비스재시작ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.서비스삭제ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.쿼리실행ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.즉시백업ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.모든서비스종료ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.모든서비스재시작ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.모든서비스삭제ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.cmsNotifyIcon1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.서버콘솔보이기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.서버종료하기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rdDBFilePath = new System.Windows.Forms.RadioButton();
            this.rdRestoreDB = new System.Windows.Forms.RadioButton();
            this.rdCreateDB = new System.Windows.Forms.RadioButton();
            this.LinkBackupFile = new System.Windows.Forms.LinkLabel();
            this.txtBackupFile = new System.Windows.Forms.TextBox();
            this.panel2.SuspendLayout();
            this.pnCommonSettingView.SuspendLayout();
            this.panel1.SuspendLayout();
            this.cmsServiceActive.SuspendLayout();
            this.cmsNotifyIcon1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.LinkBackupFile);
            this.panel2.Controls.Add(this.txtBackupFile);
            this.panel2.Controls.Add(this.rdCreateDB);
            this.panel2.Controls.Add(this.rdRestoreDB);
            this.panel2.Controls.Add(this.rdDBFilePath);
            this.panel2.Controls.Add(this.linkPortTest);
            this.panel2.Controls.Add(this.linkDBFinder);
            this.panel2.Controls.Add(this.linkExternalIP);
            this.panel2.Controls.Add(this.pnCommonSettingView);
            this.panel2.Controls.Add(this.txtDBPath);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.txtPort);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txtServiceURL);
            this.panel2.Controls.Add(this.lblCurrServiceURL);
            this.panel2.Controls.Add(this.btnAdd);
            this.panel2.Controls.Add(this.btnDelete);
            this.panel2.Controls.Add(this.btnEnd);
            this.panel2.Location = new System.Drawing.Point(316, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(678, 589);
            this.panel2.TabIndex = 3;
            // 
            // linkPortTest
            // 
            this.linkPortTest.AutoSize = true;
            this.linkPortTest.Location = new System.Drawing.Point(247, 428);
            this.linkPortTest.Name = "linkPortTest";
            this.linkPortTest.Size = new System.Drawing.Size(65, 12);
            this.linkPortTest.TabIndex = 14;
            this.linkPortTest.TabStop = true;
            this.linkPortTest.Text = "포트테스트";
            // 
            // linkDBFinder
            // 
            this.linkDBFinder.AutoSize = true;
            this.linkDBFinder.Location = new System.Drawing.Point(587, 499);
            this.linkDBFinder.Name = "linkDBFinder";
            this.linkDBFinder.Size = new System.Drawing.Size(69, 12);
            this.linkDBFinder.TabIndex = 13;
            this.linkDBFinder.TabStop = true;
            this.linkDBFinder.Text = "DB파일찾기";
            this.linkDBFinder.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkDBFinder_LinkClicked);
            // 
            // linkExternalIP
            // 
            this.linkExternalIP.AutoSize = true;
            this.linkExternalIP.Location = new System.Drawing.Point(587, 402);
            this.linkExternalIP.Name = "linkExternalIP";
            this.linkExternalIP.Size = new System.Drawing.Size(64, 12);
            this.linkExternalIP.TabIndex = 12;
            this.linkExternalIP.TabStop = true;
            this.linkExternalIP.Text = "외부IP사용";
            this.linkExternalIP.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkExternalIP_LinkClicked);
            // 
            // pnCommonSettingView
            // 
            this.pnCommonSettingView.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pnCommonSettingView.Controls.Add(this.linkDeleteAllSettings);
            this.pnCommonSettingView.Controls.Add(this.linkWarning);
            this.pnCommonSettingView.Controls.Add(this.label6);
            this.pnCommonSettingView.Controls.Add(this.linkSetMirrorPath);
            this.pnCommonSettingView.Controls.Add(this.linkBackupPath);
            this.pnCommonSettingView.Controls.Add(this.cbBackupSchedule);
            this.pnCommonSettingView.Controls.Add(this.btnSetCommonSettings);
            this.pnCommonSettingView.Controls.Add(this.rdSecurityMode);
            this.pnCommonSettingView.Controls.Add(this.rdNotSecurityMode);
            this.pnCommonSettingView.Controls.Add(this.label8);
            this.pnCommonSettingView.Controls.Add(this.txtSecureKey);
            this.pnCommonSettingView.Controls.Add(this.label7);
            this.pnCommonSettingView.Controls.Add(this.linkDeleteMirrorPath);
            this.pnCommonSettingView.Controls.Add(this.lbMirrorPaths);
            this.pnCommonSettingView.Controls.Add(this.txtBackupPath);
            this.pnCommonSettingView.Controls.Add(this.txtExternalIP);
            this.pnCommonSettingView.Controls.Add(this.label5);
            this.pnCommonSettingView.Controls.Add(this.label4);
            this.pnCommonSettingView.Controls.Add(this.label3);
            this.pnCommonSettingView.Controls.Add(this.lblExternalIP);
            this.pnCommonSettingView.Location = new System.Drawing.Point(3, 3);
            this.pnCommonSettingView.Name = "pnCommonSettingView";
            this.pnCommonSettingView.Size = new System.Drawing.Size(672, 371);
            this.pnCommonSettingView.TabIndex = 11;
            // 
            // linkDeleteAllSettings
            // 
            this.linkDeleteAllSettings.AutoSize = true;
            this.linkDeleteAllSettings.Location = new System.Drawing.Point(457, 72);
            this.linkDeleteAllSettings.Name = "linkDeleteAllSettings";
            this.linkDeleteAllSettings.Size = new System.Drawing.Size(121, 12);
            this.linkDeleteAllSettings.TabIndex = 26;
            this.linkDeleteAllSettings.TabStop = true;
            this.linkDeleteAllSettings.Text = "설정정보 초기화 하기";
            this.linkDeleteAllSettings.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkDeleteAllSettings_LinkClicked);
            // 
            // linkWarning
            // 
            this.linkWarning.ActiveLinkColor = System.Drawing.Color.White;
            this.linkWarning.AutoSize = true;
            this.linkWarning.LinkColor = System.Drawing.Color.Red;
            this.linkWarning.Location = new System.Drawing.Point(157, 17);
            this.linkWarning.Name = "linkWarning";
            this.linkWarning.Size = new System.Drawing.Size(413, 12);
            this.linkWarning.TabIndex = 25;
            this.linkWarning.TabStop = true;
            this.linkWarning.Text = "!!! 서버세팅이 변경되었습니다. 변경된 내용은 서버 재시작 후에 적용됩니다";
            this.linkWarning.Visible = false;
            this.linkWarning.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkWarning_LinkClicked);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(284, 194);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 12);
            this.label6.TabIndex = 24;
            this.label6.Text = "일 마다 백업";
            // 
            // linkSetMirrorPath
            // 
            this.linkSetMirrorPath.AutoSize = true;
            this.linkSetMirrorPath.Location = new System.Drawing.Point(160, 224);
            this.linkSetMirrorPath.Name = "linkSetMirrorPath";
            this.linkSetMirrorPath.Size = new System.Drawing.Size(97, 12);
            this.linkSetMirrorPath.TabIndex = 23;
            this.linkSetMirrorPath.TabStop = true;
            this.linkSetMirrorPath.Text = "미러링 경로 입력";
            this.linkSetMirrorPath.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkSetMirrorPath_LinkClicked);
            // 
            // linkBackupPath
            // 
            this.linkBackupPath.AutoSize = true;
            this.linkBackupPath.Location = new System.Drawing.Point(155, 139);
            this.linkBackupPath.Name = "linkBackupPath";
            this.linkBackupPath.Size = new System.Drawing.Size(85, 12);
            this.linkBackupPath.TabIndex = 22;
            this.linkBackupPath.TabStop = true;
            this.linkBackupPath.Text = "백업 경로 입력";
            this.linkBackupPath.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkBackupPath_LinkClicked);
            // 
            // cbBackupSchedule
            // 
            this.cbBackupSchedule.FormattingEnabled = true;
            this.cbBackupSchedule.Items.AddRange(new object[] {
            "1",
            "3",
            "7",
            "14",
            "30"});
            this.cbBackupSchedule.Location = new System.Drawing.Point(157, 191);
            this.cbBackupSchedule.Name = "cbBackupSchedule";
            this.cbBackupSchedule.Size = new System.Drawing.Size(121, 20);
            this.cbBackupSchedule.TabIndex = 21;
            // 
            // btnSetCommonSettings
            // 
            this.btnSetCommonSettings.Location = new System.Drawing.Point(157, 322);
            this.btnSetCommonSettings.Name = "btnSetCommonSettings";
            this.btnSetCommonSettings.Size = new System.Drawing.Size(100, 23);
            this.btnSetCommonSettings.TabIndex = 20;
            this.btnSetCommonSettings.Text = "세팅하기";
            this.btnSetCommonSettings.UseVisualStyleBackColor = true;
            this.btnSetCommonSettings.Click += new System.EventHandler(this.btnSetCommonSettings_Click);
            // 
            // rdSecurityMode
            // 
            this.rdSecurityMode.AutoSize = true;
            this.rdSecurityMode.Location = new System.Drawing.Point(334, 112);
            this.rdSecurityMode.Name = "rdSecurityMode";
            this.rdSecurityMode.Size = new System.Drawing.Size(99, 16);
            this.rdSecurityMode.TabIndex = 19;
            this.rdSecurityMode.Text = "보안모드 사용";
            this.rdSecurityMode.UseVisualStyleBackColor = true;
            this.rdSecurityMode.CheckedChanged += new System.EventHandler(this.rdSecurityMode_CheckedChanged);
            // 
            // rdNotSecurityMode
            // 
            this.rdNotSecurityMode.AutoSize = true;
            this.rdNotSecurityMode.Checked = true;
            this.rdNotSecurityMode.Location = new System.Drawing.Point(163, 112);
            this.rdNotSecurityMode.Name = "rdNotSecurityMode";
            this.rdNotSecurityMode.Size = new System.Drawing.Size(127, 16);
            this.rdNotSecurityMode.TabIndex = 18;
            this.rdNotSecurityMode.TabStop = true;
            this.rdNotSecurityMode.Text = "보안모드 시용 안함";
            this.rdNotSecurityMode.UseVisualStyleBackColor = true;
            this.rdNotSecurityMode.CheckedChanged += new System.EventHandler(this.rdNotSecurityMode_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(64, 81);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 12);
            this.label8.TabIndex = 3;
            this.label8.Text = "보안키 입력 :";
            // 
            // txtSecureKey
            // 
            this.txtSecureKey.Location = new System.Drawing.Point(160, 72);
            this.txtSecureKey.Name = "txtSecureKey";
            this.txtSecureKey.PasswordChar = '*';
            this.txtSecureKey.Size = new System.Drawing.Size(100, 21);
            this.txtSecureKey.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.Location = new System.Drawing.Point(456, 34);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(173, 16);
            this.label7.TabIndex = 17;
            this.label7.Text = "서비스 공통 설정정보";
            // 
            // linkDeleteMirrorPath
            // 
            this.linkDeleteMirrorPath.AutoSize = true;
            this.linkDeleteMirrorPath.Location = new System.Drawing.Point(295, 224);
            this.linkDeleteMirrorPath.Name = "linkDeleteMirrorPath";
            this.linkDeleteMirrorPath.Size = new System.Drawing.Size(97, 12);
            this.linkDeleteMirrorPath.TabIndex = 16;
            this.linkDeleteMirrorPath.TabStop = true;
            this.linkDeleteMirrorPath.Text = "미러링 경로 삭제";
            this.linkDeleteMirrorPath.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkDeleteMirrorPath_LinkClicked);
            // 
            // lbMirrorPaths
            // 
            this.lbMirrorPaths.FormattingEnabled = true;
            this.lbMirrorPaths.ItemHeight = 12;
            this.lbMirrorPaths.Location = new System.Drawing.Point(157, 239);
            this.lbMirrorPaths.Name = "lbMirrorPaths";
            this.lbMirrorPaths.Size = new System.Drawing.Size(498, 76);
            this.lbMirrorPaths.TabIndex = 15;
            // 
            // txtBackupPath
            // 
            this.txtBackupPath.Location = new System.Drawing.Point(157, 156);
            this.txtBackupPath.Name = "txtBackupPath";
            this.txtBackupPath.ReadOnly = true;
            this.txtBackupPath.Size = new System.Drawing.Size(498, 21);
            this.txtBackupPath.TabIndex = 12;
            // 
            // txtExternalIP
            // 
            this.txtExternalIP.Location = new System.Drawing.Point(160, 35);
            this.txtExternalIP.Name = "txtExternalIP";
            this.txtExternalIP.ReadOnly = true;
            this.txtExternalIP.Size = new System.Drawing.Size(100, 21);
            this.txtExternalIP.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 200);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 12);
            this.label5.TabIndex = 6;
            this.label5.Text = "자동백업 시간 간격 :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(61, 224);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "미러링 경로 :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(80, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "백업경로 :";
            // 
            // lblExternalIP
            // 
            this.lblExternalIP.AutoSize = true;
            this.lblExternalIP.Location = new System.Drawing.Point(89, 44);
            this.lblExternalIP.Name = "lblExternalIP";
            this.lblExternalIP.Size = new System.Drawing.Size(52, 12);
            this.lblExternalIP.TabIndex = 0;
            this.lblExternalIP.Text = "외부IP : ";
            // 
            // txtDBPath
            // 
            this.txtDBPath.Enabled = false;
            this.txtDBPath.Location = new System.Drawing.Point(160, 490);
            this.txtDBPath.Name = "txtDBPath";
            this.txtDBPath.Size = new System.Drawing.Size(418, 21);
            this.txtDBPath.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(64, 466);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "데이터 파일: ";
            // 
            // txtPort
            // 
            this.txtPort.Enabled = false;
            this.txtPort.Location = new System.Drawing.Point(160, 425);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(78, 21);
            this.txtPort.TabIndex = 8;
            this.txtPort.TextChanged += new System.EventHandler(this.txtPort_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 434);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "서비스 포트번호: ";
            // 
            // txtServiceURL
            // 
            this.txtServiceURL.Location = new System.Drawing.Point(160, 393);
            this.txtServiceURL.Name = "txtServiceURL";
            this.txtServiceURL.Size = new System.Drawing.Size(418, 21);
            this.txtServiceURL.TabIndex = 6;
            this.txtServiceURL.Text = "http://";
            this.txtServiceURL.TextChanged += new System.EventHandler(this.txtServiceURL_TextChanged);
            // 
            // lblCurrServiceURL
            // 
            this.lblCurrServiceURL.AutoSize = true;
            this.lblCurrServiceURL.Location = new System.Drawing.Point(67, 402);
            this.lblCurrServiceURL.Name = "lblCurrServiceURL";
            this.lblCurrServiceURL.Size = new System.Drawing.Size(77, 12);
            this.lblCurrServiceURL.TabIndex = 5;
            this.lblCurrServiceURL.Text = "서비스 주소: ";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(25, 551);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(116, 23);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "추가하기";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(156, 551);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(116, 23);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "삭제하기";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEnd
            // 
            this.btnEnd.Location = new System.Drawing.Point(545, 551);
            this.btnEnd.Name = "btnEnd";
            this.btnEnd.Size = new System.Drawing.Size(116, 23);
            this.btnEnd.TabIndex = 1;
            this.btnEnd.Text = "설정 끝내기";
            this.btnEnd.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lvServiceList);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(298, 589);
            this.panel1.TabIndex = 2;
            // 
            // lvServiceList
            // 
            this.lvServiceList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colURL,
            this.colActivity});
            this.lvServiceList.ContextMenuStrip = this.cmsServiceActive;
            this.lvServiceList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvServiceList.FullRowSelect = true;
            this.lvServiceList.GridLines = true;
            this.lvServiceList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvServiceList.Location = new System.Drawing.Point(0, 0);
            this.lvServiceList.MultiSelect = false;
            this.lvServiceList.Name = "lvServiceList";
            this.lvServiceList.Size = new System.Drawing.Size(298, 589);
            this.lvServiceList.TabIndex = 0;
            this.lvServiceList.UseCompatibleStateImageBehavior = false;
            this.lvServiceList.View = System.Windows.Forms.View.Details;
            // 
            // colURL
            // 
            this.colURL.Text = "서비스주소";
            this.colURL.Width = 211;
            // 
            // colActivity
            // 
            this.colActivity.Text = "활성";
            // 
            // cmsServiceActive
            // 
            this.cmsServiceActive.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.서비스시작ToolStripMenuItem,
            this.서비스종료ToolStripMenuItem,
            this.서비스재시작ToolStripMenuItem,
            this.서비스삭제ToolStripMenuItem,
            this.쿼리실행ToolStripMenuItem,
            this.즉시백업ToolStripMenuItem,
            this.모든서비스종료ToolStripMenuItem,
            this.모든서비스재시작ToolStripMenuItem,
            this.모든서비스삭제ToolStripMenuItem});
            this.cmsServiceActive.Name = "cmsServiceActive";
            this.cmsServiceActive.Size = new System.Drawing.Size(179, 202);
            // 
            // 서비스시작ToolStripMenuItem
            // 
            this.서비스시작ToolStripMenuItem.Name = "서비스시작ToolStripMenuItem";
            this.서비스시작ToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.서비스시작ToolStripMenuItem.Text = "서비스 시작";
            this.서비스시작ToolStripMenuItem.Click += new System.EventHandler(this.서비스시작ToolStripMenuItem_Click);
            // 
            // 서비스종료ToolStripMenuItem
            // 
            this.서비스종료ToolStripMenuItem.Name = "서비스종료ToolStripMenuItem";
            this.서비스종료ToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.서비스종료ToolStripMenuItem.Text = "서비스 종료";
            this.서비스종료ToolStripMenuItem.Click += new System.EventHandler(this.서비스종료ToolStripMenuItem_Click);
            // 
            // 서비스재시작ToolStripMenuItem
            // 
            this.서비스재시작ToolStripMenuItem.Name = "서비스재시작ToolStripMenuItem";
            this.서비스재시작ToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.서비스재시작ToolStripMenuItem.Text = "서비스 재시작";
            this.서비스재시작ToolStripMenuItem.Click += new System.EventHandler(this.서비스재시작ToolStripMenuItem_Click);
            // 
            // 서비스삭제ToolStripMenuItem
            // 
            this.서비스삭제ToolStripMenuItem.Name = "서비스삭제ToolStripMenuItem";
            this.서비스삭제ToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.서비스삭제ToolStripMenuItem.Text = "서비스 삭제";
            this.서비스삭제ToolStripMenuItem.Click += new System.EventHandler(this.서비스삭제ToolStripMenuItem_Click);
            // 
            // 쿼리실행ToolStripMenuItem
            // 
            this.쿼리실행ToolStripMenuItem.Name = "쿼리실행ToolStripMenuItem";
            this.쿼리실행ToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.쿼리실행ToolStripMenuItem.Text = "쿼리실행";
            this.쿼리실행ToolStripMenuItem.Click += new System.EventHandler(this.쿼리실행ToolStripMenuItem_Click);
            // 
            // 즉시백업ToolStripMenuItem
            // 
            this.즉시백업ToolStripMenuItem.Name = "즉시백업ToolStripMenuItem";
            this.즉시백업ToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.즉시백업ToolStripMenuItem.Text = "즉시 백업";
            this.즉시백업ToolStripMenuItem.Click += new System.EventHandler(this.즉시백업ToolStripMenuItem_Click);
            // 
            // 모든서비스종료ToolStripMenuItem
            // 
            this.모든서비스종료ToolStripMenuItem.Name = "모든서비스종료ToolStripMenuItem";
            this.모든서비스종료ToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.모든서비스종료ToolStripMenuItem.Text = "모든 서비스 종료";
            this.모든서비스종료ToolStripMenuItem.Click += new System.EventHandler(this.모든서비스종료ToolStripMenuItem_Click);
            // 
            // 모든서비스재시작ToolStripMenuItem
            // 
            this.모든서비스재시작ToolStripMenuItem.Name = "모든서비스재시작ToolStripMenuItem";
            this.모든서비스재시작ToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.모든서비스재시작ToolStripMenuItem.Text = "모든 서비스 재시작";
            this.모든서비스재시작ToolStripMenuItem.Click += new System.EventHandler(this.모든서비스재시작ToolStripMenuItem_Click);
            // 
            // 모든서비스삭제ToolStripMenuItem
            // 
            this.모든서비스삭제ToolStripMenuItem.Name = "모든서비스삭제ToolStripMenuItem";
            this.모든서비스삭제ToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.모든서비스삭제ToolStripMenuItem.Text = "모든 서비스 삭제";
            this.모든서비스삭제ToolStripMenuItem.Click += new System.EventHandler(this.모든서비스삭제ToolStripMenuItem_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.cmsNotifyIcon1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // cmsNotifyIcon1
            // 
            this.cmsNotifyIcon1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.서버콘솔보이기ToolStripMenuItem,
            this.서버종료하기ToolStripMenuItem});
            this.cmsNotifyIcon1.Name = "cmsNotifyIcon1";
            this.cmsNotifyIcon1.Size = new System.Drawing.Size(163, 48);
            // 
            // 서버콘솔보이기ToolStripMenuItem
            // 
            this.서버콘솔보이기ToolStripMenuItem.Name = "서버콘솔보이기ToolStripMenuItem";
            this.서버콘솔보이기ToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.서버콘솔보이기ToolStripMenuItem.Text = "서버콘솔 보이기";
            this.서버콘솔보이기ToolStripMenuItem.Click += new System.EventHandler(this.서버콘솔보이기ToolStripMenuItem_Click);
            // 
            // 서버종료하기ToolStripMenuItem
            // 
            this.서버종료하기ToolStripMenuItem.Name = "서버종료하기ToolStripMenuItem";
            this.서버종료하기ToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.서버종료하기ToolStripMenuItem.Text = "서버 종료하기";
            this.서버종료하기ToolStripMenuItem.Click += new System.EventHandler(this.서버종료하기ToolStripMenuItem_Click);
            // 
            // rdDBFilePath
            // 
            this.rdDBFilePath.AutoSize = true;
            this.rdDBFilePath.Location = new System.Drawing.Point(160, 462);
            this.rdDBFilePath.Name = "rdDBFilePath";
            this.rdDBFilePath.Size = new System.Drawing.Size(119, 16);
            this.rdDBFilePath.TabIndex = 15;
            this.rdDBFilePath.TabStop = true;
            this.rdDBFilePath.Text = "DB파일 경로 입력";
            this.rdDBFilePath.UseVisualStyleBackColor = true;
            this.rdDBFilePath.CheckedChanged += new System.EventHandler(this.rdDBFilePath_CheckedChanged);
            // 
            // rdRestoreDB
            // 
            this.rdRestoreDB.AutoSize = true;
            this.rdRestoreDB.Location = new System.Drawing.Point(293, 462);
            this.rdRestoreDB.Name = "rdRestoreDB";
            this.rdRestoreDB.Size = new System.Drawing.Size(143, 16);
            this.rdRestoreDB.TabIndex = 16;
            this.rdRestoreDB.TabStop = true;
            this.rdRestoreDB.Text = "백업파일 에서 DB복원";
            this.rdRestoreDB.UseVisualStyleBackColor = true;
            this.rdRestoreDB.CheckedChanged += new System.EventHandler(this.rdRestoreDB_CheckedChanged);
            // 
            // rdCreateDB
            // 
            this.rdCreateDB.AutoSize = true;
            this.rdCreateDB.Location = new System.Drawing.Point(452, 462);
            this.rdCreateDB.Name = "rdCreateDB";
            this.rdCreateDB.Size = new System.Drawing.Size(107, 16);
            this.rdCreateDB.TabIndex = 17;
            this.rdCreateDB.TabStop = true;
            this.rdCreateDB.Text = "빈 DB파일 생성";
            this.rdCreateDB.UseVisualStyleBackColor = true;
            this.rdCreateDB.CheckedChanged += new System.EventHandler(this.rdCreateDB_CheckedChanged);
            // 
            // LinkBackupFile
            // 
            this.LinkBackupFile.AutoSize = true;
            this.LinkBackupFile.Location = new System.Drawing.Point(584, 526);
            this.LinkBackupFile.Name = "LinkBackupFile";
            this.LinkBackupFile.Size = new System.Drawing.Size(77, 12);
            this.LinkBackupFile.TabIndex = 19;
            this.LinkBackupFile.TabStop = true;
            this.LinkBackupFile.Text = "백업파일찾기";
            this.LinkBackupFile.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkBackupFile_LinkClicked);
            // 
            // txtBackupFile
            // 
            this.txtBackupFile.Enabled = false;
            this.txtBackupFile.Location = new System.Drawing.Point(160, 517);
            this.txtBackupFile.Name = "txtBackupFile";
            this.txtBackupFile.Size = new System.Drawing.Size(418, 21);
            this.txtBackupFile.TabIndex = 18;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 609);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmMain";
            this.Text = "frmMain";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.pnCommonSettingView.ResumeLayout(false);
            this.pnCommonSettingView.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.cmsServiceActive.ResumeLayout(false);
            this.cmsNotifyIcon1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView lvServiceList;
        private System.Windows.Forms.ColumnHeader colURL;
        private System.Windows.Forms.ColumnHeader colActivity;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEnd;
        private System.Windows.Forms.TextBox txtServiceURL;
        private System.Windows.Forms.Label lblCurrServiceURL;
        private System.Windows.Forms.Panel pnCommonSettingView;
        private System.Windows.Forms.TextBox txtDBPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel linkPortTest;
        private System.Windows.Forms.LinkLabel linkDBFinder;
        private System.Windows.Forms.LinkLabel linkExternalIP;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblExternalIP;
        private System.Windows.Forms.TextBox txtBackupPath;
        private System.Windows.Forms.TextBox txtExternalIP;
        private System.Windows.Forms.ListBox lbMirrorPaths;
        private System.Windows.Forms.LinkLabel linkDeleteMirrorPath;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtSecureKey;
        private System.Windows.Forms.ContextMenuStrip cmsServiceActive;
        private System.Windows.Forms.ToolStripMenuItem 서비스시작ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 서비스종료ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 서비스재시작ToolStripMenuItem;
        private System.Windows.Forms.LinkLabel linkSetMirrorPath;
        private System.Windows.Forms.LinkLabel linkBackupPath;
        private System.Windows.Forms.ComboBox cbBackupSchedule;
        private System.Windows.Forms.Button btnSetCommonSettings;
        private System.Windows.Forms.RadioButton rdSecurityMode;
        private System.Windows.Forms.RadioButton rdNotSecurityMode;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.LinkLabel linkWarning;
        private System.Windows.Forms.ToolStripMenuItem 쿼리실행ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 즉시백업ToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ToolStripMenuItem 모든서비스삭제ToolStripMenuItem;
        private System.Windows.Forms.LinkLabel linkDeleteAllSettings;
        private System.Windows.Forms.ToolStripMenuItem 서비스삭제ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 모든서비스종료ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 모든서비스재시작ToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cmsNotifyIcon1;
        private System.Windows.Forms.ToolStripMenuItem 서버콘솔보이기ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 서버종료하기ToolStripMenuItem;
        private System.Windows.Forms.LinkLabel LinkBackupFile;
        private System.Windows.Forms.TextBox txtBackupFile;
        private System.Windows.Forms.RadioButton rdCreateDB;
        private System.Windows.Forms.RadioButton rdRestoreDB;
        private System.Windows.Forms.RadioButton rdDBFilePath;

    }
}