using HitPanSQLServicesServer.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Specialized;
namespace HitPanSQLServicesServer
{
    public partial class frmViewQuery : Form
    {
        #region 마으스 드래그로 컨트롤 이동하기
        //마우스 드래그로 이동의 선언부
        const int WM_SYSCOMMAND = 0x0112;
        const int SC_FORMMOVE = 0xF012;
        [System.Runtime.InteropServices.DllImport("User32")]
        private static extern int ReleaseCapture();
        [System.Runtime.InteropServices.DllImport("User32")]
        private static extern int SendMessage(int hWnd, int hMsg, int wParam, int lParam);
        /// <summary>
        /// 사용법 : 
        /// 마우스 드래그로 이동시키고자 하는 컨트롤의 
        /// 마우스다운 이벤트에 넣고 
        /// 이동시키고자 하는 컨트롤객체를 매개변수로 준다 
        /// </summary>
        /// <param name="control"></param>
        private void MoveControl(Control control)
        {
            ReleaseCapture();
            SendMessage(control.Handle.ToInt32(), WM_SYSCOMMAND, SC_FORMMOVE, 0);
        }
        //사용 예:
        //private void frmREFFileDownloader_MouseDown(object sender, MouseEventArgs e)
        //{
        //    if (e.Button == MouseButtons.Left)
        //    {
        //        MoveControl(this);
        //    }
        //}
        #endregion
        private string serviceURL { get; set; }
        public frmViewQuery(string serviceURL)
        {
            InitializeComponent();
            this.serviceURL = serviceURL;
            tslblServiceURL.Text = serviceURL;
        }
        private void toolStripContainer1_ContentPanel_MouseDown(object sender, MouseEventArgs e)
        {
            MoveControl(this);
        }

        private void tsbtnViewResult_Click(object sender, EventArgs e)
        {
            if (gvQueryResult.Rows.Count>0)
            {
                foreach (DataGridViewRow dr in gvQueryResult.Rows)
                {
                    try
                    {
                        gvQueryResult.Rows.Remove(dr);
                    }
                    catch (ArgumentException)
                    {
                        continue;
                    }
                    catch (InvalidOperationException) 
                    {
                        continue;
                    }
                }
                
            }
            if (txtQuery.Text==null || txtQuery.Text==string.Empty)
            {
                MessageBox.Show("실행할 쿼리가 없습니다" );
                return;
            }
            if (txtQuery.Text.Replace(" ",string.Empty).Substring(0,6)!="select")
            {
                StringCollection sc = new StringCollection();
                sc.Add(txtQuery.Text);
                WebServiceServer.ServerMain.getInstance().SetData(serviceURL, sc);
            }
            else
            {
                DataTable dt = WebServiceServer.ServerMain.getInstance().GetLocalData(serviceURL, txtQuery.Text);
                gvQueryResult.DataSource = dt;               
            }
        }

        private void tsbtnViewPlan_Click(object sender, EventArgs e)
        {
            if (txtQuery.Text == null || txtQuery.Text == string.Empty)
            {
                MessageBox.Show("실행할 쿼리가 없습니다");
                return;
            }
            DataTable dt = WebServiceServer.ServerMain.getInstance().GetPlan(serviceURL,txtQuery.Text);
            gvQueryResult.DataSource = dt;
        }

        private void tsbtnEnd_Click(object sender, EventArgs e)
        {
            try
            {
                gvQueryResult.Dispose();
            }
            catch (ArgumentOutOfRangeException)
            {
                
            }
            tsQuery.Dispose();
            this.Dispose();
        } 

        //test
        public void ErrReporter(Exception ex) 
        {
            MessageBox.Show(ex.Message);
        }

        private void toolStripContainer1_ContentPanel_Load(object sender, EventArgs e)
        {

        }
        
    }
}
