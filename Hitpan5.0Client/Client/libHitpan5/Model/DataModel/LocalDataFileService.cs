using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
namespace libHitpan5.Model.DataModel
{
    public class LocalDataFileService : IDataModel
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public System.Data.DataTable GetData(string query)
        {
            return new System.Data.DataTable();
        }

        /// <summary>
        /// 세팅파일에 로컬데이터로 입력
        /// </summary>
        /// <param name="query"></param>
        public void SetData(string JsonData)
        {
            File.WriteAllText(string.Format("{0}\\LocalSettingInfo.settings",Environment.CurrentDirectory),JsonData,Encoding.UTF8);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 지원하지 않음
        /// </summary>
        /// <param name="queryList"></param>
        public void SetData(string[] queryList)
        {
            throw new NotImplementedException();
        }
    }
}
