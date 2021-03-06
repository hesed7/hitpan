﻿using libHitpan5.Controller.CommandListener;
using libHitpan5.Model.DataModel;
using libHitpan5.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebServiceServer.WebServiceVO.Settings;
namespace libHitpan5.Controller.CommandController.CommonSetting
{
    public class Insert :abCMD
    {
        private CommonSettingProxyVO CommonSettinginfo { get; set; }
        private SQLDataServiceModel dbModel { get; set; }
        public Insert(CommonSettingProxyVO CommonSettinginfo)
            : base("기본설정 입력", Hitpan5ClientLibrary.SQLDataServiceModel)
        {
            this.CommonSettinginfo = CommonSettinginfo;
            this.dbModel = Hitpan5ClientLibrary.SQLDataServiceModel;
        }
        public override void Do()
        {
            try
            {
                base.WriteDoLog();
                new CommonSettingListener(this.dbModel).Insert(CommonSettinginfo);
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
                new CommonSettingListener(this.dbModel).Delete();
                base.WriteUnDoSuccLog();
            }
            catch (Exception e)
            {
                base.WriteUnDoFailureLog(e);
            }
        }
    }
}
