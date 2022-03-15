using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CL.Summary.DBSummary.Interface
{
    interface ISQLServerAccess
    {
        void BindPara(string paraName, SqlDbType dbType, Object value, ParameterDirection direction = ParameterDirection.Input);
    }
}
