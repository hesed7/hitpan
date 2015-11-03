using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HitpanClientView.View.설정.사용자설정.전자세금계산서
{
    public partial class frm전자세금계산서환경설정 : Form
    {
        private libHitpan5.Model.DataModel.IDataModel sqlserviceModel;

        public frm전자세금계산서환경설정()
        {
            InitializeComponent();
        }

        public frm전자세금계산서환경설정(libHitpan5.Model.DataModel.IDataModel sqlserviceModel)
        {
            // TODO: Complete member initialization
            this.sqlserviceModel = sqlserviceModel;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Dispose(true);
        }
    }
}
