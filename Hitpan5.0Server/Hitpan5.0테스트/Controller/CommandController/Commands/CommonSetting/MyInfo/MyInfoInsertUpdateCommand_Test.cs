using System;
using NUnit.Framework;
using Rhino.Mocks;
using libHitpan5;
using libHitpan5.Controller.CommandController.Commands.CommonSetting.MyInfo;
using libHitpan5.Controller.CommandController.CommandListener.SettingControllers.MyInfoController;
using libHitpan5.VO;
using libHitpan5.Controller.CommandController.CommandListener;
namespace Hitpan5_Test.Controller.CommandController.Commands
{
    [TestFixture]
    public class MyInfoInsertUpdateCommand_Test
    {
        #region execute테스트
        [Test]
        public void execute_기존에_입력된_정보가_하나도_없고_파라미터는_정상인_경우()
        {
            MockRepository mocks = new MockRepository();
            ICommandListener listener = mocks.DynamicMock<myInfoController>();
            myInfo myInfo = mocks.Stub<myInfo>();
            MyInfoInsertUpdateCommand myInfoCommand = new MyInfoInsertUpdateCommand(myInfo, listener);
            using (mocks.Record())
            {
                myInfoCommand.preMyInfo = null;
                listener.Insert(myInfo);
                LastCall.Return(true);
            }
            myInfoCommand.execute();
            mocks.Verify(listener);
        }




        [Test]
        public void execute_기존에_입력된_정보가_존재하고_파라미터는_정상인_경우()
        {
            MockRepository mocks = new MockRepository();
            ICommandListener listener = mocks.DynamicMock<myInfoController>();
            myInfo myInfo = mocks.Stub<myInfo>();
            MyInfoInsertUpdateCommand myInfoCommand = new MyInfoInsertUpdateCommand(myInfo, listener);
            using (mocks.Record())
            {
                listener.Select();
                myInfoCommand.preMyInfo = new myInfo();
                listener.Update(myInfo, null);
                LastCall.Return(true);
            }
            myInfoCommand.execute();
            mocks.Verify(listener);
        }
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void execute_기존에_입력된_정보가_존재하고_파라미터는_Null인_경우__Exception발생시키는지()
        {
            MockRepository mocks = new MockRepository();
            ICommandListener listener = mocks.DynamicMock<myInfoController>();
            myInfo myInfo = null;
            MyInfoInsertUpdateCommand myInfoCommand = new MyInfoInsertUpdateCommand(myInfo, listener);
            myInfoCommand.execute();
        } 
        #endregion
        #region UnDo() Test
        [Test]
        public void Undo_Test_기존에_입력된_내용이_없을때() 
        {
            MockRepository mocks= new MockRepository();
            ICommandListener listener= mocks.DynamicMock<myInfoController>();
            myInfo mi= mocks.Stub<myInfo>();
            MyInfoInsertUpdateCommand myIUCMD = new MyInfoInsertUpdateCommand(mi,listener);
            myIUCMD.preMyInfo = null;
            using(mocks.Record())
	        {
                listener.Delete(mi);
	        }
            myIUCMD.Undo();
            mocks.Verify(listener);
        }
        [Test]
        public void Undo_Test_기존에_입력된_내용이_있을때()
        {
            MockRepository mocks = new MockRepository();
            ICommandListener listener = mocks.DynamicMock<myInfoController>();
            myInfo mi = mocks.Stub<myInfo>();
            MyInfoInsertUpdateCommand myIUCMD = new MyInfoInsertUpdateCommand(mi, listener);
            myIUCMD.preMyInfo = new myInfo();
            using (mocks.Record())
            {
                listener.Delete(mi);
                listener.Insert(myIUCMD.preMyInfo);
                LastCall.Return(true);
            }
            myIUCMD.Undo();
            mocks.Verify(listener);
        }
        #endregion
    }
}
