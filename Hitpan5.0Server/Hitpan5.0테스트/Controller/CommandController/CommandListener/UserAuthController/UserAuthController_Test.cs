using System;
using NUnit.Framework;
using Rhino.Mocks;
using libHitpan5.Model.DataModel.DataQuery;
using libHitpan5.Model.DataModel;
using libHitpan5.Controller.CommandController.CommandListener.UserAuthController;
using libHitpan5.VO;
using libHitpan5.enums;
using System.Data;
using libHitpan5.Controller.CommandController.CommandListener.SettingControllers.MyInfoController;
using libHitpan5.Model.EncryptionModel;
using System.ServiceModel;
namespace libHitpan5_Test.Controller.CommandListener.UserAuthController_Test
{
    [TestFixture]
    public class UserAuthController_Test
    {
        [Test]
        public void Insert_Test_정상적인_값을_입력시_true를_반환하는지()
        {
            //Arrange
            MockRepository mocks = new MockRepository();
            IDataQueryRepository stubQueryRepository = mocks.Stub<IDataQueryRepository>();
            IDataModel mockDBManager = mocks.Stub<IDataModel>();
            UserAuthController userAuth = new UserAuthController(mockDBManager, stubQueryRepository);
            UserInfo stubUI = new UserInfo();
            stubUI.id = "id";
            stubUI.password = "password";
            stubUI.userAuth = "auth";
            stubUI.userType = 사용자등급.페기;
            //Act
            bool isOK= userAuth.Insert(stubUI);
            //Assert
            Assert.IsTrue(isOK);
        }
        [TestCase(null,"password","auth")]
        [TestCase("id", null, "auth")]
        [TestCase("id", "password", null)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Insert_Test_ID_Password_Auth에_해당하는_값을_Null로_준_경우_Exception이_발생하는지(string id,string password,string auth) 
        {
            //Arrange
            MockRepository mocks = new MockRepository();
            IDataQueryRepository stubQueryRepository = mocks.DynamicMock<IDataQueryRepository>();
            IDataModel mockDBManager = mocks.Stub<IDataModel>();           
            UserInfo stubUI = new UserInfo();
            stubUI.id = id;
            stubUI.password = password;
            stubUI.userAuth = auth;
            stubUI.userType = 사용자등급.페기;
            UserAuthController userAuth = new UserAuthController(mockDBManager, stubQueryRepository);
            //Act,Assert
            userAuth.Insert(stubUI);
        }

        [TestCase("id", "password", "auth", "pre_id", "pre_password", "pre_auth")]
        public void Update_Test_정상적인_파라미터_주고_True반환하는지_검증(string id, string password, string auth, string pre_id, string pre_password, string pre_auth) 
        {
            //Arrange
            MockRepository mocks = new MockRepository();
            IDataModel stubDataModel = mocks.DynamicMock<IDataModel>();
            IDataQueryRepository stubQueryReposit = mocks.Stub<IDataQueryRepository>();
            UserInfo user_info = new UserInfo();
                     user_info.id = id;
                     user_info.password = password;
                     user_info.userAuth = auth;
                     user_info.userType = 사용자등급.페기;
            UserInfo pre_user_info = new UserInfo();
                     pre_user_info.id = pre_id;
                     pre_user_info.password = pre_password;
                     pre_user_info.userAuth = pre_auth;
                     pre_user_info.userType = 사용자등급.페기;

            UserAuthController uac = new UserAuthController(stubDataModel,stubQueryReposit);
            //Act
            bool isOK= uac.Update(user_info,pre_user_info);
            //Assert
            Assert.IsTrue(isOK);
        }

        [TestCase(null, "password", "auth", "pre_id", "pre_password", "pre_auth")]
        [TestCase("id", null, "auth", "pre_id", "pre_password", "pre_auth")]
        [TestCase("id", "password", null, "pre_id", "pre_password", "pre_auth")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Update_Test_입력값에_Null_주고_Exception발생하는지(string id, string password, string auth, string pre_id, string pre_password, string pre_auth)
        {
            //Arrange
            MockRepository mocks = new MockRepository();
            IDataModel stubDataModel = mocks.DynamicMock<IDataModel>();
            IDataQueryRepository stubQueryReposit = mocks.Stub<IDataQueryRepository>();
            UserInfo user_info = new UserInfo();
            user_info.id = id;
            user_info.password = password;
            user_info.userAuth = auth;
            user_info.userType = 사용자등급.페기;
            UserInfo pre_user_info = new UserInfo();
            pre_user_info.id = pre_id;
            pre_user_info.password = pre_password;
            pre_user_info.userAuth = pre_auth;
            pre_user_info.userType = 사용자등급.페기;

            UserAuthController uac = new UserAuthController(stubDataModel, stubQueryReposit);
            //Act
            bool isOK = uac.Update(user_info, pre_user_info);
        }

        [TestCase("id", "password", "auth", null, "pre_auth")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Update_Test_파라미터값에_Null_주고_Exception발생하는지(string id, string password, string auth, string pre_id, string pre_auth)
        {
            //Arrange
            MockRepository mocks = new MockRepository();
            IDataModel stubDataModel = mocks.DynamicMock<IDataModel>();
            IDataQueryRepository stubQueryReposit = mocks.Stub<IDataQueryRepository>();
            UserInfo user_info = new UserInfo();
            user_info.id = id;
            user_info.password = password;
            user_info.userAuth = auth;
            user_info.userType = 사용자등급.페기;
            UserInfo pre_user_info = new UserInfo();
            pre_user_info.id = pre_id;
            pre_user_info.userAuth = pre_auth;
            pre_user_info.userType = 사용자등급.페기;

            UserAuthController uac = new UserAuthController(stubDataModel, stubQueryReposit);
            //Act
            bool isOK = uac.Update(user_info, pre_user_info);
        }
        [Test]
        public void Select_정상적으로_파라미터_입력시_정상적으로_쿼리생성_및_입력이_되는가() 
        {
            //Arrange
            UserInfo _param = new UserInfo();
            _param.id = "id";
            _param.password = "password";
            _param.userAuth = null;
            _param.userType = 사용자등급.일반사용자;

            MockRepository mocks = new MockRepository();

            // [1] SQLDataServiceModel을 설정
            SQLDataServiceModel mockSqlDB = mocks.DynamicMock<SQLDataServiceModel>();
            mockSqlDB.sqlService = mocks.Stub<ISQLWebService>(new object[] { mocks.Stub<InstanceContext>() });
            mockSqlDB.EncryptionSeed = "1234";
            // [2] IDataQueryRepository를 설정
            IDataQueryRepository stubQuery = mocks.Stub<SQLDataQueryRepository>();
            // [3] 테스트 할 객체 생성
            UserAuthController uac = new UserAuthController(mockSqlDB,stubQuery);
            using (mocks.Record())
            {
                string query = stubQuery.SelectUserAuth(_param.id);
                mockSqlDB.GetData(query);
            }
            mocks.VerifyAll();
        }

        [TestCase(null,"password")]
        [TestCase("id",null)]
        [TestCase("","password")]
        [TestCase("id","")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Select_아이디나_패스워드_중_하나를_Null값_이나_빈값_입력시_Exception_발생하는지(string id,string password) 
        {
            MockRepository mocks = new MockRepository();
            UserInfo _param = mocks.Stub<UserInfo>();
                     _param.id = id;
                     _param.password = password;
                     _param.userAuth = null;
                     _param.userType = 사용자등급.일반사용자;
            IDataModel stubDataModel = mocks.Stub<SQLDataServiceModel>();
            IDataQueryRepository stubQueryReposit = mocks.Stub<SQLDataQueryRepository>();
            UserAuthController uac = new UserAuthController(stubDataModel,stubQueryReposit);
            uac.Select(_param);
        }
        [Test]
        public void Select_Test_파라미터가_없는_Select메서드_테스트() 
        {
            MockRepository mocks = new MockRepository();
            //[1] IDataModel 파라미터 구성
            SQLDataServiceModel mockDataModel = mocks.DynamicMock<SQLDataServiceModel>();
            ISQLWebService stubSQLWebService = mocks.Stub<ISQLWebService>(mocks.Stub<InstanceContext>());
            mockDataModel.EncryptionSeed = "1234";
            mockDataModel.sqlService = stubSQLWebService;

            //[2] IDataQueryRepository 파라미터 구성
            IDataQueryRepository stubQueryReposit = mocks.Stub<SQLDataQueryRepository>();

            //[3] stub과 mock객체 사용해서 테스트 하고자 하는 객체 생성
            UserAuthController uac = new UserAuthController(mockDataModel, stubQueryReposit);
            using (mocks.Record())
            {
                string query = stubQueryReposit.SelectUserAuth();
                mockDataModel.GetData(query);
            }
            uac.Select();
            mocks.Verify(mockDataModel);
        }

        [TestCase("id")]
        public void Delete_Test_파라미터_있는_메서드__계정제한하는_쿼리_실행_시키는지(string id) 
        {
            MockRepository mocks = new MockRepository();

            //[1] IDataModel 파라미터 구성
            SQLDataServiceModel mockDataModel = mocks.DynamicMock<SQLDataServiceModel>();
            ISQLWebService stubSQLWebService = mocks.Stub<ISQLWebService>(mocks.Stub<InstanceContext>());
            mockDataModel.EncryptionSeed = "1234";
            mockDataModel.sqlService = stubSQLWebService;

            //[2] IDataQueryRepository 파라미터 구성
            IDataQueryRepository stubQueryRepository = mocks.Stub<SQLDataQueryRepository>();

            //[3] stub과 mock객체 사용해서 테스트 하고자 하는 객체 생성
            UserAuthController uac = new UserAuthController(mockDataModel,stubQueryRepository);

            using (mocks.Record())
            {
                string query = stubQueryRepository.DeleteUserInfo(id);
                mockDataModel.SetData(query);
            }
            uac.Delete(id);
        }

        [TestCase("")]
        [TestCase(null)]      
        [ExpectedException(typeof(ArgumentNullException))]
        public void Delete_Test_파라미터_있는_메서드_파라미터로_Null값이나_빈값_입력__Exception발생(string id)
        {
            MockRepository mocks = new MockRepository();

            //[1] IDataModel 파라미터 구성
            SQLDataServiceModel mockDataModel = mocks.DynamicMock<SQLDataServiceModel>();
            ISQLWebService stubSQLWebService = mocks.Stub<ISQLWebService>(mocks.Stub<InstanceContext>());
            mockDataModel.EncryptionSeed = "1234";
            mockDataModel.sqlService = stubSQLWebService;

            //[2] IDataQueryRepository 파라미터 구성
            IDataQueryRepository stubQueryRepository = mocks.Stub<SQLDataQueryRepository>();

            //[3] stub과 mock객체 사용해서 테스트 하고자 하는 객체 생성
            UserAuthController uac = new UserAuthController(mockDataModel, stubQueryRepository);


            uac.Delete(id);
        }


    }
}
