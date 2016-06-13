using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Panbor_ImportWebSO
{
    public sealed class SQLServer
    {
        private string myConnectionString;

        private SqlConnection DBconn;
        public SQLServer()
        {
            DTsMsSQLInfo  DTsMsSQLInfo = new DTsMsSQLInfo ();
            DTsMsSQLInfo .LoadDecryptFile();
            myConnectionString = DTsMsSQLInfo.ConnectString;
        }
        public SQLServer(string ConnectionString)
        {
            if (string.IsNullOrEmpty(ConnectionString))
            {
                throw new Exception("SQL ConnectString 尚未提供");
            }
            this.myConnectionString = ConnectionString;
        }

        /// <summary>
        /// 查閱資料表 回傳 DataTable
        /// </summary>
        public DataTable DoQuery(string Query)
        {
            try
            {
                this.GetDBConnection();
                this.OpenConnection();

                DataTable myTB = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = new SqlCommand(Query, this.DBconn);
                adapter.Fill(myTB);
                return myTB;
            }
            catch (Exception ex)
            {
                throw new Exception(Query + Environment.NewLine + ex.ToString());
            }
            finally
            {
                this.Close();
            }
        }

        /// <summary>
        /// 執行SQL
        /// </summary>
        public void ExecuteQuery(string Query)
        {
            try
            {
                this.GetDBConnection();
                this.OpenConnection();
                SqlCommand myCmd = null;
                myCmd = DBconn.CreateCommand();
                myCmd.CommandType = CommandType.Text;
                myCmd.CommandText = Query;
                myCmd.Connection = DBconn;
                myCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(Query + Environment.NewLine + ex.ToString());
            }
            finally
            {
                this.Close();
            }
        }
        /// <summary>
        /// 執行SQL
        /// </summary>
        public string ExecuteScalar (string Query)
        {
            string ret = "";
            try
            {
                this.GetDBConnection();
                this.OpenConnection();
                SqlCommand myCmd = null;
                myCmd = DBconn.CreateCommand();
                myCmd.CommandType = CommandType.Text ;
                myCmd.CommandText = Query;
                myCmd.Connection = DBconn;

                object tmp;
                tmp = myCmd.ExecuteScalar ();
                if ((tmp)!=null)
                ret = tmp.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(Query + Environment.NewLine + ex.ToString());
            }
            finally
            {
                this.Close();
            }
            return ret;
        }
        /// <summary>
        /// 打開資料庫
        /// </summary>
        private void OpenConnection()
        {
            if (this.DBconn.State == ConnectionState.Closed)
            {
                this.DBconn.Open();
            }
        }

        /// <summary>
        /// 取得SqlConnection
        /// </summary>
        private SqlConnection GetDBConnection()
        {
            //Me.myConnectionString = "server=10.204.121.8;database=ReportServer;User ID=sa;Pwd=ecudn08ccg3m/45k3"
            DBconn = new SqlConnection(this.myConnectionString);
            return DBconn;
        }

        /// <summary>
        /// 關閉資料庫
        /// </summary>
        private void Close()
        {
            this.DBconn.Close();
            this.DBconn.Dispose();
            this.DBconn = null;
        }


 



    }
}
