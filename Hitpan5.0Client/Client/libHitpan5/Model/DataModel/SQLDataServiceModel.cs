using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using libHitpan5.Model.EncryptionModel;
using System.Data;
using Newtonsoft.Json;
using System.Xml.Serialization;
using libHitpan5.Model.WebServiceModel;
namespace libHitpan5.Model.DataModel
{
    public class SQLDataServiceModel : IDataModel
    {
        internal string EncryptionSeed { get; set; }
        internal string ServiceURL { get; set; }
        internal ISQLWebService sqlProxy { get; set; }

        /// <summary>
        /// sql 쿼리를 서버에 보낸다
        /// </summary>
        /// <param name="EncryptionSeed">서버보안문자(seed)</param>
        /// <param name="sqlService">sql웹서비스 프록시객체</param>
        public SQLDataServiceModel(string EncryptionSeed, string ServiceURL, ISQLWebService sqlService)
        {
            //[1] 웹서비스 동적 추가
            this.sqlProxy = sqlService;
            this.ServiceURL = ServiceURL;
            //[2] 암호화키 
            this.EncryptionSeed = EncryptionSeed;
        }


        public DataTable GetData(string query)
        {            
            DataTable dt = null;
            try
            {
                string jsonData = this.sqlProxy.GetData(new EncryptionService().GetEncryptedKey(this.EncryptionSeed, DateTime.Now), query,this.ServiceURL);
                object returnValue = JsonConvert.DeserializeObject(jsonData, typeof(DataTable));

                dt = (DataTable)returnValue;
            }
            catch (ArgumentNullException)
            {

            }
            catch (Exception) 
            {
                throw;
            }
            return dt;
        }

        public void SetData(string query)
        {
            sqlProxy.RegistQuery(new EncryptionService().GetEncryptedKey(this.EncryptionSeed, this.sqlProxy.GetTime()), query, this.ServiceURL);
        }

        public void SetData(string[] queryList)
        {
            this.sqlProxy.RegistQueryBlock(new EncryptionService().GetEncryptedKey(this.EncryptionSeed, this.sqlProxy.GetTime()), queryList, this.ServiceURL);
        }

        public void Dispose()
        {
           
        }
    }
}
