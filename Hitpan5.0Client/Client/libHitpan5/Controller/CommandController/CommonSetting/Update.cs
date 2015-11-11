using libHitpan5.Controller.CommandListener;
using libHitpan5.enums;
using libHitpan5.Model.DataModel;
using libHitpan5.VO;
using libHitpan5.VO.CommonVO;
using libHitpan5.VO.CommonVO.UserInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebServiceServer.WebServiceVO.Settings;

namespace libHitpan5.Controller.CommandController.CommonSetting
{
    public class Update : abCMD
    {
        private CommonSettingProxyVO CommonSettinginfo { get; set; }
        private CommonSettingProxyVO pre_CommonSettinginfo { get; set; }
        private SQLDataServiceModel dbModel { get; set; }
        public Update(CommonSettingProxyVO CommonSettinginfo, CommonSettingProxyVO pre_CommonSettinginfo)
            : base("기본설정 입력", Hitpan5ClientLibrary.SQLDataServiceModel)
        {
            this.CommonSettinginfo = CommonSettinginfo;
            this.pre_CommonSettinginfo = pre_CommonSettinginfo;
            this.dbModel = Hitpan5ClientLibrary.SQLDataServiceModel;

            UserAuthProxyVO ua = new UserAuthProxyVO();
            ua["설정관리"] = 사용자권한.모두허용;
            base.RequiredAuth = ua;
        }
        public override void Do()
        {
            try
            {
                base.WriteDoLog();
                new CommonSettingListener(this.dbModel).Update(CommonSettinginfo);
                base.WriteDoSuccLog();
            }
            catch (Exception e)
            {
                base.WriteDoFailureLog(e);
            }
        }

        public override void UnDo()
        {
            try
            {
                base.WriteUnDoLog();
                new CommonSettingListener(this.dbModel).Update(pre_CommonSettinginfo);
                base.WriteUnDoSuccLog();
            }
            catch (Exception e)
            {
                base.WriteUnDoFailureLog(e);
            }
        }
    }
}
