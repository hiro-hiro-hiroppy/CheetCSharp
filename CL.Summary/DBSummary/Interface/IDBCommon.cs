using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CL.Summary.DBSummary.Interface
{
    interface IDBCommon
    {
        void SetConnectionString();
        void SetConnectionString(string connectionString);
        void OpenDB();
        void BeginTransaction();
        DataTable ExecuteReader(string query);
        int ExecuteNonQuery(string query);
        void Commit();
        void RollBack();
        void CloseDB();
        void Dispose();
        void ClearPara();
    }
}
