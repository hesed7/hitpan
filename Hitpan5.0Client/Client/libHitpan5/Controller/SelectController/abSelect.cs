using libHitpan5.Controller.Common.DocumentController;
using libHitpan5.Controller.Common.Loger;
using libHitpan5.Model.DataModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using libHitpan5.VO.CommonVO;
namespace libHitpan5.Controller.SelectController
{
    public abstract class abSelect :ISelect
    {
        public UserAuth RequiredAuth { get; set; }

        private SQLDataServiceModel dataModel { get; set; }
        internal string work { get; set; }
        private Loger loger { get; set; }

        /// <summary>
        /// 문서를 작성히는데 사용될 컨트롤러
        /// </summary>
        protected IDocController docController { get; set; }
        /// <summary>
        /// 문서작성시 RDLC에 데이터로 들어갈 데이터테이블
        /// </summary>
        protected DataTable DocumentData { get; set; }
        public abSelect(string work, SQLDataServiceModel dataModel)
        {
            this.work = work;
            this.dataModel = dataModel;
            this.loger = new Loger(this.dataModel);
        }
      
        public abstract object GetData();
        public void GetDocument()
        {
            try
            {
                WriteDocLog();
                this.docController.MakeDoc(DocumentData);
                WriteDocSuccLog();
            }
            catch (Exception e)
            {
                WriteDocFailureLog(e);
            }
        }
        #region 로그
        protected void WriteDoLog()
        {
            loger.WriteLog(string.Format("{0} 시도", this.work));
        }
        protected void WriteDoSuccLog()
        {
            loger.WriteLog(string.Format("{0} 성공", this.work));
        }
        protected void WriteDoFailureLog(Exception e)
        {
            loger.WriteLog(string.Format("{0} 실패/// 원인:{1} ///위치:{2}", this.work, e.Message, e.Source));
        }
        private void WriteDocLog()
        {
            loger.WriteLog(string.Format("{0}도큐먼트 작성 시도", this.work));
        }
        private void WriteDocSuccLog()
        {
            loger.WriteLog(string.Format("{0}도큐먼트 작성 성공", this.work));
        }
        private void WriteDocFailureLog(Exception e)
        {
            loger.WriteLog(string.Format("{0}도큐먼트 작성 실패/// 원인:{1} ///위치:{2}", this.work, e.Message, e.Source));
        } 
        #endregion
    }
}
