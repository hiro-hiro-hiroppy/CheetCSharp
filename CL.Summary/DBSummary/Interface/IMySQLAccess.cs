using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CL.Summary.DBSummary.Interface
{
    interface IMySQLAccess
    {
        void BindPara(string paraName, MySqlDbType dbType, Object value, ParameterDirection direction = ParameterDirection.Input);
    }
}
