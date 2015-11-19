namespace HitpanClientView
{
    partial class frmNetwork
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
            this.btnLogin = new System.Windows.Forms.Button();
            this.pnLogin = new System.Windows.Forms.Panel();
            this.chSecurityMode = new System.Windows.Forms.CheckBox();
            this.btnOut = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAuthKey = new System.Windows.Forms.TextBox();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.pnLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(124, 80);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(116, 25);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "설정하기";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // pnLogin
            // 
            this.pnLogin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnLogin.Controls.Add(this.chSecurityMode);
            this.pnLogin.Controls.Add(this.btnOut);
            this.pnLogin.Controls.Add(this.label3);
            this.pnLogin.Controls.Add(this.label4);
            this.pnLogin.Controls.Add(this.txtAuthKey);
            this.pnLogin.Controls.Add(this.txtURL);
            this.pnLogin.Controls.Add(this.btnLogin);
            this.pnLogin.Location = new System.Drawing.Point(12, 12);
            this.pnLogin.Name = "pnLogin";
            this.pnLogin.Size = new System.Drawing.Size(378, 114);
            this.pnLogin.TabIndex = 7;
            this.pnLogin.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnLogin_MouseDown);
            // 
            // chSecurityMode
            // 
            this.chSecurityMode.AutoSize = true;
            this.chSecurityMode.Location = new System.Drawing.Point(262, 51);
            this.chSecurityMode.Name = "chSecurityMode";
            this.chSecurityMode.Size = new System.Drawing.Size(100, 16);
            this.chSecurityMode.TabIndex = 11;
            this.chSecurityMode.Text = "보안모드 사용";
            this.chSecurityMode.UseVisualStyleBackColor = true;
            // 
            // btnOut
            // 
            this.btnOut.Location = new System.Drawing.Point(246, 80);
            this.btnOut.Name = "btnOut";
            this.btnOut.Size = new System.Drawing.Size(116, 25);
            this.btnOut.TabIndex = 10;
            this.btnOut.Text = "나가기";
            this.btnOut.UseVisualStyleBackColor = true;
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
            // frmNetwork
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 138);
            this.Controls.Add(this.pnLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmNetwork";
            this.Text = "frmLogin";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmLogin_MouseDown);
            this.pnLogin.ResumeLayout(false);
            this.pnLogin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Panel pnLogin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtAuthKey;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.Button btnOut;
        private System.Windows.Forms.CheckBox chSecurityMode;
    }
}