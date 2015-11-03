using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using libHitpan5.Controller.DocumentController;
using System.IO;
namespace DocumentInfoFileMaker
{
    public partial class Form1 : Form
    {
        private string docInfoDIRPath { get; set; }
        private string DocInfoFileName { get; set; }
        private string RDLCFileName { get; set; }
        public Form1()
        {
            InitializeComponent();
            foreach (string strPrinter in new PrintController().GetPrinterList())
            {
                ddlPrinter.Items.Add(strPrinter);   
            }
            ddlPrinter.Text = new PrintController().GetDefaultPrinter();
        }

        private void rbtnMakeDocInfoFile_CheckedChanged(object sender, EventArgs e)
        {
            rbtnAddRDLCFile.Checked = !rbtnMakeDocInfoFile.Checked;
            btnDefaultRDLC.Text = "기본 RDLC파일 경로 ";
            btnMakeFile.Text = "문서정보파일 만들기";
        }

        private void rbtnAddRDLCFile_CheckedChanged(object sender, EventArgs e)
        {
            rbtnAddRDLCFile.Checked = !rbtnMakeDocInfoFile.Checked;
            btnDefaultRDLC.Text = "RDLC파일 경로 ";
            btnMakeFile.Text = "RDLC 파일정보 추가";
        }

        private void btnDocInfo_Click(object sender, EventArgs e)
        {
            if (rbtnMakeDocInfoFile.Checked)
            {
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    docInfoDIRPath = fbd.SelectedPath;
                } 
            }
            else
            {
                OpenFileDialog fbd = new OpenFileDialog();
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    docInfoDIRPath = fbd.FileName;
                    txtDocInfoFileName.Text = docInfoDIRPath;
                }
            }
            
        }

        private void btnDefaultRDLC_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog()==DialogResult.OK)
            {               
                int lastIndex= ofd.FileName.LastIndexOf("\\");
                int Length= ofd.FileName.Length-lastIndex;
                RDLCFileName= ofd.FileName.Substring(lastIndex, Length);
                RDLCFileName = RDLCFileName.Replace("\\",string.Empty);

                File.Copy(ofd.FileName,string.Format("{0}\\{1}", Environment.CurrentDirectory,RDLCFileName));
            }
        }

        private void btnMakeFile_Click(object sender, EventArgs e)
        {
            string DocFileName=
                string.Format("{0}\\{1}.docInfo",this.docInfoDIRPath,txtDocInfoFileName.Text); 
            if (rbtnMakeDocInfoFile.Checked)
            {

                new DocController().MakeDocumentInfoFile
                    (DocFileName, ddlPrinter.Text, this.RDLCFileName, txtDataSet.Text);
            }
            else
            {
                new DocController().AddRDLC(this.docInfoDIRPath, this.RDLCFileName, txtDataSet.Text);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

    }
}
