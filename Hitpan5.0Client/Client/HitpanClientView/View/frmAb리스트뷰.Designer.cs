namespace HitpanClientView.View.설정.상품관리.상품관리
{
    partial class frmAb리스트뷰
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAb리스트뷰));
            this.pnListView = new System.Windows.Forms.Panel();
            this.lvList = new System.Windows.Forms.ListView();
            this.pnPagingConsole = new System.Windows.Forms.Panel();
            this.pnPageLink = new System.Windows.Forms.Panel();
            this.pnDetailView = new System.Windows.Forms.Panel();
            this.picGood = new System.Windows.Forms.PictureBox();
            this.pnSearchConsole = new System.Windows.Forms.Panel();
            this.pnListView.SuspendLayout();
            this.pnPagingConsole.SuspendLayout();
            this.pnDetailView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picGood)).BeginInit();
            this.SuspendLayout();
            // 
            // pnListView
            // 
            this.pnListView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnListView.Controls.Add(this.lvList);
            this.pnListView.Location = new System.Drawing.Point(12, 61);
            this.pnListView.Name = "pnListView";
            this.pnListView.Size = new System.Drawing.Size(527, 576);
            this.pnListView.TabIndex = 0;
            // 
            // lvList
            // 
            this.lvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvList.Location = new System.Drawing.Point(0, 0);
            this.lvList.Name = "lvList";
            this.lvList.Size = new System.Drawing.Size(525, 574);
            this.lvList.TabIndex = 0;
            this.lvList.UseCompatibleStateImageBehavior = false;
            this.lvList.View = System.Windows.Forms.View.Details;
            this.lvList.SelectedIndexChanged += new System.EventHandler(this.lvList_SelectedIndexChanged);
            // 
            // pnPagingConsole
            // 
            this.pnPagingConsole.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnPagingConsole.Controls.Add(this.pnPageLink);
            this.pnPagingConsole.Location = new System.Drawing.Point(12, 643);
            this.pnPagingConsole.Name = "pnPagingConsole";
            this.pnPagingConsole.Size = new System.Drawing.Size(527, 53);
            this.pnPagingConsole.TabIndex = 1;
            // 
            // pnPageLink
            // 
            this.pnPageLink.AutoSize = true;
            this.pnPageLink.Location = new System.Drawing.Point(149, 7);
            this.pnPageLink.Name = "pnPageLink";
            this.pnPageLink.Size = new System.Drawing.Size(200, 23);
            this.pnPageLink.TabIndex = 2;
            // 
            // pnDetailView
            // 
            this.pnDetailView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnDetailView.Controls.Add(this.picGood);
            this.pnDetailView.Location = new System.Drawing.Point(546, 2);
            this.pnDetailView.Name = "pnDetailView";
            this.pnDetailView.Size = new System.Drawing.Size(565, 694);
            this.pnDetailView.TabIndex = 2;
            // 
            // picGood
            // 
            this.picGood.InitialImage = ((System.Drawing.Image)(resources.GetObject("picGood.InitialImage")));
            this.picGood.Location = new System.Drawing.Point(3, 9);
            this.picGood.Name = "picGood";
            this.picGood.Size = new System.Drawing.Size(168, 161);
            this.picGood.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picGood.TabIndex = 1;
            this.picGood.TabStop = false;
            // 
            // pnSearchConsole
            // 
            this.pnSearchConsole.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnSearchConsole.Location = new System.Drawing.Point(13, 2);
            this.pnSearchConsole.Name = "pnSearchConsole";
            this.pnSearchConsole.Size = new System.Drawing.Size(527, 53);
            this.pnSearchConsole.TabIndex = 2;
            // 
            // frmAb리스트뷰
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1123, 697);
            this.Controls.Add(this.pnSearchConsole);
            this.Controls.Add(this.pnDetailView);
            this.Controls.Add(this.pnPagingConsole);
            this.Controls.Add(this.pnListView);
            this.Name = "frmAb리스트뷰";
            this.pnListView.ResumeLayout(false);
            this.pnPagingConsole.ResumeLayout(false);
            this.pnPagingConsole.PerformLayout();
            this.pnDetailView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picGood)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnListView;
        private System.Windows.Forms.Panel pnPagingConsole;
        private System.Windows.Forms.PictureBox picGood;
        private System.Windows.Forms.ListView lvList;
        private System.Windows.Forms.Panel pnPageLink;
        protected System.Windows.Forms.Panel pnDetailView;
        protected System.Windows.Forms.Panel pnSearchConsole;
    }
}