using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CL.Summary.DBSummary.Interface
{
    interface IOracleAccess
    {
        void BindPara(string paraName, OracleDbType dbType, Object value, ParameterDirection direction = ParameterDirection.Input);
    }
}
