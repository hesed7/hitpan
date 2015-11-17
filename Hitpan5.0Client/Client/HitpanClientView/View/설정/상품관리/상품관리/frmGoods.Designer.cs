namespace HitpanClientView.View.설정.상품관리.상품관리
{
    partial class frmGoods
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGoods));
            this.picGood = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.gboxBasicInfo = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.ddlDetailViewMode = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.linkLabel5 = new System.Windows.Forms.LinkLabel();
            this.label9 = new System.Windows.Forms.Label();
            this.lstbParts = new System.Windows.Forms.ListBox();
            this.linkImagePath = new System.Windows.Forms.LinkLabel();
            this.ddlStatus = new System.Windows.Forms.ComboBox();
            this.txtProperStock = new System.Windows.Forms.TextBox();
            this.txtMaker = new System.Windows.Forms.TextBox();
            this.txtNickName = new System.Windows.Forms.TextBox();
            this.txtSubname = new System.Windows.Forms.TextBox();
            this.txtGoodName = new System.Windows.Forms.TextBox();
            this.txtETC = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.linkLabel3 = new System.Windows.Forms.LinkLabel();
            this.lstbUnitCost = new System.Windows.Forms.ListBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lstbUnitsPolicy = new System.Windows.Forms.ListBox();
            this.linkLabel4 = new System.Windows.Forms.LinkLabel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lstbSeller = new System.Windows.Forms.ListBox();
            this.cmsSeller = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.매입처에연락하기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnInput = new System.Windows.Forms.Button();
            this.btnOut = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.작업메뉴ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.인쇄ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.엑셀로변환ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.엑셀에서등록ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.일괄수정ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.바코드출력ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdGoodList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.엑셀에서입력ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.엑셀로출력ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.프린터로출력ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pDF로출력ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnDetailView.SuspendLayout();
            this.pnSearchConsole.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picGood)).BeginInit();
            this.gboxBasicInfo.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.cmsSeller.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.cmdGoodList.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnDetailView
            // 
            this.pnDetailView.Controls.Add(this.btnOut);
            this.pnDetailView.Controls.Add(this.btnInput);
            this.pnDetailView.Controls.Add(this.groupBox4);
            this.pnDetailView.Controls.Add(this.groupBox3);
            this.pnDetailView.Controls.Add(this.groupBox2);
            this.pnDetailView.Controls.Add(this.gboxBasicInfo);
            this.pnDetailView.Location = new System.Drawing.Point(544, 2);
            this.pnDetailView.Size = new System.Drawing.Size(443, 694);
            // 
            // pnSearchConsole
            // 
            this.pnSearchConsole.Controls.Add(this.button1);
            this.pnSearchConsole.Controls.Add(this.label12);
            this.pnSearchConsole.Controls.Add(this.textBox2);
            this.pnSearchConsole.Controls.Add(this.comboBox2);
            this.pnSearchConsole.Controls.Add(this.label7);
            this.pnSearchConsole.Controls.Add(this.linkLabel1);
            this.pnSearchConsole.Controls.Add(this.menuStrip1);
            this.pnSearchConsole.Location = new System.Drawing.Point(11, 3);
            // 
            // picGood
            // 
            this.picGood.Image = ((System.Drawing.Image)(resources.GetObject("picGood.Image")));
            this.picGood.Location = new System.Drawing.Point(8, 49);
            this.picGood.Name = "picGood";
            this.picGood.Size = new System.Drawing.Size(170, 165);
            this.picGood.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picGood.TabIndex = 0;
            this.picGood.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(229, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "상품명 :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(240, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "규격 :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(241, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "별칭 :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(229, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "메이커 :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(241, 169);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 12);
            this.label5.TabIndex = 5;
            this.label5.Text = "상태 :";
            // 
            // gboxBasicInfo
            // 
            this.gboxBasicInfo.Controls.Add(this.label11);
            this.gboxBasicInfo.Controls.Add(this.ddlDetailViewMode);
            this.gboxBasicInfo.Controls.Add(this.textBox1);
            this.gboxBasicInfo.Controls.Add(this.label10);
            this.gboxBasicInfo.Controls.Add(this.linkLabel5);
            this.gboxBasicInfo.Controls.Add(this.label9);
            this.gboxBasicInfo.Controls.Add(this.lstbParts);
            this.gboxBasicInfo.Controls.Add(this.linkImagePath);
            this.gboxBasicInfo.Controls.Add(this.ddlStatus);
            this.gboxBasicInfo.Controls.Add(this.picGood);
            this.gboxBasicInfo.Controls.Add(this.txtProperStock);
            this.gboxBasicInfo.Controls.Add(this.txtMaker);
            this.gboxBasicInfo.Controls.Add(this.txtNickName);
            this.gboxBasicInfo.Controls.Add(this.txtSubname);
            this.gboxBasicInfo.Controls.Add(this.txtGoodName);
            this.gboxBasicInfo.Controls.Add(this.txtETC);
            this.gboxBasicInfo.Controls.Add(this.label8);
            this.gboxBasicInfo.Controls.Add(this.label6);
            this.gboxBasicInfo.Controls.Add(this.label1);
            this.gboxBasicInfo.Controls.Add(this.label2);
            this.gboxBasicInfo.Controls.Add(this.label5);
            this.gboxBasicInfo.Controls.Add(this.label3);
            this.gboxBasicInfo.Controls.Add(this.label4);
            this.gboxBasicInfo.Location = new System.Drawing.Point(24, 10);
            this.gboxBasicInfo.Name = "gboxBasicInfo";
            this.gboxBasicInfo.Size = new System.Drawing.Size(401, 356);
            this.gboxBasicInfo.TabIndex = 8;
            this.gboxBasicInfo.TabStop = false;
            this.gboxBasicInfo.Text = "기본정보";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 14);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 12);
            this.label11.TabIndex = 19;
            this.label11.Text = "상세뷰 모드 :";
            // 
            // ddlDetailViewMode
            // 
            this.ddlDetailViewMode.FormattingEnabled = true;
            this.ddlDetailViewMode.Items.AddRange(new object[] {
            "조회",
            "입력",
            "수정"});
            this.ddlDetailViewMode.Location = new System.Drawing.Point(89, 11);
            this.ddlDetailViewMode.Name = "ddlDetailViewMode";
            this.ddlDetailViewMode.Size = new System.Drawing.Size(58, 20);
            this.ddlDetailViewMode.TabIndex = 18;
            this.ddlDetailViewMode.Text = "조회";
            this.ddlDetailViewMode.SelectedIndexChanged += new System.EventHandler(this.ddlDetailViewMode_SelectedIndexChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(284, 220);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(114, 21);
            this.textBox1.TabIndex = 17;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(102, 229);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(175, 12);
            this.label10.TabIndex = 16;
            this.label10.Text = "미수 허용 일수(외상가능일수) :";
            // 
            // linkLabel5
            // 
            this.linkLabel5.AutoSize = true;
            this.linkLabel5.Location = new System.Drawing.Point(133, 254);
            this.linkLabel5.Name = "linkLabel5";
            this.linkLabel5.Size = new System.Drawing.Size(29, 12);
            this.linkLabel5.TabIndex = 13;
            this.linkLabel5.TabStop = true;
            this.linkLabel5.Text = "입력";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 254);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(117, 12);
            this.label9.TabIndex = 15;
            this.label9.Text = "제조에 필요한 부품 :";
            // 
            // lstbParts
            // 
            this.lstbParts.FormattingEnabled = true;
            this.lstbParts.ItemHeight = 12;
            this.lstbParts.Location = new System.Drawing.Point(8, 269);
            this.lstbParts.Name = "lstbParts";
            this.lstbParts.Size = new System.Drawing.Size(170, 76);
            this.lstbParts.TabIndex = 14;
            // 
            // linkImagePath
            // 
            this.linkImagePath.AutoSize = true;
            this.linkImagePath.Location = new System.Drawing.Point(6, 31);
            this.linkImagePath.Name = "linkImagePath";
            this.linkImagePath.Size = new System.Drawing.Size(85, 12);
            this.linkImagePath.TabIndex = 13;
            this.linkImagePath.TabStop = true;
            this.linkImagePath.Text = "<이미지 등록>";
            // 
            // ddlStatus
            // 
            this.ddlStatus.FormattingEnabled = true;
            this.ddlStatus.Items.AddRange(new object[] {
            "판매",
            "페기",
            "단종"});
            this.ddlStatus.Location = new System.Drawing.Point(284, 161);
            this.ddlStatus.Name = "ddlStatus";
            this.ddlStatus.Size = new System.Drawing.Size(114, 20);
            this.ddlStatus.TabIndex = 14;
            // 
            // txtProperStock
            // 
            this.txtProperStock.Location = new System.Drawing.Point(284, 193);
            this.txtProperStock.Name = "txtProperStock";
            this.txtProperStock.Size = new System.Drawing.Size(114, 21);
            this.txtProperStock.TabIndex = 13;
            // 
            // txtMaker
            // 
            this.txtMaker.Location = new System.Drawing.Point(284, 131);
            this.txtMaker.Name = "txtMaker";
            this.txtMaker.Size = new System.Drawing.Size(114, 21);
            this.txtMaker.TabIndex = 12;
            // 
            // txtNickName
            // 
            this.txtNickName.Location = new System.Drawing.Point(284, 103);
            this.txtNickName.Name = "txtNickName";
            this.txtNickName.Size = new System.Drawing.Size(114, 21);
            this.txtNickName.TabIndex = 11;
            // 
            // txtSubname
            // 
            this.txtSubname.Location = new System.Drawing.Point(284, 76);
            this.txtSubname.Name = "txtSubname";
            this.txtSubname.Size = new System.Drawing.Size(114, 21);
            this.txtSubname.TabIndex = 10;
            // 
            // txtGoodName
            // 
            this.txtGoodName.Location = new System.Drawing.Point(284, 49);
            this.txtGoodName.Name = "txtGoodName";
            this.txtGoodName.Size = new System.Drawing.Size(114, 21);
            this.txtGoodName.TabIndex = 9;
            // 
            // txtETC
            // 
            this.txtETC.Location = new System.Drawing.Point(236, 270);
            this.txtETC.Multiline = true;
            this.txtETC.Name = "txtETC";
            this.txtETC.Size = new System.Drawing.Size(162, 75);
            this.txtETC.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(240, 254);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 12);
            this.label8.TabIndex = 7;
            this.label8.Text = "기타 :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(217, 201);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 12);
            this.label6.TabIndex = 6;
            this.label6.Text = "적정재고 :";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.linkLabel3);
            this.groupBox3.Controls.Add(this.lstbUnitCost);
            this.groupBox3.Location = new System.Drawing.Point(24, 509);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(401, 125);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "매출단가 정책 정보";
            // 
            // linkLabel3
            // 
            this.linkLabel3.AutoSize = true;
            this.linkLabel3.Location = new System.Drawing.Point(131, 0);
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.Size = new System.Drawing.Size(29, 12);
            this.linkLabel3.TabIndex = 13;
            this.linkLabel3.TabStop = true;
            this.linkLabel3.Text = "입력";
            // 
            // lstbUnitCost
            // 
            this.lstbUnitCost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstbUnitCost.FormattingEnabled = true;
            this.lstbUnitCost.ItemHeight = 12;
            this.lstbUnitCost.Location = new System.Drawing.Point(3, 17);
            this.lstbUnitCost.Name = "lstbUnitCost";
            this.lstbUnitCost.Size = new System.Drawing.Size(395, 105);
            this.lstbUnitCost.TabIndex = 6;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lstbUnitsPolicy);
            this.groupBox4.Controls.Add(this.linkLabel4);
            this.groupBox4.Location = new System.Drawing.Point(243, 372);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(182, 127);
            this.groupBox4.TabIndex = 14;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = " 단위 정책";
            // 
            // lstbUnitsPolicy
            // 
            this.lstbUnitsPolicy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstbUnitsPolicy.FormattingEnabled = true;
            this.lstbUnitsPolicy.ItemHeight = 12;
            this.lstbUnitsPolicy.Location = new System.Drawing.Point(3, 17);
            this.lstbUnitsPolicy.Name = "lstbUnitsPolicy";
            this.lstbUnitsPolicy.Size = new System.Drawing.Size(176, 107);
            this.lstbUnitsPolicy.TabIndex = 14;
            // 
            // linkLabel4
            // 
            this.linkLabel4.AutoSize = true;
            this.linkLabel4.Location = new System.Drawing.Point(71, 0);
            this.linkLabel4.Name = "linkLabel4";
            this.linkLabel4.Size = new System.Drawing.Size(29, 12);
            this.linkLabel4.TabIndex = 13;
            this.linkLabel4.TabStop = true;
            this.linkLabel4.Text = "입력";
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(84, 0);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(29, 12);
            this.linkLabel2.TabIndex = 12;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "입력";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.linkLabel2);
            this.groupBox2.Controls.Add(this.lstbSeller);
            this.groupBox2.Location = new System.Drawing.Point(24, 372);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(216, 131);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "매입처 정보";
            // 
            // lstbSeller
            // 
            this.lstbSeller.ContextMenuStrip = this.cmsSeller;
            this.lstbSeller.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstbSeller.FormattingEnabled = true;
            this.lstbSeller.ItemHeight = 12;
            this.lstbSeller.Location = new System.Drawing.Point(3, 17);
            this.lstbSeller.Name = "lstbSeller";
            this.lstbSeller.Size = new System.Drawing.Size(210, 111);
            this.lstbSeller.TabIndex = 6;
            // 
            // cmsSeller
            // 
            this.cmsSeller.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.매입처에연락하기ToolStripMenuItem});
            this.cmsSeller.Name = "cmsSeller";
            this.cmsSeller.Size = new System.Drawing.Size(175, 26);
            // 
            // 매입처에연락하기ToolStripMenuItem
            // 
            this.매입처에연락하기ToolStripMenuItem.Name = "매입처에연락하기ToolStripMenuItem";
            this.매입처에연락하기ToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.매입처에연락하기ToolStripMenuItem.Text = "매입처에 연락하기";
            // 
            // btnInput
            // 
            this.btnInput.Location = new System.Drawing.Point(159, 648);
            this.btnInput.Name = "btnInput";
            this.btnInput.Size = new System.Drawing.Size(113, 23);
            this.btnInput.TabIndex = 15;
            this.btnInput.Text = "btnInput";
            this.btnInput.UseVisualStyleBackColor = true;
            this.btnInput.Visible = false;
            // 
            // btnOut
            // 
            this.btnOut.Location = new System.Drawing.Point(312, 648);
            this.btnOut.Name = "btnOut";
            this.btnOut.Size = new System.Drawing.Size(113, 23);
            this.btnOut.TabIndex = 16;
            this.btnOut.Text = "닫기";
            this.btnOut.UseVisualStyleBackColor = true;
            this.btnOut.Click += new System.EventHandler(this.btnOut_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(91, 9);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(69, 12);
            this.linkLabel1.TabIndex = 18;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "<카테고리>";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 19;
            this.label7.Text = "검색 영역 :";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "상품명",
            "규격",
            "별칭(관리코드,품목코드..)",
            "메이커",
            "메입처",
            "면세",
            "세트(키워드는 완성품명)",
            "기타(참고사항)"});
            this.comboBox2.Location = new System.Drawing.Point(93, 24);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 20);
            this.comboBox2.TabIndex = 20;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(287, 24);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(152, 21);
            this.textBox2.TabIndex = 21;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(232, 27);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(49, 12);
            this.label12.TabIndex = 22;
            this.label12.Text = "검색어 :";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(445, 24);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(77, 20);
            this.button1.TabIndex = 23;
            this.button1.Text = "검색";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.작업메뉴ToolStripMenuItem,
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(525, 24);
            this.menuStrip1.TabIndex = 24;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 작업메뉴ToolStripMenuItem
            // 
            this.작업메뉴ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.인쇄ToolStripMenuItem,
            this.엑셀로변환ToolStripMenuItem,
            this.엑셀에서등록ToolStripMenuItem,
            this.일괄수정ToolStripMenuItem,
            this.바코드출력ToolStripMenuItem});
            this.작업메뉴ToolStripMenuItem.Name = "작업메뉴ToolStripMenuItem";
            this.작업메뉴ToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.작업메뉴ToolStripMenuItem.Text = "작업메뉴";
            // 
            // 인쇄ToolStripMenuItem
            // 
            this.인쇄ToolStripMenuItem.Name = "인쇄ToolStripMenuItem";
            this.인쇄ToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.인쇄ToolStripMenuItem.Text = "인쇄";
            // 
            // 엑셀로변환ToolStripMenuItem
            // 
            this.엑셀로변환ToolStripMenuItem.Name = "엑셀로변환ToolStripMenuItem";
            this.엑셀로변환ToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.엑셀로변환ToolStripMenuItem.Text = "엑셀로 변환";
            // 
            // 엑셀에서등록ToolStripMenuItem
            // 
            this.엑셀에서등록ToolStripMenuItem.Name = "엑셀에서등록ToolStripMenuItem";
            this.엑셀에서등록ToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.엑셀에서등록ToolStripMenuItem.Text = "엑셀에서 등록";
            // 
            // 일괄수정ToolStripMenuItem
            // 
            this.일괄수정ToolStripMenuItem.Name = "일괄수정ToolStripMenuItem";
            this.일괄수정ToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.일괄수정ToolStripMenuItem.Text = "일괄 수정";
            // 
            // 바코드출력ToolStripMenuItem
            // 
            this.바코드출력ToolStripMenuItem.Name = "바코드출력ToolStripMenuItem";
            this.바코드출력ToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.바코드출력ToolStripMenuItem.Text = "바코드 출력";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(25, 20);
            this.toolStripMenuItem1.Text = "||";
            // 
            // cmdGoodList
            // 
            this.cmdGoodList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.엑셀에서입력ToolStripMenuItem,
            this.엑셀로출력ToolStripMenuItem,
            this.프린터로출력ToolStripMenuItem,
            this.pDF로출력ToolStripMenuItem});
            this.cmdGoodList.Name = "cmdGoodList";
            this.cmdGoodList.Size = new System.Drawing.Size(151, 92);
            // 
            // 엑셀에서입력ToolStripMenuItem
            // 
            this.엑셀에서입력ToolStripMenuItem.Name = "엑셀에서입력ToolStripMenuItem";
            this.엑셀에서입력ToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.엑셀에서입력ToolStripMenuItem.Text = "엑셀에서 입력";
            // 
            // 엑셀로출력ToolStripMenuItem
            // 
            this.엑셀로출력ToolStripMenuItem.Name = "엑셀로출력ToolStripMenuItem";
            this.엑셀로출력ToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.엑셀로출력ToolStripMenuItem.Text = "엑셀로 출력";
            // 
            // 프린터로출력ToolStripMenuItem
            // 
            this.프린터로출력ToolStripMenuItem.Name = "프린터로출력ToolStripMenuItem";
            this.프린터로출력ToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.프린터로출력ToolStripMenuItem.Text = "프린터로 출력";
            // 
            // pDF로출력ToolStripMenuItem
            // 
            this.pDF로출력ToolStripMenuItem.Name = "pDF로출력ToolStripMenuItem";
            this.pDF로출력ToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.pDF로출력ToolStripMenuItem.Text = "PDF로 출력";
            // 
            // frmGoods
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(997, 729);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmGoods";
            this.Text = "frmGoods";
            this.Load += new System.EventHandler(this.frmGoods_Load);
            this.Controls.SetChildIndex(this.pnDetailView, 0);
            this.Controls.SetChildIndex(this.pnSearchConsole, 0);
            this.pnDetailView.ResumeLayout(false);
            this.pnSearchConsole.ResumeLayout(false);
            this.pnSearchConsole.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picGood)).EndInit();
            this.gboxBasicInfo.ResumeLayout(false);
            this.gboxBasicInfo.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.cmsSeller.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.cmdGoodList.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox picGood;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListBox lstbUnitCost;
        private System.Windows.Forms.GroupBox gboxBasicInfo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox lstbParts;
        private System.Windows.Forms.LinkLabel linkLabel5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ListBox lstbUnitsPolicy;
        private System.Windows.Forms.LinkLabel linkLabel4;
        private System.Windows.Forms.LinkLabel linkLabel3;
        private System.Windows.Forms.ComboBox ddlStatus;
        private System.Windows.Forms.TextBox txtProperStock;
        private System.Windows.Forms.TextBox txtMaker;
        private System.Windows.Forms.TextBox txtNickName;
        private System.Windows.Forms.TextBox txtSubname;
        private System.Windows.Forms.TextBox txtGoodName;
        private System.Windows.Forms.TextBox txtETC;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.ListBox lstbSeller;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.LinkLabel linkImagePath;
        private System.Windows.Forms.Button btnOut;
        private System.Windows.Forms.Button btnInput;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox ddlDetailViewMode;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.ContextMenuStrip cmsSeller;
        private System.Windows.Forms.ToolStripMenuItem 매입처에연락하기ToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 작업메뉴ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 인쇄ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 엑셀로변환ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 엑셀에서등록ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 일괄수정ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 바코드출력ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ContextMenuStrip cmdGoodList;
        private System.Windows.Forms.ToolStripMenuItem 엑셀에서입력ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 엑셀로출력ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 프린터로출력ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pDF로출력ToolStripMenuItem;
    }
}