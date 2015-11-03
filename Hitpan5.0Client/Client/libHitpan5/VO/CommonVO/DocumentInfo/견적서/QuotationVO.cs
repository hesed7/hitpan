using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
namespace libHitpan5.VO
{
    /// <summary>
    /// 견적서 작성시 사용하는 데이터 프록시클래스
    /// </summary>
    public class QuotationVO
    {
        public Font font { get; set; }
        public Font HeaderFont { get; set; }
        /// <summary>
        /// 견적일자
        /// </summary>
        public string QuotationDate { get; set; }
        public string EstimateSheetNumber { get; set; }
        public int EstimateCount { get; set; }
        public string 품명 { get; set; }
        public string 규격 { get; set; }
        public string 단위 { get; set; }
        public string 수량 { get; set; }
        public string 단가 { get; set; }
        public string 부가세액 { get; set; }
        /// <summary>
        /// 견적비고
        /// </summary>
        public string etc { get; set; }
        public string MyName { get; set; }
        public string MyAddress { get; set; }
        /// <summary>
        /// 담당자
        /// </summary>
        public string MyEmployee { get; set; }
        public string MyPhone { get; set; }
        public string Myemail { get; set; }
        public string Myfax { get; set; }
        public string MyHomePage { get; set; }

        public string CompanyName { get; set; }
        /// <summary>
        /// 결재조건
        /// </summary>
        public string DealTerms { get; set; }
    }
}
