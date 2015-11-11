using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Runtime.Serialization;
using WebServiceServer.WebServiceVO.Users;
using WebServiceServer.Enums;
namespace WebServiceServer.WebServiceVO.Users
{
    [DataContract]
    public class UsersVO
    {
        [DataMember]
        public string UserID { get; set; }
        [DataMember]
        public string UserPassword { get; set; }
        [DataMember]
        public UserAuth UserAuth { get; set; }
        [DataMember]
        public 사용자등급 UserType { get; set; }
    }
}
