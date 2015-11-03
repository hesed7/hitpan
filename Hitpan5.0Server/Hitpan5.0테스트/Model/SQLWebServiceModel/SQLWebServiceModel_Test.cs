using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rhino.Mocks;
using NUnit.Framework;
using libHitpan5.Model.WebServiceModel;
using libHitpan5.Model.WebServiceModel.proxy.callback;
namespace libHitpan5_Test.Controller.WebServiceController
{
    [TestFixture]
    class SQLWebServiceModel_Test
    {
        [Test]
        public void CallWebserviceUsingCallback_Test_SQLWebServiceModel을_생성할_때에_웹서비스_프록시를_정상적으로_생성하는지() 
        {
            //Arrange
            MockRepository mocks = new MockRepository();
            ISQLWebServiceCallback callback= mocks.Stub<SQLWebserviceCallback>();           
            //Act
            SQLWebServiceModel webserviceProvider = SQLWebServiceModel.getinstance("http://127.0.0.1:8080", callback);
            //Assert
            Assert.IsNotNull(webserviceProvider.webservice);
        }
    }
}
