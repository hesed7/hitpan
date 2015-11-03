using System;
using NUnit.Framework;
using Rhino.Mocks;
using libHitpan5.Model.DataModel.DataQuery;

namespace libHitpan5_Test.Model.DataModel.SQLQuery
{
    [TestFixture]
    public class LocalDataQueryRepository_Test
    {
        [Test]
        public void selectCommonSettinginfo_Test_빈값이_아닌_값을_반환하는지()
        {
            LocalDataQueryRepository localDataQuery = new LocalDataQueryRepository();
            string returnValue = localDataQuery.selectSettingInfo();
            Assert.IsNotEmpty(returnValue);
        }

        [Test]
        public void insertCommonSettinginfo_Null입력시_NullException발생하는지() 
        {
            bool isOK = false;
            LocalDataQueryRepository localDataQuery = new LocalDataQueryRepository();
            try
            {
                string returnValue = localDataQuery.insertSettingInfo(null);
                isOK = true;
            }
            catch (NullReferenceException)
            {
                                
            }

            Assert.IsFalse(isOK);
        }

        [Test]
        public void DeleteCommonSettinginfo_Test_빈값이_아닌_값을_반환하는지()
        {
            LocalDataQueryRepository localDataQuery = new LocalDataQueryRepository();
            string returnValue = localDataQuery.DeleteSettingInfo();
            Assert.IsNotEmpty(returnValue);
        }
    }
}
