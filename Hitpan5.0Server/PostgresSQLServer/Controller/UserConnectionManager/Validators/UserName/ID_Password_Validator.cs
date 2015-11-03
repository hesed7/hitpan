using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IdentityModel;
using System.IdentityModel.Selectors;
using System.ServiceModel;
using System.Data;
using System.Collections.Specialized;
using PostgresSQLServer.Controller.DBManager;
namespace PostgresSQLServer.Controller.UserConnectionManager.Validators.UserName
{
    public class ID_Password_Validator :UserNamePasswordValidator
    {
        private string serviceURL { get; set; }
        private bool UseHitpanDB { get; set; }
        public ID_Password_Validator(string serviceURL)
        {
            this.serviceURL = serviceURL;
            this.UseHitpanDB = (bool)ServerMain.getInstance().SettingsValue["UseHitpanDB"];
        }
        public override void Validate(string userName, string password)
        {
            if (userName==string.Empty || userName==null)
            {
                throw new FaultException("사용자 아이디가 없습니다");
            }
            if (password == string.Empty || password == null)
            {
                throw new FaultException("사용자 패스워드가 없습니다");
            }
            try
            {
                if (UseHitpanDB)
                {
                    ValidateWithHitpanDB(userName, password);
                }
                else
                {
                    ValidateWithSettingFile(userName, password);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// 히트판 DB와 서버 연동
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        private void ValidateWithHitpanDB(string userName, string password) 
        {
            if (userName.Contains("'"))
            {
                userName = userName.Replace("'", "''");
            }
            string query = string.Format("select * from users where userid='{0}'", userName);
            DataTable dt = DBController.getInstance().GetData(this.serviceURL,query);

            string pwd = string.Empty;
            try
            {
                pwd = dt.Rows[0]["userPassword"].ToString();
            }
            catch (IndexOutOfRangeException)
            {                
                throw new FaultException("해당되는 사용자가 없습니다");;
            }
            if (pwd != password)
            {
                throw new FaultException("사용자 암호가 틀립니다");
            }        
        }
        private void ValidateWithSettingFile(string userName, string password) 
        {
            try
            {
                try
                {
                    IDictionary<string, string> userDic = (IDictionary<string, string>)ServerMain.getInstance().SettingsValue["users"];
                    if (!(userDic.Keys.Contains(userName)))
                    {
                        throw new FaultException("서버 아이디가 없거나 패스워드가 일치하지 않습니다");
                    }
                    if (userDic[userName] != password)
                    {
                        throw new FaultException("서버 아이디가 없거나 패스워드가 일치하지 않습니다");
                    }
                }
                catch (Exception)
                {                   
                    throw new FaultException("서버에 등록된 유저가 아무도 없습니다");
                }
            }
            catch (NullReferenceException)
            {                
                throw new FaultException("설정된 서버 ID정보가 하나도 없습니다. 서버에서 유저정보를 입력한 후에 다시 시도 하십시오");
            }
        }        
    }
}
