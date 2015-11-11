using libHitpan5.Controller.CommandListener;
using libHitpan5.Controller.Common.DocumentController;
using libHitpan5.enums;
using libHitpan5.Model.DataModel;
using libHitpan5.VO.CommonVO;
using libHitpan5.VO.CommonVO.UserInfo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using WebServiceServer.WebServiceVO.Settings;
namespace libHitpan5.Controller.SelectController.CommonSettings
{
    public class SelectCommonSettings : abSelect
    {
        private SQLDataServiceModel dbModel { get; set; }
        public SelectCommonSettings()
            : base("세팅정보 세팅", Hitpan5ClientLibrary.SQLDataServiceModel)
        {
            this.dbModel = Hitpan5ClientLibrary.SQLDataServiceModel;

            UserAuthProxyVO ua = new UserAuthProxyVO();   //실행에 필요한 권한
            ua["설정관리"] = 사용자권한.조회만가능;
            base.RequiredAuth = ua;
            base.docController = new libHitpan5.Controller.Common.DocumentController.CommonSettingsDocument();//문서작성용 컨트롤러
        }
        public override object GetData()
        {
            object returnValue = null;
            try
            {
                base.WriteDoLog();
                CommonSettingListener CommonSettingListener = new CommonSettingListener(this.dbModel);
                returnValue = CommonSettingListener.GetData();
                this.DocumentData = CommonSettingListener.DocumentData;//문서작성용 데이터
                base.WriteDoSuccLog();
            }
            catch (Exception e)
            {
                base.WriteDoFailureLog(e);
                
            }
            return returnValue;
        }
    }
}
