using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServiceServer.Enums;
using WebServiceServer.WebServiceVO.Settings;
namespace libHitpan5.VO
{
    public class MyCompanyProxyVO
    {
        public MyCompany MyCompany { get; set; }
        public MyCompanyProxyVO()
        {
            this.MyCompany = new MyCompany();
        }
        public string this[string key] 
        {
            get 
            {
                string val = string.Empty;
                switch (key)
	            {
                    case "myName": { val = MyCompany.myName; break; }
                    case "myPostNo": { val = MyCompany.myPostNo; break; }
                    case "myDetailAddress": { val = MyCompany.myDetailAddress; break; }
                    case "B_N": { val = MyCompany.B_N; break; }
                    case "subB_N": { val = MyCompany.subB_N; break; }
                    case "RegistryNumber": { val = MyCompany.RegistryNumber; break; }
                    case "chairMan": { val = MyCompany.chairMan; break; }
                    case "phone": { val = MyCompany.phone; break; }
                    case "fax": { val = MyCompany.fax; break; }
                    case "etc": { val = MyCompany.etc; break; }
                    case "email": { val = MyCompany.email; break; }
                    case "startDate": { val = MyCompany.startDate; break; }
                    case "licence": { val = MyCompany.licence; break; }
                    case "businessType": { val = MyCompany.businessType; break; }
                    case "subBusinessType": { val = MyCompany.subBusinessType; break; }
                    case "homePage": { val = MyCompany.homePage; break; }
		            default:
                    break;
	            }
                return val;
            }
            set 
            {
                switch (key)
                {
                    case "myName": { MyCompany.myName = value; break; }
                    case "myPostNo": { MyCompany.myPostNo = value; break; }
                    case "myDetailAddress": { MyCompany.myDetailAddress = value; break; }
                    case "B_N": { MyCompany.B_N = value; break; }
                    case "subB_N": { MyCompany.subB_N = value; break; }
                    case "RegistryNumber": { MyCompany.RegistryNumber = value; break; }
                    case "chairMan": { MyCompany.chairMan = value; break; }
                    case "phone": { MyCompany.phone = value; break; }
                    case "fax": { MyCompany.fax = value; break; }
                    case "etc": { MyCompany.etc = value; break; }
                    case "email": { MyCompany.email = value; break; }
                    case "startDate": { MyCompany.startDate = value; break; }
                    case "licence": { MyCompany.licence = value; break; }
                    case "businessType": { MyCompany.businessType = value; break; }
                    case "subBusinessType": { MyCompany.subBusinessType = value; break; }
                    case "homePage": { MyCompany.homePage = value; break; }
                    default:
                        break;
                }
            }
        }
    }
}
