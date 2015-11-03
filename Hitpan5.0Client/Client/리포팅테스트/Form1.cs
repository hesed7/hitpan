using libHitpan5.Model.DocumentModel;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace 리포팅테스트
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: 이 코드는 데이터를 'AdventureWorksDataSet.Employee' 테이블에 로드합니다. 필요한 경우 이 코드를 이동하거나 제거할 수 있습니다.
            this.EmployeeTableAdapter.Fill(this.AdventureWorksDataSet.Employee);
            this.reportViewer1.RefreshReport();

            foreach (string print in new libHitpan5.Model.DocumentModel.PrinterModel().GetPrinterNameList())
            {
                comboBox1.Items.Add(print);
            }
            string defaultPrinter = new libHitpan5.Model.DocumentModel.PrinterModel().GetDefaultPrinterName();
            comboBox1.SelectedText = defaultPrinter;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            libHitpan5.Model.DocumentModel.ReportService rs = new libHitpan5.Model.DocumentModel.ReportService();
            rs.PDFWriter(Environment.GetFolderPath(Environment.SpecialFolder.CommonDesktopDirectory)+"\\test.pdf",reportViewer1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            libHitpan5.Model.DocumentModel.ReportService rs = new libHitpan5.Model.DocumentModel.ReportService();
            rs.WordWriter(Environment.GetFolderPath(Environment.SpecialFolder.CommonDesktopDirectory) + "\\test.rtf", reportViewer1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            libHitpan5.Model.DocumentModel.ReportService rs = new libHitpan5.Model.DocumentModel.ReportService();
            rs.ExcelWriter(Environment.GetFolderPath(Environment.SpecialFolder.CommonDesktopDirectory) + "\\test.xls", reportViewer1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ReportService rs = new ReportService();
            rs.Print(reportViewer1,comboBox1.Text);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            libHitpan5.Model.DocumentModel.ReportService rs = new libHitpan5.Model.DocumentModel.ReportService();
            rs.ImageWriter(Environment.GetFolderPath(Environment.SpecialFolder.CommonDesktopDirectory) + "\\test.jpg", reportViewer1);
        }


    }
}

            
        