using CL.Summary.DBSummary.Interface;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Text;

namespace CL.Summary.DBSummary
{
    public class SqliteAccess : IDBCommon, ISqliteAccess
    {
        private SqliteConnection connect = null;
        private SqliteTransaction transaction = null;
        private SqliteCommand command = new SqliteCommand();
        private string connectionString;
        private List<SqliteParameter> sqlParameters = new List<SqliteParameter>();
        private readonly int timeOut = 300;

        /// <summary>
        /// 接続文字列を設定する(デフォルト)
        /// </summary>
        public void SetConnectionString()
        {
            this.connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        }

        /// <summary>
        /// 接続文字列を設定する
        /// </summary>
        public void SetConnectionString(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// データベースをオープンする
        /// </summary>
        public void OpenDB()
        {
            try
            {
                if (this.connect == null)
                {
                    this.connect = new SqliteConnection();
                }

                if (this.connect.State == ConnectionState.Broken || this.connect.State == ConnectionState.Closed)
                {
                    if (this.connect.State == ConnectionState.Broken)
                    {
                        this.connect.Close();
                    }

                    this.connect.ConnectionString = this.connectionString;

                    this.connect.Open();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// トランザクションを開始する
        /// </summary>
        public void BeginTransaction()
        {
            try
            {
                this.transaction = this.connect.BeginTransaction();
            }
            catch (Exception ex)
            {
                throw ex;
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

            try
            {
                this.command.Connection = this.connect;
                this.command.CommandText = query;
                //this.command.BindByName = true;
                //this.command.CommandType = CommandType.Text;
                this.command.Parameters.Clear();
                this.command.CommandTimeout = this.timeOut;

                foreach (var p in sqlParameters)
                {
                    this.command.Parameters.Add(p);
                }

                SqliteDataReader da = command.ExecuteReader();
                dt.Load(da);
            }
            catch (Exception ex)
            {
                dt = null;
                throw ex;
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
            int nCnt = -1;

            try
            {
                this.command.Connection = this.connect;
                this.command.CommandText = query;
                //this.command.BindByName = true;
                this.command.CommandType = CommandType.Text;
                this.command.Parameters.Clear();
                this.command.CommandTimeout = this.timeOut;

                foreach (var p in sqlParameters)
                {
                    this.command.Parameters.Add(p);
                }

                nCnt = this.command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                nCnt = -1;
                throw ex;
            }

            return nCnt;
        }

        /// <summary>
        /// トランザクションをコミットする
        /// </summary>
        public void Commit()
        {
            try
            {
                if (this.transaction != null)
                {
                    this.transaction.Commit();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// トランザクションのロールバックをする
        /// </summary>
        public void RollBack()
        {
            try
            {
                if (this.transaction != null)
                {
                    this.transaction.Rollback();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// データベースをクローズする
        /// </summary>
        public void CloseDB()
        {
            try
            {
                if (this.connect != null)
                {
                    this.connect.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// データベースをDisposeする
        /// </summary>
        public void Dispose()
        {
            try
            {
                if (this.connect != null)
                {
                    this.connect.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// パラメータをバインドする
        /// </summary>
        /// <param name="paraName"></param>
        /// <param name="dbType"></param>
        /// <param name="value"></param>
        /// <param name="direction"></param>
        public void BindPara(string paraName, DbType dbType, Object value, ParameterDirection direction = ParameterDirection.Input)
        {
            SqliteParameter oraPara = new SqliteParameter();

            oraPara.ParameterName = paraName;
            oraPara.DbType = dbType;
            oraPara.Value = value;
            oraPara.Direction = direction;
            sqlParameters.Add(oraPara);
        }

        /// <summary>
        /// パラメータをクリアする
        /// </summary>
        public void ClearPara()
        {
            sqlParameters.Clear();
        }
    }
}
