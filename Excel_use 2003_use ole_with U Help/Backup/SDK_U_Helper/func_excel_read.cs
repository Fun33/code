//using Microsoft.VisualBasic;
//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Data;
//using System.Diagnostics;

//using System.Data.OleDb;
//using System.IO; 
//  public class func_excel_read
//{
 
 ////使用說明
   //private void Search()
   //     {
   //         OpenFileDialog openFileDialog1 = new OpenFileDialog();
   //         openFileDialog1.Filter = "xls Excel 檔案|*.xls|xlsx 2007 Excel 檔案|*.xlsx";
   //         openFileDialog1.Title = "Select a Excel File";

   //         if (openFileDialog1.ShowDialog() == DialogResult.OK)
   //         {
   //             TextFilePath.Text = openFileDialog1.FileName;
   //         }
   //     }
   //     public System.Data.DataTable loadGridFromExcel(string astrFileName, string orderCmd)
   //     {
   //         System.Data.DataTable ret;
   //         func_excel_read f = new func_excel_read();

   //         // "D:\cadmen\服務部\客戶提供的文件\panbor\_test\大買家_test.xls"
   //         string strSheetName = f.GetExcelWorkSheets(astrFileName)[0].ToString().Trim();
   //          string cmd = "Select  * from [{0}$] {1}"; 
   //         cmd = string.Format(cmd, strSheetName, orderCmd);
   //         ret = f.GetExcelData(astrFileName, cmd);// order by 訂單編號");

   //         return ret;
   //     }
//    //public DataTable GetExcelData(string astrFileName)
//    //{
//    //    string strSheetName = GetExcelWorkSheets(astrFileName)[0].ToString();
//    //    return GetExcelData(astrFileName, strSheetName);
//    //}
//    //GetExcelData有用到.
//    public  ArrayList GetExcelWorkSheets(string strFilePath)
//    {
//        ArrayList alTables = new ArrayList();

//        OleDbConnection odn = new OleDbConnection(GetExcelConnection(strFilePath));
//        odn.Open();

//        DataTable dt = new DataTable();

//        dt = odn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

//        if (dt == null)
//        {
//            throw new Exception("can't read");
//        }

//        foreach (DataRow dr in dt.Rows)
//        {
//            string tempName = dr["Table_Name"].ToString();

//            int iDolarIndex = tempName.IndexOf("$");

//            if (iDolarIndex > 0)
//            {
//                tempName = tempName.Substring(0, iDolarIndex);
//            }


//            if (string.IsNullOrEmpty(tempName[0].ToString()))
//            {
//                if (string.IsNullOrEmpty(tempName[tempName.Length - 1].ToString()))
//                {
//                    tempName = tempName.Substring(1, tempName.Length - 2);
//                }
//                else
//                {
//                    tempName = tempName.Substring(1, tempName.Length - 1);

//                }
//            }
//            if (!alTables.Contains(tempName))
//            {
//                alTables.Add(tempName);
//            }
//        }

//        odn.Close();

//        if (alTables.Count == 0)
//        {
//            return null;
//        }

//        return alTables;
//    }
//    //public   DataTable GetExcelData(string FilePath, string WorkSheetName)
//    //{
//    //    if (WorkSheetName =="")
//    //        WorkSheetName = GetExcelWorkSheets(FilePath)[0].ToString();
//    //    DataTable dtExcel = new DataTable();
//    //    OleDbConnection con = new OleDbConnection(GetExcelConnection(FilePath));
//    //    OleDbDataAdapter adapter = new OleDbDataAdapter("Select *  from [" + WorkSheetName + "$]", con);
//    //    con.Open();
//    //    adapter.FillSchema(dtExcel, SchemaType.Mapped);
//    //    adapter.Fill(dtExcel);
//    //    con.Close();
//    //    dtExcel.TableName = WorkSheetName;

//    //    return dtExcel;
//    //}


//      public DataTable GetExcelData(string FilePath, string cmd)
//      {
//          DataTable dtExcel = new DataTable();
//          OleDbConnection con = new OleDbConnection(GetExcelConnection(FilePath));
//          OleDbDataAdapter adapter = new OleDbDataAdapter(cmd, con);
//          con.Open();
//          adapter.FillSchema(dtExcel, SchemaType.Mapped);
//          adapter.Fill(dtExcel);
//          con.Close();
//          dtExcel.TableName = "";

//          return dtExcel;
//      }
//    public string GetExcelConnection(string strFilePath)
//    {
//        if (!File.Exists(strFilePath))
//        {
//            throw new Exception("no file！");
//        }
//        return "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + strFilePath + ";Extended properties=\"Excel 8.0;Imex=1;HDR=Yes;\"";
//        //Return "Provider=Microsoft.Jet.OLEDB.12.0;Data Source=" & strFilePath & ";Extended properties=""Excel 12.0;Imex=1;HDR=No;"""

//        //@"Provider=Microsoft.Jet.OLEDB.4.0;" +
//        //@"Data Source=" + strFilePath + ";" +
//        //@"Extended Properties=" + Convert.ToChar(34).ToString() +
//        //@"Excel 8.0;" + "Imex=1;HDR=Yes;" + Convert.ToChar(34).ToString();        
//    }
//}
