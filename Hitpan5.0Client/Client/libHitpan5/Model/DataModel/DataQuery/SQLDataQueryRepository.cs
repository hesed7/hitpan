using libHitpan5.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using libHitpan5.VO;
using Newtonsoft.Json;

using libHitpan5.Controller.CommandController;
using libHitpan5.VO.DBTableVO.CompanyInfo;
using libHitpan5.VO.DBTableVO.GoodsInfo;

namespace libHitpan5.Model.DataModel
{
    internal class SQLDataQueryRepository  
    {
        //private string GetTimeLine() 
        //{
        //    SQLWebServiceModel sqlModel=SQLWebServiceModel.getinstance();
        //    DateTime time = sqlModel.webservice.GetTime();
        //    return time.ToString();
            
        //}
        #region 로그
        public string InsertLog(LogType type, string user, string log, string timeLine)
        {
            //string timeLine = GetTimeLine();
            StringBuilder sb = new StringBuilder();
            sb.Append("insert into log values('");
            sb.Append(timeLine);
            sb.Append("',");
            sb.Append(Convert.ToInt32(type));
            sb.Append(",'");
            sb.Append(GetEscapedString(user,false));
            sb.Append("','");
            sb.Append(GetEscapedString(log,false));
            sb.Append("')");
            return sb.ToString();
        }
        public string GetLog(DateTime firstdt, DateTime lastdt, Log log)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from log where timeline between '");
            sb.Append(firstdt);
            sb.Append("' and '");
            sb.Append(lastdt);
            sb.Append("'");
            foreach (var prop in log.GetType().GetProperties())
            {
                //시간 프로퍼티 중복 회피 위해
                if (prop.Name == "timeline")
                {
                    continue;
                }
                sb.Append(" and ");
                sb.Append(prop.Name);
                if (prop.PropertyType == typeof(string))
                {
                    sb.Append(" like '%");
                    sb.Append(GetEscapedString(log[prop.Name].ToString(),true));
                    sb.Append("%'");
                    sb.Append(" escape '#'");
                }
                else
                {
                    sb.Append(" = ");
                    sb.Append(log[prop.Name]);
                }
            }
            return sb.ToString();
        } 
        #endregion
        #region myInfo
        public string InsertMyInfo(myInfo myInfo)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("insert into commonSetting(jsonMyInfo) values('");
            sb.Append(GetEscapedString(JsonConvert.SerializeObject(myInfo),false));
            sb.Append("')");
            return sb.ToString();
        }
        public string UpdateMyInfo(myInfo myInfo)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("update commonSetting set ");
            sb.Append("jsonMyInfo = '");
            sb.Append(GetEscapedString(JsonConvert.SerializeObject(myInfo),false));
            sb.Append("'");
            return sb.ToString();
        }
        public string GetMyInfo()
        {
            return "select jsonMyInfo from commonSetting";
        }
        public string DeleteMyInfo()
        {
            return "delete jsonMyInfo from commonSetting";
        } 
        #endregion
        #region 세팅데이터
        public string selectSettingInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select jsonSettingInfoData from commonSetting");
            return sb.ToString();
        }
        public string insertSettingInfo(CommonSettinginfo param)
        {
            if (param == null)
            {
                throw new NullReferenceException();
            }
            
            string info = JsonConvert.SerializeObject(param);
                   info= GetEscapedString(info, false);
            StringBuilder sb = new StringBuilder();
            sb.Append("insert into commonSetting(jsonSettingInfoData) ");
            sb.Append("values('");
            sb.Append(info);
            sb.Append("')");
            return sb.ToString();
        }
        public string updateSettingInfo(CommonSettinginfo param)
        {
            string jsonData = JsonConvert.SerializeObject(param);
                   jsonData = GetEscapedString(jsonData, false);
            StringBuilder sb = new StringBuilder();
            sb.Append("update commonSetting set jsonSettingInfoData='");
            sb.Append(jsonData);
            sb.Append("'");
            return sb.ToString();
        }

        public string DeleteSettingInfo()
        {
            return "delete jsonSettingInfoData from commonSetting";
        } 
        #endregion
        #region 사용자정보
        public string InsertUserInfo(string id, string password, string Auth, 사용자등급 userType)
        {
            try
            {
                id          = GetEscapedString(id, false);
                password    = GetEscapedString(password, false);
                Auth        = GetEscapedString(Auth, false);
                if (password == null || id == null)
                {
                    throw new ArgumentNullException();
                }
                StringBuilder sb = new StringBuilder();
                sb.Append("insert into Users values('");
                sb.Append(id);
                sb.Append("','");
                sb.Append(password);
                sb.Append("','");
                sb.Append(Auth);
                sb.Append("',");
                sb.Append(Convert.ToInt32(userType));
                sb.Append(")");
                return sb.ToString();
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public string UpdateUserInfo(string id, string password, string preID, string Auth, 사용자등급 userType)
        {
            if (preID==null)
            {
                throw new ArgumentNullException();
            }
            if (id==null)
            {
                id = preID;
            }
            string dynamicPassword = password == null ? string.Empty : string.Format("',userPassword='{0}", password);

            StringBuilder sb = new StringBuilder();
            sb.Append("update Users set userID='");
            sb.Append(id);            
            sb.Append(dynamicPassword);
            sb.Append("',userAuth='");
            sb.Append(Auth);
            sb.Append("',userType=");
            sb.Append(Convert.ToInt32(userType));
            sb.Append(" where userID='");
            sb.Append(preID);
            sb.Append("'");
            return sb.ToString();
        }
        public string SelectUserInfo(string id)
        {
            if (id==null)
            {
                throw new ArgumentNullException();
            }
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from Users where userID='");
            sb.Append(id);
            sb.Append("'");
            return sb.ToString();
        }         
        public string SelectUserInfo()
        {
            return "select * from Users";
        }
        public string DeleteUserInfo(string id)
        {
            id = GetEscapedString(id,false);
            if (id==null || id== string.Empty)
            {
                throw new ArgumentNullException("id가 null 이거나 빈값 입니다");
            }
            return string.Format("update Users set userType={0} where userID='{1}'",Convert.ToInt32(사용자등급.페기),id); ;
        }
        #endregion
        #region 상품정보

        /// <summary>
        /// 상품정보테이블 만 CRUD
        /// </summary>
        /// <param name="goodInfo"></param>
        /// <returns></returns>
        public string InsertGoods(Goods goodInfo) 
        {            
            //[1] 상품 표준정보 입력
            StringBuilder sbGoods1 = new StringBuilder();
            StringBuilder sbGoods2 = new StringBuilder();
            sbGoods1.Append("insert into goods(");
            sbGoods2.Append(" values (");

            bool isFirstGoods = true;
            foreach (var good in typeof(Goods).GetProperties())
            {
                if (good.Name.ToLower() == "item" || good.Name == "GoodPK" || good.Name == "Page" || good.Name == "RowCount" | good.Name == "orderby")
                {
                    continue;
                }
                if (!isFirstGoods)
                {
                    sbGoods1.Append(",");
                    sbGoods2.Append(",");
                }
                sbGoods1.Append(good.Name);
                if (good.PropertyType==typeof(string))
                {
                    sbGoods2.Append("'");
                    sbGoods2.Append(goodInfo[good.Name]);
                    sbGoods2.Append("'");
                }
                isFirstGoods = false;
            }
            sbGoods1.Append(")");
            sbGoods2.Append(")");
            return sbGoods1.ToString()+sbGoods2.ToString();
        }
        public string UpdateGoods(Goods goodInfo)
        {
            StringBuilder sbGoodUpdate = new StringBuilder();
            sbGoodUpdate.Append("update Goods set ");
            bool isFirst = true;
            foreach (var prop in typeof(Goods).GetProperties())
            {
                if (prop.Name.ToLower() == "item" || prop.Name == "GoodPK" || prop.Name == "Page" || prop.Name == "RowCount" | prop.Name == "orderby")
                {
                    continue;
                }
                if (!isFirst)
                {
                    sbGoodUpdate.Append(",");
                }
                sbGoodUpdate.Append(prop.Name);
                sbGoodUpdate.Append("=");
                if (prop.PropertyType==typeof(string))
	            {
                    sbGoodUpdate.Append("'");
                    sbGoodUpdate.Append(goodInfo[prop.Name]);
                    sbGoodUpdate.Append("'");
	            }
                else
	            {
                    sbGoodUpdate.Append(goodInfo[prop.Name]);
	            }                
                isFirst = false;
            }//End of foreach
            sbGoodUpdate.Append(" where GoodPK=");
            sbGoodUpdate.Append(goodInfo.GoodPK);
            return sbGoodUpdate.ToString();
        }
        public string DeleteGoods(Goods goodInfo, bool useLike) 
        {
            StringBuilder sbWhere = new StringBuilder();
            foreach (var prop in typeof(Goods).GetProperties())
            {
                if (goodInfo[prop.Name]==null)
	            {
                    continue;
	            }
                if (prop.Name.ToLower()=="item" || prop.Name=="RowCount" || prop.Name=="Page")
                {
                    continue;
                }
                if (sbWhere.Length<=0)
                {
                    sbWhere.Append("where ");
                }
                else
                {
                    sbWhere.Append(" and ");
                }
                sbWhere.Append(prop.Name);
                if (prop.PropertyType==typeof(string))
                {
                    if (useLike)
	                {
                        sbWhere.AppendFormat(" like '%{0}%'",goodInfo[prop.Name]);
	                }
                    else
                    {
                        sbWhere.AppendFormat("='{0}'", goodInfo[prop.Name]);
                    }
                    
                }
                else
                {
                    sbWhere.AppendFormat("={0}", goodInfo[prop.Name]);
                }
            }

            if (sbWhere.Length<=0)
            {
                return null;
            }
            StringBuilder sbGoods = new StringBuilder();
            sbGoods.Append("delete from Goods ");
            sbGoods.Append(sbWhere.ToString());
            return sbGoods.ToString();
        }
        public string DeleteSeller(Goods goodInfo, Companies companyInfo,bool useLike) 
        {
            //[1] 이너뷰 작성
            string goodsWhere = string.Empty;
            string companyWhere = string.Empty;
            if (goodInfo!=null)
            {
                IDictionary<string, string> goodDic = new Dictionary<string, string>();
                foreach (var prop in typeof(Goods).GetProperties())
                {
                    if (prop.Name.ToLower() == "item" || prop.Name == "RowCount" || prop.Name == "Page")
                    {
                        continue;
                    }
                    if (goodInfo[prop.Name] == null)
                    {
                        continue;
                    }
                    goodDic.Add(prop.Name, goodInfo[prop.Name].ToString());
                }
                goodsWhere = string.Format("select GoodPK as GoodIDX from Goods{0}", MakeWhereBlock(typeof(Goods), goodDic, useLike)); 
            }

            if (companyInfo!=null)
            {
                IDictionary<string, string> comDic = new Dictionary<string, string>();
                foreach (var prop in typeof(Companies).GetProperties())
                {
                    if (prop.Name.ToLower() == "item" || prop.Name == "RowCount" || prop.Name == "Page")
                    {
                        continue;
                    }
                    if (companyInfo[prop.Name] == null || companyInfo[prop.Name].Replace(" ","") == string.Empty)
                    {
                        continue;
                    }
                    comDic.Add(prop.Name, companyInfo[prop.Name].ToString());
                }
                companyWhere = string.Format("select CompanyPK as SellerIDX from Companies{0}", MakeWhereBlock(typeof(Companies), comDic, useLike)); 
            }

            //[2] 이너뷰 이용한 where정 작성
            StringBuilder sbWhere = new StringBuilder();            
            if (goodsWhere!=string.Empty)
            {
                sbWhere.Append(" where ");
                sbWhere.AppendFormat("GoodIDX in ({0})",goodsWhere);
                if (companyWhere!=string.Empty)
                {
                    sbWhere.Append(" and ");
                }
            }
            if (companyWhere != string.Empty)
            {
                if (goodsWhere==string.Empty)
                {
                    sbWhere.Append(" where ");
                }
                sbWhere.AppendFormat("SellerIDX in ({0})", companyWhere);
            }

            //[3] 쿼리작성
            StringBuilder sbQuery = new StringBuilder();
            sbQuery.Append("Delete from GoodSeller");
            sbQuery.Append(sbWhere.ToString());
            return sbQuery.ToString();
        }
        public string DeleteParts_With_FinalGoods(Goods FinalGoodInfo, bool useLike) 
        {
            IDictionary<string,string> finalDic= new Dictionary<string,string>();
            foreach (var prop in typeof(Goods).GetProperties())
            {
                if (FinalGoodInfo[prop.Name]==null || FinalGoodInfo[prop.Name].ToString()==string.Empty)
                {
                    continue;
                }
                finalDic.Add(prop.Name,FinalGoodInfo[prop.Name].ToString());
            }
            string strWhere = MakeWhereBlock(typeof(Goods),finalDic,useLike);
            string InnerView = string.Format("select GoodPK as FinishedGoodIDX from Goods{0}",strWhere);
            string query = string.Format("Delete from Parts where FinishedGoodIDX in ({0})",InnerView.ToString());
            return query;
        }
        public string DeleteParts(Goods PartsInfo, bool useLike)
        {
            IDictionary<string, string> PartsDic = new Dictionary<string, string>();
            foreach (var prop in typeof(Goods).GetProperties())
            {
                if (PartsInfo[prop.Name] == null || PartsInfo[prop.Name].ToString()==string.Empty)
                {
                    continue;
                }
                PartsDic.Add(prop.Name, PartsInfo[prop.Name].ToString());
            }
            string strWhere = MakeWhereBlock(typeof(Goods), PartsDic, useLike);
            string InnerView = string.Format("select GoodPK as PartIDX from Goods{0}", strWhere);
            string query = string.Format("Delete from Parts where PartIDX in ({0})", InnerView.ToString());
            return query;
        }
        public string DeleteUnitCost(Goods goodInfo, Companies companyInfo, bool useLike) 
        {
            IDictionary<string, string> goodDic = new Dictionary<string, string>();
            if (goodInfo!=null)
            {
                foreach (var prop in typeof(Goods).GetProperties())
                {
                    if (goodInfo[prop.Name] == null || goodInfo[prop.Name].ToString() == string.Empty)
                    {
                        continue;
                    }
                    goodDic.Add(prop.Name, goodInfo[prop.Name].ToString());
                } 
            }
            IDictionary<string, string> companyDic = new Dictionary<string, string>();
            if (companyInfo!=null)
            {
                foreach (var prop in typeof(Companies).GetProperties())
                {
                    if (companyInfo[prop.Name] == null || companyInfo[prop.Name].ToString() == string.Empty)
                    {
                        continue;
                    }
                    companyDic.Add(prop.Name, companyInfo[prop.Name].ToString());
                } 
            }

            StringBuilder sbWhere = new StringBuilder();
            if (goodDic.Count>0)
            {
                sbWhere.Append(" where GoodIDX in (");
                sbWhere.AppendFormat("select GoodPK as GoodIDX from Goods{0}", MakeWhereBlock(typeof(Goods), goodDic, useLike));
                sbWhere.Append(")");
            }
            if (companyDic.Count>0)
            {
                if (goodDic.Count>0)
                {
                    sbWhere.Append(" and ");
                }
                else
                {
                    sbWhere.Append(" where ");
                }
                sbWhere.Append("CompanyIDX in (");
                sbWhere.AppendFormat("select CompanyPK as CompanyIDX from Companies{0}", MakeWhereBlock(typeof(Companies), companyDic, useLike));
                sbWhere.Append(")");
            }
            StringBuilder sbQuery = new StringBuilder();
            sbQuery.AppendFormat("Delete from UnitCost{0}",sbWhere.ToString());
            return sbQuery.ToString();
        }
        public string SelectGoods(Goods goods,bool IsLikeSearch) 
        {
            IDictionary<string, string> dataDic = null;
            if (goods!=null)
            {
                dataDic = new Dictionary<string, string>();
                foreach (var prop in typeof(Goods).GetProperties())
                {
                    if (prop.Name.ToLower() == "item" || goods[prop.Name] == null)
                    {
                        continue;
                    }
                    dataDic.Add(prop.Name, goods[prop.Name].ToString());
                } 
            }
            string query= GetSelectQuery(typeof(Goods),dataDic,IsLikeSearch,true);
            return query;
        }
        public string SelectGoodsAndPartsAndUnitCost(Goods FinishedWork,bool UseLike) 
        {
            IDictionary<string,string> FinalGoodDic= new Dictionary<string,string>();
            foreach (var prop in typeof(Goods).GetProperties())
            {
                try
                {
                    FinalGoodDic.Add(prop.Name, FinishedWork[prop.Name].ToString());
                }
                catch (NullReferenceException)
                {
                    continue;
                }
            }
            string query_Goods = GetSelectQuery(typeof(Goods), FinalGoodDic, UseLike, false);

            StringBuilder sbQuery = new StringBuilder();
            sbQuery.Append("select * from (select good.*,null as FinishedGoodIDX ,null as PartIDX,null as amount,ucost.* from(");
            sbQuery.Append(query_Goods);
            sbQuery.Append(") as good  ");
            sbQuery.Append("left join ");
            sbQuery.Append("(select * from unitcost) as ucost ");
            sbQuery.Append("on ");
            sbQuery.Append("good.GoodPK=ucost.GoodIDX ");
            sbQuery.Append("union all ");
            sbQuery.Append("select good.*,part.*,ucost.* from(");
            sbQuery.Append(query_Goods);
            sbQuery.Append(") as Finished_good ");
            sbQuery.Append("(select * from parts) as part ");
            sbQuery.Append("on ");
            sbQuery.Append("Finished_good.goodPK= part.FinishedGoodIDX ");
            sbQuery.Append("left join ");
            sbQuery.Append("(select * from goods) as good ");
            sbQuery.Append("on ");
            sbQuery.Append("part.PartIDX=good.goodPK ");
            sbQuery.Append("left join ");
            sbQuery.Append("(select * from unitcost) as ucost ");
            sbQuery.Append("on ");
            sbQuery.Append("part.PartIDX=ucost.GoodIDX ");
            sbQuery.Append(") ");
            sbQuery.Append("limit ");
            if (FinishedWork.RowCount != 0)
            {
                sbQuery.AppendFormat("{0} offset {1}", FinishedWork.RowCount, (FinishedWork.Page - 1) * FinishedWork.RowCount);
            }
            else
            {
                sbQuery.AppendFormat("{0} offset {1}", 10, 1);
            }
            string query = sbQuery.ToString();
            return query;
        }
        public string SelectGoodsAndUnitCost(Goods FinishedWork, bool UseLike) 
        {
            IDictionary<string, string> FinishedDic = new Dictionary<string, string>();
            foreach (var prop in typeof(Goods).GetProperties())
            {
                try
                {
                    FinishedDic.Add(prop.Name, FinishedWork[prop.Name].ToString());
                }
                catch (NullReferenceException)
                {
                    continue;
                }
            }
            string query_Goods= GetSelectQuery(typeof(Goods),FinishedDic,UseLike,false);
            StringBuilder sbQuery = new StringBuilder();
            sbQuery.Append("select * from ((");
            sbQuery.Append(query_Goods);
            sbQuery.Append(") as good inner join (select * from UnitCost) as ucost on good.GoodPK=ucost.GoodIDX) limit ");
            if (FinishedWork.RowCount!=0)
            {
                sbQuery.AppendFormat("{0} offset {1}", FinishedWork.RowCount, (FinishedWork.Page - 1) * FinishedWork.RowCount);
            }
            else
            {
                sbQuery.AppendFormat("{0} offset {1}", 10, 1);
            }
            string query = sbQuery.ToString();          
            return query;
        }
        public string SelectGoodsAndSellers(Goods FinishedWork,bool useLike) 
        {
            IDictionary<string, string> GoodData = new Dictionary<string, string>();
            foreach (var prop in typeof(Goods).GetProperties())
            {
                if (FinishedWork[prop.Name]==null)
                {
                    continue;
                }
                GoodData.Add(prop.Name,FinishedWork[prop.Name].ToString());
            }
            string query_Goods= GetSelectQuery(typeof(Goods),GoodData,useLike,false);


            StringBuilder sbQuery = new StringBuilder();
            sbQuery.Append("select * from ((");
            sbQuery.Append(query_Goods);
            sbQuery.Append(") as good inner join (select * from GoodSeller) as seller on good.GoodPK=seller.GoodIDX inner join (select * from UnitCost) as ucost on seller.GoodIDX=ucost.GoodIDX and seller.SellerIDX=ucost.CompanyIDX) limit ");
            if (FinishedWork.RowCount != 0)
            {
                sbQuery.AppendFormat("{0} offset {1}", FinishedWork.RowCount, (FinishedWork.Page-1)*FinishedWork.RowCount);
            }
            else
            {
                sbQuery.AppendFormat("{0} offset {1}", 10, 1);
            }
            string query = sbQuery.ToString();          
            return query;
        }
        #endregion
        #region 공통
        /// <summary>
        /// 문자열중 특수문자를 이스케이프시킴
        /// </summary>
        /// <param name="original"></param>
        /// <returns></returns>
        private string GetEscapedString(string original, bool useLike)
        {
            if (original == null)
            {
                return null;
            }
            string[] arrEscape = { "#", "%" };
            string escaped = original.Replace("'", "''");
            if (useLike)
            {
                foreach (string es in arrEscape)
                {
                    escaped = escaped.Replace("#", "##");
                    escaped = escaped.Replace("%", "#%");
                }
            }
            return escaped;
        }//End of GetEscapedString

        /// <summary>
        /// 해당 VO객체의 메타데이터를 분석해서 Select 쿼리를 반환
        /// VO 객체는 그 타입의 이름과 멤버의 이름 및 멤버의 타입이 동일해야 한다. 
        /// </summary>
        /// <param name="dataType">
        /// VO객체의 타입
        /// </param>
        /// <param name="data">
        /// 검색에 사용할 VO객체의 값과 그 이름을 담은 딕셔너리
        /// 키: VO객체의 프로퍼티 이름
        /// 값: VO객체의 프로퍼티 값
        /// </param>
        /// <param name="IsLikeSearch">
        /// 문자열 검색의 경우에 like검색을 사용할 것인지 정하는 값
        /// </param>
        /// <param name="PartialSearchMode">
        /// 부분범위 검색 구문을 작성할 것인지 결정
        /// </param>        
        /// <returns></returns>
        private string GetSelectQuery(Type dataType, IDictionary<string, string> data, bool IsLikeSearch,bool PartialSearchMode)
        {
            StringBuilder sbSelect = new StringBuilder();
            sbSelect.Append("select * from ");
            sbSelect.Append(dataType.Name);
            String strWhere = string.Empty;
            /**
             * data가 없으면(조건없는 전체검색) where절을 생성하지 않는다
             * **/
            if (data != null)
            {
                strWhere=MakeWhereBlock(dataType, data, IsLikeSearch);
                if (PartialSearchMode)
                {
                    //부분범위 검색
                    int StartRow = Convert.ToInt32(data["RowCount"]) * (Convert.ToInt32(data["Page"]) - 1);
                    strWhere= string.Format("{0}limit {1} offset {2}", strWhere,data["RowCount"], StartRow.ToString());                    
                }                
            }            
            sbSelect.Append(strWhere.ToString());
            return sbSelect.ToString();
        }

        /// <summary>
        /// where절 생성
        /// </summary>
        /// <param name="dataType"></param>
        /// <param name="data"></param>
        /// <param name="IsLikeSearch"></param>
        /// <param name="sbWhere"></param>
        private string MakeWhereBlock(Type dataType, IDictionary<string, string> data, bool IsLikeSearch)
        {
            StringBuilder sbWhere = new StringBuilder();
            foreach (var prop in dataType.GetProperties())
            {
                /**
                 * 키 없으면 다음 요소로 넘어간다
                 * **/
                try
                {
                    if (prop.Name.ToLower() == "item" || data[prop.Name] == null)
                    {
                        continue;
                    }
                    if (prop.Name == "Page" || prop.Name == "RowCount" || prop.Name == "orderby")
                    {
                        continue;
                    }
                    if (sbWhere.Length <= 0)
                    {
                        sbWhere.Append(" where ");
                    }
                    else
                    {
                        sbWhere.Append(" and ");
                    }
                    sbWhere.Append(prop.Name);

                    if (prop.PropertyType == typeof(string))
                    {
                        if (IsLikeSearch)
                        {
                            sbWhere.Append(" like ");
                            sbWhere.Append("'%");
                            sbWhere.Append(GetEscapedString(data[prop.Name].ToString(), IsLikeSearch));
                            sbWhere.Append("%'");
                        }
                        else
                        {
                            sbWhere.Append("=");
                            sbWhere.Append("'");
                            sbWhere.Append(GetEscapedString(data[prop.Name].ToString(), IsLikeSearch));
                            sbWhere.Append("'");
                        }
                    }
                    else
                    {
                        sbWhere.Append("=");
                        sbWhere.Append(data[prop.Name]);
                    }
                }
                catch (KeyNotFoundException)
                {
                    continue;
                }
            }//End of Foreach

            //정렬
            if (data["orderby"]!=null && data["orderby"]!=string.Empty)
            {
                sbWhere.Append(" order by ");
                sbWhere.Append(data["orderby"]);                                
            }
            sbWhere.Append(" ");
            return sbWhere.ToString();
        } //End of MakeWhereBlock
        #endregion
    }
}
