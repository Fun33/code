using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;

using System.Data.OleDb;
using System.IO;
public class func_excel_read_ole_csv
{

    //使用方法
    //         System.Data.DataTable dt = new func_excel_read_ole().CreateDataSource(@"Z:\cadmen\服務部\客戶需求單\YFY\ERP標準書(SAP).xls;", "內容物重量");

    //        for (int i = 0; i < dt.Rows.Count; i++)
    //        {
    //            string msg = dt.Rows[i]["內容物"].ToString() + "--" + dt.Rows[i]["重量"].ToString();
    //            MessageBox.Show(msg);
    //        }

    public DataTable CreateDataSource(string filePath, string sheetName)
    {
        string strConn = "Driver={Microsoft Text Driver (*.txt; *.csv)}; " +
                         "Dbq= " + filePath + ";Extensions=csv,txt ";

        strConn = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath + ";Extended Properties='Text;'";

        System.Data.OleDb.OleDbConnection conn = new System.Data.OleDb.OleDbConnection(strConn);
        System.Data.OleDb.OleDbDataAdapter Adapter = new System.Data.OleDb.OleDbDataAdapter("SELECT * FROM [" + sheetName + "$]", strConn);
        DataSet myDataSet = new DataSet();
        Adapter.Fill(myDataSet);
        return myDataSet.Tables[0];
    }
    /// <summary>
    /// 取出sheet
    /// </summary>
    /// <param name="filePath"></param>
    /// <returns></returns>
    public string getFirstSheetName(string filePath)
    {
        string ret = "";
        string strConn = "Driver={Microsoft Text Driver (*.txt; *.csv)}; " +
                         "Dbq= " + filePath + ";Extensions=csv,txt "; 

        strConn = string.Format(strConn, filePath);

        System.Data.OleDb.OleDbConnection conn = new System.Data.OleDb.OleDbConnection(strConn);
        conn.Open();
        using (DataTable dt = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null))
        {
            ////取得工作表數量，法一
            //foreach (DataRow dr in dt.Rows)
            //{
            //    Console.WriteLine((String)dr["TABLE_NAME"]);
            //}
            //取得工作表數量，法二
            int TableCount = dt.Rows.Count;
            for (int i = 0; i < TableCount; i++)
            {  
                ret = dt.Rows[i  ][2].ToString().Trim().TrimEnd('$');
                conn.Close();
                return ret;           
            }
        }
        conn.Close();
        return ret;
    }
    //private DataSet CreateDataSource2(string filePath, string sheetName)
    //{
    //    string strConn;
    //    strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" +
    //    @"Data Source={0}" +
    //    "Extended Properties=Excel 8.0;;HDR=YES\"";
    //    strConn = string.Format(strConn, filePath);

    //    System.Data.OleDb.OleDbConnection conn = new System.Data.OleDb.OleDbConnection(strConn);
    //    System.Data.OleDb.OleDbDataAdapter myCommand = new System.Data.OleDb.OleDbDataAdapter("SELECT * FROdM [" + sheetName + "$]", strConn);
    //    DataSet myDataSet = new DataSet();
    //    myCommand.Fill(myDataSet);
    //    return myDataSet;
    //}
    #region 其它的讀的方式,日後若有需要,則可參考
    //public void Retrieve_Records_Reader()
    //{
    //    //==========================================================
    //    //Use a DataReader to read data from the EmployeeData table.
    //    //==========================================================

    //    System.Data.OleDb.OleDbConnection conn1 = new System.Data.OleDb.OleDbConnection(m_sConn1);
    //    conn1.Open();
    //    System.Data.OleDb.OleDbCommand cmd1 = new System.Data.OleDb.OleDbCommand("Select * From [Sheet1$]", conn1);
    //    OleDbDataReader rdr = cmd1.ExecuteReader();

    //    //Debug.WriteLine(Constants.vbCrLf + "Sheet1:" + Constants.vbCrLf + "=============");
    //    while (rdr.Read())
    //    {
    //        MessageBox.Show(System.String.Format("{0,-10}{1, -15}{2}", rdr.GetString(0), rdr.GetString(1), rdr.GetDateTime(2).ToString("d")));
    //    }
    //    rdr.Close();
    //    conn1.Close();
    //}
    //public void Retrieve_Records_DataSet()
    //{
    //    //========================================================
    //    //Use a DataSet to read data from the InventoryData table.
    //    //========================================================
    //    OleDbConnection conn2 = new OleDbConnection(m_sConn2);
    //    OleDbDataAdapter da = new OleDbDataAdapter("Select * From [InventoryData$]", conn2);
    //    DataSet ds = new DataSet();
    //    da.Fill(ds);
    //    //Debug.WriteLine(Constants.vbCrLf + "InventoryData:" + Constants.vbCrLf + "==============");
    //    DataRow dr = null;
    //    //Show results in output window
    //    foreach (DataRow dr_loopVariable in ds.Tables[0].Rows)
    //    {
    //        dr = dr_loopVariable;
    //        Debug.WriteLine(System.String.Format("{0,-15}{1, -6}{2}", dr["Product"], dr["Qty"], dr["Price"]));
    //    }
    //    conn2.Close();
    //}
    #endregion 
} 
