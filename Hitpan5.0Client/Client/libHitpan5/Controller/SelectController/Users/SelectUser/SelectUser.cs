using libHitpan5.Controller.CommandListener;
using libHitpan5.Controller.Common.DocumentController;
using libHitpan5.enums;
using libHitpan5.Model.DataModel;
using libHitpan5.VO;
using libHitpan5.VO.CommonVO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace libHitpan5.Controller.SelectController.Users.SelectUser
{
    public class SelectUser :abSelect
    {
        public SQLDataServiceModel dbModel { get; set; }
        public string id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="id">특정 ID정보를 찾고자 할 때만 id값을 주고 전부 찾고자 하면 null값을 준다</param>
        /// <param name="dbModel"></param>
        public SelectUser(string id)
            : base(string.Format("{0}에 대한 정보 검색", id), Hitpan5ClientLibrary.SQLDataServiceModel)
        {
            this.dbModel = Hitpan5ClientLibrary.SQLDataServiceModel;
            this.id = id;

            UserAuth ua = new UserAuth();   //실행에 필요한 권한
            ua.계정관리 = 사용자권한.조회만가능;
            base.RequiredAuth = ua;

            base.docController = new UserDocument();//문서작성용 컨트롤러
        }



        /// <summary>
        /// 
        /// </summary>
        /// <returns>
        /// 모든 유저의 정보는 IList<UserInfo>형식으로 반환된다
        /// </returns>
        public override object GetData()
        {
            try
            {
                if (id == null)
                {
                    base.WriteDoLog();
                    UserListener UserListener=new UserListener(this.dbModel);
                    object ReturnValue = UserListener.GetUserInfo();
                    base.DocumentData = UserListener.DocumentData; //문서 작성시 사용될 데이터
                    base.WriteDoSuccLog();
                    return ReturnValue;
                }
                else
                {
                    base.WriteDoLog();
                    UserListener UserListener = new UserListener(this.dbModel);
                    object ReturnValue = UserListener.GetUserInfo(this.id);
                    base.DocumentData = UserListener.DocumentData; //문서 작성시 사용될 데이터
                    base.WriteDoSuccLog();
                    return ReturnValue;
                }
            }
            catch (Exception e)
            {
                base.WriteDoFailureLog(e);
                return null;
            }
            
        }
    }
}
