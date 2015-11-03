namespace DocumentInfoFileMaker
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnDocInfo = new System.Windows.Forms.Button();
            this.ddlPrinter = new System.Windows.Forms.ComboBox();
            this.btnDefaultRDLC = new System.Windows.Forms.Button();
            this.txtDataSet = new System.Windows.Forms.TextBox();
            this.btnMakeFile = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbtnMakeDocInfoFile = new System.Windows.Forms.RadioButton();
            this.rbtnAddRDLCFile = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDocInfoFileName = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "DocInfo파일 디렉토리 경로";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(99, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "프린터 이름";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(71, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = " RDLC 파일 경로";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(87, 173);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "데이터셋 이름";
            // 
            // btnDocInfo
            // 
            this.btnDocInfo.Location = new System.Drawing.Point(199, 81);
            this.btnDocInfo.Name = "btnDocInfo";
            this.btnDocInfo.Size = new System.Drawing.Size(209, 23);
            this.btnDocInfo.TabIndex = 4;
            this.btnDocInfo.Text = "DocInfo파일 경로";
            this.btnDocInfo.UseVisualStyleBackColor = true;
            this.btnDocInfo.Click += new System.EventHandler(this.btnDocInfo_Click);
            // 
            // ddlPrinter
            // 
            this.ddlPrinter.FormattingEnabled = true;
            this.ddlPrinter.Location = new System.Drawing.Point(199, 109);
            this.ddlPrinter.Name = "ddlPrinter";
            this.ddlPrinter.Size = new System.Drawing.Size(209, 20);
            this.ddlPrinter.TabIndex = 5;
            // 
            // btnDefaultRDLC
            // 
            this.btnDefaultRDLC.Location = new System.Drawing.Point(199, 136);
            this.btnDefaultRDLC.Name = "btnDefaultRDLC";
            this.btnDefaultRDLC.Size = new System.Drawing.Size(209, 23);
            this.btnDefaultRDLC.TabIndex = 6;
            this.btnDefaultRDLC.Text = "기본 RDLC파일 경로";
            this.btnDefaultRDLC.UseVisualStyleBackColor = true;
            this.btnDefaultRDLC.Click += new System.EventHandler(this.btnDefaultRDLC_Click);
            // 
            // txtDataSet
            // 
            this.txtDataSet.Location = new System.Drawing.Point(199, 164);
            this.txtDataSet.Name = "txtDataSet";
            this.txtDataSet.Size = new System.Drawing.Size(209, 21);
            this.txtDataSet.TabIndex = 7;
            // 
            // btnMakeFile
            // 
            this.btnMakeFile.Location = new System.Drawing.Point(199, 191);
            this.btnMakeFile.Name = "btnMakeFile";
            this.btnMakeFile.Size = new System.Drawing.Size(209, 23);
            this.btnMakeFile.TabIndex = 8;
            this.btnMakeFile.Text = "문서정보 파일 만들기";
            this.btnMakeFile.UseVisualStyleBackColor = true;
            this.btnMakeFile.Click += new System.EventHandler(this.btnMakeFile_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel1.Controls.Add(this.txtDocInfoFileName);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.rbtnAddRDLCFile);
            this.panel1.Controls.Add(this.rbtnMakeDocInfoFile);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnMakeFile);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtDataSet);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.btnDefaultRDLC);
            this.panel1.Controls.Add(this.btnDocInfo);
            this.panel1.Controls.Add(this.ddlPrinter);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(429, 232);
            this.panel1.TabIndex = 9;
            // 
            // rbtnMakeDocInfoFile
            // 
            this.rbtnMakeDocInfoFile.AutoSize = true;
            this.rbtnMakeDocInfoFile.Location = new System.Drawing.Point(39, 34);
            this.rbtnMakeDocInfoFile.Name = "rbtnMakeDocInfoFile";
            this.rbtnMakeDocInfoFile.Size = new System.Drawing.Size(129, 16);
            this.rbtnMakeDocInfoFile.TabIndex = 9;
            this.rbtnMakeDocInfoFile.TabStop = true;
            this.rbtnMakeDocInfoFile.Text = "DocInfo파일 만들기";
            this.rbtnMakeDocInfoFile.UseVisualStyleBackColor = true;
            this.rbtnMakeDocInfoFile.CheckedChanged += new System.EventHandler(this.rbtnMakeDocInfoFile_CheckedChanged);
            // 
            // rbtnAddRDLCFile
            // 
            this.rbtnAddRDLCFile.AutoSize = true;
            this.rbtnAddRDLCFile.Location = new System.Drawing.Point(199, 34);
            this.rbtnAddRDLCFile.Name = "rbtnAddRDLCFile";
            this.rbtnAddRDLCFile.Size = new System.Drawing.Size(131, 16);
            this.rbtnAddRDLCFile.TabIndex = 10;
            this.rbtnAddRDLCFile.TabStop = true;
            this.rbtnAddRDLCFile.Text = "RDLC파일 추가하기";
            this.rbtnAddRDLCFile.UseVisualStyleBackColor = true;
            this.rbtnAddRDLCFile.CheckedChanged += new System.EventHandler(this.rbtnAddRDLCFile_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(69, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 12);
            this.label5.TabIndex = 11;
            this.label5.Text = "DocInfo파일 이름";
            // 
            // txtDocInfoFileName
            // 
            this.txtDocInfoFileName.Location = new System.Drawing.Point(199, 56);
            this.txtDocInfoFileName.Name = "txtDocInfoFileName";
            this.txtDocInfoFileName.Size = new System.Drawing.Size(209, 21);
            this.txtDocInfoFileName.TabIndex = 12;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 499);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnDocInfo;
        private System.Windows.Forms.ComboBox ddlPrinter;
        private System.Windows.Forms.Button btnDefaultRDLC;
        private System.Windows.Forms.TextBox txtDataSet;
        private System.Windows.Forms.Button btnMakeFile;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rbtnAddRDLCFile;
        private System.Windows.Forms.RadioButton rbtnMakeDocInfoFile;
        private System.Windows.Forms.TextBox txtDocInfoFileName;
        private System.Windows.Forms.Label label5;
    }
}

