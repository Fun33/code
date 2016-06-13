using System;
using System.Collections.Generic;
using System.Text;

 
   public class func_txt
    {
        #region log
        //叫出記事本         
        // System.Diagnostics.Process.Start(@"E:\123.txt"); 

        public static void log(string Msg)
        {
            log("C:\\\\Log", Msg);
        }
        ///<summary>
        ///log
        ///     </summary>
        ///<param name="StartupPath">儲存的目錄位置</param>
        ///<param name="ErrorMsg">訊息</param>    
        public static void log(string StartupPath, string msg)
        {
            string FileName = DateTime.Now.ToString("yyyyMMdd");
            string sPath = null;

            sPath = StartupPath;

            System.IO.DirectoryInfo oDir = new System.IO.DirectoryInfo(sPath);
            if (!oDir.Exists)
            {
                oDir.Create();
            }

            System.IO.StreamWriter sw = new System.IO.StreamWriter(sPath + "\\\\" + FileName + ".log", true, System.Text.Encoding.GetEncoding("utf-8"));

            sw.WriteLine(DateTime.Now.ToString() + " --" + msg);
            sw.Close();
        }
        #endregion
        #region "write and show"
       private void button1_Click(object sender, EventArgs e)
       {
           //寫入記事本
           string msg = "你好" + Environment.NewLine;
           msg += "愛你怎麼能用嘴巴說" + Environment.NewLine;
           string filePath = @"E:\123.txt";
           log(filePath, msg);
       }
       public static void LogAndShow(string filePath, string msg)
       {
           //System.IO.StreamWriter sw = new System.IO.StreamWriter(sPath + "\\\\" + FileName + ".log", true, System.Text.Encoding.GetEncoding("utf-8"));
           System.IO.StreamWriter sw = new System.IO.StreamWriter(filePath, true, System.Text.Encoding.GetEncoding("utf-8"));

           sw.WriteLine(msg);
           sw.Close();

           //叫出記事本         
           System.Diagnostics.Process.Start(filePath);
       }
        #endregion 
    }
 