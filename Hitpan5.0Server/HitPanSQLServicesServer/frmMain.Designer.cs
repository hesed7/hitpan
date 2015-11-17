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
            this.LinkBackupFile = new System.Windows.Forms.LinkLabel();
            this.txtBackupFile = new System.Windows.Forms.TextBox();
            this.rdCreateDB = new System.Windows.Forms.RadioButton();
            this.rdRestoreDB = new System.Windows.Forms.RadioButton();
            this.linkPortTest = new System.Windows.Forms.LinkLabel();
            this.linkExternalIP = new System.Windows.Forms.LinkLabel();
            this.pnCommonSettingView = new System.Windows.Forms.Panel();
            this.linkWarning = new System.Windows.Forms.LinkLabel();
            this.label6 = new System.Windows.Forms.Label();
            this.linkBackupPath = new System.Windows.Forms.LinkLabel();
            this.cbBackupSchedule = new System.Windows.Forms.ComboBox();
            this.btnSetCommonSettings = new System.Windows.Forms.Button();
            this.rdSecurityMode = new System.Windows.Forms.RadioButton();
            this.rdNotSecurityMode = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSecureKey = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtBackupPath = new System.Windows.Forms.TextBox();
            this.txtExternalIP = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblExternalIP = new System.Windows.Forms.Label();
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
            this.즉시백업ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dB복원ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.모든서비스종료ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.모든서비스재시작ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.모든서비스삭제ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.쿼리실행ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.cmsNotifyIcon1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.서버콘솔보이기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.서버종료하기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSettingClear = new System.Windows.Forms.Button();
            this.tabCommonSetting = new System.Windows.Forms.TabControl();
            this.tpageCommonSetting = new System.Windows.Forms.TabPage();
            this.gboxMainDBStatus = new System.Windows.Forms.GroupBox();
            this.rbtnMainDBOK = new System.Windows.Forms.RadioButton();
            this.rbtnMainDBRecovery = new System.Windows.Forms.RadioButton();
            this.rbtnMainDBFault = new System.Windows.Forms.RadioButton();
            this.gboxStandbyDBStatus = new System.Windows.Forms.GroupBox();
            this.rbtnStandbyDBFault = new System.Windows.Forms.RadioButton();
            this.rbtnStandbyDBInUse = new System.Windows.Forms.RadioButton();
            this.rbtnStandbyDBOK = new System.Windows.Forms.RadioButton();
            this.tpageDBServer = new System.Windows.Forms.TabPage();
            this.gboxMainDB = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtDBURL = new System.Windows.Forms.TextBox();
            this.txtDBPort = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.linkInstallMainDB = new System.Windows.Forms.LinkLabel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.lblDBFolder = new System.Windows.Forms.Label();
            this.txtDBFolderPath = new System.Windows.Forms.TextBox();
            this.linkDBFolderPath = new System.Windows.Forms.LinkLabel();
            this.btnSetDBServer = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.pnCommonSettingView.SuspendLayout();
            this.panel1.SuspendLayout();
            this.cmsServiceActive.SuspendLayout();
            this.cmsNotifyIcon1.SuspendLayout();
            this.tabCommonSetting.SuspendLayout();
            this.tpageCommonSetting.SuspendLayout();
            this.gboxMainDBStatus.SuspendLayout();
            this.gboxStandbyDBStatus.SuspendLayout();
            this.tpageDBServer.SuspendLayout();
            this.gboxMainDB.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tabCommonSetting);
            this.panel2.Controls.Add(this.LinkBackupFile);
            this.panel2.Controls.Add(this.txtBackupFile);
            this.panel2.Controls.Add(this.rdCreateDB);
            this.panel2.Controls.Add(this.rdRestoreDB);
            this.panel2.Controls.Add(this.linkPortTest);
            this.panel2.Controls.Add(this.linkExternalIP);
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
            this.panel2.Size = new System.Drawing.Size(678, 534);
            this.panel2.TabIndex = 3;
            // 
            // LinkBackupFile
            // 
            this.LinkBackupFile.AutoSize = true;
            this.LinkBackupFile.Location = new System.Drawing.Point(584, 463);
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
            this.txtBackupFile.Location = new System.Drawing.Point(160, 454);
            this.txtBackupFile.Name = "txtBackupFile";
            this.txtBackupFile.Size = new System.Drawing.Size(418, 21);
            this.txtBackupFile.TabIndex = 18;
            // 
            // rdCreateDB
            // 
            this.rdCreateDB.AutoSize = true;
            this.rdCreateDB.Location = new System.Drawing.Point(319, 432);
            this.rdCreateDB.Name = "rdCreateDB";
            this.rdCreateDB.Size = new System.Drawing.Size(119, 16);
            this.rdCreateDB.TabIndex = 17;
            this.rdCreateDB.TabStop = true;
            this.rdCreateDB.Text = "비어있는 DB 생성";
            this.rdCreateDB.UseVisualStyleBackColor = true;
            this.rdCreateDB.CheckedChanged += new System.EventHandler(this.rdCreateDB_CheckedChanged);
            // 
            // rdRestoreDB
            // 
            this.rdRestoreDB.AutoSize = true;
            this.rdRestoreDB.Location = new System.Drawing.Point(160, 432);
            this.rdRestoreDB.Name = "rdRestoreDB";
            this.rdRestoreDB.Size = new System.Drawing.Size(143, 16);
            this.rdRestoreDB.TabIndex = 16;
            this.rdRestoreDB.TabStop = true;
            this.rdRestoreDB.Text = "백업파일 에서 DB생성";
            this.rdRestoreDB.UseVisualStyleBackColor = true;
            this.rdRestoreDB.CheckedChanged += new System.EventHandler(this.rdRestoreDB_CheckedChanged);
            // 
            // linkPortTest
            // 
            this.linkPortTest.AutoSize = true;
            this.linkPortTest.Location = new System.Drawing.Point(247, 396);
            this.linkPortTest.Name = "linkPortTest";
            this.linkPortTest.Size = new System.Drawing.Size(65, 12);
            this.linkPortTest.TabIndex = 14;
            this.linkPortTest.TabStop = true;
            this.linkPortTest.Text = "포트테스트";
            // 
            // linkExternalIP
            // 
            this.linkExternalIP.AutoSize = true;
            this.linkExternalIP.Location = new System.Drawing.Point(587, 370);
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
            this.pnCommonSettingView.Controls.Add(this.gboxStandbyDBStatus);
            this.pnCommonSettingView.Controls.Add(this.gboxMainDBStatus);
            this.pnCommonSettingView.Controls.Add(this.btnSettingClear);
            this.pnCommonSettingView.Controls.Add(this.linkWarning);
            this.pnCommonSettingView.Controls.Add(this.label6);
            this.pnCommonSettingView.Controls.Add(this.linkBackupPath);
            this.pnCommonSettingView.Controls.Add(this.cbBackupSchedule);
            this.pnCommonSettingView.Controls.Add(this.btnSetCommonSettings);
            this.pnCommonSettingView.Controls.Add(this.rdSecurityMode);
            this.pnCommonSettingView.Controls.Add(this.rdNotSecurityMode);
            this.pnCommonSettingView.Controls.Add(this.label8);
            this.pnCommonSettingView.Controls.Add(this.txtSecureKey);
            this.pnCommonSettingView.Controls.Add(this.label7);
            this.pnCommonSettingView.Controls.Add(this.txtBackupPath);
            this.pnCommonSettingView.Controls.Add(this.txtExternalIP);
            this.pnCommonSettingView.Controls.Add(this.label5);
            this.pnCommonSettingView.Controls.Add(this.label3);
            this.pnCommonSettingView.Controls.Add(this.lblExternalIP);
            this.pnCommonSettingView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnCommonSettingView.Location = new System.Drawing.Point(3, 3);
            this.pnCommonSettingView.Name = "pnCommonSettingView";
            this.pnCommonSettingView.Size = new System.Drawing.Size(656, 309);
            this.pnCommonSettingView.TabIndex = 11;
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
            this.btnSetCommonSettings.Location = new System.Drawing.Point(405, 283);
            this.btnSetCommonSettings.Name = "btnSetCommonSettings";
            this.btnSetCommonSettings.Size = new System.Drawing.Size(109, 23);
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
            // txtBackupPath
            // 
            this.txtBackupPath.Location = new System.Drawing.Point(157, 156);
            this.txtBackupPath.Name = "txtBackupPath";
            this.txtBackupPath.ReadOnly = true;
            this.txtBackupPath.Size = new System.Drawing.Size(472, 21);
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(64, 434);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "데이터 파일: ";
            // 
            // txtPort
            // 
            this.txtPort.Enabled = false;
            this.txtPort.Location = new System.Drawing.Point(160, 393);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(78, 21);
            this.txtPort.TabIndex = 8;
            this.txtPort.TextChanged += new System.EventHandler(this.txtPort_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 402);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "서비스 포트번호: ";
            // 
            // txtServiceURL
            // 
            this.txtServiceURL.Location = new System.Drawing.Point(160, 361);
            this.txtServiceURL.Name = "txtServiceURL";
            this.txtServiceURL.Size = new System.Drawing.Size(418, 21);
            this.txtServiceURL.TabIndex = 6;
            this.txtServiceURL.Text = "http://";
            this.txtServiceURL.TextChanged += new System.EventHandler(this.txtServiceURL_TextChanged);
            // 
            // lblCurrServiceURL
            // 
            this.lblCurrServiceURL.AutoSize = true;
            this.lblCurrServiceURL.Location = new System.Drawing.Point(67, 370);
            this.lblCurrServiceURL.Name = "lblCurrServiceURL";
            this.lblCurrServiceURL.Size = new System.Drawing.Size(77, 12);
            this.lblCurrServiceURL.TabIndex = 5;
            this.lblCurrServiceURL.Text = "서비스 주소: ";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(29, 498);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(116, 23);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "추가하기";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(160, 498);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(116, 23);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "삭제하기";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEnd
            // 
            this.btnEnd.Location = new System.Drawing.Point(549, 498);
            this.btnEnd.Name = "btnEnd";
            this.btnEnd.Size = new System.Drawing.Size(116, 23);
            this.btnEnd.TabIndex = 1;
            this.btnEnd.Text = "설정 끝내기";
            this.btnEnd.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lvServiceList);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1000, 551);
            this.panel1.TabIndex = 2;
            // 
            // lvServiceList
            // 
            this.lvServiceList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colURL,
            this.colActivity});
            this.lvServiceList.ContextMenuStrip = this.cmsServiceActive;
            this.lvServiceList.FullRowSelect = true;
            this.lvServiceList.GridLines = true;
            this.lvServiceList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvServiceList.Location = new System.Drawing.Point(0, 0);
            this.lvServiceList.MultiSelect = false;
            this.lvServiceList.Name = "lvServiceList";
            this.lvServiceList.Size = new System.Drawing.Size(298, 546);
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
            this.즉시백업ToolStripMenuItem,
            this.dB복원ToolStripMenuItem,
            this.모든서비스종료ToolStripMenuItem,
            this.모든서비스재시작ToolStripMenuItem,
            this.모든서비스삭제ToolStripMenuItem,
            this.쿼리실행ToolStripMenuItem});
            this.cmsServiceActive.Name = "cmsServiceActive";
            this.cmsServiceActive.Size = new System.Drawing.Size(179, 224);
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
            // 즉시백업ToolStripMenuItem
            // 
            this.즉시백업ToolStripMenuItem.Name = "즉시백업ToolStripMenuItem";
            this.즉시백업ToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.즉시백업ToolStripMenuItem.Text = "즉시 백업";
            this.즉시백업ToolStripMenuItem.Click += new System.EventHandler(this.즉시백업ToolStripMenuItem_Click);
            // 
            // dB복원ToolStripMenuItem
            // 
            this.dB복원ToolStripMenuItem.Name = "dB복원ToolStripMenuItem";
            this.dB복원ToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.dB복원ToolStripMenuItem.Text = "즉시 DB복원";
            this.dB복원ToolStripMenuItem.Click += new System.EventHandler(this.dB복원ToolStripMenuItem_Click);
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
            // 쿼리실행ToolStripMenuItem
            // 
            this.쿼리실행ToolStripMenuItem.Name = "쿼리실행ToolStripMenuItem";
            this.쿼리실행ToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.쿼리실행ToolStripMenuItem.Text = "쿼리실행";
            this.쿼리실행ToolStripMenuItem.Click += new System.EventHandler(this.쿼리실행ToolStripMenuItem_Click);
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
            // btnSettingClear
            // 
            this.btnSettingClear.Location = new System.Drawing.Point(520, 283);
            this.btnSettingClear.Name = "btnSettingClear";
            this.btnSettingClear.Size = new System.Drawing.Size(109, 23);
            this.btnSettingClear.TabIndex = 20;
            this.btnSettingClear.Text = "설정정보 초기화";
            this.btnSettingClear.UseVisualStyleBackColor = true;
            this.btnSettingClear.Click += new System.EventHandler(this.btnSettingClear_Click);
            // 
            // tabCommonSetting
            // 
            this.tabCommonSetting.Controls.Add(this.tpageCommonSetting);
            this.tabCommonSetting.Controls.Add(this.tpageDBServer);
            this.tabCommonSetting.Location = new System.Drawing.Point(8, 3);
            this.tabCommonSetting.Name = "tabCommonSetting";
            this.tabCommonSetting.SelectedIndex = 0;
            this.tabCommonSetting.Size = new System.Drawing.Size(670, 341);
            this.tabCommonSetting.TabIndex = 1;
            // 
            // tpageCommonSetting
            // 
            this.tpageCommonSetting.Controls.Add(this.pnCommonSettingView);
            this.tpageCommonSetting.Location = new System.Drawing.Point(4, 22);
            this.tpageCommonSetting.Name = "tpageCommonSetting";
            this.tpageCommonSetting.Padding = new System.Windows.Forms.Padding(3);
            this.tpageCommonSetting.Size = new System.Drawing.Size(662, 315);
            this.tpageCommonSetting.TabIndex = 1;
            this.tpageCommonSetting.Text = "공통 설정사항";
            this.tpageCommonSetting.UseVisualStyleBackColor = true;
            // 
            // gboxMainDBStatus
            // 
            this.gboxMainDBStatus.Controls.Add(this.rbtnMainDBFault);
            this.gboxMainDBStatus.Controls.Add(this.rbtnMainDBRecovery);
            this.gboxMainDBStatus.Controls.Add(this.rbtnMainDBOK);
            this.gboxMainDBStatus.Location = new System.Drawing.Point(23, 216);
            this.gboxMainDBStatus.Name = "gboxMainDBStatus";
            this.gboxMainDBStatus.Size = new System.Drawing.Size(606, 32);
            this.gboxMainDBStatus.TabIndex = 26;
            this.gboxMainDBStatus.TabStop = false;
            this.gboxMainDBStatus.Text = "메인DB서버  상태";
            // 
            // rbtnMainDBOK
            // 
            this.rbtnMainDBOK.AutoSize = true;
            this.rbtnMainDBOK.Enabled = false;
            this.rbtnMainDBOK.Location = new System.Drawing.Point(137, 10);
            this.rbtnMainDBOK.Name = "rbtnMainDBOK";
            this.rbtnMainDBOK.Size = new System.Drawing.Size(47, 16);
            this.rbtnMainDBOK.TabIndex = 0;
            this.rbtnMainDBOK.TabStop = true;
            this.rbtnMainDBOK.Text = "정상";
            this.rbtnMainDBOK.UseVisualStyleBackColor = true;
            // 
            // rbtnMainDBRecovery
            // 
            this.rbtnMainDBRecovery.AutoSize = true;
            this.rbtnMainDBRecovery.Enabled = false;
            this.rbtnMainDBRecovery.Location = new System.Drawing.Point(281, 10);
            this.rbtnMainDBRecovery.Name = "rbtnMainDBRecovery";
            this.rbtnMainDBRecovery.Size = new System.Drawing.Size(59, 16);
            this.rbtnMainDBRecovery.TabIndex = 1;
            this.rbtnMainDBRecovery.TabStop = true;
            this.rbtnMainDBRecovery.Text = "복구중";
            this.rbtnMainDBRecovery.UseVisualStyleBackColor = true;
            // 
            // rbtnMainDBFault
            // 
            this.rbtnMainDBFault.AutoSize = true;
            this.rbtnMainDBFault.Enabled = false;
            this.rbtnMainDBFault.Location = new System.Drawing.Point(426, 10);
            this.rbtnMainDBFault.Name = "rbtnMainDBFault";
            this.rbtnMainDBFault.Size = new System.Drawing.Size(71, 16);
            this.rbtnMainDBFault.TabIndex = 2;
            this.rbtnMainDBFault.TabStop = true;
            this.rbtnMainDBFault.Text = "사용불가";
            this.rbtnMainDBFault.UseVisualStyleBackColor = true;
            // 
            // gboxStandbyDBStatus
            // 
            this.gboxStandbyDBStatus.Controls.Add(this.rbtnStandbyDBFault);
            this.gboxStandbyDBStatus.Controls.Add(this.rbtnStandbyDBInUse);
            this.gboxStandbyDBStatus.Controls.Add(this.rbtnStandbyDBOK);
            this.gboxStandbyDBStatus.Location = new System.Drawing.Point(23, 248);
            this.gboxStandbyDBStatus.Name = "gboxStandbyDBStatus";
            this.gboxStandbyDBStatus.Size = new System.Drawing.Size(606, 32);
            this.gboxStandbyDBStatus.TabIndex = 27;
            this.gboxStandbyDBStatus.TabStop = false;
            this.gboxStandbyDBStatus.Text = "대기DB서버  상태";
            // 
            // rbtnStandbyDBFault
            // 
            this.rbtnStandbyDBFault.AutoSize = true;
            this.rbtnStandbyDBFault.Enabled = false;
            this.rbtnStandbyDBFault.Location = new System.Drawing.Point(426, 10);
            this.rbtnStandbyDBFault.Name = "rbtnStandbyDBFault";
            this.rbtnStandbyDBFault.Size = new System.Drawing.Size(71, 16);
            this.rbtnStandbyDBFault.TabIndex = 2;
            this.rbtnStandbyDBFault.TabStop = true;
            this.rbtnStandbyDBFault.Text = "사용불가";
            this.rbtnStandbyDBFault.UseVisualStyleBackColor = true;
            // 
            // rbtnStandbyDBInUse
            // 
            this.rbtnStandbyDBInUse.AutoSize = true;
            this.rbtnStandbyDBInUse.Enabled = false;
            this.rbtnStandbyDBInUse.Location = new System.Drawing.Point(281, 10);
            this.rbtnStandbyDBInUse.Name = "rbtnStandbyDBInUse";
            this.rbtnStandbyDBInUse.Size = new System.Drawing.Size(47, 16);
            this.rbtnStandbyDBInUse.TabIndex = 1;
            this.rbtnStandbyDBInUse.TabStop = true;
            this.rbtnStandbyDBInUse.Text = "활성";
            this.rbtnStandbyDBInUse.UseVisualStyleBackColor = true;
            // 
            // rbtnStandbyDBOK
            // 
            this.rbtnStandbyDBOK.AutoSize = true;
            this.rbtnStandbyDBOK.Enabled = false;
            this.rbtnStandbyDBOK.Location = new System.Drawing.Point(137, 10);
            this.rbtnStandbyDBOK.Name = "rbtnStandbyDBOK";
            this.rbtnStandbyDBOK.Size = new System.Drawing.Size(59, 16);
            this.rbtnStandbyDBOK.TabIndex = 0;
            this.rbtnStandbyDBOK.TabStop = true;
            this.rbtnStandbyDBOK.Text = "대기중";
            this.rbtnStandbyDBOK.UseVisualStyleBackColor = true;
            // 
            // tpageDBServer
            // 
            this.tpageDBServer.Controls.Add(this.btnSetDBServer);
            this.tpageDBServer.Controls.Add(this.groupBox1);
            this.tpageDBServer.Controls.Add(this.gboxMainDB);
            this.tpageDBServer.Location = new System.Drawing.Point(4, 22);
            this.tpageDBServer.Name = "tpageDBServer";
            this.tpageDBServer.Size = new System.Drawing.Size(662, 315);
            this.tpageDBServer.TabIndex = 2;
            this.tpageDBServer.Text = "DB서버 설정";
            this.tpageDBServer.UseVisualStyleBackColor = true;
            // 
            // gboxMainDB
            // 
            this.gboxMainDB.Controls.Add(this.linkDBFolderPath);
            this.gboxMainDB.Controls.Add(this.txtDBFolderPath);
            this.gboxMainDB.Controls.Add(this.lblDBFolder);
            this.gboxMainDB.Controls.Add(this.linkInstallMainDB);
            this.gboxMainDB.Controls.Add(this.textBox2);
            this.gboxMainDB.Controls.Add(this.textBox1);
            this.gboxMainDB.Controls.Add(this.txtDBPort);
            this.gboxMainDB.Controls.Add(this.txtDBURL);
            this.gboxMainDB.Controls.Add(this.label11);
            this.gboxMainDB.Controls.Add(this.label10);
            this.gboxMainDB.Controls.Add(this.label9);
            this.gboxMainDB.Controls.Add(this.label4);
            this.gboxMainDB.Location = new System.Drawing.Point(3, 16);
            this.gboxMainDB.Name = "gboxMainDB";
            this.gboxMainDB.Size = new System.Drawing.Size(649, 118);
            this.gboxMainDB.TabIndex = 0;
            this.gboxMainDB.TabStop = false;
            this.gboxMainDB.Text = "메인DB서버";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "URL :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(444, 29);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 12);
            this.label9.TabIndex = 1;
            this.label9.Text = "Port :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(39, 56);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(24, 12);
            this.label10.TabIndex = 2;
            this.label10.Text = "ID :";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(186, 54);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(70, 12);
            this.label11.TabIndex = 3;
            this.label11.Text = "Password :";
            // 
            // txtDBURL
            // 
            this.txtDBURL.Location = new System.Drawing.Point(69, 22);
            this.txtDBURL.Name = "txtDBURL";
            this.txtDBURL.Size = new System.Drawing.Size(358, 21);
            this.txtDBURL.TabIndex = 5;
            // 
            // txtDBPort
            // 
            this.txtDBPort.Location = new System.Drawing.Point(485, 22);
            this.txtDBPort.Name = "txtDBPort";
            this.txtDBPort.Size = new System.Drawing.Size(51, 21);
            this.txtDBPort.TabIndex = 6;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(69, 49);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(111, 21);
            this.textBox1.TabIndex = 7;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(262, 49);
            this.textBox2.Name = "textBox2";
            this.textBox2.PasswordChar = '*';
            this.textBox2.Size = new System.Drawing.Size(165, 21);
            this.textBox2.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.linkLabel2);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.textBox4);
            this.groupBox1.Controls.Add(this.textBox5);
            this.groupBox1.Controls.Add(this.textBox6);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Location = new System.Drawing.Point(4, 161);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(649, 111);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "대기 DB서버";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(261, 70);
            this.textBox3.Name = "textBox3";
            this.textBox3.PasswordChar = '*';
            this.textBox3.Size = new System.Drawing.Size(165, 21);
            this.textBox3.TabIndex = 8;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(68, 70);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(111, 21);
            this.textBox4.TabIndex = 7;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(485, 22);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(51, 21);
            this.textBox5.TabIndex = 6;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(69, 22);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(358, 21);
            this.textBox6.TabIndex = 5;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(185, 75);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(70, 12);
            this.label12.TabIndex = 3;
            this.label12.Text = "Password :";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(38, 79);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(24, 12);
            this.label13.TabIndex = 2;
            this.label13.Text = "ID :";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(444, 29);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(35, 12);
            this.label14.TabIndex = 1;
            this.label14.Text = "Port :";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(27, 31);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(36, 12);
            this.label15.TabIndex = 0;
            this.label15.Text = "URL :";
            // 
            // linkInstallMainDB
            // 
            this.linkInstallMainDB.AutoSize = true;
            this.linkInstallMainDB.Location = new System.Drawing.Point(446, 56);
            this.linkInstallMainDB.Name = "linkInstallMainDB";
            this.linkInstallMainDB.Size = new System.Drawing.Size(141, 12);
            this.linkInstallMainDB.TabIndex = 9;
            this.linkInstallMainDB.TabStop = true;
            this.linkInstallMainDB.Text = "이 컴퓨터에 DB서버 설치";
            this.linkInstallMainDB.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkInstallMainDB_LinkClicked);
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(443, 79);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(141, 12);
            this.linkLabel2.TabIndex = 10;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "이 컴퓨터에 DB서버 설치";
            // 
            // lblDBFolder
            // 
            this.lblDBFolder.AutoSize = true;
            this.lblDBFolder.Location = new System.Drawing.Point(10, 88);
            this.lblDBFolder.Name = "lblDBFolder";
            this.lblDBFolder.Size = new System.Drawing.Size(53, 12);
            this.lblDBFolder.TabIndex = 10;
            this.lblDBFolder.Text = "DB폴더 :";
            this.lblDBFolder.Visible = false;
            // 
            // txtDBFolderPath
            // 
            this.txtDBFolderPath.Location = new System.Drawing.Point(69, 79);
            this.txtDBFolderPath.Name = "txtDBFolderPath";
            this.txtDBFolderPath.Size = new System.Drawing.Size(358, 21);
            this.txtDBFolderPath.TabIndex = 11;
            this.txtDBFolderPath.Visible = false;
            // 
            // linkDBFolderPath
            // 
            this.linkDBFolderPath.AutoSize = true;
            this.linkDBFolderPath.Location = new System.Drawing.Point(433, 88);
            this.linkDBFolderPath.Name = "linkDBFolderPath";
            this.linkDBFolderPath.Size = new System.Drawing.Size(29, 12);
            this.linkDBFolderPath.TabIndex = 12;
            this.linkDBFolderPath.TabStop = true;
            this.linkDBFolderPath.Text = "설정";
            this.linkDBFolderPath.Visible = false;
            // 
            // btnSetDBServer
            // 
            this.btnSetDBServer.Location = new System.Drawing.Point(478, 278);
            this.btnSetDBServer.Name = "btnSetDBServer";
            this.btnSetDBServer.Size = new System.Drawing.Size(111, 23);
            this.btnSetDBServer.TabIndex = 11;
            this.btnSetDBServer.Text = "DB서버 설정 끝";
            this.btnSetDBServer.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 551);
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
            this.tabCommonSetting.ResumeLayout(false);
            this.tpageCommonSetting.ResumeLayout(false);
            this.gboxMainDBStatus.ResumeLayout(false);
            this.gboxMainDBStatus.PerformLayout();
            this.gboxStandbyDBStatus.ResumeLayout(false);
            this.gboxStandbyDBStatus.PerformLayout();
            this.tpageDBServer.ResumeLayout(false);
            this.gboxMainDB.ResumeLayout(false);
            this.gboxMainDB.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel linkPortTest;
        private System.Windows.Forms.LinkLabel linkExternalIP;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblExternalIP;
        private System.Windows.Forms.TextBox txtBackupPath;
        private System.Windows.Forms.TextBox txtExternalIP;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtSecureKey;
        private System.Windows.Forms.ContextMenuStrip cmsServiceActive;
        private System.Windows.Forms.ToolStripMenuItem 서비스시작ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 서비스종료ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 서비스재시작ToolStripMenuItem;
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
        private System.Windows.Forms.ToolStripMenuItem dB복원ToolStripMenuItem;
        private System.Windows.Forms.Button btnSettingClear;
        private System.Windows.Forms.TabControl tabCommonSetting;
        private System.Windows.Forms.TabPage tpageCommonSetting;
        private System.Windows.Forms.GroupBox gboxStandbyDBStatus;
        private System.Windows.Forms.RadioButton rbtnStandbyDBFault;
        private System.Windows.Forms.RadioButton rbtnStandbyDBInUse;
        private System.Windows.Forms.RadioButton rbtnStandbyDBOK;
        private System.Windows.Forms.GroupBox gboxMainDBStatus;
        private System.Windows.Forms.RadioButton rbtnMainDBFault;
        private System.Windows.Forms.RadioButton rbtnMainDBRecovery;
        private System.Windows.Forms.RadioButton rbtnMainDBOK;
        private System.Windows.Forms.TabPage tpageDBServer;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.GroupBox gboxMainDB;
        private System.Windows.Forms.LinkLabel linkDBFolderPath;
        private System.Windows.Forms.TextBox txtDBFolderPath;
        private System.Windows.Forms.Label lblDBFolder;
        private System.Windows.Forms.LinkLabel linkInstallMainDB;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox txtDBPort;
        private System.Windows.Forms.TextBox txtDBURL;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSetDBServer;

    }
}