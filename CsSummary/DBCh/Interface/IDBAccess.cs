using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using NpgsqlTypes;
using Oracle.ManagedDataAccess.Client;

namespace CheetNetCoreMVC.CS.DB
{
    public interface IDBAccess
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

    public interface IOracleAccess
    {
        void BindPara(string paraName, OracleDbType dbType, Object value, ParameterDirection direction = ParameterDirection.Input);
    }

    public interface ISQLServerAccess
    {
        void BindPara(string paraName, SqlDbType dbType, Object value, ParameterDirection direction = ParameterDirection.Input);
    }

    public interface IMySQLAccess
    {
        void BindPara(string paraName, MySqlDbType dbType, Object value, ParameterDirection direction = ParameterDirection.Input);
    }

    public interface ISqliteAccess
    {
        void BindPara(string paraName, DbType dbType, Object value, ParameterDirection direction = ParameterDirection.Input);
    }

    public interface IPostgreSQLAccess
    {
        void BindPara(string paraName, NpgsqlDbType dbType, Object value, ParameterDirection direction = ParameterDirection.Input);
    }

}