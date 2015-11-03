 explain
 
 select * from
 (select * from goods where Goods.GoodName='testName1') as good
left join
(select * from GoodSeller) as gs
on 
good.GoodPK=gs.GoodIDX
left join
(select * from Companies) as com
on
gs.SellerIDX=com.CompanyPK
left join
(select  PartIDX ,FinishedGoodIDX,amount as '필량' from parts) partInfo
on
good.GoodPK=partInfo.FinishedGoodIDX
left join
(select  GoodPK,GoodName as 'PartsName',GoodSubName as 'PartsSubName' from Goods) as part
on
part.GoodPK=PartIDX
left join
(select GoodPK,GoodName as 'FinishedWorkName',GoodSubName as 'FinishedWorkSubName' from Goods) as finishedWork
on
partInfo.FinishedGoodIDX=finishedWork.GoodPK
left join 
(select * from UnitCost) as uCost
on 
good.goodPK=ucost.GoodIDX and com.CompanyPK=ucost.CompanyIDX