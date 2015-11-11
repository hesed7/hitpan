using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
namespace WebServiceServer.webService.WebServiceVO.Goods
{
    [DataContract]
    public class GoodsListVO
    {
        [DataMember]
        public long good_pk { get; set; }
        [DataMember]
        public string good_image { get; set; }
        [DataMember]
        public string good_name { get; set; }
        [DataMember]
        public string good_subname { get; set; }
        [DataMember]
        public string good_nickname { get; set; }
        [DataMember]
        public string good_maker { get; set; }
        [DataMember]
        public string status { get; set; }

        public object this[string param]
        {
            get 
            {
                object val = null;
                switch (param)
                {
                    case "good_pk": { val= this.good_pk; break; }
                    case "good_image": { val = this.good_image; break; }
                    case "good_name": { val = this.good_name; break; }
                    case "good_subname": { val = this.good_subname; break; }
                    case "good_nickname": { val = this.good_nickname; break; }
                    case "good_maker": { val = this.good_maker; break; }
                    case "status": { val = this.status; break; }
                    default:
                        break;
                }
                return val;
            }
            set 
            {

                switch (param)
                {
                    case "good_pk": {this.good_pk = (long)value; break; }
                    case "good_image": {this.good_image = (string)value; break; }
                    case "good_name": { this.good_name = (string)value; break; }
                    case "good_subname": { this.good_subname = (string)value; break; }
                    case "good_nickname": {this.good_nickname = (string)value; break; }
                    case "good_maker": { this.good_maker = (string)value; break; }
                    case "status": { this.status = (string)value; break; }
                }
            
            }
        }
    }
}
