using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace libHitpan5.Model.DataModel
{
    public interface IDataModel
    {
        DataTable GetData(string query);
        void SetData(string query);
        void SetData(string[] queryList);
        void Dispose();
    }
}
