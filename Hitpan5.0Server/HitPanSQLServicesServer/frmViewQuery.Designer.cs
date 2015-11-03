namespace HitPanSQLServicesServer
{
    partial class frmViewQuery
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmViewQuery));
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.gvQueryResult = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtQuery = new System.Windows.Forms.TextBox();
            this.tsQuery = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tslblServiceURL = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnViewResult = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnViewPlan = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnEnd = new System.Windows.Forms.ToolStripButton();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvQueryResult)).BeginInit();
            this.tsQuery.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainer1
            // 
            this.toolStripContainer1.BottomToolStripPanelVisible = false;
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.toolStripContainer1.ContentPanel.Controls.Add(this.gvQueryResult);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.label2);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.label1);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.txtQuery);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(1197, 628);
            this.toolStripContainer1.ContentPanel.Load += new System.EventHandler(this.toolStripContainer1_ContentPanel_Load);
            this.toolStripContainer1.ContentPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.toolStripContainer1_ContentPanel_MouseDown);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.LeftToolStripPanelVisible = false;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.RightToolStripPanelVisible = false;
            this.toolStripContainer1.Size = new System.Drawing.Size(1197, 653);
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.tsQuery);
            // 
            // gvQueryResult
            // 
            this.gvQueryResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvQueryResult.Location = new System.Drawing.Point(23, 218);
            this.gvQueryResult.Name = "gvQueryResult";
            this.gvQueryResult.RowTemplate.Height = 23;
            this.gvQueryResult.Size = new System.Drawing.Size(1143, 398);
            this.gvQueryResult.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 190);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "실행계획 및 결과 : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "쿼리 : ";
            // 
            // txtQuery
            // 
            this.txtQuery.Location = new System.Drawing.Point(21, 33);
            this.txtQuery.Multiline = true;
            this.txtQuery.Name = "txtQuery";
            this.txtQuery.Size = new System.Drawing.Size(1145, 119);
            this.txtQuery.TabIndex = 0;
            // 
            // tsQuery
            // 
            this.tsQuery.Dock = System.Windows.Forms.DockStyle.None;
            this.tsQuery.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.tslblServiceURL,
            this.toolStripSeparator1,
            this.tsbtnViewResult,
            this.toolStripSeparator2,
            this.tsbtnViewPlan,
            this.toolStripSeparator3,
            this.tsbtnEnd});
            this.tsQuery.Location = new System.Drawing.Point(3, 0);
            this.tsQuery.Name = "tsQuery";
            this.tsQuery.Size = new System.Drawing.Size(418, 25);
            this.tsQuery.TabIndex = 0;
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(71, 22);
            this.toolStripLabel1.Text = "서비스 URL:";
            // 
            // tslblServiceURL
            // 
            this.tslblServiceURL.Name = "tslblServiceURL";
            this.tslblServiceURL.Size = new System.Drawing.Size(88, 22);
            this.tslblServiceURL.Text = "tslblServiceURL";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbtnViewResult
            // 
            this.tsbtnViewResult.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtnViewResult.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnViewResult.Image")));
            this.tsbtnViewResult.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnViewResult.Name = "tsbtnViewResult";
            this.tsbtnViewResult.Size = new System.Drawing.Size(67, 22);
            this.tsbtnViewResult.Text = "쿼리 실행 ";
            this.tsbtnViewResult.Click += new System.EventHandler(this.tsbtnViewResult_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbtnViewPlan
            // 
            this.tsbtnViewPlan.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtnViewPlan.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnViewPlan.Image")));
            this.tsbtnViewPlan.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnViewPlan.Name = "tsbtnViewPlan";
            this.tsbtnViewPlan.Size = new System.Drawing.Size(115, 22);
            this.tsbtnViewPlan.Text = "쿼리 실행계획 보기";
            this.tsbtnViewPlan.Click += new System.EventHandler(this.tsbtnViewPlan_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbtnEnd
            // 
            this.tsbtnEnd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtnEnd.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnEnd.Image")));
            this.tsbtnEnd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnEnd.Name = "tsbtnEnd";
            this.tsbtnEnd.Size = new System.Drawing.Size(47, 22);
            this.tsbtnEnd.Text = "끝내기";
            this.tsbtnEnd.Click += new System.EventHandler(this.tsbtnEnd_Click);
            // 
            // frmViewQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1197, 653);
            this.Controls.Add(this.toolStripContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmViewQuery";
            this.Text = "frmViewQuery";
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.ContentPanel.PerformLayout();
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvQueryResult)).EndInit();
            this.tsQuery.ResumeLayout(false);
            this.tsQuery.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStrip tsQuery;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripLabel tslblServiceURL;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbtnViewResult;
        private System.Windows.Forms.ToolStripButton tsbtnViewPlan;
        private System.Windows.Forms.DataGridView gvQueryResult;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtQuery;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsbtnEnd;

    }
}