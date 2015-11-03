using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using libHitpan5.enums;
namespace libHitpan5.VO
{
    public class UserInfo
    {
        public string id { get; set; }
        public string password { get; set; }
        public 사용자등급 userType { get; set; }
        public string userAuth { get; set; }
    }
}
