using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Panbor_ImportWebSO
{
    public sealed class Activity
    {
        private string _actNO, _SONO, _StatusCode,_StatusDesc,_failQty,_failReasonCode,_failReasonDesc,_RptID,_RptDate,_RptTime;

        //private const string Path = "C:\\\\TMVC\\";
        //private const string FileName = Path + "Rpt1.log";

        #region 公開屬性
        public string key { get { return _actNO; } set { _actNO = value; } }
        public string SONO { get { return _SONO; } set { _SONO = value; } }
        public string StatusCode { get { return _StatusCode; } set { _StatusCode = value; } }
        public string StatusDesc { get { return _StatusDesc; } set { _StatusDesc = value; } }
        public string RptID { get { return _RptID; } set { _RptID = value; } }
        public string RptDate { get { return _RptDate; } set { _RptDate = value; } }
        public string RptTime { get { return _RptTime; } set { _RptTime = value; } }
        public string NGQty { get { return _failQty; } set { _failQty = value; } }
        public string NGReasonCode { get { return _failReasonCode; } set { _failReasonCode = value; } }
        public string NGReasonDesc { get { return _failReasonDesc; } set { _failReasonDesc = value; } }


        #endregion
        public Activity()
        {
            //System.IO.DirectoryInfo oDir = new System.IO.DirectoryInfo();
            ////if (!oDir.Exists)
            //{
            //    oDir.Create();
            //}
            key = "";
            SONO = "";
            StatusCode = "";
            StatusDesc = "";
            RptID = "";
            RptDate = "";
            RptTime = "";
            NGQty = "0";
            NGReasonCode = "";
            NGReasonDesc = "";
        }

        /// <summary>
        /// 讀取文件
        /// </summary>
        //public StreamReader ReadAll()
        //{
        //    StreamReader ret;           
        //        try
        //        {
        //            ret = new StreamReader(FileName);
        //        }
        //        catch (Exception e)
        //        {
        //            // Let the user know what went wrong.
        //            throw (e);
        //        } 
        //    return ret;
        //}

        //#region save(delall/delpart/nodel)
        ///// <summary>
        ///// 儲存文件
        ///// </summary>
        //public void addRow()
        //{
        //    string s = string.Empty;
        //    //第0位置訂單號碼
        //    //第1位置站點狀態code
        //    //第2位置站點狀態desc

        //    //第3位置fail 物料數量
        //    //第4位置fail原因code
        //    //第5位置fail原因desc     
       
        //    //第6位置回報人員
        //    //第7位置回報日期
        //    //第8位置回報time
        //    s += this.SONO;
        //    s += ";" + this.StatusCode;
        //    s += ";" + this.StatusDesc;

        //    s += ";" + this.failQty;
        //    s += ";" + this.failReasonCode;
        //    s += ";" + this.failReasonDesc;

        //    s += ";" + this.RptID;
        //    s += ";" + this.RptDate;
        //    s += ";" + this.RptTime;

        //    save(s, FileName);             
        //}
        //public void addFirstRow()
        //{
        //    string s = string.Empty;
        //    //第0位置訂單號碼
        //    //第1位置站點狀態code
        //    //第2位置站點狀態desc

        //    //第3位置fail 物料數量
        //    //第4位置fail原因code
        //    //第5位置fail原因desc     

        //    //第6位置回報人員
        //    //第7位置回報日期
        //    //第8位置回報time
        //    s += this.SONO;
        //    s += ";" + this.StatusCode;
        //    s += ";" + this.StatusDesc;

        //    s += ";" + this.failQty;
        //    s += ";" + this.failReasonCode;
        //    s += ";" + this.failReasonDesc;

        //    s += ";" + this.RptID;
        //    s += ";" + this.RptDate;
        //    s += ";" + this.RptTime;

        //    saveFirstRow(s, FileName);
        //}
        //public void Del()
        //{
        //    File.Delete(FileName);
        //}
        //#endregion 

        
        //public  bool existedFile()
        //{
        //    bool ret =   File.Exists(FileName);
        //    return ret;
        //}
        //#region save function for this cs

        //private void save(string Msg, string Path)
        //{
        //    using (System.IO.StreamWriter sw = new System.IO.StreamWriter(Path, true, System.Text.Encoding.GetEncoding(65001)))
        //    {
        //        sw.WriteLine(Msg);
        //        sw.Dispose();
        //    }
        //}
        //private void saveFirstRow(string Msg, string Path)
        //{
        //    using (System.IO.StreamWriter sw = new System.IO.StreamWriter(Path, false, System.Text.Encoding.GetEncoding(65001)))
        //    {
        //        sw.WriteLine(Msg);
        //        sw.Dispose();
        //    }
        //}

        //#endregion 


    }
}

            //if (string.IsNullOrEmpty(s))
            //{
            //    return;
            //}

            //string[] ary = s.Split(new char[] { ';' });

            //int i = 0;

            //for (i = 0; i <= ary.Length - 1; i++)
            //{
            //    s = ary[i];
            //    switch (i)
            //    {
            //        case 0:
            //            this.SONO = s;
            //            break; 
            //        case 1:
            //            this.StatusCode  = s;
            //            break;
            //        case 2:
            //            this.StatusDesc = s;                        
            //            break;

            //        case 3:
            //            this.failQty = s;
            //            break;
            //        case 4:
            //            this.failReasonCode = s;
            //            break;
            //        case 5:
            //            this.failReasonDesc = s;
            //            break;

            //        case 6:
            //            this.RptID = s;
            //            break;
            //        case 7:
            //            this.RptDate = s;
            //            break;
            //        case 8:
            //            this.RptTime = s;
            //            break;
                    
            //    }