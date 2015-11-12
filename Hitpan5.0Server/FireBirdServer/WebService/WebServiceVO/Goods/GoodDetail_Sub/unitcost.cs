using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using WebServiceServer.Enums;
namespace WebServiceServer.WebServiceVO.Goods.GoodDetail_Sub
{
    [DataContract]
    public class unitcost
    {
        [DataMember]
        public Int64 good_idx { get; set; }
        [DataMember]
        public Int64 company_idx { get; set; }
        [DataMember]
        public UnitCostType cost_type { get; set; }
        [DataMember]
        public Int64 cost { get; set; }
        [DataMember]
        public bool is_free_tax { get; set; }
        [DataMember]
        public bool contain_tax { get; set; }
        [DataMember]
        public string unit { get; set; }

        public object this[string param]
        {
            get{
                object val = null;
                switch (param)
	            {
                    case "good_idx": { val = this.good_idx; break; }
                    case "company_idx": { val = this.company_idx; break; }
                    case "cost_type": { val = this.cost_type; break; }
                    case "cost": { val = this.cost; break; }
                    case "is_free_tax": { val = this.is_free_tax; break; }
                    case "contain_tax": {val = this.contain_tax; break; }
                    case "unit": { val = this.unit; break; }
	            }
                return val;
            }
            set
            {
                switch (param)
                {
                    case "good_idx": {this.good_idx = (Int64)value; break; }
                    case "company_idx": { this.company_idx = (Int64)value; break; }
                    case "cost_type": {this.cost_type = (UnitCostType)Enum.Parse(typeof(UnitCostType),value.ToString()); break; }
                    case "cost": { this.cost = (Int64)value; break; }
                    case "is_free_tax": { this.is_free_tax = (bool)value; break; }
                    case "contain_tax": { this.contain_tax = (bool)value; break; }
                    case "unit": { this.unit = (string)value; break; }
                }            
            }
        }
    }
}
