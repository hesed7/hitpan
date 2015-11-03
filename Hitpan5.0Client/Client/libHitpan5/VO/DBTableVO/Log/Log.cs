using libHitpan5.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace libHitpan5.VO
{
    public class Log
    {
        public DateTime timeline { get; set; }
        /// <summary>
        /// 인덱서로 값을 가져오면 int로 전환되서 값을 반환한다
        /// </summary>
        public LogType type { get; set; }
        public string user { get; set; }
        public string log { get; set; }
        internal object this[string key] 
        {
            get 
            {
                object val = null;
                switch (key)
                {
                    case "type":
                        {
                            val = Convert.ToInt32(type);
                            break;
                        }
                    case "user":
                        {
                            val = user;
                            break;
                        }
                    case "log":
                        {
                            val = log;
                            break;
                        }
                    default:
                        break;
                }
                return val;
            }//End of Get
            set 
            {
                switch (key)
                {
                    case "type":
                        {
                            type=(LogType)value;
                            break;
                        }
                    case "user":
                        {
                            user=value.ToString();
                            break;
                        }
                    case "log":
                        {
                            log=value.ToString();
                            break;
                        }
                    default:
                        break;
                }
            }//End of Set
        }//End of Indexer
    }
}
