using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

 
    #region 單次使用的概念
 public   class SQLServer
    {
        //ref
        //用 Windows 身份驗證
        //String strCon = "Data Source=(local);Initial Catalog=TestDb;Integrated Security=SSPI;";

        //用 SQL Server 身份驗證
        //String strCon = @"Data Source=.\SQLExpress;Database=TestDb;Uid=sa;Pwd=1234;";
 

        public static string GetConnectString(string Server, string DataBase, string Sa, string Password)
        {
            string ret = "";

            ret = "server=" + Server + ";database=" + DataBase + ";User ID=" + Sa + ";Pwd=" + Password;

            return ret;
        }
        public bool connTest(string ConnectString)
        {
            bool IsConned = false;

            using (SqlConnection SqlSvrCon = new SqlConnection(ConnectString))//如果strconn有誤.這時侯還不會出錯
            {
                try
                {
                    //if (conn.State == ConnectionState.Closed)
                    //    conn.Open(); 
                    SqlSvrCon.Open();//如果strconn有誤.open時就會出錯.
                    SqlSvrCon.Close();
                    IsConned = true;
                }
                catch (Exception ex)
                {
                    IsConned = false;
                }
            }
            return IsConned;
        }
        public bool connTest(string ConnectString,ref string sErrMsg)
     {
         bool IsConned = false;

         using (SqlConnection SqlSvrCon = new SqlConnection(ConnectString))//如果strconn有誤.這時侯還不會出錯
         {
             try
             {
                 //if (conn.State == ConnectionState.Closed)
                 //    conn.Open(); 
                 SqlSvrCon.Open();//如果strconn有誤.open時就會出錯.
                 SqlSvrCon.Close();
                 IsConned = true;
             }
             catch (Exception ex)
             {
                 //"Login failed for user 'sa'.":帳號碼密錯了,都是這個訊息
                 sErrMsg = ex.Message.ToString();
                 IsConned = false;
             }
         }
         return IsConned;
     }
        //留著以後可以用
        //public SQLServer()
        //{
        //    DTsMsSQLInfo DTsMsSQLInfo = new DTsMsSQLInfo();
        //    DTsMsSQLInfo.LoadDecryptFile();
        //    myConnectionString = DTsMsSQLInfo.ConnectString;
        //}
        public SQLServer( )
        {
       
        }

        /// <summary>
        /// 查閱資料表 回傳 DataTable
        /// </summary>
        public DataTable DoQuery(string strConn,string strCmd)
        {

            DataTable ret = new DataTable();

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                //string status = conn.State.ToString();
                if (conn.State == ConnectionState.Closed)
                    conn.Open(); 
                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = new SqlCommand(strCmd, conn);
                    adapter.Fill(ret);
                }
                catch (Exception ex)
                {
                    throw new Exception(strCmd + Environment.NewLine + ex.ToString());
                }
            }
            return ret;


        }

        /// <summary>
        /// 執行SQL
        /// </summary>
        public void ExecuteQuery(string strConn,string strCmd)
        {

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                //string status = conn.State.ToString();
                if (conn.State == ConnectionState.Closed)
                    conn.Open(); 
                try
                {
                    SqlCommand cmd = new SqlCommand(strCmd, conn);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception(strCmd + Environment.NewLine + ex.ToString());
                }
            }
        }
        /// <summary>
        /// 執行SQL
        /// </summary>
        public string ExecuteScalar(string strConn,string strCmd)
        {
            string ret = "";
            try
            {
                using (SqlConnection conn = new SqlConnection(strConn))
                {
                    if (conn.State == ConnectionState.Closed) 
                        conn.Open(); 
                    SqlCommand cmd   = new SqlCommand(strCmd, conn);         

                    object tmp;
                    tmp = cmd.ExecuteScalar();
                    if ((tmp) != null)
                        ret = tmp.ToString();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(strCmd + Environment.NewLine + ex.ToString());
            }

            return ret;
        }






    }
    #endregion

    #region half ok
    //class SQLServer
    //{
    //    //ref
    //    //用 Windows 身份驗證
    //    //String strCon = "Data Source=(local);Initial Catalog=TestDb;Integrated Security=SSPI;";

    //    //用 SQL Server 身份驗證
    //    //String strCon = @"Data Source=.\SQLExpress;Database=TestDb;Uid=sa;Pwd=1234;";

    //    string connString;

    //    public static string GetConnectString(string Server, string DataBase, string Sa, string Password)
    //    {
    //        string ret = "";

    //        ret = "server=" + Server + ";database=" + DataBase + ";User ID=" + Sa + ";Pwd=" + Password;

    //        return ret;
    //    }
    //    public bool connTest(string ConnectString)
    //    {
    //        bool IsConned = false;
          
    //        SqlConnection SqlSvrCon = new SqlConnection(ConnectString);
    //        try
    //        {
    //            SqlSvrCon.Open();
    //            SqlSvrCon.Close();
    //            IsConned = true;                
    //        }
    //        catch (Exception ex)
    //        {
    //            IsConned = false;
    //        }            
    //        return IsConned;
    //    }
  
    //    //留著以後可以用
    //    //public SQLServer()
    //    //{
    //    //    DTsMsSQLInfo DTsMsSQLInfo = new DTsMsSQLInfo();
    //    //    DTsMsSQLInfo.LoadDecryptFile();
    //    //    myConnectionString = DTsMsSQLInfo.ConnectString;
    //    //}
    //    public SQLServer(string ConnectionString)
    //    {
    //        if (string.IsNullOrEmpty(ConnectionString))
    //        {
    //            throw new Exception("SQL ConnectString 尚未提供");
    //        }
    //        connString = ConnectionString;
    //    }

    //    /// <summary>
    //    /// 查閱資料表 回傳 DataTable
    //    /// </summary>
    //    public DataTable DoQuery(string Query)
    //    {
            
    //        DataTable ret = new DataTable();

    //        using (SqlConnection DBconn = new SqlConnection(this.connString))
    //        {
    //            DBconn.Open();
    //            try
    //            {
    //                SqlDataAdapter adapter = new SqlDataAdapter();
    //                adapter.SelectCommand = new SqlCommand(Query, DBconn);
    //                adapter.Fill(ret);
    //            }
    //            catch (Exception ex)
    //            {
    //                throw new Exception(Query + Environment.NewLine + ex.ToString());
    //            }
    //        }
    //            return ret;
     
        
    //    }

    //    /// <summary>
    //    /// 執行SQL
    //    /// </summary>
    //    public void ExecuteQuery(string Query)
    //    {

    //        using (SqlConnection conn = new SqlConnection(this.connString))
    //        {
    //            conn.Open();
    //            try
    //            {
    //                SqlCommand cmd = new SqlCommand(Query, conn);          
    //                cmd.ExecuteNonQuery();
    //            }
    //            catch (Exception ex)
    //            {
    //                throw new Exception(Query + Environment.NewLine + ex.ToString());
    //            }
    //        }
    //    }
    //    /// <summary>
    //    /// 執行SQL
    //    /// </summary>
    //    public string ExecuteScalar(string Query)
    //    {
    //        string ret = "";
    //        try
    //        {
    //            using (SqlConnection DBconn = new SqlConnection(this.connString))
    //            {
    //                if (DBconn.State == ConnectionState.Closed)
    //                {
    //                    DBconn.Open();
    //                }
    //                SqlCommand cmd = null;
    //                cmd = DBconn.CreateCommand();
    //                cmd.CommandType = CommandType.Text;
    //                cmd.CommandText = Query;
    //                cmd.Connection = DBconn;

    //                object tmp;
    //                tmp = cmd.ExecuteScalar();
    //                if ((tmp) != null)
    //                    ret = tmp.ToString();
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            throw new Exception(Query + Environment.NewLine + ex.ToString());
    //        }
        
    //        return ret;
    //    }






    //}
    #endregion 
    #region half una
    //    /// <summary>
    //    /// helf una
    //    /// </summary>
    //public sealed class SQLServer
    //{
    //    private string myConnectionString;

    //    private SqlConnection DBconn;

    //    public static string GetConnectString(string server, string database, string sa, string pwd)
    //    {
    //        string ret = "";

    //        ret = "server=" + Server + ";database=" + DataBase + ";User ID=" + Sa + ";Pwd=" + Password;

    //        return ret;
    //    }
    //    public SQLServer()
    //    {
    //        DTsMsSQLInfo DTsMsSQLInfo = new DTsMsSQLInfo();
    //        DTsMsSQLInfo.LoadDecryptFile();
    //        myConnectionString = DTsMsSQLInfo.ConnectString;
    //    }
    //    public SQLServer(string ConnectionString)
    //    {
    //        if (string.IsNullOrEmpty(ConnectionString))
    //        {
    //            throw new Exception("SQL ConnectString 尚未提供");
    //        }
    //        this.myConnectionString = ConnectionString;
    //    }

    //    /// <summary>
    //    /// 查閱資料表 回傳 DataTable
    //    /// </summary>
    //    public DataTable DoQuery(string Query)
    //    {
    //        try
    //        {
    //            this.GetDBConnection();
    //            this.OpenConnection();

    //            DataTable myTB = new DataTable();
    //            SqlDataAdapter adapter = new SqlDataAdapter();
    //            adapter.SelectCommand = new SqlCommand(Query, this.DBconn);
    //            adapter.Fill(myTB);
    //            return myTB;
    //        }
    //        catch (Exception ex)
    //        {
    //            throw new Exception(Query + Environment.NewLine + ex.ToString());
    //        }
    //        finally
    //        {
    //            this.Close();
    //        }
    //    }

    //    /// <summary>
    //    /// 執行SQL
    //    /// </summary>
    //    public void ExecuteQuery(string Query)
    //    {
    //        try
    //        {
    //            this.GetDBConnection();
    //            this.OpenConnection();
    //            SqlCommand myCmd = null;
    //            myCmd = DBconn.CreateCommand();
    //            myCmd.CommandType = CommandType.Text;
    //            myCmd.CommandText = Query;
    //            myCmd.Connection = DBconn;
    //            myCmd.ExecuteNonQuery();
    //        }
    //        catch (Exception ex)
    //        {
    //            throw new Exception(Query + Environment.NewLine + ex.ToString());
    //        }
    //        finally
    //        {
    //            this.Close();
    //        }
    //    }
    //    /// <summary>
    //    /// 執行SQL
    //    /// </summary>
    //    public string ExecuteScalar(string Query)
    //    {
    //        string ret = "";
    //        try
    //        {
    //            this.GetDBConnection();
    //            this.OpenConnection();
    //            SqlCommand myCmd = null;
    //            myCmd = DBconn.CreateCommand();
    //            myCmd.CommandType = CommandType.Text;
    //            myCmd.CommandText = Query;
    //            myCmd.Connection = DBconn;

    //            object tmp;
    //            tmp = myCmd.ExecuteScalar();
    //            if ((tmp) != null)
    //                ret = tmp.ToString();
    //        }
    //        catch (Exception ex)
    //        {
    //            throw new Exception(Query + Environment.NewLine + ex.ToString());
    //        }
    //        finally
    //        {
    //            this.Close();
    //        }
    //        return ret;
    //    }
    //    /// <summary>
    //    /// 打開資料庫
    //    /// </summary>
    //    private void OpenConnection()
    //    {
    //        if (this.DBconn.State == ConnectionState.Closed)
    //        {
    //            this.DBconn.Open();
    //        }
    //    }

    //    /// <summary>
    //    /// 取得SqlConnection
    //    /// </summary>
    //    private SqlConnection GetDBConnection()
    //    {
    //        //Me.myConnectionString = "server=10.204.121.8;database=ReportServer;User ID=sa;Pwd=ecudn08ccg3m/45k3"
    //        DBconn = new SqlConnection(this.myConnectionString);
    //        return DBconn;
    //    }

    //    /// <summary>
    //    /// 關閉資料庫
    //    /// </summary>
    //    private void Close()
    //    {
    //        this.DBconn.Close();
    //        this.DBconn.Dispose();
    //        this.DBconn = null;
    //    }
    //}
    #endregion 
 
