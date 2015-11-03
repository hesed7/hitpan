using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Rhino.Mocks;
using libHitpan5;
using libHitpan5.Controller.CommandController.Commands.CommonSetting.MyInfo;
using libHitpan5.Controller.CommandController.CommandListener.SettingControllers.MyInfoController;
using libHitpan5.Controller.CommandController.CommandListener;
namespace libHitpan5_Test.Controller.CommandController.Commands.CommonSetting.MyInfo
{
    [TestFixture]
    class MyInfoSelectCommand_Test
    {
        [Test]
        public void execute_Test_True를_반환하는가() 
        {
            //Arrange
            MockRepository mocks = new MockRepository();
            ICommandListener listener= mocks.DynamicMock<myInfoController>();
            MyInfoSelectCommand select = new MyInfoSelectCommand(listener);
            //Act
            object param = null;
            bool isOK = select.execute(out param);
            //Assert
            Assert.IsTrue(isOK);
        }
    }
}
