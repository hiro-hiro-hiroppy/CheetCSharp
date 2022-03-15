using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CL.Summary.DBSummary.Interface
{
    interface IPostgreSQLAccess
    {
        void BindPara(string paraName, NpgsqlDbType dbType, Object value, ParameterDirection direction = ParameterDirection.Input);
    }
}
