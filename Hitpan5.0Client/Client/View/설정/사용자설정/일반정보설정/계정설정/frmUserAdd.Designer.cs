namespace HitpanClientView.View.설정.사용자설정.일반정보설정.계정설정
{
    partial class frmUserAdd
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
            this.pnAddUser = new System.Windows.Forms.Panel();
            this.btnOut = new System.Windows.Forms.Button();
            this.btnInsertUpdate = new System.Windows.Forms.Button();
            this.ddlUserType = new System.Windows.Forms.ComboBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lvUserList = new System.Windows.Forms.ListView();
            this.colID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colUserType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ddl계정관리 = new System.Windows.Forms.ComboBox();
            this.ddl표준관리 = new System.Windows.Forms.ComboBox();
            this.ddl양식정보 = new System.Windows.Forms.ComboBox();
            this.ddl고객정보 = new System.Windows.Forms.ComboBox();
            this.ddl상품정보 = new System.Windows.Forms.ComboBox();
            this.ddl일정정보 = new System.Windows.Forms.ComboBox();
            this.ddl견적관리 = new System.Windows.Forms.ComboBox();
            this.ddl매입관리 = new System.Windows.Forms.ComboBox();
            this.ddl판매관리 = new System.Windows.Forms.ComboBox();
            this.ddl재고관리 = new System.Windows.Forms.ComboBox();
            this.ddl회계관리 = new System.Windows.Forms.ComboBox();
            this.ddl인사관리 = new System.Windows.Forms.ComboBox();
            this.ddl데이터관리 = new System.Windows.Forms.ComboBox();
            this.ddl나의정보관리 = new System.Windows.Forms.ComboBox();
            this.ddl세금계산서관리 = new System.Windows.Forms.ComboBox();
            this.ddl에프터서비스관리 = new System.Windows.Forms.ComboBox();
            this.linkInsertMode = new System.Windows.Forms.LinkLabel();
            this.pnAddUser.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnAddUser
            // 
            this.pnAddUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnAddUser.Controls.Add(this.linkInsertMode);
            this.pnAddUser.Controls.Add(this.btnOut);
            this.pnAddUser.Controls.Add(this.btnInsertUpdate);
            this.pnAddUser.Controls.Add(this.ddlUserType);
            this.pnAddUser.Controls.Add(this.txtPassword);
            this.pnAddUser.Controls.Add(this.txtID);
            this.pnAddUser.Controls.Add(this.groupBox1);
            this.pnAddUser.Controls.Add(this.lvUserList);
            this.pnAddUser.Controls.Add(this.label3);
            this.pnAddUser.Controls.Add(this.label2);
            this.pnAddUser.Controls.Add(this.label1);
            this.pnAddUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnAddUser.Location = new System.Drawing.Point(0, 0);
            this.pnAddUser.Name = "pnAddUser";
            this.pnAddUser.Size = new System.Drawing.Size(751, 677);
            this.pnAddUser.TabIndex = 0;
            this.pnAddUser.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnAddUser_MouseDown);
            // 
            // btnOut
            // 
            this.btnOut.Location = new System.Drawing.Point(610, 635);
            this.btnOut.Name = "btnOut";
            this.btnOut.Size = new System.Drawing.Size(124, 36);
            this.btnOut.TabIndex = 9;
            this.btnOut.Text = "나가기";
            this.btnOut.UseVisualStyleBackColor = true;
            this.btnOut.Click += new System.EventHandler(this.btnOut_Click);
            // 
            // btnInsertUpdate
            // 
            this.btnInsertUpdate.Location = new System.Drawing.Point(461, 636);
            this.btnInsertUpdate.Name = "btnInsertUpdate";
            this.btnInsertUpdate.Size = new System.Drawing.Size(131, 36);
            this.btnInsertUpdate.TabIndex = 8;
            this.btnInsertUpdate.Text = "입력/수정";
            this.btnInsertUpdate.UseVisualStyleBackColor = true;
            this.btnInsertUpdate.Click += new System.EventHandler(this.btnInsertUpdate_Click);
            // 
            // ddlUserType
            // 
            this.ddlUserType.FormattingEnabled = true;
            this.ddlUserType.Location = new System.Drawing.Point(467, 65);
            this.ddlUserType.Name = "ddlUserType";
            this.ddlUserType.Size = new System.Drawing.Size(267, 20);
            this.ddlUserType.TabIndex = 7;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(467, 32);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(267, 21);
            this.txtPassword.TabIndex = 6;
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(467, 5);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(267, 21);
            this.txtID.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.groupBox1.Controls.Add(this.ddl에프터서비스관리);
            this.groupBox1.Controls.Add(this.ddl세금계산서관리);
            this.groupBox1.Controls.Add(this.ddl나의정보관리);
            this.groupBox1.Controls.Add(this.ddl데이터관리);
            this.groupBox1.Controls.Add(this.ddl인사관리);
            this.groupBox1.Controls.Add(this.ddl회계관리);
            this.groupBox1.Controls.Add(this.ddl재고관리);
            this.groupBox1.Controls.Add(this.ddl판매관리);
            this.groupBox1.Controls.Add(this.ddl매입관리);
            this.groupBox1.Controls.Add(this.ddl견적관리);
            this.groupBox1.Controls.Add(this.ddl일정정보);
            this.groupBox1.Controls.Add(this.ddl상품정보);
            this.groupBox1.Controls.Add(this.ddl고객정보);
            this.groupBox1.Controls.Add(this.ddl양식정보);
            this.groupBox1.Controls.Add(this.ddl표준관리);
            this.groupBox1.Controls.Add(this.ddl계정관리);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(323, 104);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(411, 525);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "사용자 권한";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(6, 62);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(53, 12);
            this.label19.TabIndex = 18;
            this.label19.Text = "표준관리";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(6, 95);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(53, 12);
            this.label18.TabIndex = 17;
            this.label18.Text = "양식정보";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(6, 130);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(53, 12);
            this.label17.TabIndex = 16;
            this.label17.Text = "고객정보";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 172);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(53, 12);
            this.label16.TabIndex = 15;
            this.label16.Text = "상품정보";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 210);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(53, 12);
            this.label15.TabIndex = 14;
            this.label15.Text = "일정정보";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(7, 245);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 12);
            this.label14.TabIndex = 13;
            this.label14.Text = "견적관리";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 282);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 12);
            this.label13.TabIndex = 12;
            this.label13.Text = "매입관리";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 311);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 11;
            this.label12.Text = "판매관리";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 340);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 10;
            this.label11.Text = "재고관리";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 366);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 9;
            this.label10.Text = "회계관리";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 399);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 8;
            this.label9.Text = "인사관리";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 427);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 7;
            this.label8.Text = "데이터관리";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 454);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 12);
            this.label7.TabIndex = 6;
            this.label7.Text = "나의정보관리";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 479);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "세금계산서관리";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 510);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "에프터서비스관리";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "계정관리";
            // 
            // lvUserList
            // 
            this.lvUserList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colID,
            this.colUserType});
            this.lvUserList.GridLines = true;
            this.lvUserList.Location = new System.Drawing.Point(3, 3);
            this.lvUserList.Name = "lvUserList";
            this.lvUserList.Size = new System.Drawing.Size(312, 626);
            this.lvUserList.TabIndex = 3;
            this.lvUserList.UseCompatibleStateImageBehavior = false;
            this.lvUserList.View = System.Windows.Forms.View.Details;
            this.lvUserList.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lvUserList_MouseClick);
            // 
            // colID
            // 
            this.colID.Text = "사용자ID";
            this.colID.Width = 173;
            // 
            // colUserType
            // 
            this.colUserType.Text = "사용자등급";
            this.colUserType.Width = 118;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(321, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "사용자등급";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(320, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(321, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID";
            // 
            // ddl계정관리
            // 
            this.ddl계정관리.FormattingEnabled = true;
            this.ddl계정관리.Location = new System.Drawing.Point(138, 23);
            this.ddl계정관리.Name = "ddl계정관리";
            this.ddl계정관리.Size = new System.Drawing.Size(267, 20);
            this.ddl계정관리.TabIndex = 19;
            // 
            // ddl표준관리
            // 
            this.ddl표준관리.FormattingEnabled = true;
            this.ddl표준관리.Location = new System.Drawing.Point(138, 54);
            this.ddl표준관리.Name = "ddl표준관리";
            this.ddl표준관리.Size = new System.Drawing.Size(267, 20);
            this.ddl표준관리.TabIndex = 20;
            // 
            // ddl양식정보
            // 
            this.ddl양식정보.FormattingEnabled = true;
            this.ddl양식정보.Location = new System.Drawing.Point(138, 87);
            this.ddl양식정보.Name = "ddl양식정보";
            this.ddl양식정보.Size = new System.Drawing.Size(267, 20);
            this.ddl양식정보.TabIndex = 21;
            // 
            // ddl고객정보
            // 
            this.ddl고객정보.FormattingEnabled = true;
            this.ddl고객정보.Location = new System.Drawing.Point(138, 122);
            this.ddl고객정보.Name = "ddl고객정보";
            this.ddl고객정보.Size = new System.Drawing.Size(267, 20);
            this.ddl고객정보.TabIndex = 22;
            // 
            // ddl상품정보
            // 
            this.ddl상품정보.FormattingEnabled = true;
            this.ddl상품정보.Location = new System.Drawing.Point(138, 164);
            this.ddl상품정보.Name = "ddl상품정보";
            this.ddl상품정보.Size = new System.Drawing.Size(267, 20);
            this.ddl상품정보.TabIndex = 23;
            // 
            // ddl일정정보
            // 
            this.ddl일정정보.FormattingEnabled = true;
            this.ddl일정정보.Location = new System.Drawing.Point(138, 202);
            this.ddl일정정보.Name = "ddl일정정보";
            this.ddl일정정보.Size = new System.Drawing.Size(267, 20);
            this.ddl일정정보.TabIndex = 24;
            // 
            // ddl견적관리
            // 
            this.ddl견적관리.FormattingEnabled = true;
            this.ddl견적관리.Location = new System.Drawing.Point(138, 237);
            this.ddl견적관리.Name = "ddl견적관리";
            this.ddl견적관리.Size = new System.Drawing.Size(267, 20);
            this.ddl견적관리.TabIndex = 25;
            // 
            // ddl매입관리
            // 
            this.ddl매입관리.FormattingEnabled = true;
            this.ddl매입관리.Location = new System.Drawing.Point(138, 274);
            this.ddl매입관리.Name = "ddl매입관리";
            this.ddl매입관리.Size = new System.Drawing.Size(267, 20);
            this.ddl매입관리.TabIndex = 26;
            // 
            // ddl판매관리
            // 
            this.ddl판매관리.FormattingEnabled = true;
            this.ddl판매관리.Location = new System.Drawing.Point(138, 303);
            this.ddl판매관리.Name = "ddl판매관리";
            this.ddl판매관리.Size = new System.Drawing.Size(267, 20);
            this.ddl판매관리.TabIndex = 27;
            // 
            // ddl재고관리
            // 
            this.ddl재고관리.FormattingEnabled = true;
            this.ddl재고관리.Location = new System.Drawing.Point(138, 332);
            this.ddl재고관리.Name = "ddl재고관리";
            this.ddl재고관리.Size = new System.Drawing.Size(267, 20);
            this.ddl재고관리.TabIndex = 28;
            // 
            // ddl회계관리
            // 
            this.ddl회계관리.FormattingEnabled = true;
            this.ddl회계관리.Location = new System.Drawing.Point(138, 358);
            this.ddl회계관리.Name = "ddl회계관리";
            this.ddl회계관리.Size = new System.Drawing.Size(267, 20);
            this.ddl회계관리.TabIndex = 29;
            // 
            // ddl인사관리
            // 
            this.ddl인사관리.FormattingEnabled = true;
            this.ddl인사관리.Location = new System.Drawing.Point(138, 391);
            this.ddl인사관리.Name = "ddl인사관리";
            this.ddl인사관리.Size = new System.Drawing.Size(267, 20);
            this.ddl인사관리.TabIndex = 30;
            // 
            // ddl데이터관리
            // 
            this.ddl데이터관리.FormattingEnabled = true;
            this.ddl데이터관리.Location = new System.Drawing.Point(138, 419);
            this.ddl데이터관리.Name = "ddl데이터관리";
            this.ddl데이터관리.Size = new System.Drawing.Size(267, 20);
            this.ddl데이터관리.TabIndex = 31;
            // 
            // ddl나의정보관리
            // 
            this.ddl나의정보관리.FormattingEnabled = true;
            this.ddl나의정보관리.Location = new System.Drawing.Point(138, 446);
            this.ddl나의정보관리.Name = "ddl나의정보관리";
            this.ddl나의정보관리.Size = new System.Drawing.Size(267, 20);
            this.ddl나의정보관리.TabIndex = 32;
            // 
            // ddl세금계산서관리
            // 
            this.ddl세금계산서관리.FormattingEnabled = true;
            this.ddl세금계산서관리.Location = new System.Drawing.Point(138, 472);
            this.ddl세금계산서관리.Name = "ddl세금계산서관리";
            this.ddl세금계산서관리.Size = new System.Drawing.Size(267, 20);
            this.ddl세금계산서관리.TabIndex = 33;
            // 
            // ddl에프터서비스관리
            // 
            this.ddl에프터서비스관리.FormattingEnabled = true;
            this.ddl에프터서비스관리.Location = new System.Drawing.Point(138, 502);
            this.ddl에프터서비스관리.Name = "ddl에프터서비스관리";
            this.ddl에프터서비스관리.Size = new System.Drawing.Size(267, 20);
            this.ddl에프터서비스관리.TabIndex = 34;
            // 
            // linkInsertMode
            // 
            this.linkInsertMode.AutoSize = true;
            this.linkInsertMode.Location = new System.Drawing.Point(329, 655);
            this.linkInsertMode.Name = "linkInsertMode";
            this.linkInsertMode.Size = new System.Drawing.Size(93, 12);
            this.linkInsertMode.TabIndex = 10;
            this.linkInsertMode.TabStop = true;
            this.linkInsertMode.Text = "입력모드로 변경";
            this.linkInsertMode.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkInsertMode_LinkClicked);
            // 
            // frmUserAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 677);
            this.Controls.Add(this.pnAddUser);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmUserAdd";
            this.Text = "frmUserAdd";
            this.Load += new System.EventHandler(this.frmUserAdd_Load);
            this.pnAddUser.ResumeLayout(false);
            this.pnAddUser.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnAddUser;
        private System.Windows.Forms.ListView lvUserList;
        private System.Windows.Forms.ColumnHeader colID;
        private System.Windows.Forms.ColumnHeader colUserType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ddlUserType;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnInsertUpdate;
        private System.Windows.Forms.Button btnOut;
        private System.Windows.Forms.ComboBox ddl에프터서비스관리;
        private System.Windows.Forms.ComboBox ddl세금계산서관리;
        private System.Windows.Forms.ComboBox ddl나의정보관리;
        private System.Windows.Forms.ComboBox ddl데이터관리;
        private System.Windows.Forms.ComboBox ddl인사관리;
        private System.Windows.Forms.ComboBox ddl회계관리;
        private System.Windows.Forms.ComboBox ddl재고관리;
        private System.Windows.Forms.ComboBox ddl판매관리;
        private System.Windows.Forms.ComboBox ddl매입관리;
        private System.Windows.Forms.ComboBox ddl견적관리;
        private System.Windows.Forms.ComboBox ddl일정정보;
        private System.Windows.Forms.ComboBox ddl상품정보;
        private System.Windows.Forms.ComboBox ddl고객정보;
        private System.Windows.Forms.ComboBox ddl양식정보;
        private System.Windows.Forms.ComboBox ddl표준관리;
        private System.Windows.Forms.ComboBox ddl계정관리;
        private System.Windows.Forms.LinkLabel linkInsertMode;
    }
}