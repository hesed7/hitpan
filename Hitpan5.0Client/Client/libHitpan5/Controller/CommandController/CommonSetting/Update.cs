using libHitpan5.Controller.CommandListener;
using libHitpan5.enums;
using libHitpan5.Model.DataModel;
using libHitpan5.VO;
using libHitpan5.VO.CommonVO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace libHitpan5.Controller.CommandController.CommonSetting
{
    public class Update : abCMD
    {
        private CommonSettinginfo CommonSettinginfo { get; set; }
        private CommonSettinginfo pre_CommonSettinginfo { get; set; }
        private IDataModel dbModel { get; set; }
        public Update(CommonSettinginfo CommonSettinginfo, CommonSettinginfo pre_CommonSettinginfo)
            : base("기본설정 입력", Hitpan5ClientLibrary.SQLDataServiceModel)
        {
            this.CommonSettinginfo = CommonSettinginfo;
            this.pre_CommonSettinginfo = pre_CommonSettinginfo;
            this.dbModel = Hitpan5ClientLibrary.SQLDataServiceModel;

            UserAuth ua = new UserAuth();
            ua.설정관리 = 사용자권한.모두허용;
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
