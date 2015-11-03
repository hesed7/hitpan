using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Rhino.Mocks;
using libHitpan5;
using libHitpan5.Model.DocumentModel;
using Microsoft.Reporting.WinForms;
using System.Data;
namespace libHitpan5_Test.Model.DocumentModel
{
    [TestFixture]
    class ReportService_Test
    {

        //[Test]
        //public void ReportSetter_Test_리포트를_정상적으로_세팅하는지() 
        //{
        //    MockRepository mocks = new MockRepository();
        //    ReportService target = new ReportService();
        //    ReportViewer viewer = new ReportViewer();
        //    target.Viewer = viewer;
        //    string RDLCPath= Environment.CurrentDirectory+"\\test.rdlc";
        //    DataTable data= mocks.Stub<DataTable>();

        //    target.ReportSetter(RDLCPath,data);

        //    Assert.AreEqual(RDLCPath,target.Viewer.LocalReport.ReportPath);
        //    Assert.AreEqual(data.TableName,target.Viewer.LocalReport.DataSources[0].Name);
        //}
    }
}
