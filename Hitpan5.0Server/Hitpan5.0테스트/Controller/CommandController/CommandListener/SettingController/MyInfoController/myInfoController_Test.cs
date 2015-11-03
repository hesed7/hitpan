using System;
using NUnit.Framework;
using Rhino.Mocks;
using libHitpan5.Controller.CommandController.CommandListener.SettingControllers.MyInfoController;
using libHitpan5.Model.DataModel;
using libHitpan5.VO;
using libHitpan5.Model.DataModel.DataQuery;
namespace Hitpan5_Test.Controller.CommandListener.SettingController.MyInfoController
{
    [TestFixture]
    public class myInfoController_Test
    {
        private myInfoController MyInfoController { get; set; }
        [SetUp]
        public void Setup() 
        {
            MockRepository mock = new MockRepository();
            IDataModel stubDb = mock.Stub<IDataModel>();
            IDataQueryRepository stubReposit = mock.Stub<IDataQueryRepository>();
            MyInfoController = new myInfoController(stubDb, stubReposit);            
        }
        [TearDown]
        public void TearDown() 
        {
            MyInfoController = null;
        }

        [Test]
        public void Insert_Test_True를반환하는지() 
        {
            //Arrange
            MockRepository mock = new MockRepository();
            myInfo mi = mock.Stub<myInfo>();
            //Act
            bool isOK= MyInfoController.Insert(mi);
            Assert.IsTrue(isOK);
        }
    }
}
