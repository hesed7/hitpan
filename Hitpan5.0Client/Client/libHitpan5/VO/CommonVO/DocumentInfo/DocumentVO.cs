using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using libHitpan5.enums;
using System.Drawing.Printing;
namespace libHitpan5.VO.DocumentInfo
{
    public class DocumentVO
    {
        /// <summary>
        /// RDLC 리스트
        /// </summary>
        public IList<RDLC> RDLCList { get; set; }
        /// <summary>
        /// 기본 RDLC
        /// </summary>
        public RDLC DefaultRDLC { get; set; }
        public object DocumentDetailInfo { get; set; }
        public string StampImagePath { get; set; }
        public DocumentVO()
        {
            this.DefaultRDLC = new RDLC();
            this.RDLCList = new List<RDLC>();
        }
    }
}
