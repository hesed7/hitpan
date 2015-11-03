using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace libHitpan5.VO.DBTableVO.CompanyInfo
{
    public class Companies
    {
        public long? CompanyPK { get; set; }
        public string CompanyName { get; set; }
        public string CompanyPostNo { get; set; }
        public string CompanyDetailAddress { get; set; }
        public string B_N { get; set; }
        /// <summary>
        /// 종사업자번호
        /// </summary>
        public string subB_N { get; set; }
        /// <summary>
        /// 법인번호
        /// </summary>
        public string RegistryNumber { get; set; }
        public string chairMan { get; set; }
        public string phone { get; set; }
        public string fax { get; set; }
        public string etc { get; set; }
        public string email { get; set; }
        public string startDate { get; set; }
        public string businessType { get; set; }
        public string subBusinessType { get; set; }
        public string homePage { get; set; }
        public string this[string key]
        {
            get
            {
                string val = string.Empty;
                switch (key)
                {
                    case "CompanyName": { val = this.CompanyName; break; }
                    case "CompanyPostNo": { val = this.CompanyPostNo; break; }
                    case "CompanyDetailAddress": { val = this.CompanyDetailAddress; break; }
                    case "B_N": { val = this.B_N; break; }
                    case "subB_N": { val = this.subB_N; break; }
                    case "RegistryNumber": { val = this.RegistryNumber; break; }
                    case "chairMan": { val = this.chairMan; break; }
                    case "phone": { val = this.phone; break; }
                    case "fax": { val = this.fax; break; }
                    case "etc": { val = this.etc; break; }
                    case "email": { val = this.email; break; }
                    case "startDate": { val = this.startDate; break; }
                    case "businessType": { val = this.businessType; break; }
                    case "subBusinessType": { val = this.subBusinessType; break; }
                    case "homePage": { val = this.homePage; break; }
                    default:
                        break;
                }
                return val;
            }
            set
            {
                switch (key)
                {
                    case "CompanyName": { this.CompanyName = value; break; }
                    case "CompanyPostNo": { this.CompanyPostNo = value; break; }
                    case "CompanyDetailAddress": { this.CompanyDetailAddress = value; break; }
                    case "B_N": { this.B_N = value; break; }
                    case "subB_N": { this.subB_N = value; break; }
                    case "RegistryNumber": { this.RegistryNumber = value; break; }
                    case "chairMan": { this.chairMan = value; break; }
                    case "phone": { this.phone = value; break; }
                    case "fax": { this.fax = value; break; }
                    case "etc": { this.etc = value; break; }
                    case "email": { this.email = value; break; }
                    case "startDate": { this.startDate = value; break; }
                    case "businessType": { this.businessType = value; break; }
                    case "subBusinessType": { this.subBusinessType = value; break; }
                    case "homePage": { this.homePage = value; break; }
                    default:
                        break;
                }
            }
        }
    }
}
