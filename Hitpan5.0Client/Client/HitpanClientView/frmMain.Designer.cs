namespace HitpanClientView
{
    partial class frmMain
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.설ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.사용자설ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.일반정보설정ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.관리정보설정ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.양식정보설정ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.전자세금계산서설정ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.초기잔액이월ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.상품관리ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.상품관리ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.세트설정분해조립ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.설ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(953, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 설ToolStripMenuItem
            // 
            this.설ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.사용자설ToolStripMenuItem,
            this.toolStripSeparator2,
            this.상품관리ToolStripMenuItem});
            this.설ToolStripMenuItem.Name = "설ToolStripMenuItem";
            this.설ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.설ToolStripMenuItem.Text = "설정";
            // 
            // 사용자설ToolStripMenuItem
            // 
            this.사용자설ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.일반정보설정ToolStripMenuItem,
            this.관리정보설정ToolStripMenuItem,
            this.양식정보설정ToolStripMenuItem,
            this.toolStripSeparator1,
            this.전자세금계산서설정ToolStripMenuItem,
            this.초기잔액이월ToolStripMenuItem});
            this.사용자설ToolStripMenuItem.Name = "사용자설ToolStripMenuItem";
            this.사용자설ToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.사용자설ToolStripMenuItem.Text = "사용자설정";
            // 
            // 일반정보설정ToolStripMenuItem
            // 
            this.일반정보설정ToolStripMenuItem.Name = "일반정보설정ToolStripMenuItem";
            this.일반정보설정ToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.일반정보설정ToolStripMenuItem.Text = "일반정보설정";
            this.일반정보설정ToolStripMenuItem.Click += new System.EventHandler(this.일반정보설정ToolStripMenuItem_Click);
            // 
            // 관리정보설정ToolStripMenuItem
            // 
            this.관리정보설정ToolStripMenuItem.Name = "관리정보설정ToolStripMenuItem";
            this.관리정보설정ToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.관리정보설정ToolStripMenuItem.Text = "관리정보설정";
            this.관리정보설정ToolStripMenuItem.Click += new System.EventHandler(this.관리정보설정ToolStripMenuItem_Click);
            // 
            // 양식정보설정ToolStripMenuItem
            // 
            this.양식정보설정ToolStripMenuItem.Name = "양식정보설정ToolStripMenuItem";
            this.양식정보설정ToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.양식정보설정ToolStripMenuItem.Text = "양식정보설정";
            this.양식정보설정ToolStripMenuItem.Click += new System.EventHandler(this.양식정보설정ToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(183, 6);
            // 
            // 전자세금계산서설정ToolStripMenuItem
            // 
            this.전자세금계산서설정ToolStripMenuItem.Name = "전자세금계산서설정ToolStripMenuItem";
            this.전자세금계산서설정ToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.전자세금계산서설정ToolStripMenuItem.Text = "전자세금계산서 설정";
            this.전자세금계산서설정ToolStripMenuItem.Click += new System.EventHandler(this.전자세금계산서설정ToolStripMenuItem_Click);
            // 
            // 초기잔액이월ToolStripMenuItem
            // 
            this.초기잔액이월ToolStripMenuItem.Name = "초기잔액이월ToolStripMenuItem";
            this.초기잔액이월ToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.초기잔액이월ToolStripMenuItem.Text = "초기잔액 이월";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(131, 6);
            // 
            // 상품관리ToolStripMenuItem
            // 
            this.상품관리ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.상품관리ToolStripMenuItem1,
            this.세트설정분해조립ToolStripMenuItem});
            this.상품관리ToolStripMenuItem.Name = "상품관리ToolStripMenuItem";
            this.상품관리ToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.상품관리ToolStripMenuItem.Text = "상품관리";
            // 
            // 상품관리ToolStripMenuItem1
            // 
            this.상품관리ToolStripMenuItem1.Name = "상품관리ToolStripMenuItem1";
            this.상품관리ToolStripMenuItem1.Size = new System.Drawing.Size(178, 22);
            this.상품관리ToolStripMenuItem1.Text = "상품관리";
            this.상품관리ToolStripMenuItem1.Click += new System.EventHandler(this.상품관리ToolStripMenuItem1_Click);
            // 
            // 세트설정분해조립ToolStripMenuItem
            // 
            this.세트설정분해조립ToolStripMenuItem.Name = "세트설정분해조립ToolStripMenuItem";
            this.세트설정분해조립ToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.세트설정분해조립ToolStripMenuItem.Text = "세트설정(분해조립)";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(953, 613);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "frmMain";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 설ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 사용자설ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 일반정보설정ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 관리정보설정ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 양식정보설정ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem 전자세금계산서설정ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 초기잔액이월ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem 상품관리ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 상품관리ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 세트설정분해조립ToolStripMenuItem;
    }
}

