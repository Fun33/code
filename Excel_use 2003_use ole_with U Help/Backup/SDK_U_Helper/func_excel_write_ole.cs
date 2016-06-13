using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics; 
using System.Reflection;
using System.Data.OleDb;
using System.IO;

//http://www.dotblogs.com.tw/yc421206/archive/2009/01/11/6727.aspx
//http://blog.csdn.net/hummy010/article/details/6222751

public class func_excel_write_ole
{
    //要怎麼加try catch比較好呢

    //使用說明
    //string filepath = @"E:\ExcelData1.xls";
    // If the workbooks already exist, prompt to delete.
    //DialogResult answer = default(DialogResult);
    //if (!string.IsNullOrEmpty(FileSystem.Dir(filePath, FileAttribute.Normal)))
    //{
    //    answer = MessageBox.Show("Delete existing workbooks (" + filePath + ")?", "詢問", MessageBoxButtons.YesNo);
    //    if (answer == DialogResult.Yes)
    //    {
    //        if (!string.IsNullOrEmpty(FileSystem.Dir(filePath, FileAttribute.Normal)))
    //            FileSystem.Kill(filePath);
    //    }
    //    else
    //    {
    //        return;
    //    }
    //}
    //"CREATE TABLE Sheet1 (Id char(255), Name char(255), Name2 char(255))" 
    //"INSERT INTO EmployeeData (Id, Name, BirthDate) values ('AAA', 'Andrew', '12/4/1955')";
    //"UPDATE [EmployeeData$F3:G3] SET F1 = 'Cell F3', F2 = 'Cell G3'"
    //可以create table/add recorder/update recorder
    public void DoQery(string filePath, string CommandText)
    {
        string m_sConn1 = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + filePath + ";" + "Extended Properties=\"Excel 8.0;HDR=YES\"";


      

        
            //==========================================================================
            // Create a workbook with a table named EmployeeData. The table has 3 
            // fields: ID (char 255), Name (char 255) and Birthdate (date).  
            //==========================================================================
            OleDbConnection conn = new OleDbConnection();
            try
            {
            conn.ConnectionString = m_sConn1;
            conn.Open();
            OleDbCommand cmd1 = new OleDbCommand();
            cmd1.Connection = conn;
            cmd1.CommandText = CommandText;//"CREATE TABLE Sheet1 (Id char(255), Name char(255), Name2 char(255))";
            cmd1.ExecuteNonQuery();
            //cmd1.CommandText = "INSERT INTO EmployeeData (Id, Name, BirthDate) values ('AAA', 'Andrew', '12/4/1955')";
            //cmd1.ExecuteNonQuery();
            conn.Close();
        }
        catch (Exception ex)
        {
            conn.Close();
        }
    }

    //public void Create(string filePath)
    //{
    //    string CommandText = "供應商 char(255),項目群組 char(255),利潤群組 char(255),貨號 char(255),條碼 char(255),項目說明 char(255),外國語言說明 char(255),定價 char(255),採購單位 char(255),銷售單位 char(255),顏色 char(255),尺寸 char(255),使用者定義佣金 char(255),係數1 char(255),係數2 char(255),係數3 char(255),係數4 char(255),長度 char(255),寬度 char(255),毛重 char(255),材積 char(255),特別說明 char(255),主題 char(255),倉庫 char(255),屬性1 char(255),屬性2 char(255),屬性3 char(255),屬性4 char(255),屬性5 char(255),屬性6 char(255),屬性7 char(255),屬性8 char(255),屬性9 char(255),屬性10 char(255),屬性11 char(255),屬性12 char(255),屬性13 char(255),屬性14 char(255),屬性15 char(255),屬性16 char(255),屬性17 char(255),屬性18 char(255),屬性19 char(255),屬性20 char(255),屬性21 char(255),屬性22 char(255),屬性23 char(255),屬性24 char(255),屬性25 char(255),屬性26 char(255),屬性27 char(255),屬性28 char(255),屬性29 char(255),屬性30 char(255),屬性31 char(255),屬性32 char(255),屬性33 char(255),屬性34 char(255),屬性35 char(255),屬性36 char(255),屬性37 char(255),屬性38 char(255),屬性39 char(255),屬性40 char(255),屬性41 char(255),屬性42 char(255),屬性43 char(255),屬性44 char(255),屬性45 char(255),屬性46 char(255),屬性47 char(255),屬性48 char(255),屬性49 char(255),屬性50 char(255),屬性51 char(255),屬性52 char(255),屬性53 char(255),屬性54 char(255),屬性55 char(255),屬性56 char(255),屬性57 char(255),屬性58 char(255),屬性59 char(255),屬性60 char(255),屬性61 char(255),屬性62 char(255),屬性63 char(255),屬性64 char(255),年度 char(255),國碼 char(255),採購基礎價 char(255)";

    //    CommandText = "CREATE TABLE Sheet1 ( " & CommandText & ")";
    //    DoQery(filePath, CommandText);

    //}
    //public void Insert(string filePath)
    //{

    //    string CommandText = "供應商,項目群組,利潤群組,貨號,條碼,項目說明,外國語言說明,定價,採購單位,銷售單位,顏色,尺寸,使用者定義佣金,係數1,係數2,係數3,係數4,長度,寬度,毛重,材積,特別說明,主題,倉庫,屬性1,屬性2,屬性3,屬性4,屬性5,屬性6,屬性7,屬性8,屬性9,屬性10,屬性11,屬性12,屬性13,屬性14,屬性15,屬性16,屬性17,屬性18,屬性19,屬性20,屬性21,屬性22,屬性23,屬性24,屬性25,屬性26,屬性27,屬性28,屬性29,屬性30,屬性31,屬性32,屬性33,屬性34,屬性35,屬性36,屬性37,屬性38,屬性39,屬性40,屬性41,屬性42,屬性43,屬性44,屬性45,屬性46,屬性47,屬性48,屬性49,屬性50,屬性51,屬性52,屬性53,屬性54,屬性55,屬性56,屬性57,屬性58,屬性59,屬性60,屬性61,屬性62,屬性63,屬性64,年度,國碼,採購基礎價";

    //            vals.Split(",");
    //            CommandText = "INSERT INTO Sheet1 (" & flds & ") VALUES (" & vals & ")";
    //    flds.Split(",");
    //    DoQery(filePath, CommandText);

    //}
    public void ExportExcel(System.Data.DataTable dt, string file)
    {

        //string file = @"Z:\123.xls";
        System.IO.StreamWriter sw = null;
        string ColumnTitle = "";
        try
        {
            using (System.IO.Stream fs = System.IO.File.Create(file))
            {
                using (sw = new System.IO.StreamWriter(fs, System.Text.Encoding.UTF8))
                //using (sw = new StreamWriter(file))
                {

                    //寫標題
                    for (int i = 0; i <= dt.Columns.Count - 1; i++)
                    {
                        if (i > 0)
                        {//new char[] { '\t' }
                            ColumnTitle += ",";//Convert.ToChar(9); // Constants.vbTab;
                        }
                        ColumnTitle += dt.Columns[i].Caption;
                    }
                    sw.WriteLine(ColumnTitle);

                    //寫內容
                    for (int j = 0; j <= dt.Rows.Count - 1; j++)
                    {
                        string columnValue = "";
                        for (int k = 0; k <= dt.Columns.Count - 1; k++)
                        {
                            if (k > 0)
                            {
                                columnValue += ",";// Convert.ToChar(9); // Constants.vbTab;
                            }
                            //日期處理
                            if (dt.Rows[j][k].GetType().ToString().ToUpper() == "SYSTEM.DATETIME")
                            {
                                try
                                {
                                    columnValue += System.DateTime.Parse(dt.Rows[j][k].ToString());
                                }
                                catch
                                {
                                    columnValue += "";
                                }
                            }
                            else
                            {
                                columnValue += dt.Rows[j][k].ToString();
                            }
                        }
                        sw.WriteLine(columnValue);
                    }
                }
            }
        }
        catch (Exception ex)
        { 
            throw(new Exception(ex.ToString()));
        }
    }
  
}
