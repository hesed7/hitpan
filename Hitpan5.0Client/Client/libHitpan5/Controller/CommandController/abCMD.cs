using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using libHitpan5.Controller.Common.Loger;
using libHitpan5.Model.DataModel;
using libHitpan5.VO.CommonVO;
using libHitpan5.VO.CommonVO.UserInfo;
namespace libHitpan5.Controller.CommandController
{
    public abstract class abCMD :ICMD
    {
        public UserAuthProxyVO RequiredAuth { get; set; }

        private Loger loger { get; set; }
        private string work { get; set; }

        private SQLDataServiceModel dataModel { get; set; }
        public abCMD(string work, SQLDataServiceModel dataModel)
        {
            this.work = work;
            this.loger = new Loger(dataModel);
        }
        abstract public void Do();
        abstract public void UnDo();

        protected void WriteDoLog() 
        {
            loger.WriteLog(string.Format("{0} 시도",this.work));
        }
        protected void WriteUnDoLog()
        {
            loger.WriteLog(string.Format("{0} 취소 시도", this.work));
        }
        protected void WriteDoSuccLog() 
        {
            loger.WriteLog(string.Format("{0} 성공", this.work));
        }
        protected void WriteUnDoSuccLog()
        {
            loger.WriteLog(string.Format("{0} 취소 성공", this.work));
        }
        protected void WriteDoFailureLog(Exception e) 
        {
            loger.WriteLog(string.Format("{0} 실패/// 원인:{1} ///위치:{2}", this.work,e.Message,e.Source));
        }
        protected void WriteUnDoFailureLog(Exception e)
        {
            loger.WriteLog(string.Format("{0} 취소 실패/// 원인:{1} ///위치:{2}", this.work, e.Message, e.Source));
        }
    }
}





