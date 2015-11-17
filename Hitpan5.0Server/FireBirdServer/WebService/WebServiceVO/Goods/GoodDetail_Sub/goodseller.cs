using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace WebServiceServer.WebServiceVO.Goods.GoodDetail_Sub
{
    [DataContract]
    public class goodseller
    {
        [DataMember]
        public Int64 goods_idx { get; set; }
        [DataMember]
        public Int64 seller_idx { get; set; }
        [DataMember]
        public string company_name { get; set; }
        [DataMember]
        public int company_worktime { get; set; }
        [DataMember]
        public string company_phone { get; set; }
        [DataMember]
        public string company_fax { get; set; }
        [DataMember]
        public string company_addr { get; set; }

        public object this[string param] 
        {
            get 
            {
                object val = null;
                switch (param)
                {
                    case "goods_idx": {val =  this.goods_idx ;break; }
                    case "seller_idx": {val = this.seller_idx ;break; }
                    case "company_name": {val = this.company_name ;break; }
                    case "company_worktime": {val = this.company_worktime ;break; }
                    case "company_phone": {val = this.company_phone ;break; }
                    case "company_fax": {val = this.company_fax ;break; }
                    case "company_addr": {val = this.company_addr ;break; }
                    default:
                        break;
                }
                return val;
            }
            set 
            {
                switch (param)
                {
                    case "goods_idx": {this.goods_idx = Convert.ToInt64(value) ;break; }
                    case "seller_idx": {this.seller_idx = Convert.ToInt64(value) ;break; }
                    case "company_name": {this.company_name = value.ToString() ;break; }
                    case "company_worktime": {this.company_worktime = Convert.ToInt32(value) ;break; }
                    case "company_phone": {this.company_phone = value.ToString() ;break; }
                    case "company_fax": {this.company_fax   = value.ToString() ;break; }
                    case "company_addr": {this.company_addr = value.ToString() ;break; }
                    default:
                        break;
                }            
            }
        }
    }
}
