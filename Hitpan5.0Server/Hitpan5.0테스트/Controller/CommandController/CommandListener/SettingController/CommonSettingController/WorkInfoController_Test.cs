using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Rhino.Mocks;
using libHitpan5.Model.DataModel;
using libHitpan5.Controller.CommandController.CommandListener.SettingControllers.CommonSettingController;
using libHitpan5.VO;
using libHitpan5.enums;
using libHitpan5.Model.DataModel.DataQuery;
using System.Data.Sql;
using System.Data;
using System.ServiceModel;
namespace Hitpan5_Test.Controller.CommandListener.SettingController.CommonSettingController
{
    [TestFixture]
    class WorkInfoController_Test
    {
        public MockRepository mocks { get; set; }
        public IDataModel dbModel { get; set; }
        public IDataQueryRepository sqlQueryHouse { get; set; }
        public IDataModel LocalModel { get; set; }
        public IDataQueryRepository LocalQueryHouse { get; set; }
        public WorkInfoController objectForTest { get; set; }
        [SetUp]
        public void SetUp() 
        {
            mocks = new MockRepository();
            SQLDataServiceModel dbModel = mocks.DynamicMock<SQLDataServiceModel>();
            dbModel.sqlService = mocks.Stub<ISQLWebService>(mocks.Stub<InstanceContext>());
            dbModel.EncryptionSeed = "1234";
            this.dbModel = dbModel;

            this.sqlQueryHouse = mocks.Stub<SQLDataQueryRepository>();
            
            this.LocalModel = mocks.DynamicMock<LocalDataFileService>();

            this.LocalQueryHouse = mocks.Stub<LocalDataQueryRepository>();

            this.objectForTest = new WorkInfoController(dbModel,LocalModel,sqlQueryHouse,LocalQueryHouse);
        }
        #region 인서트
        [Test]
        public void Insert_Test_올바른_값_입력시에_올바르게_작동하는지()
        {
            CommonSettinginfo_From_DB si_db = new CommonSettinginfo_From_DB();
            CommonSettinginfo_From_LocalFile si_local = new CommonSettinginfo_From_LocalFile();
            CommonSettinginfo si = mocks.Stub<CommonSettinginfo>();            
            si.CommonSettinginfo_DB = si_db;
            si.CommonSettinginfo_LocalFile = si_local;
            using (mocks.Record())
            {
                string SQLQuery = sqlQueryHouse.insertSettingInfo(si);
                dbModel.SetData(SQLQuery);
                string LocalQuery = LocalQueryHouse.insertSettingInfo(si);
                LocalModel.SetData(LocalQuery);
            }
            objectForTest.Insert(si);
            mocks.VerifyAll();
        }

        [Test]
        public void Insert_Test_CommonSettinginfo_From_LocalFile만_Null로_입력시에_CommonSettinginfo_From_DB만_입력_하는지()
        {
            CommonSettinginfo si = mocks.Stub<CommonSettinginfo>();
            si.CommonSettinginfo_LocalFile = null;
            si.CommonSettinginfo_DB = new CommonSettinginfo_From_DB();
            using (mocks.Record())
            {
                string sqlQuery = sqlQueryHouse.insertSettingInfo(si);
                dbModel.SetData(sqlQuery);
            }
            objectForTest.Insert(si);
            mocks.VerifyAll();
        }
        [Test]
        public void Insert_Test_CommonSettinginfo_From_LocalFile만_Null로_입력시에_True반환하는지()
        {
            CommonSettinginfo si = mocks.Stub<CommonSettinginfo>();
            si.CommonSettinginfo_LocalFile = null;
            si.CommonSettinginfo_DB = new CommonSettinginfo_From_DB();
            bool isOK = objectForTest.Insert(si);
            Assert.IsTrue(isOK);
        }

        [Test]
        public void Insert_Test_CommonSettinginfo_From_DB만_Null로_입력시에_CommonSettinginfo_From_LocalFile만_입력_하는지()
        {
            CommonSettinginfo si = mocks.Stub<CommonSettinginfo>();
            si.CommonSettinginfo_DB = null;
            si.CommonSettinginfo_LocalFile = new CommonSettinginfo_From_LocalFile();
            using (mocks.Record())
            {
                string LocalQuery = LocalQueryHouse.insertSettingInfo(si);
                LocalModel.SetData(LocalQuery);
            }
            objectForTest.Insert(si);
            mocks.VerifyAll();
        }
        [Test]
        public void Insert_Test_CommonSettinginfo_From_DB만_Null로_입력시에_True반환하는지()
        {
            CommonSettinginfo si = mocks.Stub<CommonSettinginfo>();
            si.CommonSettinginfo_LocalFile = new CommonSettinginfo_From_LocalFile();
            si.CommonSettinginfo_DB = null;
            bool isOK = objectForTest.Insert(si);
            Assert.IsTrue(isOK);
        }
        [Test]
        public void Insert_Test_CommonSettinginfo_From_DB를_포함해서_모든_파라미터를_Null로_입력시에_false반환하는지()
        {
            //Arrange
            CommonSettinginfo si = mocks.Stub<CommonSettinginfo>();
            si.CommonSettinginfo_LocalFile = null;
            si.CommonSettinginfo_DB = null;
            //act
            bool isOK = objectForTest.Insert(si);
            //Assert
            Assert.IsFalse(isOK);
        }

        [Test]
        public void Insert_Test_모든_파라미터를_Null로_입력시에_false반환하는지()
        {
            //Arrange
            CommonSettinginfo si = null;
            //act
            bool isOK = objectForTest.Insert(si);
            //Assert
            Assert.IsFalse(isOK);
        } 
        #endregion
        #region 업데이트
        [Test]
        public void Update_Test_정상적인_값_입력하고_정상적인_과정_거치는지()
        {
            CommonSettinginfo si= mocks.Stub<CommonSettinginfo>();
            si.CommonSettinginfo_DB = new CommonSettinginfo_From_DB();
            si.CommonSettinginfo_LocalFile = new CommonSettinginfo_From_LocalFile();
            using (mocks.Record())
            {
                string strSQLQuery = sqlQueryHouse.updateSettingInfo(si);
                dbModel.SetData(strSQLQuery);
                string strLocalQuery = LocalQueryHouse.updateSettingInfo(si);
                LocalModel.SetData(strLocalQuery);
            }
            objectForTest.Update(si,null);
            mocks.VerifyAll();
        }
        [Test]
        public void Update_Test_정상적인_값_입력하고_True반환_하는지() 
        {
            //Arrange
            CommonSettinginfo si = mocks.Stub<CommonSettinginfo>();
            si.CommonSettinginfo_DB = new CommonSettinginfo_From_DB();
            si.CommonSettinginfo_LocalFile = new CommonSettinginfo_From_LocalFile();
            //Act
            bool isOK= objectForTest.Update(si, null);
            //Assert
            Assert.IsTrue(isOK);      
        }
        [Test]
        public void Update_Test_CommonSettinginfo_From_DB만Null인_경우_true반환하는지()
        {
            //Arrange
            CommonSettinginfo si = mocks.Stub<CommonSettinginfo>();
            si.CommonSettinginfo_LocalFile = new CommonSettinginfo_From_LocalFile();
            //Act
            bool isOK = objectForTest.Update(si, null);
            //Assert
            Assert.IsTrue(isOK);
        }
        [Test]
        public void Update_Test_CommonSettinginfo_From_LocalFile만Null인_경우_true반환하는지()
        {
            //Arrange
            CommonSettinginfo si = mocks.Stub<CommonSettinginfo>();
            si.CommonSettinginfo_DB = new CommonSettinginfo_From_DB();
            //Act
            bool isOK = objectForTest.Update(si, null);
            //Assert
            Assert.IsTrue(isOK);
        }
        [Test]
        public void Update_Test_모두Null인_경우_false반환하는지()
        {
            //Arrange
            CommonSettinginfo si = mocks.Stub<CommonSettinginfo>();
            //Act
            bool isOK = objectForTest.Update(si, null);
            //Assert
            Assert.IsFalse(isOK);
        }
        [Test]
        public void Update_Test_CommonSettinginfo가_Null인_경우_false반환하는지()
        {
            //Arrange
            CommonSettinginfo si = null;
            //Act
            bool isOK = objectForTest.Update(si, null);
            //Assert
            Assert.IsFalse(isOK);
        }
        #endregion
        #region 셀렉트
        [Test]
        public void Select_Test_정상적인_과정을_거쳐서_검색하는지() 
        {
            using (mocks.Record())
            {
                string strSQLQuery = sqlQueryHouse.selectSettingInfo();
                dbModel.GetData(strSQLQuery);
                string strLocalQuery = LocalQueryHouse.selectSettingInfo();
                LocalModel.GetData(strLocalQuery);
            }
            objectForTest.Select();
            mocks.VerifyAll();
        }
        #endregion
        #region 델리트
        [Test]
        public void Delete_Test_삭제과정을_제대로_거치는지() 
        {
            using (mocks.Record())
            {
                string query = sqlQueryHouse.DeleteSettingInfo();
                dbModel.SetData(query);                
            }
            objectForTest.Delete();
            mocks.Verify(dbModel);
        }
        #endregion
    }
}
