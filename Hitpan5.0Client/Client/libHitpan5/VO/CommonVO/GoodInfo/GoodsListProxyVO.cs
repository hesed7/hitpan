using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebServiceServer.WebServiceVO.Goods;
namespace libHitpan5.VO.CommonVO.GoodInfo
{
    public class GoodsListProxyVO
    {
        public long TotalRowCount { get; set; }
        public GoodsListVO GoodsListVO { get; set; }

        public GoodsListProxyVO()
        {
            this.GoodsListVO = new GoodsListVO();
        }

        public object this[string param] 
        {
            get 
            {
                object val = null;
                switch (param)
                {
                    case "good_image":      { val = this.GoodsListVO.good_image; break; }
                    case "good_maker":      { val = this.GoodsListVO.good_maker; break; }
                    case "good_name":       { val = this.GoodsListVO.good_name; break; }
                    case "good_nickname":   { val = this.GoodsListVO.good_nickname; break; }
                    case "good_pk":         { val = this.GoodsListVO.good_pk; break; }
                    case "good_subname":    { val = this.GoodsListVO.good_subname; break; }
                    case "status":          { val = this.GoodsListVO.status; break; }
                    default:
                        break;
                }
                return val;
            }
            set 
            {
                switch (param)
                {
                    case "good_image":      { this.GoodsListVO.good_image = value.ToString(); break; }
                    case "good_maker":      { this.GoodsListVO.good_maker = value.ToString(); break; }
                    case "good_name":       { this.GoodsListVO.good_name = value.ToString(); break; }
                    case "good_nickname":   { this.GoodsListVO.good_nickname = value.ToString(); break; }
                    case "good_pk":         { this.GoodsListVO.good_pk=Convert.ToInt64(value);break; }
                    case "good_subname":    { this.GoodsListVO.good_subname = value.ToString(); break; }
                    case "status":          { this.GoodsListVO.status = value.ToString(); break; }
                    default:
                        break;
                }                                                         
            }
        }
    }
}
