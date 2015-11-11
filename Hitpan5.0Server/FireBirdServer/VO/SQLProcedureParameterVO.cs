using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace WebServiceServer.VO
{
    class SQLProcedureParameterVO
    {
        public string  parameterName { get; set; }
        public DbType DBType { get; set; }
        public object value { get; set; }
    }
}
