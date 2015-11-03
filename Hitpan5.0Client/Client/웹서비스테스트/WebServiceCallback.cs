using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ServiceModel;
namespace 웹서비스테스트
{
    public class WebServiceCallback : ISQLWebServiceCallback
    {
        public void OnJobEnd(string message)
        {
            MessageBox.Show(message);
        }
    }
}
