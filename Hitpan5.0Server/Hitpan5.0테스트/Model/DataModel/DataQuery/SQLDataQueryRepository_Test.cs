using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using libHitpan5;
using NUnit.Framework;
using Rhino.Mocks;
using libHitpan5.Model.DataModel;
using libHitpan5.VO;
using Newtonsoft.Json;
using libHitpan5.VO.DBTableVO.CompanyInfo;
using libHitpan5.VO.DBTableVO.GoodsInfo;
//using Newtonsoft.Json;
namespace libHitpan5_Test.Model.DataModel.DataQuery
{
    [TestFixture]
    class SQLDataQueryRepository_Test
    {
        [Test]
        public void selectCommonSettinginfo_Test() 
        {
            SQLDataQueryRepository sqlQuery = new SQLDataQueryRepository();
            string query = sqlQuery.selectSettingInfo();
            Assert.IsNotEmpty(query);
        }

        [Test]
        public void insertCommonSettinginfo_Test_바른_값을_주고_바른_쿼리를_반환하는지()         
        {        
            //Arrange
            MockRepository mocks = new MockRepository();
            CommonSettinginfo si = new CommonSettinginfo();
            si.CommonSettinginfo_DB = new CommonSettinginfo_From_DB();
            string ExpectedJson = JsonConvert.SerializeObject(si.CommonSettinginfo_DB);
            string ExpectedString = string.Format("insert into commonSetting(jsonSettingInfoData) values('{0}')", ExpectedJson);
            SQLDataQueryRepository sqlQuery = new SQLDataQueryRepository();                       
            //Act
            string actualQuery = sqlQuery.insertSettingInfo(si);
            //Assert
            Assert.AreEqual(ExpectedString,actualQuery);
        }

        [Test]
        public void insertCommonSettinginfo_Test_Null_값을_주고_NullReferenceException이_발생하는지()
        {
            //Arrange

            bool isNullReferenceException = false;
            CommonSettinginfo si = null;
            SQLDataQueryRepository sqlQuery = new SQLDataQueryRepository();
            //Act
            try
            {
                string actualQuery = sqlQuery.insertSettingInfo(si);
            }
            catch (NullReferenceException)
            {
                isNullReferenceException = true;
            }
            //Assert
            Assert.IsTrue(isNullReferenceException);
        }

        [Test]
        public void DeleteCommonSettinginfo_빈값이_아닌_값이_반환되는지() 
        {
            SQLDataQueryRepository sql = new SQLDataQueryRepository();
            string val = sql.DeleteSettingInfo();
            Assert.IsNotEmpty(val);
        }

        [Test]
        public void InsertUserAuth_올바른_값_입력하면_올바른_쿼리가_반환되는지()
        {
            SQLDataQueryRepository sql = new SQLDataQueryRepository();
            string query = sql.InsertUserAuth("id","password","auth",libHitpan5.enums.사용자등급.관리자);
            Assert.AreEqual("insert into Users values('id','password','auth',1)", query);
        }

        [Test]
        public void InsertUserAuth_패스워드_빼고_입력하면_Exception이_발생허는지()
        {
            bool ThrowException = false;
            SQLDataQueryRepository sql = new SQLDataQueryRepository();
            try
            {
                string query = sql.InsertUserAuth("id", null, "auth", libHitpan5.enums.사용자등급.관리자);
                ThrowException = true;
            }
            catch (ArgumentNullException)
            {
                ThrowException = false;
            }
            Assert.IsFalse(ThrowException);
        }

        [Test]
        public void UpdateUserAuth_올바른_값_입력하면_올바른_쿼리가_반환되는지() 
        {
            //Arrange
            SQLDataQueryRepository sql = new SQLDataQueryRepository();
            //Act
            string query= sql.UpdateUserAuth("id1","password1","id","auth",libHitpan5.enums.사용자등급.관리자);
            //Assert
            Assert.AreEqual("update Users set userID='id1',userPassword='password1',userAuth='auth',userType=1 where userID='id'", query);
        }


        [Test]
        public void UpdateUserAuth_아이디를_null로_입력시_기존ID_Password_로_대체되어서_쿼리가_생성되는지()
        {
            //Arrange
            SQLDataQueryRepository sql = new SQLDataQueryRepository();
            //Act
            string query = sql.UpdateUserAuth(null, null, "id", "auth", libHitpan5.enums.사용자등급.관리자);
            //Assert
            Assert.AreEqual("update Users set userID='id',userAuth='auth',userType=1 where userID='id'", query);
        }

        [Test]
        public void SelectUserAuth_Test_모든_값을_다_준_경우_쿼리생성이_정상적으로_되는지() 
        {
            //Arrange
            string Expected = "select * from Users where userID='user'";
            SQLDataQueryRepository sql = new SQLDataQueryRepository();

            //Act
            string actual= sql.SelectUserAuth("user");

            //Assert
            Assert.AreEqual(Expected,actual);
        }
        [Test]
        public void SelectUserAuth_Test_아이디를_Null로_준_경우_ArgumentNullException_이_발생하는가() 
        {
            //Arrange
            bool Exc = false;
            //Act
            try
            {
                new SQLDataQueryRepository().SelectUserAuth(null);
                Exc = true;
            }
            catch (ArgumentNullException)
            {
                Exc = false;
            }
            //Assert
            Assert.IsFalse(Exc);
        }

        [Test]
        public void SelectUserAuth_파라미터_없는_메서드_테스트_Return_ID_전부_반환하는_쿼리() 
        {
            //Arrange
            SQLDataQueryRepository queryReposit = new SQLDataQueryRepository();
            //Act
            string query = queryReposit.SelectUserAuth();
            //Assert
            Assert.AreEqual("select * from Users", query);
        }


        [TestCase("id")]
        public void DeleteUserInfo_Test_정상적으로_파라미터를_입력했을때_사용자등급을_페기로_업데이트_하는_쿼리_반환(string id) 
        {
            //Arrange
            SQLDataQueryRepository sqlQuery = new SQLDataQueryRepository();
            string Expected="update Users set userType=0 where userID='id'";
            //Act
            string query= sqlQuery.DeleteUserInfo(id);
            //Assert
            Assert.AreEqual(Expected, query);
        }

        [TestCase(null)]
        [TestCase("")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DeleteUserInfo_Test_빈값이나_Null입력시에_Exception발생(string id)
        {
            //Arrange
            SQLDataQueryRepository sqlQuery = new SQLDataQueryRepository();
            //Act
            string query = sqlQuery.DeleteUserInfo(id);
        }

        [Test]
        public void InsertGoods_Test_올바른_값을_입력시_예상되는_값이_반환되는가() 
        {
            //Arrange
            Goods goods = new Goods();
            goods.ETCInfo = "etc";
            goods.GoodMaker = "maker";
            goods.GoodName = "name";
            goods.GoodNickName = "nickname";
            goods.GoodSubName = "subname";
            goods.GoodUnit = "unit";
            goods.ProperStock = "1";
            goods.Status = "testStatus";
            string exQuery = "insert into goods(GoodName,GoodSubName,GoodMaker,GoodNickName,GoodUnit,ProperStock,ETCInfo,Status) values ('name','subname','maker','nickname','unit','1','etc','testStatus')";
            //Act
            string query = new SQLDataQueryRepository().InsertGoods(goods);
            //Assert
            Assert.AreEqual(exQuery,query);
        }
        [Test]
        public void UpdateGoods_Test올바른_값을_입력시_예상되는_값이_반환되는가() 
        {
            //Arrange
            Goods goods = new Goods();
            goods.GoodPK = 1;
            goods.ETCInfo = "etc";
            goods.GoodMaker = "maker";
            goods.GoodName = "name";
            goods.GoodNickName = "nickname";
            goods.GoodSubName = "subname";
            goods.GoodUnit = "unit";
            goods.ProperStock = "1";
            goods.Status = "testStatus";
            string exGoodQuery = "update Goods set GoodName='name',GoodSubName='subname',GoodMaker='maker',GoodNickName='nickname',GoodUnit='unit',ProperStock='1',ETCInfo='etc',Status='testStatus' where GoodPK=1";
            //act
            string query = new SQLDataQueryRepository().UpdateGoods(goods);
            //Assert
            Assert.AreEqual(exGoodQuery,query);        
        }
        [TestCase(true)]
        [TestCase(false)]
        public void DeleteGoods_Test올바른_값을_입력시_예상되는_값이_반환되는가(bool useLike) 
        {
            //Arrange
            string exQuery = "delete from Goods where GoodPK=1 and GoodName='test'";
            if (useLike)
            {
                exQuery = "delete from Goods where GoodPK=1 and GoodName like '%test%'";
            }           
            Goods g = new Goods();
            g.GoodPK = 1;
            g.GoodName = "test";
            //Act
            string query = new SQLDataQueryRepository().DeleteGoods(g, useLike);
            //Assert
            Assert.AreEqual(exQuery,query);
        }

        #region 매입자 정보 지우기
        [TestCase(true)]
        [TestCase(false)]
        public void DeleteSeller_Test_상품관련정보_입력시_예상되는_값이_반환되는가(bool useLike)
        {
            string exQuery = string.Format("Delete from GoodSeller where GoodIDX in (select GoodPK as GoodIDX from Goods where GoodName='test')");
            if (useLike)
            {
                exQuery = string.Format("Delete from GoodSeller where GoodIDX in (select GoodPK as GoodIDX from Goods where GoodName like '%test%')");
            }

            Goods g = new Goods();
            g.GoodName = "test";
            string query = new SQLDataQueryRepository().DeleteSeller(g, null, useLike);
            Assert.AreEqual(exQuery, query);
        }
        [TestCase(true)]
        [TestCase(false)]
        public void DeleteSeller_Test_업체관련정보_입력시_예상되는_값이_반환되는가(bool useLike)
        {
            string exQuery = string.Format("Delete from GoodSeller where SellerIDX in (select CompanyPK as SellerIDX from Companies where CompanyName='test')");
            if (useLike)
            {
                exQuery = string.Format("Delete from GoodSeller where SellerIDX in (select CompanyPK as SellerIDX from Companies where CompanyName like '%test%')");
            }

            Companies c = new Companies();
            c.CompanyName = "test";
            string query = new SQLDataQueryRepository().DeleteSeller(null, c, useLike);
            Assert.AreEqual(exQuery, query);
        }
        [TestCase(true)]
        [TestCase(false)]
        public void DeleteSeller_Test_업체관련정보와_상품정보_입력시_예상되는_값이_반환되는가(bool useLike)
        {
            string exQuery = string.Format("Delete from GoodSeller where GoodIDX in (select GoodPK as GoodIDX from Goods where GoodName='testGood') and SellerIDX in (select CompanyPK as SellerIDX from Companies where CompanyName='testCompany')");
            if (useLike)
            {
                exQuery = string.Format("Delete from GoodSeller where GoodIDX in (select GoodPK as GoodIDX from Goods where GoodName like '%testGood%') and SellerIDX in (select CompanyPK as SellerIDX from Companies where CompanyName like '%testCompany%')");
            }

            Companies c = new Companies();
            c.CompanyName = "testCompany";
            Goods g = new Goods();
            g.GoodName = "testGood";
            string query = new SQLDataQueryRepository().DeleteSeller(g, c, useLike);
            Assert.AreEqual(exQuery, query);
        }
        [Test]
        public void DeleteSeller_Test_어떤_정보도_입력하지_않았을때_예상되는_값이_반환되는가()
        {
            string exQuery = "Delete from GoodSeller";
            string query = new SQLDataQueryRepository().DeleteSeller(null, null, false);
            Assert.AreEqual(exQuery, query);
        } 
        #endregion
        #region 부품,완성품정보 지우기
        [TestCase(true)]
        [TestCase(false)]
        public void DeleteParts_With_FinalGoods_Test_완성품관련정보_입력시_예상되는_값이_반환되는가(bool useLike)
        {
            string exQuery = string.Format("Delete from Parts where FinishedGoodIDX in (select GoodPK as FinishedGoodIDX from Goods where GoodName='test')");
            if (useLike)
            {
                exQuery = string.Format("Delete from Parts where FinishedGoodIDX in (select GoodPK as FinishedGoodIDX from Goods where GoodName like '%test%')");
            }

            Goods g = new Goods();
            g.GoodName = "test";
            string query = new SQLDataQueryRepository().DeleteParts_With_FinalGoods(g, useLike);
            Assert.AreEqual(exQuery, query);
        }
        [TestCase(true)]
        [TestCase(false)]
        public void DeleteParts_Test_부품관련정보_입력시_예상되는_값이_반환되는가(bool useLike)
        {
            string exQuery = string.Format("Delete from Parts where PartIDX in (select GoodPK as PartIDX from Goods where GoodName='test')");
            if (useLike)
            {
                exQuery = string.Format("Delete from Parts where PartIDX in (select GoodPK as PartIDX from Goods where GoodName like '%test%')");
            }

            Goods g = new Goods();
            g.GoodName = "test";
            string query = new SQLDataQueryRepository().DeleteParts(g, useLike);
            Assert.AreEqual(exQuery, query);
        } 
        #endregion
        #region 단가정보
        [TestCase(true)]
        [TestCase(false)]
        public void DeleteUnitCost_Test_제품정보와_업체정보_입력시_예상되는_쿼리_반환하는지(bool useLike) 
        {
            string exQuery = string.Format("Delete from UnitCost where GoodIDX in (select GoodPK as GoodIDX from Goods where GoodName='testGood') and CompanyIDX in (select CompanyPK as CompanyIDX from Companies where CompanyName='testCompany')");
            if (useLike)
            {
                exQuery = string.Format("Delete from UnitCost where GoodIDX in (select GoodPK as GoodIDX from Goods where GoodName like '%testGood%') and CompanyIDX in (select CompanyPK as CompanyIDX from Companies where CompanyName like '%testCompany%')");
            }

            Companies c = new Companies();
            c.CompanyName = "testCompany";
            Goods g = new Goods();
            g.GoodName = "testGood";
            string query = new SQLDataQueryRepository().DeleteUnitCost(g, c, useLike);
            Assert.AreEqual(exQuery, query);            
        }
        [TestCase(true)]
        [TestCase(false)]
        public void DeleteUnitCost_Test_제품정보만_입력시_예상되는_쿼리_반환하는지(bool useLike)
        {
            string exQuery = string.Format("Delete from UnitCost where GoodIDX in (select GoodPK as GoodIDX from Goods where GoodName='testGood')");
            if (useLike)
            {
                exQuery = string.Format("Delete from UnitCost where GoodIDX in (select GoodPK as GoodIDX from Goods where GoodName like '%testGood%')");
            }

            Goods g = new Goods();
            g.GoodName = "testGood";
            string query = new SQLDataQueryRepository().DeleteUnitCost(g, null, useLike);
            Assert.AreEqual(exQuery, query);
        }
        [TestCase(true)]
        [TestCase(false)]
        public void DeleteUnitCost_Test_회사정보만_입력시_예상되는_쿼리_반환하는지(bool useLike)
        {
            string exQuery = string.Format("Delete from UnitCost where CompanyIDX in (select CompanyPK as CompanyIDX from Companies where CompanyName='testCompany')");
            if (useLike)
            {
                exQuery = string.Format("Delete from UnitCost where CompanyIDX in (select CompanyPK as CompanyIDX from Companies where CompanyName like '%testCompany%')");
            }

            Companies c = new Companies();
            c.CompanyName = "testCompany";
            string query = new SQLDataQueryRepository().DeleteUnitCost(null, c, useLike);
            Assert.AreEqual(exQuery, query);
        }
        #endregion
        [Test]
        public void SelectGoods_Test_매개변수를_아무것도_입력하지_않았을때_상품_전부_검색하는_쿼리_반환() 
        {
            //Arrange

            //Act
            string query = new SQLDataQueryRepository().SelectGoods(null,false);
            //Assert
            Assert.AreEqual("select * from Goods",query);
        }
        [Test]
        public void SelectGoods_Test_GoodPK를_매개변수로_줬을때_예상되는_쿼리_반환()
        {
            //Arrange
            Goods g = new Goods();
            g.GoodPK = 1;
            //Act
            string query = new SQLDataQueryRepository().SelectGoods(g, false);
            //Assert
            Assert.AreEqual("select * from Goods where GoodPK=1 limit 0 offset 0", query);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void SelectGoods_Test_GoodName를_매개변수로_줬을때_예상되는_쿼리_반환(bool isLikeMode)
        {
            //Arrange
            Goods g = new Goods();
            g.GoodName = "test";
            g.RowCount = 1;
            g.Page = 3;
            string expected = string.Empty;
            if (isLikeMode)
            {
                expected = "select * from Goods where GoodName like '%test%' limit 1 offset 2";
            }
            else
            {
                expected = "select * from Goods where GoodName='test' limit 1 offset 2";
            }
            //Act
            string query = new SQLDataQueryRepository().SelectGoods(g, isLikeMode);
            //Assert
            Assert.AreEqual(expected, query);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void SelectGoodsAndPartsAndUnitCost_Test_매개변수를_올바르게_입력시에_예상되는_쿼리_반환_하는지(bool UseLike) 
        {
            //Arrange
            string queryNoLike =
                    @"select *
                    from
                    (
                        select good.*,null as FinishedGoodIDX ,null as PartIDX,null as amount,ucost.* from
                        (select * from Goods where GoodName='testName1') as good
                        left join
                        (select * from unitcost) as ucost
                        on
                        good.GoodPK=ucost.GoodIDX

                        union all

                        select good.*,part.*,ucost.* from
                        (select * from Goods where GoodName='testName1') as Finished_good
                        left join 
                        (select * from parts) as part 
                        on
                        Finished_good.goodPK= part.FinishedGoodIDX
                        left join
                        (select * from goods) as good
                        on
                        part.PartIDX=good.goodPK 
                        left join
                        (select * from unitcost) as ucost
                        on
                        part.PartIDX=ucost.GoodIDX
                    )
                    limit 1 offset 2";

            string queryLike =
                    @"select *
                    from
                    (
                        select good.*,null as FinishedGoodIDX ,null as PartIDX,null as amount,ucost.* from
                        (select * from Goods where GoodName like '%testName1%') as good
                        left join
                        (select * from unitcost) as ucost
                        on
                        good.GoodPK=ucost.GoodIDX

                        union all

                        select good.*,part.*,ucost.* from
                        (select * from Goods where GoodName like '%testName1%') as Finished_good
                        left join 
                        (select * from parts) as part 
                        on
                        Finished_good.goodPK= part.FinishedGoodIDX
                        left join
                        (select * from goods) as good
                        on
                        part.PartIDX=good.goodPK 
                        left join
                        (select * from unitcost) as ucost
                        on
                        part.PartIDX=ucost.GoodIDX
                    )
                    limit 1 offset 2";
            Goods g = new Goods();
            g.RowCount = 1;
            g.Page = 3;
            g.GoodName = "testName1";
            //Act
            string query = new SQLDataQueryRepository().SelectGoodsAndPartsAndUnitCost(g,UseLike);
            //Assert       
            if (UseLike)
            {
                Assert.AreEqual(queryLike,query);
            }
            else
            {
                Assert.AreEqual(queryNoLike,query);
            }
        }

        [TestCase(true)]
        [TestCase(false)]
        public void SelectGoodsAndUnitCost_Test_매개변수를_올바르게_입력시에_예상되는_쿼리_반환_하는지(bool UseLike) 
        {
            string exQuery = string.Empty;
            //Arrange
            if (!UseLike)
            {
                exQuery=
                "select * from ((select * from Goods where GoodName='testName1') as good inner join (select * from UnitCost) as ucost on good.GoodPK=ucost.GoodIDX) limit 1 offset 1";                
            }
            else
            {
                exQuery =
                "select * from ((select * from Goods where GoodName like '%testName1%') as good inner join (select * from UnitCost) as ucost on good.GoodPK=ucost.GoodIDX) limit 1 offset 1";
            }
            Goods g = new Goods();
            g.RowCount = 1;
            g.Page = 2;
            g.GoodName = "testName1";
            //Act
            string query = new SQLDataQueryRepository().SelectGoodsAndUnitCost(g,UseLike);
            //Assert
            Assert.AreEqual(exQuery, query);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void SelectGoodsAndSellers_Test_매개변수를_올바르게_입력시에_예상되는_쿼리_반환_하는지(bool UseLike)
        {
            string exQuery = string.Empty;
            //Arrange
            if (!UseLike)
            {
                exQuery =
                "select * from ((select * from Goods where GoodName='testName1') as good inner join (select * from GoodSeller) as seller on good.GoodPK=seller.GoodIDX inner join (select * from UnitCost) as ucost on seller.GoodIDX=ucost.GoodIDX and seller.SellerIDX=ucost.CompanyIDX) limit 1 offset 2";
            }
            else
            {
                exQuery =
                "select * from ((select * from Goods where GoodName like '%testName1%') as good inner join (select * from GoodSeller) as seller on good.GoodPK=seller.GoodIDX inner join (select * from UnitCost) as ucost on seller.GoodIDX=ucost.GoodIDX and seller.SellerIDX=ucost.CompanyIDX) limit 1 offset 2";
            }
            Goods g = new Goods();
            g.RowCount = 1;
            g.Page = 3;
            g.GoodName = "testName1";
            //Act
            string query = new SQLDataQueryRepository().SelectGoodsAndSellers(g, UseLike);
            //Assert
            Assert.AreEqual(exQuery, query);
        }
    }
}
