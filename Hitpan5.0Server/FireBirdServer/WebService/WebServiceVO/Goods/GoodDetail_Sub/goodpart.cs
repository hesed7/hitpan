using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace WebServiceServer.WebServiceVO.Goods.GoodDetail_Sub
{
    [DataContract]
    public class goodpart
    {
        [DataMember]
        public Int64 final_good_idx { get; set; }
        [DataMember]
        public Int64 required_good { get; set; }
        [DataMember]
        public Int64 required_amount { get; set; }

        public object this[string param] 
        {
            get 
            {
                object val = null;
                switch (param)
                {
                    case "final_good_idx":  {val = this.final_good_idx ;break; }
                    case "required_good":   { val = this.required_good; ;break; }
                    case "required_amount": { val = this.required_amount; break; }
                    default:
                        break;
                }
                return val;
            }
            set 
            {
                switch (param)
                {
                    case "final_good_idx": {this.final_good_idx     = Convert.ToInt64(value) ;break; }
                    case "required_good": { this.required_good      = Convert.ToInt64(value) ; break; }
                    case "required_amount": {this.required_amount   = Convert.ToInt64(value) ;break; }
                    default:
                        break;
                }            
            }
        }
    }
}
