using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Rhino.Mocks;
using libHitpan5;
using libHitpan5.Controller.CommandController;
using libHitpan5.Controller.CommandController.CommandListener;
using libHitpan5.Model.DataModel;
using libHitpan5.Model.DataModel.DataQuery;
using libHitpan5.VO;
using libHitpan5.Controller.CommandController.CommandListener.UserAuthController;
using libHitpan5.Controller.CommandController.Commands.CommonSetting.WorkInfo;
using libHitpan5.Controller.CommandController.CommandListener.SettingControllers.CommonSettingController;
using System.ServiceModel;
namespace Hitpan5_Test.Controller.CommandController.Commands
{
    [TestFixture]
    class CMDManager_Test
    {
        public MockRepository mocks { get; set; }
        public SQLDataServiceModel dataModel { get; set; }
        public SQLDataQueryRepository queryHouse { get; set; }
        public LocalDataFileService LocalDataModel { get; set; }
        public LocalDataQueryRepository LocalDataQuery { get; set; }
        public LogController Loger { get; set; }
        public WorkInfoSelectCommand workInfoSelectCMD { get; set; }
        public CMDManager cmdManager { get; set; }

        [SetUp]
        public void SetUp() 
        {
            this.mocks = new MockRepository();


            this.LocalDataModel = mocks.Stub<LocalDataFileService>();
            this.LocalDataQuery = mocks.Stub<LocalDataQueryRepository>();
            this.dataModel = mocks.Stub<SQLDataServiceModel>();
            dataModel.sqlService = mocks.Stub<ISQLWebService>(mocks.Stub<InstanceContext>());
                 dataModel.EncryptionSeed="1234";
            this.queryHouse = mocks.Stub<SQLDataQueryRepository>();


            this.Loger = mocks.Stub<LogController>();
                 Loger.DB = dataModel;
                 Loger.SQLQueryHouse = queryHouse;

            object[] paramList = { this.dataModel, this.LocalDataModel, this.queryHouse,this.LocalDataQuery };
            WorkInfoController workInfoCMDListener = mocks.Stub<WorkInfoController>(paramList);
            this.workInfoSelectCMD = mocks.Stub<WorkInfoSelectCommand>(workInfoCMDListener);

            this.cmdManager = CMDManager.getInstance(this.Loger,this.workInfoSelectCMD);
            this.cmdManager.userInfo = mocks.Stub<UserInfo>();
        }



        [TestCase("","password")]
        [TestCase("id", "")]
        [TestCase(null, "password")]
        [TestCase("id", null)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void LoginService_아이디나_패스워드가_Null이나_빈값인_경우_Exception발생_시키는지(string id,string password) 
        {
            //Arrange
            UserAuthController stubUserInfoWorker = mocks.Stub<UserAuthController>();
            //Act
            this.cmdManager.LoginService(id, password, stubUserInfoWorker);
        }
        [Test]
        public void LoginService_아이디나_패스워드가_정상값인_경우_정상적인_작동을_하는지()
        {
            //Arrange

            // 사용자계정 관련된 커맨드리스너
            UserAuthController stubUserInfoWorker = mocks.Stub<UserAuthController>();
            //Act
            object ui = this.cmdManager.LoginService("id", "password", stubUserInfoWorker);
            //Assert
            Assert.NotNull(ui);
        }
        [Test]
        public void Do_ref형_파라미터_없는_메서드가_정상적인_상태에서_정상적으로_작동을_하는지_검증() 
        {
            //Arrange
            //[3] ICMD 구성
            ICMD stubCMD = mocks.Stub<ICMD>();
            this.Loger = mocks.DynamicMock<LogController>();
            Loger.DB = this.dataModel;
            Loger.SQLQueryHouse=this.queryHouse;

            UserInfo ui= new UserInfo();
            ui.id="id";
            this.cmdManager.userInfo = ui;
            using (mocks.Record())
            {                
                string log = string.Format("{0} 성공", stubCMD.description);
                this.Loger.WriteLog(stubCMD.logType, ui.id, log);
            }
            this.cmdManager.Do(stubCMD);
            mocks.Verify(this.Loger);
        }
        [Test]
        [ExpectedException(typeof(NotLoginException))]
        public void Do_ref형_파라미터_없는_메서드가_로그인_안한_상태에서_Exception을_발생_시키는지() 
        {
            ICMD stubCMD = mocks.Stub<ICMD>();
            this.cmdManager.userInfo = null;
            this.cmdManager.Do(stubCMD);           
        }
        [Test]
        [ExpectedException(typeof(NotAuthException))]
        public void Do_ref형_파라미터_없는_메서드가_권한_없는_상태에서_Exception을_발생_시키는지() 
        {
            //Arrange
            UserAuthController stubUserInfoWorker = mocks.Stub<UserAuthController>();
            UserAuth ua= mocks.Stub<UserAuth>();
            ICMD stubCMD = mocks.Stub<ICMD>();
            stubCMD.userAuth = ua;
            this.cmdManager.userInfo = mocks.Stub<UserInfo>();
            this.cmdManager.Do(stubCMD);             
        }
        public void UnDo() { }
        public void ReDo() { }


        [Test]
        public void GetCommonSetting_Test_정상적인_처리과정을_거치는지() 
        {
            using (mocks.Record())
            {
                object obj = new object();
                workInfoSelectCMD.execute(out obj);
                LastCall.Return(true);
            }
            this.cmdManager.GetCommonSetting();
        }

    }
}
