using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Rhino.Mocks;
using libHitpan5;
using libHitpan5.Controller.CommandController.Commands.CommonSetting.WorkInfo;
using libHitpan5.Controller.CommandController.CommandListener.SettingControllers.MyInfoController;
using libHitpan5.Controller.CommandController.CommandListener.SettingControllers.CommonSettingController;
using libHitpan5.Model.DataModel;
using libHitpan5.Model.DataModel.DataQuery;
using libHitpan5.VO;
using libHitpan5.Controller.CommandController.CommandListener;
using System.ServiceModel;
namespace libHitpan5_Test.Controller.CommandController.Commands.CommonSetting.WorkInfo
{
    [TestFixture]
    class WorkInfoInsertUpdateCommand_Test
    {
        public MockRepository mocks { get; set; }
        public ICommandListener mocksCMDListener { get; set; }
        [SetUp]
        public void Setup() 
        {
            mocks = new MockRepository();
            SQLDataServiceModel dbModel = mocks.Stub<SQLDataServiceModel>();
                                dbModel.EncryptionSeed = "1234";
                                dbModel.sqlService = mocks.Stub<ISQLWebService>(mocks.Stub<InstanceContext>());
            SQLDataQueryRepository sqlQueryHouse = mocks.Stub<SQLDataQueryRepository>();
           
            LocalDataFileService LocalDataModel = mocks.Stub<LocalDataFileService>();
            IDataQueryRepository LocalQueryHouse= mocks.Stub<LocalDataQueryRepository>();
            object[] paramList= {dbModel,LocalDataModel,sqlQueryHouse,LocalQueryHouse};
            mocksCMDListener = mocks.DynamicMock<WorkInfoController>(paramList);
        }

        [Test]
        public void execute_Test_이미_설정값_존재시_올바른_값_입력받고_True반환() 
        {
            //Arrange
            CommonSettinginfo si = mocks.Stub<CommonSettinginfo>();
            si.CommonSettinginfo_DB = mocks.Stub<CommonSettinginfo_From_DB>();
            si.CommonSettinginfo_LocalFile = mocks.Stub<CommonSettinginfo_From_LocalFile>();
            WorkInfoInsertUpdateCommand cmd = new WorkInfoInsertUpdateCommand(this.mocksCMDListener, si);            

            //Act
            bool isOK= cmd.execute();
            //Assert
            Assert.IsTrue(isOK);
        }
        [Test]
        public void execute_Test_기존설정값_없을때_올바른_값_입력받고_True반환()
        {
            //Arrange
            CommonSettinginfo si = mocks.Stub<CommonSettinginfo>();
            si.CommonSettinginfo_DB = mocks.Stub<CommonSettinginfo_From_DB>();
            si.CommonSettinginfo_LocalFile = mocks.Stub<CommonSettinginfo_From_LocalFile>();
            WorkInfoInsertUpdateCommand cmd = new WorkInfoInsertUpdateCommand(this.mocksCMDListener, si);
            cmd.settingInfo = null;
            //Act
            bool isOK = cmd.execute();
            //Assert
            Assert.IsTrue(isOK);
        }
    }
}
