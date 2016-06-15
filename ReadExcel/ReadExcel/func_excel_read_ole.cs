using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;

using System.Data.OleDb;
using System.IO;

//11EC00讀到空白
//解決方案
//"Extended Properties='Excel 8.0;IMEX=1;HDR=yes;'";
//+前面加' ('11EC00)
//無效的解決方案
//"Extended Properties='Excel 8.0;IMEX=1;HDR=yes;'"; + col設為文字 >>讀的到,但它會以為是數字
//"Extended Properties='Excel 8.0;'"; + col設為文字     >>讀不到
//"Extended Properties='Excel 8.0;'"; + 前面加'            >>讀不到

/*2007  Provider - Microsoft.ACE.OLEDB.12.0
到了Office 2007 之後，檔案架構已經不一樣了，
 * Office 2007 是使用 XML 格式來存檔的，而且，
 * Office 2007 又比 Micorsoft,Jet.OleDB.4.0 晚出好幾年，理所當然是不可能支援的。
因此，就會出現新的 Provider "Microsoft.ACE.OLEDB.12.0" 。

新的 Provider 需要至完軟的網站下載並安裝 AccessDatabaseEngine.exe，
 * 下載位置：2007 Office system 驅動程式：資料連線元件 http://www.microsoft.com/zh-tw/download/details.aspx?id=23734

這一組元件，可供非 Microsoft Office 應用程式用來讀取 2007 Office system 檔案中的資料，
 * 例如 Microsoft Office Access 2007 (mdb 和 accdb) 檔案以及 Microsoft Office Excel 2007 (xls、xlsx 和 xlsb) 檔案。
 * 也支援連線至 Microsoft Windows SharePoint Services 和文字檔案。
 */

 
public   class func_excel_read_ole 
{

    //?要怎麼加try catch比較好呢

    //使用方法
    //         System.Data.DataTable dt = new func_excel_read_ole().CreateDataSource(@"Z:\cadmen\服務部\客戶需求單\YFY\ERP標準書(SAP).xls;", "內容物重量");

    //        for (int i = 0; i < dt.Rows.Count; i++)
    //        {
    //            string msg = dt.Rows[i]["內容物"].ToString() + "--" + dt.Rows[i]["重量"].ToString();
    //            MessageBox.Show(msg);
    //        }

    private string sConnstring = "";
    private string sConnstring2003 = "Provider=Microsoft.Jet.OLEDB.4.0;" +
                @"Data Source={0};" +
                 "Extended Properties='Excel 8.0;HDR=yes;IMEX=1;' ";

    private string sConnstring2007 = @"Provider=Microsoft.ACE.OLEDB.12.0;" +
        "Data Source={0};" +
        "Extended Properties='Excel 12.0 Xml;HDR=YES;IMEX=1;' ";
  public   enum ExcelVersion { e2003, e2007 }

    /// <summary>
    /// 沒給預設2003
    /// </summary>
    public   func_excel_read_ole()
    {
        sConnstring = sConnstring2003;
    }
    public   func_excel_read_ole(ExcelVersion ver)
    {
        if (ver == ExcelVersion.e2003)
            sConnstring = sConnstring2003;
        else
            sConnstring = sConnstring2007;
    }
    public DataTable CreateDataSourceTop1(string filePath, string sheetName)
    {
        DataSet myDataSet = new DataSet();

        string strConn = sConnstring;

        strConn = string.Format(strConn, filePath);

        System.Data.OleDb.OleDbConnection conn = new System.Data.OleDb.OleDbConnection(strConn);
        System.Data.OleDb.OleDbDataAdapter Adapter = new System.Data.OleDb.OleDbDataAdapter("SELECT top 1 * FROM [" + sheetName + "$]", strConn);

        Adapter.Fill(myDataSet);

        return myDataSet.Tables[0];
    }
    /// <summary>          
    /// func_excel_read_ole f = new func_excel_read_ole();
    /// System.Data.DataTable ret = f.CreateDataSource(filePath, SheetName); 
    /// </summary>
    /// <param name="filePath"></param>
    /// <param name="sheetName"></param>
    /// <returns></returns>
    public DataTable GetDataSource(string filePath, string sheetName)
    {
        string strConn = sConnstring;

        strConn = string.Format(strConn, filePath);

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
        string strConn = sConnstring;
        //"Extended Properties=Excel 8.0;";

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
                ret = dt.Rows[i][2].ToString().Trim().TrimEnd('$');
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
    /////// <summary>
    /////// 好的.只是因為TTFB,沒有用到UI,所以拿掉
    /////// </summary>
    //public  void Convert(SAPbouiCOM.DataTable oDTto, System.Data.DataTable oDTfr)
    //{
    //    oDTto.Clear();
    //    //add col
    //    for (int i = 0; i < oDTfr.Columns.Count; i++)
    //    {
    //        oDTto.Columns.Add(oDTfr.Columns[i].Caption, SAPbouiCOM.BoFieldsType.ft_AlphaNumeric, 254);
    //    }

    //    //add row
    //    for (int i = 0; i < oDTfr.Rows.Count; i++)
    //    {
    //        oDTto.Rows.Add(1);
    //        for (int j = 0; j < oDTfr.Columns.Count; j++)
    //        {
    //            oDTto.SetValue(j, i, oDTfr.Rows[i][j].ToString());
    //        }
    //    }
    //} 
    #endregion
}
