using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace myControls
{
    public partial class frmTabContainer : Form
    {
        public TabPage tabPage { get; set; }
        public TabControl tabParent { get; set; }
        public frmTabContainer(TabPage tabPage,TabControl tabParent)
        {
            InitializeComponent();
            this.tabPage = tabPage;
            this.tabParent = tabParent;
        }

        private void frmTabContainer_Load(object sender, EventArgs e)
        {
            tabCombine = false;
            this.Text = tabPage.Text;

            this.Size = tabPage.Controls[0].Size;
            this.Controls.Add(tabPage.Controls[0]);
            this.Controls[0].Dock = DockStyle.Fill;
            tabParent.Invoke(new MethodInvoker(delegate
            {
                tabParent.TabPages.Remove(tabPage);
            }));
        }

        private void frmTabContainer_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.tabPage.Controls.Count<=0)
            {
                this.tabPage.Controls.Add(this.Controls[0]);
            }
            tabParent.Invoke(new MethodInvoker(delegate {
                tabParent.TabPages.Add(tabPage);
            }));
        }

        public bool tabCombine { get; set; }
    }
}
