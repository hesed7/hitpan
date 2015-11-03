using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Rhino.Mocks;
using libHitpan5;
using libHitpan5.Controller.CommandController.CommandListener.GoodsController;
using libHitpan5.Model.DataModel;
using libHitpan5.Model.DataModel.DataQuery;
using libHitpan5.VO.DBTableVO;
using libHitpan5.VO.CommonVO.GoodInfo;
using libHitpan5.VO.DBTableVO.GoodsInfo;
using System.Data;
using System.ServiceModel;
namespace libHitpan5_Test.Controller.CommandController.CommandListener.GoodsController
{
    public class GoodsControoller_Test
    {       
        public MockRepository mocks { get; set; }
        public GoodsInfoController goodController { get; set; }
        public SQLDataServiceModel mockSQLModel { get; set; }
        public SQLDataQueryRepository stubQuery { get; set; }
        [SetUp]
        public void SetUp() 
        {
            mocks= new MockRepository();

            mockSQLModel = mocks.DynamicMock<SQLDataServiceModel>();
            mockSQLModel.sqlService = mocks.Stub<ISQLWebService>(mocks.Stub<InstanceContext>());
            mockSQLModel.EncryptionSeed = "1234";
            stubQuery = mocks.Stub<SQLDataQueryRepository>();

            goodController = new GoodsInfoController(mockSQLModel,stubQuery);
        }
    }
}
