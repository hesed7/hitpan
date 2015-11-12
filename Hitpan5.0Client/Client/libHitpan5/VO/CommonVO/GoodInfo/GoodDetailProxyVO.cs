using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebServiceServer.WebServiceVO.Goods;
using WebServiceServer.WebServiceVO.Goods.GoodDetail_Sub;
namespace libHitpan5.VO.CommonVO.GoodInfo
{
    public class GoodDetailProxyVO
    {
        public GoodsDetail GoodsDetail { get; set; }

        public GoodDetailProxyVO()
        {
            GoodsDetail = new GoodsDetail();
        }

        public object this[string param]
        {
            get 
            {
                object val = null;
                switch (param)
                {
                    case "etc_info":            { val = this.GoodsDetail.etc_info; break; }
                    case "good_image":          { val = this.GoodsDetail.good_image; break; }
                    case "good_maker":          { val = this.GoodsDetail.good_maker; break; }
                    case "good_name":           { val = this.GoodsDetail.good_name; break; }
                    case "good_nickname":       { val = this.GoodsDetail.good_nickname; break; }
                    case "good_pk":             { val = this.GoodsDetail.good_pk; break; }
                    case "good_subname":        { val = this.GoodsDetail.good_subname; break; }
                    case "good_unit_infoList":  { val = this.GoodsDetail.good_unit_infoList; break; }
                    case "goodpartList":        { val = this.GoodsDetail.goodpartList; break; }
                    case "goodsellerList":      { val = this.GoodsDetail.goodsellerList; break; }
                    case "properstock":         { val = this.GoodsDetail.properstock; break; }
                    case "status":              { val = this.GoodsDetail.status; break; }
                    case "unitcostList":        { val = this.GoodsDetail.unitcostList; break; }

                    default:
                        break;
                }
                return val;
            }
            set 
            {
                switch (param)
                {
                    case "etc_info": {this.GoodsDetail.etc_info  =(string) value ;break; }          
                    case "good_image":{this.GoodsDetail.good_image =(string) value ;break; }
                    case "good_maker":{this.GoodsDetail.good_maker =(string) value ;break; }
                    case "good_name":{this.GoodsDetail.good_name = (string)value ;break; }
                    case "good_nickname":{this.GoodsDetail.good_nickname = (string)value ;break; }
                    case "good_pk":{this.GoodsDetail.good_pk = (Int64)value ;break; }
                    case "good_subname":{this.GoodsDetail.good_subname = (string)value ;break; }
                    case "good_unit_infoList":{this.GoodsDetail.good_unit_infoList = (good_unit_info[])value ;break; }
                    case "goodpartList":{this.GoodsDetail.goodpartList =(goodpart[]) value ;break; }
                    case "goodsellerList":{ this.GoodsDetail.goodsellerList=(goodseller[]) value ;break; }
                    case "properstock":{this.GoodsDetail.properstock = (long)value ;break; }
                    case "status":{ this.GoodsDetail.status= (string)value ;break; }
                    case "unitcostList": { this.GoodsDetail.unitcostList =(unitcost[]) value; break; }
                }            
            }
        }
    }
}
