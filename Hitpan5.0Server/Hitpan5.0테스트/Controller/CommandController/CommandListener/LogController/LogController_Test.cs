using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Rhino.Mocks;
using libHitpan5.Model.DataModel;
using libHitpan5.Controller.CommandController.CommandListener;
using libHitpan5.Model.DataModel.DataQuery;
using System.ServiceModel;
namespace Hitpan5_Test.Controller.LogController_Test
{
    [TestFixture]
    class LogController_Test
    {
        //[Test]
        public void WriteLog_작성된_쿼리가_제대로_들어가는지() 
        {
            MockRepository mocks = new MockRepository();
            IDataModel db = mocks.DynamicMock<SQLDataServiceModel>();
            ((SQLDataServiceModel)db).sqlService = mocks.Stub<ISQLWebService>(mocks.Stub<InstanceContext>());
            IDataQueryRepository query = mocks.Stub<IDataQueryRepository>();
            LogController loger= LogController.getInstance(db, query);
            using (mocks.Record())
            {
                DateTime date= ((SQLDataServiceModel)db).sqlService.GetTime();
                string q = query.InsertLog(libHitpan5.enums.LogType.에러, "test", "log",date.ToString());
                db.SetData(q);
            }
            //db.ViewQueryForTest
        }
    }
}
