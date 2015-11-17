using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace WebServiceServer.WebServiceVO.Goods.GoodDetail_Sub
{
    [DataContract]
    public class good_unit_info
    {
        [DataMember]
        public Int64 good_idx { get; set; }
        [DataMember]
        public String unit { get; set; }
        [DataMember]
        public String flag_unit { get; set; }
        [DataMember]
        public Int64 amount { get; set; }

        public object this[string param] 
        {
            get
            {
                object val = null;
                switch (param)
                {
                    case "good_idx":    {val = this.good_idx ; break; }
                    case "unit":        {val = this.unit ; break; }
                    case "flag_unit":   {val = this.flag_unit; break; }
                    case "amount":      {val = this.amount; break; }
                }
                return val;
            }
            set 
            {
                switch (param)
                {
                    case "good_idx": {this.good_idx =   Convert.ToInt64     (value) ; break; }
                    case "unit": { this.unit =          Convert.ToString    (value); break; }
                    case "flag_unit": {this.flag_unit = Convert.ToString    (value) ; break; }
                    case "amount": {this.amount =       Convert.ToInt64     (value) ; break; }
                }            
            }
        }
    }
}
