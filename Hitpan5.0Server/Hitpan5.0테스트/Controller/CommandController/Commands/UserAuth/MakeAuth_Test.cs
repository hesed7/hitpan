using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Rhino.Mocks;
using libHitpan5;
using libHitpan5.Controller.CommandController.Commands._UserAuth;
using libHitpan5.VO;
using libHitpan5.Controller.CommandController.CommandListener.SettingControllers.MyInfoController;
using libHitpan5.Controller.CommandController.CommandListener.UserAuthController;
using libHitpan5.enums;
using libHitpan5.Controller.CommandController.CommandListener;
namespace libHitpan5_Test.Controller.CommandController.Commands.UserAuth
{
    [TestFixture]
    class MakeAuth_Test
    {
        [Test]
        public void execute_Test_정상적인_값을_파라미터로_주고_정상적으로_입력되는지() 
        {
            MockRepository mocks = new MockRepository();
            UserInfo data= mocks.Stub<UserInfo>();
            ICommandListener mockCommandListener= mocks.DynamicMock<UserAuthController>();
            MakeAuth MakeUserCommand = new MakeAuth(data, mockCommandListener);
            using (mocks.Record())
            {
                data.id = "id";
                data.password = "password";
                data.userAuth = "userAuth";
                data.userType = 사용자등급.일반사용자;
                mockCommandListener.Insert(data);
                LastCall.Return(true);
            }
            MakeUserCommand.execute();
            mocks.Verify(mockCommandListener);
        }
        [Test]
        [ExpectedException(typeof(AlreadyExsistedIDException))]
        public void execute_Test_기존에_입력된_ID와_중복된_ID인_경우_예외가_발생하는지()
        {
            //Arrange
            MockRepository mocks = new MockRepository();
            UserInfo data = mocks.Stub<UserInfo>();
            data.id = "id";
            data.password = "password";
            data.userAuth = "userAuth";
            ICommandListener mockCommandListener = mocks.DynamicMock<UserAuthController>();
            MakeAuth MakeUserCommand = new MakeAuth(data, mockCommandListener);
            MakeUserCommand.strIDList = new string[] { "id"};
            //Act
            MakeUserCommand.execute();
        }

        [TestCase("id","password",null)]
        [TestCase("id", null, "userAuth")]
        [TestCase(null, "password", "userAuth")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void execute_Test_입력할_ID_Password_User권한이_Null_일때_예외가_발생하는지(string id,string password,string userAuth)
        {
            //Arrange
            MockRepository mocks = new MockRepository();
            UserInfo data = mocks.Stub<UserInfo>();
            data.id = id;
            data.password = password;
            data.userAuth = userAuth;
            data.userType = 사용자등급.일반사용자;
            ICommandListener mockCommandListener = mocks.DynamicMock<UserAuthController>();
            MakeAuth MakeUserCommand = new MakeAuth(data, mockCommandListener);
            //Act
            MakeUserCommand.execute();
        }
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void execute_Test_생성자에_입력되는_파라미터가_Null인_경우__예외_발생_하는가()
        {
            //Arrange
            MockRepository mocks = new MockRepository();
            UserInfo data = null;
            ICommandListener mockCommandListener = mocks.DynamicMock<UserAuthController>();
            MakeAuth MakeUserCommand = new MakeAuth(data, mockCommandListener);
            //Act
            MakeUserCommand.execute();
        }


        [Test]
        public void Undo_Test_입력했던_파라미터_기록이_남아있는_경우()
        {
            MockRepository mocks = new MockRepository();
            UserInfo data = mocks.Stub<UserInfo>();
                     data.id = "id";
                     data.password = "password";
                     data.userAuth = "userAuth";
            ICommandListener mockCommandListener = mocks.DynamicMock<UserAuthController>();
            MakeAuth MakeUserCommand = new MakeAuth(data, mockCommandListener);
            using (mocks.Record())
            {
                mockCommandListener.Delete(data);
            }
            MakeUserCommand.Undo();
            mocks.Verify(mockCommandListener);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Undo_Test_입력했던_파라미터_기록이_없는_경우__Exception을_발생시키는가()
        {
            MockRepository mocks = new MockRepository();
            UserInfo data = mocks.Stub<UserInfo>();
            ICommandListener mockCommandListener = mocks.DynamicMock<UserAuthController>();
            MakeAuth MakeUserCommand = new MakeAuth(data, mockCommandListener);
            using (mocks.Record())
            {
                mockCommandListener.Delete(data);
            }
            MakeUserCommand.Undo();
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Undo_Test_입력했던_파라미터가_Null인_경우__Exception을_발생시키는가()
        {
            MockRepository mocks = new MockRepository();
            UserInfo data = null;
            ICommandListener mockCommandListener = mocks.DynamicMock<UserAuthController>();
            MakeAuth MakeUserCommand = new MakeAuth(data, mockCommandListener);
            using (mocks.Record())
            {
                mockCommandListener.Delete(data);
            }
            MakeUserCommand.Undo();
        }
    }
}
