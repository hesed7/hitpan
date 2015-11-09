using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Runtime.Serialization;
namespace WebService.WebServiceVO.Users
{
    [DataContract]
    public class UsersVO
    {
        [DataMember]
        public string UserID { get; set; }
        [DataMember]
        public string UserPassword { get; set; }
        [DataMember]
        public string UserAuth { get; set; }
        [DataMember]
        public int UserType { get; set; }
    }
}
