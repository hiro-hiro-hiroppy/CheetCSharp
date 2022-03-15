using CL.Summary.DBSummary.Interface;
using MySql.Data.MySqlClient;
using NpgsqlTypes;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CL.Summary.DBSummary
{
    public class DBCommon : IDBCommon, IMySQLAccess, IOracleAccess, IPostgreSQLAccess, ISqliteAccess,ISQLServerAccess
    {
        private DBType dbName;
        private OracleAccess oraAccess = null;
        private SQLServerAccess ssAccess = null;
        private MySQLAccess mysqlAccess = null;
        private SqliteAccess sqliteAccess = null;
        private PostgreSQLAccess posAccess = null;


        public enum DBType
        {
            Oracle,
            SQLServer,
            MySQL,
            Sqlite,
            PostgreSQL,
        }

        public DBCommon(DBType dbType, string connectionString = null)
        {
            dbName = dbType;

            switch (dbName)
            {
                case DBType.Oracle:
                    oraAccess = new OracleAccess();
                    break;

                case DBType.SQLServer:
                    ssAccess = new SQLServerAccess();
                    break;

                case DBType.MySQL:
                    mysqlAccess = new MySQLAccess();
                    break;

                case DBType.Sqlite:
                    sqliteAccess = new SqliteAccess();
                    break;

                case DBType.PostgreSQL:
                    posAccess = new PostgreSQLAccess();
                    break;

                default:
                    break;
            }

            if (connectionString != null)
            {
                SetConnectionString(connectionString);
            }
            else
            {
                SetConnectionString();
            }
            OpenDB();
        }

        /// <summary>
        /// 接続文字列を設定する
        /// </summary>
        public void SetConnectionString()
        {
            switch (dbName)
            {
                case DBType.Oracle:
                    oraAccess.SetConnectionString();
                    break;

                case DBType.SQLServer:
                    ssAccess.SetConnectionString();
                    break;

                case DBType.MySQL:
                    mysqlAccess.SetConnectionString();
                    break;

                case DBType.Sqlite:
                    sqliteAccess.SetConnectionString();
                    break;

                case DBType.PostgreSQL:
                    posAccess.SetConnectionString();
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// 接続文字列を設定する
        /// </summary>
        public void SetConnectionString(string connectionString)
        {
            switch (dbName)
            {
                case DBType.Oracle:
                    oraAccess.SetConnectionString(connectionString);
                    break;

                case DBType.SQLServer:
                    ssAccess.SetConnectionString(connectionString);
                    break;

                case DBType.MySQL:
                    mysqlAccess.SetConnectionString(connectionString);
                    break;

                case DBType.Sqlite:
                    sqliteAccess.SetConnectionString(connectionString);
                    break;

                case DBType.PostgreSQL:
                    posAccess.SetConnectionString(connectionString);
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// データベースをオープンする
        /// </summary>
        public void OpenDB()
        {
            switch (dbName)
            {
                case DBType.Oracle:
                    oraAccess.OpenDB();
                    break;

                case DBType.SQLServer:
                    ssAccess.OpenDB();
                    break;

                case DBType.MySQL:
                    mysqlAccess.OpenDB();
                    break;

                case DBType.Sqlite:
                    sqliteAccess.OpenDB();
                    break;

                case DBType.PostgreSQL:
                    posAccess.OpenDB();
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// トランザクションを開始する
        /// </summary>
        public void BeginTransaction()
        {
            switch (dbName)
            {
                case DBType.Oracle:
                    oraAccess.BeginTransaction();
                    break;

                case DBType.SQLServer:
                    ssAccess.BeginTransaction();
                    break;

                case DBType.MySQL:
                    mysqlAccess.BeginTransaction();
                    break;

                case DBType.Sqlite:
                    sqliteAccess.BeginTransaction();
                    break;

                case DBType.PostgreSQL:
                    posAccess.BeginTransaction();
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// SQLクエリを実行する（SELECTなどデータの取得あり）
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public DataTable ExecuteReader(string query)
        {
            DataTable dt = null;

            switch (dbName)
            {
                case DBType.Oracle:
                    dt = oraAccess.ExecuteReader(query);
                    break;

                case DBType.SQLServer:
                    dt = ssAccess.ExecuteReader(query);
                    break;

                case DBType.MySQL:
                    dt = mysqlAccess.ExecuteReader(query);
                    break;

                case DBType.Sqlite:
                    dt = sqliteAccess.ExecuteReader(query);
                    break;

                case DBType.PostgreSQL:
                    dt = posAccess.ExecuteReader(query);
                    break;

                default:
                    break;
            }

            return dt;
        }

        /// <summary>
        /// SQLクエリを実行する（INSERTなどデータの取得なし）
        /// </summary>
        /// <param name="query">SQL文</param>
        /// <returns>クエリ実行結果　0以上:正常、-1以下:異常</returns>
        public int ExecuteNonQuery(string query)
        {
            int rCnt = -1;

            switch (dbName)
            {
                case DBType.Oracle:
                    rCnt = oraAccess.ExecuteNonQuery(query);
                    break;

                case DBType.SQLServer:
                    rCnt = ssAccess.ExecuteNonQuery(query);
                    break;

                case DBType.MySQL:
                    rCnt = mysqlAccess.ExecuteNonQuery(query);
                    break;

                case DBType.Sqlite:
                    rCnt = sqliteAccess.ExecuteNonQuery(query);
                    break;

                case DBType.PostgreSQL:
                    rCnt = posAccess.ExecuteNonQuery(query);
                    break;

                default:
                    break;
            }

            return rCnt;
        }

        /// <summary>
        /// トランザクションをコミットする
        /// </summary>
        public void Commit()
        {
            switch (dbName)
            {
                case DBType.Oracle:
                    oraAccess.Commit();
                    break;

                case DBType.SQLServer:
                    ssAccess.Commit();
                    break;

                case DBType.MySQL:
                    mysqlAccess.Commit();
                    break;

                case DBType.Sqlite:
                    sqliteAccess.Commit();
                    break;

                case DBType.PostgreSQL:
                    posAccess.Commit();
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// トランザクションのロールバックをする
        /// </summary>
        public void RollBack()
        {
            switch (dbName)
            {
                case DBType.Oracle:
                    oraAccess.RollBack();
                    break;

                case DBType.SQLServer:
                    ssAccess.RollBack();
                    break;

                case DBType.MySQL:
                    mysqlAccess.RollBack();
                    break;

                case DBType.Sqlite:
                    sqliteAccess.RollBack();
                    break;

                case DBType.PostgreSQL:
                    posAccess.RollBack();
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// データベースをクローズする
        /// </summary>
        public void CloseDB()
        {
            switch (dbName)
            {
                case DBType.Oracle:
                    oraAccess.CloseDB();
                    break;

                case DBType.SQLServer:
                    ssAccess.CloseDB();
                    break;

                case DBType.MySQL:
                    mysqlAccess.CloseDB();
                    break;

                case DBType.Sqlite:
                    sqliteAccess.CloseDB();
                    break;

                case DBType.PostgreSQL:
                    posAccess.CloseDB();
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// データベースをDisposeする
        /// </summary>
        public void Dispose()
        {
            switch (dbName)
            {
                case DBType.Oracle:
                    oraAccess.Dispose();
                    break;

                case DBType.SQLServer:
                    ssAccess.Dispose();
                    break;

                case DBType.MySQL:
                    mysqlAccess.Dispose();
                    break;

                case DBType.Sqlite:
                    sqliteAccess.Dispose();
                    break;

                case DBType.PostgreSQL:
                    posAccess.Dispose();
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// パラメータをバインドする(Oracle用)
        /// </summary>
        /// <param name="paraName"></param>
        /// <param name="dbType"></param>
        /// <param name="value"></param>
        /// <param name="direction"></param>
        public void BindPara(string paraName, OracleDbType dbType, Object value, ParameterDirection direction = ParameterDirection.Input)
        {
            if (dbName == DBType.Oracle)
            {
                oraAccess.BindPara(paraName, dbType, value, direction);
            }
        }

        /// <summary>
        /// パラメータをバインドする(SQL Server用)
        /// </summary>
        /// <param name="paraName"></param>
        /// <param name="dbType"></param>
        /// <param name="value"></param>
        /// <param name="direction"></param>
        public void BindPara(string paraName, SqlDbType dbType, Object value, ParameterDirection direction = ParameterDirection.Input)
        {
            if (dbName == DBType.SQLServer)
            {
                ssAccess.BindPara(paraName, dbType, value, direction);
            }
        }

        /// <summary>
        /// パラメータをバインドする(MySQL用)
        /// </summary>
        /// <param name="paraName"></param>
        /// <param name="dbType"></param>
        /// <param name="value"></param>
        /// <param name="direction"></param>
        public void BindPara(string paraName, MySqlDbType dbType, Object value, ParameterDirection direction = ParameterDirection.Input)
        {
            if (dbName == DBType.SQLServer)
            {
                mysqlAccess.BindPara(paraName, dbType, value, direction);
            }
        }

        /// <summary>
        /// パラメータをバインドする(Sqlite用)
        /// </summary>
        /// <param name="paraName"></param>
        /// <param name="dbType"></param>
        /// <param name="value"></param>
        /// <param name="direction"></param>
        public void BindPara(string paraName, DbType dbType, Object value, ParameterDirection direction = ParameterDirection.Input)
        {
            if (dbName == DBType.Sqlite)
            {
                sqliteAccess.BindPara(paraName, dbType, value, direction);
            }
        }

        /// <summary>
        /// パラメータをバインドする(Sqlite用)
        /// </summary>
        /// <param name="paraName"></param>
        /// <param name="dbType"></param>
        /// <param name="value"></param>
        /// <param name="direction"></param>
        public void BindPara(string paraName, NpgsqlDbType dbType, Object value, ParameterDirection direction = ParameterDirection.Input)
        {
            if (dbName == DBType.Sqlite)
            {
                posAccess.BindPara(paraName, dbType, value, direction);
            }
        }

        /// <summary>
        /// パラメータをクリアする
        /// </summary>
        public void ClearPara()
        {
            switch (dbName)
            {
                case DBType.Oracle:
                    oraAccess.ClearPara();
                    break;

                case DBType.SQLServer:
                    ssAccess.ClearPara();
                    break;

                case DBType.MySQL:
                    mysqlAccess.ClearPara();
                    break;

                case DBType.Sqlite:
                    sqliteAccess.ClearPara();
                    break;

                case DBType.PostgreSQL:
                    posAccess.ClearPara();
                    break;

                default:
                    break;
            }
        }
    }
}
