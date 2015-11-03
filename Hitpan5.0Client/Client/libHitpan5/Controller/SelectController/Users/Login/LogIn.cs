using libHitpan5.Controller.CommandListener;
using libHitpan5.Controller.Common.DocumentController;
using libHitpan5.Model.DataModel;
using libHitpan5.VO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace libHitpan5.Controller.SelectController.Login
{
    class LogIn :abSelect
    {
        private IDataModel dataModel { get; set; }
        public string id { get; set; }
        public string password { get; set; }
        public LogIn(string id,string password)
            : base(string.Format("{0} 아이디로 로그인", id), Hitpan5ClientLibrary.SQLDataServiceModel)
        {
            this.dataModel = Hitpan5ClientLibrary.SQLDataServiceModel;
            this.id = id;
            this.password = password;
        }
        override public object GetData() 
        {
            //아이디, 패스워드 일치하면 UserInfo반환 일치하지 않으면 false 반환
            try
            {
                base.WriteDoLog();
                UserListener UserListener =new UserListener(this.dataModel);
                object returnValue = UserListener.Login(this.id, this.password);
                if (returnValue==null)
                {
                    throw new Exception("아이디 또는 패스워드가 맞지 않습니다");
                }
                base.WriteDoSuccLog();
                return returnValue;
            }
            catch (Exception e)
            {
                base.WriteDoFailureLog(e);
                return false;
            }
        }
    }
}
