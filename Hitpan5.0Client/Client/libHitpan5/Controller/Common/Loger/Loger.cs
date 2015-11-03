using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace libHitpan5.Controller.Common.Loger
{
    class Loger
    {
        private Model.DataModel.IDataModel dataModel;

        public Loger(Model.DataModel.IDataModel dataModel)
        {
            // TODO: Complete member initialization
            this.dataModel = dataModel;
        }
        internal void WriteLog(string p)
        {
            MessageBox.Show(p);
        }
    }
}
