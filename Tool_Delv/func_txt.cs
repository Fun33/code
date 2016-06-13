using System;
using System.Collections.Generic;
using System.Text;

/*
 * sql有誤,跳出來看
 * service 開發階段,要知道它做了什麼
 */
public class func_txt
{
    private static bool IsDebug = true;//detail 
    private static bool OnlyError = false;
    public enum LogType { none, error };

    /// <summary>
    /// func_txt.ReadSQL(@"SQLFunction\RunCost1.sql");
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public static string ReadSQL(string path)
    {
        string filePath, cmd = "";
        System.IO.FileInfo file;
        try
        {
            filePath = System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, path);
            file = new System.IO.FileInfo(filePath);
            System.IO.StreamReader sr = file.OpenText();
            //System.Diagnostics.Debug.WriteLine(sr.CurrentEncoding);
            cmd = sr.ReadToEnd();
            //cmd = file.OpenText().ReadToEnd();
        }
        catch (Exception ex)
        {
            func_txt.log(func_txt.LogType.error, ex.Message + Environment.NewLine + ex.ToString());
        }
        return cmd;
    }
    #region log
    //叫出記事本         
    // System.Diagnostics.Process.Start(@"E:\123.txt"); 


    /// <summary>
    /// debug show 
    /// release just log
    /// </summary>
    /// <param name="Msg"></param>
    public static void log(string Msg)
    {
        string FilePath = System.IO.Directory.GetCurrentDirectory();
        log(FilePath, Msg);
    }
    public static void chat(string Msg)
    {
        string FilePath = System.IO.Directory.GetCurrentDirectory();
        chat(FilePath, Msg);
    }
    public static void log(LogType type, string Msg)
    {
        if (type == LogType.none && OnlyError == true)
            return;

        string FilePath = System.IO.Directory.GetCurrentDirectory();
        log(FilePath, Msg);
    }
    private static void chat(string StartupPath, string msg)
    {
        string FileName = DateTime.Now.ToString("yyyyMMdd");
        string sPath = null;
        string filePath;
        sPath = StartupPath;

        System.IO.DirectoryInfo oDir = new System.IO.DirectoryInfo(sPath);
        if (!oDir.Exists)
        {
            oDir.Create();
        }
        filePath = sPath + "\\\\" + FileName + ".log";

        //System.IO.StreamWriter sw = new System.IO.StreamWriter(filePath, true, System.Text.Encoding.GetEncoding("Big5"));
        System.IO.StreamWriter sw = new System.IO.StreamWriter(filePath, true, System.Text.Encoding.GetEncoding("utf-8"));
        //System.IO.StreamWriter sw = new System.IO.StreamWriter(filePath, true, System.Text.Encoding.GetEncoding("Unicode"));

        sw.WriteLine(DateTime.Now.ToShortTimeString () + "  " + msg);
        sw.Close();

        //if (IsDebug)
        //    //叫出記事本         
        //    System.Diagnostics.Process.Start(filePath);
    } 
    ///<summary>
    ///log
    ///     </summary>
    ///<param name="StartupPath">儲存的目錄位置</param>
    ///<param name="ErrorMsg">訊息</param>    
    private static void log(string StartupPath, string msg)
    {
        string FileName = DateTime.Now.ToString("yyyyMMdd");
        string sPath = null;
        string filePath;
        sPath = StartupPath;

        System.IO.DirectoryInfo oDir = new System.IO.DirectoryInfo(sPath);
        if (!oDir.Exists)
        {
            oDir.Create();
        }
        filePath =sPath + "\\\\" + FileName + ".log";
      
        //System.IO.StreamWriter sw = new System.IO.StreamWriter(filePath, true, System.Text.Encoding.GetEncoding("Big5"));
        System.IO.StreamWriter sw = new System.IO.StreamWriter(filePath, true, System.Text.Encoding.GetEncoding("utf-8"));
        //System.IO.StreamWriter sw = new System.IO.StreamWriter(filePath, true, System.Text.Encoding.GetEncoding("Unicode"));

        sw.WriteLine(DateTime.Now.ToString() + " --" + msg);
        sw.Close();

        //if (IsDebug)
        //    //叫出記事本         
        //    System.Diagnostics.Process.Start(filePath);
    } 
    ///<summary>
    ///log
    ///     </summary>
    ///<param name="StartupPath">儲存的目錄位置</param>
    ///<param name="ErrorMsg">訊息</param>    
    ///<param name="ErrorMsg">FileName</param>    
    public static void log(string StartupPath, string msg, string FileName)
    { 
        string sPath = null;
        string filePath;
        if (StartupPath =="")
                StartupPath = System.IO.Directory.GetCurrentDirectory();

        sPath = StartupPath;

        System.IO.DirectoryInfo oDir = new System.IO.DirectoryInfo(sPath);
        if (!oDir.Exists)
        {
            oDir.Create();
        }
        filePath = sPath + "\\\\" +  DateTime.Now.ToString("yyyyMMdd")+FileName + ".log";

        //System.IO.StreamWriter sw = new System.IO.StreamWriter(filePath, true, System.Text.Encoding.GetEncoding("Big5"));
        //System.IO.StreamWriter sw = new System.IO.StreamWriter(filePath, true, System.Text.Encoding.GetEncoding("utf-8"));
        System.IO.StreamWriter sw = new System.IO.StreamWriter(filePath, true, System.Text.Encoding.GetEncoding("Unicode"));

        sw.WriteLine(DateTime.Now.ToString() + " --" + msg);
        sw.Close();

        //if (IsDebug)
        //    //叫出記事本         
        //    System.Diagnostics.Process.Start(filePath);
    }
    public static  void ShowLog()
    {
        string FileName = DateTime.Now.ToString("yyyyMMdd");
        string sPath = System.IO.Directory.GetCurrentDirectory(); ;
        string   filePath = sPath + "\\\\" + FileName + ".log";
        System.Diagnostics.Process.Start(filePath);
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

    public static void LogAndShow(string Msg)
    {
        string FilePath = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\\\debug.txt";//System.IO.Directory.GetCurrentDirectory();
        LogAndShow(FilePath, Msg);
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
 