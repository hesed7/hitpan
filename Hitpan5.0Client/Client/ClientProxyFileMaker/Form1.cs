using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClientProxyFileMaker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            ProcessStartInfo psi = new ProcessStartInfo();
                             psi.WorkingDirectory = Environment.CurrentDirectory;
                             psi.Arguments = textBox1.Text;
                             psi.FileName = Environment.CurrentDirectory + "\\SvcUtil.exe";
            Process p = new Process();
            p.StartInfo=psi;
            if (p.Start())
            {
                p.WaitForExit();
                MessageBox.Show("프록시파일 생성!!");
            }
            else
            {
                MessageBox.Show("프록시파일 생성 실패");
            }
        }
    }
}
