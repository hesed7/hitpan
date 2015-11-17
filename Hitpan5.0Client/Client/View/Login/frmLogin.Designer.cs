namespace HitpanClientView
{
    partial class frmLogin
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.txtUserPassword = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.pnLogin = new System.Windows.Forms.Panel();
            this.btnOut = new System.Windows.Forms.Button();
            this.chStoreServerInfo = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAuthKey = new System.Windows.Forms.TextBox();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.chSecurityMode = new System.Windows.Forms.CheckBox();
            this.pnLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(94, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password :";
            // 
            // txtUserID
            // 
            this.txtUserID.Location = new System.Drawing.Point(124, 69);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(116, 21);
            this.txtUserID.TabIndex = 2;
            // 
            // txtUserPassword
            // 
            this.txtUserPassword.Location = new System.Drawing.Point(124, 96);
            this.txtUserPassword.Name = "txtUserPassword";
            this.txtUserPassword.PasswordChar = '#';
            this.txtUserPassword.Size = new System.Drawing.Size(116, 21);
            this.txtUserPassword.TabIndex = 3;
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(124, 164);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(116, 25);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "로그인";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // pnLogin
            // 
            this.pnLogin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnLogin.Controls.Add(this.chSecurityMode);
            this.pnLogin.Controls.Add(this.btnOut);
            this.pnLogin.Controls.Add(this.chStoreServerInfo);
            this.pnLogin.Controls.Add(this.label3);
            this.pnLogin.Controls.Add(this.label4);
            this.pnLogin.Controls.Add(this.txtAuthKey);
            this.pnLogin.Controls.Add(this.txtURL);
            this.pnLogin.Controls.Add(this.label1);
            this.pnLogin.Controls.Add(this.btnLogin);
            this.pnLogin.Controls.Add(this.label2);
            this.pnLogin.Controls.Add(this.txtUserPassword);
            this.pnLogin.Controls.Add(this.txtUserID);
            this.pnLogin.Location = new System.Drawing.Point(12, 12);
            this.pnLogin.Name = "pnLogin";
            this.pnLogin.Size = new System.Drawing.Size(384, 209);
            this.pnLogin.TabIndex = 7;
            this.pnLogin.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnLogin_MouseDown);
            // 
            // btnOut
            // 
            this.btnOut.Location = new System.Drawing.Point(292, 164);
            this.btnOut.Name = "btnOut";
            this.btnOut.Size = new System.Drawing.Size(70, 25);
            this.btnOut.TabIndex = 10;
            this.btnOut.Text = "나가기";
            this.btnOut.UseVisualStyleBackColor = true;
            // 
            // chStoreServerInfo
            // 
            this.chStoreServerInfo.AutoSize = true;
            this.chStoreServerInfo.Location = new System.Drawing.Point(124, 123);
            this.chStoreServerInfo.Name = "chStoreServerInfo";
            this.chStoreServerInfo.Size = new System.Drawing.Size(160, 16);
            this.chStoreServerInfo.TabIndex = 9;
            this.chStoreServerInfo.Text = "서버 정보 및 아이디 저장";
            this.chStoreServerInfo.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "서비스 보안키 :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "Data서비스 주소 :";
            // 
            // txtAuthKey
            // 
            this.txtAuthKey.Location = new System.Drawing.Point(124, 42);
            this.txtAuthKey.Name = "txtAuthKey";
            this.txtAuthKey.PasswordChar = '*';
            this.txtAuthKey.Size = new System.Drawing.Size(116, 21);
            this.txtAuthKey.TabIndex = 6;
            // 
            // txtURL
            // 
            this.txtURL.Location = new System.Drawing.Point(124, 14);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(238, 21);
            this.txtURL.TabIndex = 5;
            this.txtURL.Text = "http://";
            // 
            // chSecurityMode
            // 
            this.chSecurityMode.AutoSize = true;
            this.chSecurityMode.Location = new System.Drawing.Point(124, 142);
            this.chSecurityMode.Name = "chSecurityMode";
            this.chSecurityMode.Size = new System.Drawing.Size(100, 16);
            this.chSecurityMode.TabIndex = 11;
            this.chSecurityMode.Text = "보안모드 사용";
            this.chSecurityMode.UseVisualStyleBackColor = true;
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 290);
            this.Controls.Add(this.pnLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmLogin";
            this.Text = "frmLogin";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmLogin_MouseDown);
            this.pnLogin.ResumeLayout(false);
            this.pnLogin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUserID;
        private System.Windows.Forms.TextBox txtUserPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Panel pnLogin;
        private System.Windows.Forms.CheckBox chStoreServerInfo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtAuthKey;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.Button btnOut;
        private System.Windows.Forms.CheckBox chSecurityMode;
    }
}