using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;//for debug.write
using System.Text.RegularExpressions;//for regular
using System.Drawing;//for Graphics
using System.Text;//for Encoding
using System.IO;
using System.Runtime.InteropServices;


//CR.ref.http://tw.myblog.yahoo.com/jw!TXvX2.6THhMT2NTraH1FQXe8/article?mid=1

/// <summary>
/// 不限用於SAP
/// </summary>
public class func
{
    #region enum
    //public  enum character
    //  { 
    //      tw=0,
    //      eng=1,
    //      number=2
    //  }
#endregion 


    public static bool IsFileLocked(string file)
    {
        try
        {
            using (File.Open(file, FileMode.Open, FileAccess.Write, FileShare.None))
            {
                return false;
            }
        }
        catch (IOException exception)
        {
            int errorCode = Marshal.GetHRForException(exception) & 65535;
            return errorCode == 32 || errorCode == 33;
        }
        catch (Exception)
        {
            return false;
        }
    }
  
    public static string  DefInt(string val)
    {
        string  ret ="0";
        if (val.Trim() == "")
            ret = "0";
        else
            ret = val;

        return ret;
    }
    //matrix datatable ref http://forums.sdn.sap.com/thread.jspa?threadID=338107

 //    stuff(time, 2, 0, ':')
    //using System.Globalization;
    //DateTime parsed;
    //DateTime.TryParseExact("2012/01/01", "yyyy/MM/dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out parsed);



    //要幾空白,就回傳幾個空白
    public string AddSpace(float cnt)
    {
        string ret = "";
        for (int i = 0; i < cnt; i++)
        {
            ret += " ";
        }
        return ret;
    }
    

    //public class Pair
    //{
    //    public string key;
    //    public string value;
    //}
    //       Pair [] oPairs= new Pair[ oDTFrmXLS.Rows.Count];
    //           for (i = 0; i < oDTFrmXLS.Rows.Count; i++)
    //           {
    //               oPairs[i].key = "";
    //               oPairs[i].value = "";

    

    #region log
     //叫出記事本         
    // System.Diagnostics.Process.Start(@"E:\123.txt"); 

    public static void log(string Msg)
    {
  func_txt.log ("C:\\\\Log", Msg);
    }
    ///<summary>
    ///log
    ///     </summary>
    ///<param name="StartupPath">儲存的目錄位置</param>
    ///<param name="ErrorMsg">訊息</param>    
    public static void log(string StartupPath, string msg)
    {
        func_txt.log(StartupPath, msg);
    }
    #endregion

    
    //用補空白的方式.目前僅提供中文
    public string 分散對齊(float txtWidth, string stxt, System.Drawing.Graphics g, System.Drawing.Font Fnt)
    {
        string ret = "";
        float WordTWWidth = GetWidth_TWWord(g, Fnt);// float.Parse("15.44678");
        float headFooterWidth = GetHeadFootWidth_TW(g, Fnt);//;float.Parse(" 4.99511");
        float spaceWidth = GetSpaceWidth(g, Fnt);// float.Parse("4.013669");

        float room;  //一個字有多少空間(字+空白的空間)
        float spacecnt;//前+後的sapce count  

        stxt = stxt.Replace(" ", "");
        float FontWidth = GetMeasureString(stxt, g, Fnt);

        if (txtWidth > (FontWidth + (spaceWidth * 2 * stxt.Length)))
        {
            //一個字有多少空間(字+空白的空間)
            room = (txtWidth - headFooterWidth) / stxt.Length;
            //前+後的sapce count
            spacecnt = float.Parse(Math.Floor((room - WordTWWidth) / spaceWidth).ToString());
            //前的sapce count
            spacecnt = float.Parse(Math.Floor(((room - WordTWWidth) / spaceWidth) / 2).ToString());

            for (int i = 0; i < stxt.Length; i++)
            {
                ret += AddSpace(spacecnt);
                ret += stxt.Substring(i, 1);
                ret += AddSpace(spacecnt);
            }
        }
        else if (txtWidth > (FontWidth + (spaceWidth * stxt.Length)))
        {
            //一個字有多少空間(字+空白的空間)
            room = (txtWidth - headFooterWidth) / stxt.Length;
            //後的sapce count
            spacecnt = (room - WordTWWidth) / spaceWidth;

            for (int i = 0; i < stxt.Length; i++)
            {
                ret += stxt.Substring(i, 1);
                ret += AddSpace(spacecnt);
            }
        }
        else
            ret = stxt;
        return ret;
    }
 
     //不用這樣.g.MeasureString(s1, Fnt).Width;就好了,
    //private float GetWordWidth(character type, int cnt, System.Drawing.Graphics g, System.Drawing.Font Fnt)
    //{
    //    float ret = 0;
    //    switch (type)
    //    { 
    //        case character.tw:
    //            ret = GetWidth_TWWord(g,Fnt ) * cnt + GetHeadFootWidth_TW(g,Fnt );
    //            break;
    //        case character.number :
    //            ret = GetWidth_Digital(g, Fnt) * cnt + GetHeadFootWidth_Digital(g,Fnt);
    //            break;
    //        case character.eng :
    //            ret = GetWidth_eng(g, Fnt) * cnt + GetHeadFootWidth_eng(g,Fnt);
    //            break;
    //    }
    //    return ret;
    //}
    public float GetWidth_eng(System.Drawing.Graphics g, System.Drawing.Font Fnt)
    {
        float ret = 0;
        string s1 = "";
        s1 = "ab";
        float t1 = g.MeasureString(s1, Fnt).Width;
        ret = t1 - GetHeadFootWidth_eng(g, Fnt);

        return ret;
    }
    public float GetHeadFootWidth_eng(System.Drawing.Graphics g, System.Drawing.Font Fnt)
    {
        float ret = 0;

        string s1 = "a", s2 = "ab";
        float t1 = g.MeasureString(s1, Fnt).Width;
        float t2 = g.MeasureString(s2, Fnt).Width;
        ret = t2 - t1;

        return ret;
    }
    public float GetWidth_Digital(System.Drawing.Graphics eGraphics, System.Drawing.Font Fnt)
    {
        float ret = 0;
        string s1 = "";
        s1 = "12";
        float t1 = eGraphics.MeasureString(s1, Fnt).Width;
        ret = t1 - GetHeadFootWidth_Digital(eGraphics, Fnt);

        return ret;
    }
    public float GetHeadFootWidth_Digital(System.Drawing.Graphics eGraphics, System.Drawing.Font Fnt)
    {
        float ret = 0;

        string s1 = "1", s2 = "12";        
        float t1 = eGraphics.MeasureString(s1, Fnt).Width;        
        float t2 = eGraphics.MeasureString(s2, Fnt).Width;
        ret = t2 - t1;

        return ret;
    }
 
    public float GetWidth_TWWord(System.Drawing.Graphics eGraphics, System.Drawing.Font Fnt)
    {
        float ret = 0;
        string s1 = "";
        s1 = "我";
        float t1 = eGraphics.MeasureString(s1, Fnt).Width;
        ret =t1- GetHeadFootWidth_TW(eGraphics, Fnt);

        return ret;
    }
    public float GetHeadFootWidth_TW(System.Drawing.Graphics eGraphics, System.Drawing.Font Fnt)
    {
        float ret = 0;
        
        string s1 = "",s2="";
        s1 = "我";
        float t1 = eGraphics.MeasureString(s1, Fnt).Width;
        s2 = "我他";
        float t2 = eGraphics.MeasureString(s2, Fnt).Width;
        ret = t2 - t1;

        return ret;
    }
    public float GetSpaceWidth(System.Drawing.Graphics eGraphics, System.Drawing.Font Fnt)
    {
        float ret = 0;

        string s1 = "", s2 = ""; 
        s1 = "我 你";
        float t1 = eGraphics.MeasureString(s1, Fnt).Width;
        s2 = "我你";
        float t2 = eGraphics.MeasureString(s2, Fnt).Width;
        ret = t1 - t2;

        return ret;
    }


        //sample
         //MessageBox.Show(new func().GetMeasureString("12345678901234",this.CreateGraphics(), this.Font).ToString());
         //   MessageBox.Show(new func().GetMeasureString("一二三四五六七八九十", this.CreateGraphics(), this.Font).ToString());
         //   MessageBox.Show(new func().GetMeasureString("一二三四五", this.CreateGraphics(), this.Font).ToString());        
    //取字的寬度
    public float GetMeasureString(string Str, System.Drawing.Graphics eGraphics, System.Drawing.Font Fnt)
    {
        //System.Drawing.Font Fnt = G1.DefaultCellStyle.Font;
        float fontwidth = eGraphics.MeasureString(Str, Fnt).Width;
        return fontwidth;
    }
    //取字的高度
    private float GetHeighString(string Str, System.Drawing.Graphics eGraphics, System.Drawing.Font Fnt)
    {
        //System.Drawing.Font Fnt = G1.DefaultCellStyle.Font;
        float fontwidth = eGraphics.MeasureString(Str, Fnt).Height;
        return fontwidth;
    }
 

    #region Regex 是不是中文.是不是數字
    /// <summary>
    /// Description:判断字符是否为中文
    /// </summary>
    /// <param name="c">待判断的字符</param>
    /// <returns>是中文的返回ture,否则返回false</returns>
    public   bool IsChinese(string  c)
    {
        return Regex.IsMatch(c.ToString(), "^[一-龥]+$");
          
    }
    public bool IsNumber(string str)
    {        
        System.Text.RegularExpressions.Regex reg1 ;
        reg1= new System.Text.RegularExpressions.Regex(@"^[0-9]+$");

        return reg1.IsMatch(str);

    }
    public bool IsEngOrNumber(string str)
    {

        System.Text.RegularExpressions.Regex reg1;
        reg1= new System.Text.RegularExpressions.Regex(@"^[A-Za-z0-9]+$");

        return reg1.IsMatch(str);

    }
    public bool IsEng(string str)
    {///^[a-zA-Z]*$/
        //bool ret=false ;
        //ret =     char.IsLetter(str);//英文,中文,都會回傳true
        System.Text.RegularExpressions.Regex reg1 ;
        reg1 = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z]+$"); 
        
        return reg1.IsMatch(str); 
    }
    #endregion
    #region 參考.未測試.

//而需要判斷是否為中文字
//方法很簡單重點只有一個  中文字起始範圍是0x4E00-0x9FFF
        //判斷指定字串內的指定位置是否為中文字
        private bool IsChinese(string strInputString, int intIndexNumber)
        {
            int intCode = 0;

            //中文範圍（0x4e00 - 0x9fff）轉換成int（intChineseFrom - intChineseEnd）
            int intChineseFrom = Convert.ToInt32("4e00", 16); 
            int intChineseEnd = Convert.ToInt32("9fff", 16);
            if (strInputString != "")
            {
                //取得input字串中指定判斷的index字元的unicode碼
                intCode = Char.ConvertToUtf32(strInputString, intIndexNumber);   

                if (intCode >= intChineseFrom && intCode <= intChineseEnd)
                {
                    return true;     //如果是範圍內的數值就回傳true
                }
                else
                {
                    return false;    //如果是範圍外的數值就回傳true
                }
            }
            return false;
        }
        //    主要是用來判斷字串是否是中文
        //但如果"中英文混合的字串"要計算正確的字數呢?
        //請使用以下的方法, 不要一個一個判斷unicode,  那樣太累了.......
        private int GetWordByte(string str)
        {
            //byte[] byteStr = Encoding.Default.GetBytes(textBox1.Text); //使用Default方法在非中文系統下可能會有問題, 感謝Bibby指正
            byte[] byteStr = Encoding.GetEncoding("big5").GetBytes(str); //把string轉為byte 
            return byteStr.Length; //取byte的長度, 中文字就會算2碼了
        }    
    #endregion 

}
#region 分散對齊,使用範例
//private void G1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
//{
//DataGridView G1 = xxx;

//    int row = e.RowIndex;
//    int col = e.ColumnIndex;
//    if (col == -1)
//        return;

//    if (G1.Columns[col].Name == "Column1" && row == 0)
//    {
//        Graphics g = this.CreateGraphics();
//        System.Drawing.Font Fnt = G1.DefaultCellStyle.Font;
//        float headWidth = G1.Columns[col].Width;
//        string value = G1.Columns[col].HeaderText;

//        G1.Columns[col].HeaderText = new func().分散對齊(headWidth, value, g, Fnt);
//        G1.Columns[col].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
//    }
//    return;
//}
#endregion 
