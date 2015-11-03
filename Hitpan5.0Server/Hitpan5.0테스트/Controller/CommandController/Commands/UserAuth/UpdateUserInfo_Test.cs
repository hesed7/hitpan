using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Rhino.Mocks;
using libHitpan5;
using libHitpan5.VO;
using libHitpan5.Controller.CommandController.CommandListener.SettingControllers.MyInfoController;
using libHitpan5.Controller.CommandController.CommandListener.UserAuthController;
using libHitpan5.Controller.CommandController.Commands._UserAuth;
using libHitpan5.Controller.CommandController.CommandListener;
namespace libHitpan5_Test.Controller.CommandController.Commands.UserAuth
{
    [TestFixture]
    class UpdateUserInfo_Test
    {
        [Test]
        public void execute_업데이트과정_정상적으로_거치는지_검증() 
        {
            MockRepository mocks = new MockRepository();
            UserInfo stubData = mocks.Stub<UserInfo>();
            stubData.id = "id";
            stubData.password = "password";
            ICommandListener mockListener = mocks.DynamicMock<UserAuthController>();
            UpdateUserInfo uui = new UpdateUserInfo(stubData, mockListener);
            using (mocks.Record())
            {
                mockListener.Select(stubData);
                mockListener.Update(stubData,stubData);
                LastCall.Return(true);
            }
            uui.execute();
            mocks.Verify(mockListener);
        }

        [Test]
        public void Undo_업데이트제거과정_정상적으로_거치는지_검증()
        {
            MockRepository mocks = new MockRepository();
            UserInfo stubData = mocks.Stub<UserInfo>();
            UserInfo stubPreData = mocks.Stub<UserInfo>();
            stubData.id = "id";
            stubData.password = "password";
            ICommandListener mockListener = mocks.DynamicMock<UserAuthController>();
            UpdateUserInfo uui = new UpdateUserInfo(stubData, mockListener);
            uui.preUserInfo = stubPreData;
            using (mocks.Record())
            {
                mockListener.Update(stubPreData, stubPreData);
                LastCall.Return(true);
            }
            uui.Undo();
            mocks.Verify(mockListener);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Undo_업데이트제거과정시에_업데이트_전의_데이터가_없는_경우()
        {
            //Arrange
            MockRepository mocks = new MockRepository();
            UserInfo stubData = mocks.Stub<UserInfo>();
            UserInfo stubPreData = null;
            stubData.id = "id";
            stubData.password = "password";
            ICommandListener mockListener = mocks.DynamicMock<UserAuthController>();
            UpdateUserInfo uui = new UpdateUserInfo(stubData, mockListener);
            uui.preUserInfo = stubPreData;
            //Act
            uui.Undo();
        }
    }
}
