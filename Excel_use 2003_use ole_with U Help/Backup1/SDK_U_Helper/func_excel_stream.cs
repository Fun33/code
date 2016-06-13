using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace SDK_U_Helper
{
 public    class func_excel_stream
    {
        //public System.Data.DataTable ReadExcel()
        //{
        //    System.Data.DataTable dt = new System.Data.DataTable();
            
        //    StreamReader sr = new StreamReader(txtSource);
        //    DataRow dr;
        //    int dtCount = dt.Columns.Count;
        //    string input;
        //    int i = 0;
        //    while ((input = sr.ReadLine()) != null)
        //    {

        //        try
        //        {
        //            string[] stringRows = input.Split(new char[] { '\t' });
        //            dr = dt.NewRow();
        //            for (int a = 0; a < dtCount; a++)
        //            {
        //                string dataType = dt.Columns[a].DataType.ToString();
        //                if (stringRows[a] == "" && (dataType == "System.Int32" || dataType == "System.Int64"))
        //                {
        //                    stringRows[a] = "0";
        //                }
        //                dr[a] = Convert.ChangeType(stringRows[a], dt.Columns[a].DataType);

        //            }
        //            dt.Rows.Add(dr);
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine(ex.ToString());
        //        }
        //        i++;
        //    }
        //    return dt;
        //}

        //if no choose folder>看起來沒有問題
        //if error
        //chk header right or not.>看起來沒有問題
        //chk date>看起來沒有問題.
        public string ExportExcel(string Title, System.Data.DataTable dt, System.Windows.Forms.SaveFileDialog saveFileDialog)
        {
            //SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Execl files (*.xls)|*.xls";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.CreatePrompt = false;
            saveFileDialog.Title = Title;
            saveFileDialog.FileName = System.DateTime.Now.ToString("yyyyMMdd");
            saveFileDialog.ShowDialog();
            //如果按下取消,那就會拿到沒有path的filename,所以只要判斷有沒有:,如果沒有,回傳-1,表示按下取消
            if (saveFileDialog.FileName.IndexOf(":") < 0)
            {
                return "";
            }

            //字串流
            System.IO.Stream myStream = null;
            System.IO.StreamWriter sw = null;
            string ColumnTitle = "";
            try
            {
                myStream = saveFileDialog.OpenFile();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            //你要寫哪個流,把它放進去.
            sw = new System.IO.StreamWriter(myStream, System.Text.Encoding.UTF8);
            try
            {
                //寫標題
                for (int i = 0; i <= dt.Columns.Count - 1; i++)
                {

                    if (i > 0)
                    {
                        ColumnTitle += ",";// Constants.vbTab;
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
                            columnValue += ",";// Constants.vbTab;
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
                sw.Close();
                myStream.Close();
                return saveFileDialog.FileName + "檔案匯出完成";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
            finally
            {
                sw.Close();
                myStream.Close();
            }

        }
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
                            {
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
            { }
        }
    }
}
