using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Rhino.Mocks;
using libHitpan5;
using libHitpan5.Controller.CommandController.Commands._UserAuth;
using libHitpan5.Controller.CommandController.CommandListener.SettingControllers.MyInfoController;
using libHitpan5.Controller.CommandController.CommandListener.UserAuthController;
using libHitpan5.VO;
using libHitpan5.Model.DataModel;
using libHitpan5.Model.DataModel.DataQuery;
using libHitpan5.Controller.CommandController.CommandListener;
namespace libHitpan5_Test.Controller.CommandController.Commands.UserAuth
{
    [TestFixture]
    class Login_Test
    {
        [Test]
        public void execute_Test_정상적으로입력_Return_True() 
        {
            //Arrange  
            MockRepository mocks = new MockRepository();
            object uInfo = null;
            UserInfo LoginInfo=mocks.Stub<UserInfo>();
                     LoginInfo.id = "id";
                     LoginInfo.password = "password";
            ICommandListener mockCMDListener = mocks.DynamicMock<UserAuthController>();
            Login login = new Login(mockCMDListener, LoginInfo);
            using (mocks.Record())
            {
                mockCMDListener.Select(LoginInfo);
            }
            //Act
            bool isOK = login.execute(out uInfo);
            //Assert
            mocks.Verify(mockCMDListener);
        }

        [TestCase("","password")]
        [TestCase("id", "")]
        [TestCase(null, "password")]
        [TestCase("id", null)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void execute_Test_아이디_패스워드를_Null이나_빈값입력시_Exception발생하는지(string id,string password)
        {
            //Arrange
            MockRepository mocks = new MockRepository();
            object uInfo = null;
            UserInfo LoginInfo = mocks.Stub<UserInfo>();
                     LoginInfo.id = id;
                     LoginInfo.password = password;
            ICommandListener stubCMDListener = mocks.Stub<UserAuthController>();
            Login login = new Login(stubCMDListener,LoginInfo);
            //Act
            bool isOK = login.execute(out uInfo);
        }



        [Test]
        public void Undo_Test_정상적으로입력_Return_True()
        {
            //Arrange
            MockRepository mocks = new MockRepository();
            UserInfo uInfo = null;
            UserInfo LoginInfo = mocks.Stub<UserInfo>();
                     LoginInfo.id = "id";
            ICommandListener stubCMDListener = mocks.Stub<UserAuthController>();
            Login login = new Login(stubCMDListener,LoginInfo);
            //Act
            bool isOK = login.Undo(ref uInfo);
            //Assert
            Assert.IsNull(uInfo);
        }
    }
}
