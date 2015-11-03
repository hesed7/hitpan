using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Rhino.Mocks;
using libHitpan5.Controller.CommandController.Commands.CommonSetting.WorkInfo;
using libHitpan5.Model.DataModel;
using libHitpan5.Controller.CommandController.CommandListener.SettingControllers.MyInfoController;
using libHitpan5.Controller.CommandController.CommandListener.SettingControllers.CommonSettingController;
using libHitpan5.Model.DataModel.DataQuery;
using libHitpan5.Controller.CommandController.CommandListener;
using System.ServiceModel;
using System.ServiceModel.Description;
namespace libHitpan5_Test.Controller.CommandController.Commands.CommonSetting.WorkInfo
{
    [TestFixture]
    class WorkInfoSelectCommand_Test
    {
        [Test]
        public void execute_Out타입_파라미터_있는_메서드_Test_정상적으로_로직_실행_하는지() 
        {
            MockRepository mocks = new MockRepository();

            InstanceContext ClientCallback = mocks.Stub<InstanceContext>();
            ISQLWebService stubService     = mocks.Stub<SQLWebServiceClient>(new object[] {ClientCallback});
            IDataModel dbModel             = mocks.Stub<SQLDataServiceModel>();
            ((SQLDataServiceModel)dbModel).sqlService = stubService;
            ((SQLDataServiceModel)dbModel).EncryptionSeed = "1234";
            IDataQueryRepository SQLQueryHouse= mocks.Stub<SQLDataQueryRepository>();
            IDataModel localDataModel = mocks.Stub<LocalDataFileService>();

            IDataQueryRepository localQueryHouse = mocks.Stub<LocalDataQueryRepository>();
            object[] paramList = { dbModel,localDataModel,SQLQueryHouse,localQueryHouse};
            ICommandListener mockCMDListener = mocks.Stub<WorkInfoController>(paramList);
            WorkInfoSelectCommand selectCommand = new WorkInfoSelectCommand(mockCMDListener);
            object returnValue = new object();
            using (mocks.Record())
            {
                selectCommand.execute(out returnValue);
            }
            mocks.Verify(mockCMDListener);
        }
    }
}
