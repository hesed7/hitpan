namespace HitpanClientView.View.설정.사용자설정.관리정보설정
{
    partial class frm관리정보설정
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
            this.pnConfig = new System.Windows.Forms.Panel();
            this.btnSetting = new System.Windows.Forms.Button();
            this.linkClose = new System.Windows.Forms.LinkLabel();
            this.pnSettings = new System.Windows.Forms.Panel();
            this.pnConfig.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnConfig
            // 
            this.pnConfig.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnConfig.Controls.Add(this.pnSettings);
            this.pnConfig.Controls.Add(this.btnSetting);
            this.pnConfig.Controls.Add(this.linkClose);
            this.pnConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnConfig.Location = new System.Drawing.Point(0, 0);
            this.pnConfig.Name = "pnConfig";
            this.pnConfig.Size = new System.Drawing.Size(413, 662);
            this.pnConfig.TabIndex = 0;
            this.pnConfig.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnConfig_MouseDown);
            // 
            // btnSetting
            // 
            this.btnSetting.Location = new System.Drawing.Point(12, 610);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Size = new System.Drawing.Size(384, 39);
            this.btnSetting.TabIndex = 2;
            this.btnSetting.Text = "세팅하기";
            this.btnSetting.UseVisualStyleBackColor = true;
            this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
            // 
            // linkClose
            // 
            this.linkClose.AutoSize = true;
            this.linkClose.Location = new System.Drawing.Point(367, 8);
            this.linkClose.Name = "linkClose";
            this.linkClose.Size = new System.Drawing.Size(29, 12);
            this.linkClose.TabIndex = 1;
            this.linkClose.TabStop = true;
            this.linkClose.Text = "닫기";
            this.linkClose.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkClose_LinkClicked);
            // 
            // pnSettings
            // 
            this.pnSettings.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnSettings.Location = new System.Drawing.Point(12, 31);
            this.pnSettings.Name = "pnSettings";
            this.pnSettings.Size = new System.Drawing.Size(384, 573);
            this.pnSettings.TabIndex = 3;
            // 
            // frm관리정보설정
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 662);
            this.Controls.Add(this.pnConfig);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm관리정보설정";
            this.Text = "관리정보설정";
            this.Load += new System.EventHandler(this.frm관리정보설정_Load);
            this.pnConfig.ResumeLayout(false);
            this.pnConfig.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnConfig;
        private System.Windows.Forms.LinkLabel linkClose;
        private System.Windows.Forms.Button btnSetting;
        private System.Windows.Forms.Panel pnSettings;
    }
}