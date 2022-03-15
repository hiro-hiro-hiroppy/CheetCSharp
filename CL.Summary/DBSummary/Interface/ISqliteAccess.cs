using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CL.Summary.DBSummary.Interface
{
    interface ISqliteAccess
    {
        void BindPara(string paraName, DbType dbType, Object value, ParameterDirection direction = ParameterDirection.Input);
    }
}
