using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebServiceServer.WebServiceVO.Goods;

namespace WebServiceServer.WebServiceSQL.Goods
{
    class GoodsQuery
    {
        #region SelectGoodList
        internal string SelectGoodsList
            (
            int Page,
            int RowCount,
            string good_name,
            string good_subName,
            string good_nickname,
            string good_maker
            )
        {
            int firstRow = ((Page - 1) * RowCount) + 1;
            int lastRow = ((Page) * RowCount);

            StringBuilder sbGoods = new StringBuilder();
            sbGoods.Append(" select goodsInfo.* ");
            sbGoods.Append(" from( ");
            sbGoods.Append(" SELECT (ROW_NUMBER() OVER()) AS ROWNUM, *");
            sbGoods.Append(" FROM goods");
            sbGoods.Append(" ) goodsInfo");
            sbGoods.Append(" where ");
            sbGoods.Append(" rownum between");
            sbGoods.Append(" ");
            sbGoods.Append(firstRow);
            sbGoods.Append(" and ");
            sbGoods.Append(lastRow);
            sbGoods.Append(GetWhereClause(good_name, good_subName, good_nickname, good_maker));

            return sbGoods.ToString();
        }//End of SelectGoodsList

        internal string GetGoodsCount
            (
                string good_name,
                string good_subName,
                string good_nickname,
                string good_maker
            )
        {
            string where = " where " + GetWhereClause(good_name, good_subName, good_nickname, good_maker);
            string query = string.Format("select count(good_pk) from goods");
            if ((where.Replace(" where ",string.Empty)).Length > 0)
            {
                query += where;
            }
            return query;
        } 
        #endregion
        #region SelectGoodDetails
        public string GoodDetails(long Good_PK) 
        {
            string Query =  string.Format
                (
                    @"
                    select *
                    from 
                    goods
                    left outer join
                    (
                    select * from
                    goodseller
                    inner join
                    companies
                    on
                    goodseller.seller_idx=companies.company_pk
                    ) goodseller
                    on
                    goods.good_pk=goodseller.goods_idx
                    left outer join
                    unitcost
                    on
                    goods.good_pk = unitcost.good_idx
                    left outer join
                    good_unit_info
                    on
                    good_unit_info.good_idx=goods.good_pk
                    left outer join
                    goodparts
                    on
                    goodparts.final_good_idx = goods.good_pk
                    where
                    good_pk = '{0}'
                    ", Good_PK
                );
            return Query;
        }
        public string GoodDetails_GoodName(string GoodName,bool UseLike)
        {
            string where = "";
            if (UseLike)
            {
                where = string.Format(" good_name like '%{0}%'", GoodName);
            }
            else
            {
                where = string.Format(" good_name = '{0}'", GoodName);
            }
            string Query = string.Format
                (
                    @"
                    select *
                    from 
                    goods
                    left outer join
                    (
                    select * from
                    goodseller
                    inner join
                    companies
                    on
                    goodseller.seller_idx=companies.company_pk
                    ) goodseller
                    on
                    goods.good_pk=goodseller.goods_idx
                    left outer join
                    unitcost
                    on
                    goods.good_pk = unitcost.good_idx
                    left outer join
                    good_unit_info
                    on
                    good_unit_info.good_idx=goods.good_pk
                    left outer join
                    goodparts
                    on
                    goodparts.final_good_idx = goods.good_pk
                    where
                    {0}
                    ", where
                );
            return Query;
        }
        public string GoodDetails_GoodSubName(string good_subname, bool UseLike)
        {
            string where = "";
            if (UseLike)
            {
                where = string.Format(" good_subname like '%{0}%'", good_subname);
            }
            else
            {
                where = string.Format(" good_subname = '{0}'", good_subname);
            }
            string Query = string.Format
                (
                    @"
                    select *
                    from 
                    goods
                    left outer join
                    (
                    select * from
                    goodseller
                    inner join
                    companies
                    on
                    goodseller.seller_idx=companies.company_pk
                    ) goodseller
                    on
                    goods.good_pk=goodseller.goods_idx
                    left outer join
                    unitcost
                    on
                    goods.good_pk = unitcost.good_idx
                    left outer join
                    good_unit_info
                    on
                    good_unit_info.good_idx=goods.good_pk
                    left outer join
                    goodparts
                    on
                    goodparts.final_good_idx = goods.good_pk
                    where
                    {0}
                    ", where
                );
            return Query;
        }
        public string GoodDetails_GoodNickName(string good_nickname, bool UseLike)
        {
            string where = "";
            if (UseLike)
            {
                where = string.Format(" good_nickname like '%{0}%'", good_nickname);
            }
            else
            {
                where = string.Format(" good_nickname = '{0}'", good_nickname);
            }
            string Query = string.Format
                (
                    @"
                    select *
                    from 
                    goods
                    left outer join
                    (
                    select * from
                    goodseller
                    inner join
                    companies
                    on
                    goodseller.seller_idx=companies.company_pk
                    ) goodseller
                    on
                    goods.good_pk=goodseller.goods_idx
                    left outer join
                    unitcost
                    on
                    goods.good_pk = unitcost.good_idx
                    left outer join
                    good_unit_info
                    on
                    good_unit_info.good_idx=goods.good_pk
                    left outer join
                    goodparts
                    on
                    goodparts.final_good_idx = goods.good_pk
                    where
                    {0}
                    ", where
                );
            return Query;
        }
        public string GoodDetails_GoodMaker(string good_maker, bool UseLike)
        {
            string where = "";
            if (UseLike)
            {
                where = string.Format(" good_maker like '%{0}%'", good_maker);
            }
            else
            {
                where = string.Format(" good_maker = '{0}'", good_maker);
            }
            string Query = string.Format
                (
                    @"
                    select *
                    from 
                    goods
                    left outer join
                    (
                    select * from
                    goodseller
                    inner join
                    companies
                    on
                    goodseller.seller_idx=companies.company_pk
                    ) goodseller
                    on
                    goods.good_pk=goodseller.goods_idx
                    left outer join
                    unitcost
                    on
                    goods.good_pk = unitcost.good_idx
                    left outer join
                    good_unit_info
                    on
                    good_unit_info.good_idx=goods.good_pk
                    left outer join
                    goodparts
                    on
                    goodparts.final_good_idx = goods.good_pk
                    where
                    {0}
                    ", where
                );
            return Query;
        }
        #endregion
        #region UpdateGood
        internal String UpdateGood(long good_pk,IDictionary<string,string> updates) 
        {
            StringBuilder sbUpdate = new StringBuilder();
            sbUpdate.Append("update goods set ( ");
            foreach (string col in updates.Keys)
            {
                sbUpdate.Append(col);
                sbUpdate.Append(" = ");
                if (col!="properstock")
                {
                    sbUpdate.Append("'"); 
                }
                sbUpdate.Append(updates[col]);
                if (col != "properstock")
                {
                    sbUpdate.Append("'");
                }
                
            }
            sbUpdate.AppendFormat(" where good_pk='{0}'",good_pk);
            return sbUpdate.ToString();
        }       
        #endregion
        #region Insert
        internal string InsertGood(IDictionary<string, string> insertValue)
        {
            StringBuilder sbColname = new StringBuilder();
            StringBuilder sbValues = new StringBuilder();
            foreach (string colName in insertValue.Keys)
            {
                if (sbColname.Length > 0)
                {
                    sbColname.Append(",");
                    sbValues.Append(",");
                }
                sbColname.Append(colName);

                if (colName != "properstock")
                {
                    sbValues.Append("'");
                    sbValues.Append(insertValue[colName]);
                    sbValues.Append(",");
                }
                else
                {
                    sbValues.Append(insertValue[colName]);
                }
            }
            return string.Format("insert into goods({0})values({1})", sbColname.ToString(), sbValues.ToString());
        } 
        #endregion
        private string GetWhereClause(string good_name, string good_subName, string good_nickname, string good_maker)
        {
            StringBuilder sbCheck = new StringBuilder();
            if (good_name != null && sbCheck.Length > 0)
            {
                sbCheck.Append(" and ");
                sbCheck.Append(" good_name ");
                sbCheck.Append(" >= ");
                sbCheck.AppendFormat("'{0}' ", good_name);
                sbCheck.Append(" and ");
                sbCheck.Append(" good_name ");
                sbCheck.Append(" like ");
                sbCheck.AppendFormat("'%{0}%' ", good_name);
            }
            else if (good_name != null)
            {
                sbCheck.Append(" good_name ");
                sbCheck.Append(" >= ");
                sbCheck.AppendFormat("'%{0}%' ", good_name);
                sbCheck.Append(" and ");
                sbCheck.Append(" good_name ");
                sbCheck.Append(" like ");
                sbCheck.AppendFormat("'%{0}%' ", good_name);
            }
            if (good_subName != null && sbCheck.Length > 0)
            {
                sbCheck.Append(" and ");
                sbCheck.Append(" good_subName ");
                sbCheck.Append(" >= ");
                sbCheck.AppendFormat("'%{0}%' ", good_subName);
                sbCheck.Append(" and ");
                sbCheck.Append(" good_subName ");
                sbCheck.Append(" like ");
                sbCheck.AppendFormat("'%{0}%' ", good_subName);
            }
            else if (good_subName != null)
            {
                sbCheck.Append(" good_name ");
                sbCheck.Append(" >= ");
                sbCheck.AppendFormat("'%{0}%' ", good_name);
                sbCheck.Append(" and ");
                sbCheck.Append(" good_name ");
                sbCheck.Append(" like ");
                sbCheck.AppendFormat("'%{0}%' ", good_name);
            }
            if (good_nickname != null && sbCheck.Length > 0)
            {
                sbCheck.Append(" and ");
                sbCheck.Append(" good_nickname ");
                sbCheck.Append(" >= ");
                sbCheck.AppendFormat("'%{0}%' ", good_nickname);
                sbCheck.Append(" and ");
                sbCheck.Append(" good_nickname ");
                sbCheck.Append(" like ");
                sbCheck.AppendFormat("'%{0}%' ", good_nickname);
            }
            else if (good_nickname != null)
            {
                sbCheck.Append(" good_name ");
                sbCheck.Append(" >= ");
                sbCheck.AppendFormat("'%{0}%' ", good_name);
                sbCheck.Append(" and ");
                sbCheck.Append(" good_name ");
                sbCheck.Append(" like ");
                sbCheck.AppendFormat("'%{0}%' ", good_name);
            }
            if (good_maker != null && sbCheck.Length > 0)
            {
                sbCheck.Append(" and ");
                sbCheck.Append(" good_maker ");
                sbCheck.Append(" >= ");
                sbCheck.AppendFormat("'%{0}%' ", good_maker);
                sbCheck.Append(" and ");
                sbCheck.Append(" good_maker ");
                sbCheck.Append(" like ");
                sbCheck.AppendFormat("'%{0}%' ", good_maker);
            }
            else if (good_maker != null)
            {
                sbCheck.Append(" good_name ");
                sbCheck.Append(" >= ");
                sbCheck.AppendFormat("'%{0}%' ", good_name);
                sbCheck.Append(" and ");
                sbCheck.Append(" good_name ");
                sbCheck.Append(" like ");
                sbCheck.AppendFormat("'%{0}%' ", good_name);
            }
            return sbCheck.ToString();
        }
    }
}
