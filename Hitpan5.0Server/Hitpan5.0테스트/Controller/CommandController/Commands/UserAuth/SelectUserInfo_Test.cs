using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Rhino.Mocks;
using libHitpan5;
using libHitpan5.Controller.CommandController.Commands._UserAuth;
using libHitpan5.Controller.CommandController.CommandListener.SettingControllers.MyInfoController;
using libHitpan5.Controller.CommandController.CommandListener.UserAuthController;
using libHitpan5.Model.DataModel;
using System.Data;
using System.ServiceModel;
namespace libHitpan5_Test.Controller.CommandController.Commands.UserAuth
{
    [TestFixture]
    class SelectUserInfo_Test
    {
        public MockRepository mocks { get; set; }
        public UserAuthController mockListener { get; set; }

        [SetUp]
        public void SetUp() 
        {
            mocks = new MockRepository();

            SQLDataServiceModel stubSQLlModel = mocks.Stub<SQLDataServiceModel>();
            stubSQLlModel.sqlService = mocks.Stub<ISQLWebService>(mocks.Stub<InstanceContext>());
                                stubSQLlModel.EncryptionSeed = "1234";

            mockListener = mocks.DynamicMock<UserAuthController>();
            mockListener.sqlDBManager = stubSQLlModel;
            mockListener.query = mocks.Stub<SQLDataQueryRepository>();        
        
        }
        [TearDown]
        public void TearDown() 
        {
            if (mocks!=null)
            {
                mocks = null;
            }
        }

        [Test]
        public void execute_Test_아이디를_포함한_정상적인_파라미터를_주고_정상적인_과정을_거치는지_검사() 
        {
            //[Arrange]

            //[Act]
            SelectUserInfo sui = new SelectUserInfo(mockListener, "id1");
            using (mocks.Record())
            {
                mockListener.Select("id1");
            }
            object dt=null;
            bool isOK= sui.execute(out dt);
            mocks.Verify(mockListener);
        }

        [Test]
        public void execute_Test_아이디를_Null로_준_경우_정상적인_과정을_거치는지_검사() 
        {
            SelectUserInfo sui = new SelectUserInfo(mockListener, null);
            using (mocks.Record())
            {
                mockListener.Select();
            }
            object dt = null;
            bool isOK = sui.execute(out dt);
            mocks.Verify(mockListener);
        }

        [Test]
        public void execute_Test_아이디를_빈값으로_준_경우_정상적인_과정을_거치는지_검사() 
        {
            SelectUserInfo sui = new SelectUserInfo(mockListener,string.Empty);
            using (mocks.Record())
            {
                mockListener.Select();
            }
            object obj= null;
            sui.execute(out obj);
            mocks.Verify(mockListener);
        }
    }
}
