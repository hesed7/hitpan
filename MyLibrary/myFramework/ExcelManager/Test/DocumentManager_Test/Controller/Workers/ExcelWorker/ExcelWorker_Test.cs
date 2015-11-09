using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentManager;
using DocumentManager.Controller.Workers.ExcelWorker;
using NUnit.Framework;
using Rhino.Mocks;
using System.IO;
using System.Data;
namespace DocumentManager_Test.Controller.Workers.ExcelWorker
{
    [TestFixture]
    class ExcelWorker_Test
    {
        [Test]
        public void WriteDocument_입력한_위치에_파일_생성_되는지()
        {
            //Arrange
            string filePath = Environment.CurrentDirectory + "\\test.xls";
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            DataTable data = new DataTable();
            data.Columns.Add("testvalue", typeof(string));
            data.Rows.Add(new string[] { "test" });
            //Act
            new DocumentManager.Controller.Workers.ExcelWorker.ExcelWorker().WriteDocument(data, filePath);
            bool isExist = File.Exists(filePath);
            //Assert
            Assert.IsTrue(isExist);
        }               
    }
}
