using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Xml;
using Microsoft.VisualBasic;

public class Function
{
    /// <summary>
    /// 驗證輸入是否為 數字
    /// </summary>
    public static void IsKeyDownInteger(System.Windows.Forms.KeyPressEventArgs e)
    {
        if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
        {
            e.Handled = true;
        }
    }

    /// <summary>
    /// 驗證輸入是否為 數字
    /// </summary>
    public static bool IsKeyDownInteger(string e)
    {
        if (string.IsNullOrEmpty(e))
        {
            return true;
        }
        System.Text.RegularExpressions.Regex regul = new System.Text.RegularExpressions.Regex("[0-9]");
        if (!regul.IsMatch(e))
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// 驗證輸入是否為 空值
    /// </summary>
    public static bool IsKeyDownString(string e)
    {
        if (e != null && string.IsNullOrEmpty(e))
        {
            return true;
        }
        return false;
    }

    //取得XML
    //Public Shared Function GetInfoData(ByVal s As String) As String
    //    Dim doc As XmlDocument = New XmlDocument
    //    Dim sPath As String = Application.StartupPath + "\Connect\Connecting.xml"
    //    Dim reader As New XmlTextReader(sPath)
    //    reader.WhitespaceHandling = WhitespaceHandling.None
    //    reader.MoveToContent()
    //    reader.Read()
    //    'reader.Skip() 'Skip the first book.
    //    'reader.Skip() 'Skip the second book.
    //    doc.Load(reader)

    //    ' Move to an element.
    //    Dim XmlElement As XmlElement
    //    XmlElement = doc.DocumentElement
    //    ' Get an attribute.
    //    Dim attr As XmlAttribute

    //    attr = XmlElement.GetAttributeNode(s)
    //    'Debug.WriteLine(attr.InnerText)
    //    doc = Nothing
    //    reader = Nothing
    //    Return attr.InnerText

    //    'Dim i As Integer
    //    'For i = 0 To XmlElement.Attributes.Count - 1
    //    '    Debug.Write(XmlElement.Attributes(i).Name + ":" + XmlElement.Attributes(i).InnerText)
    //    'Next i

    //    'If XmlElement.HasChildNodes Then
    //    '    For i = 0 To XmlElement.ChildNodes.Count - 1
    //    '        Debug.Write(XmlElement.ChildNodes(i).Name + ":" + XmlElement.ChildNodes(i).InnerText + vbCrLf)
    //    '    Next i
    //    'End If

    //End Function
    private static void chkNode(ref XmlDocument xmlDoc, string ChildName)
    {
        XmlNodeList elemList = xmlDoc.GetElementsByTagName(ChildName);
        if (elemList.Count == 0)
        {
            System.Xml.XmlNodeList elemList2 = xmlDoc.GetElementsByTagName("Info").Item(0).ChildNodes;
            elemList2.Item(0).AppendChild(xmlDoc.CreateElement(ChildName));
        }
    }
    /// <summary>
    /// 取得XML
    /// </summary>
    public static string GetInfoData(string FileName, string ChildName)
    {
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(FileName);
        XmlNode xn = xmlDoc.SelectSingleNode("Info");
        XmlNodeList xnl = xn.ChildNodes;
        string s = string.Empty;
        XmlNode xnf = null;
        foreach (XmlNode xnf_loopVariable in xnl)
        {
            xnf = xnf_loopVariable;
            XmlElement xe = (XmlElement)xnf;
            //s = xe.GetAttribute(ChildName)

            XmlNodeList xnf1 = xe.ChildNodes;
            XmlNode xn2 = null;
            foreach (XmlNode xn2_loopVariable in xnf1)
            {
                xn2 = xn2_loopVariable;
                if (xn2.Name == ChildName)
                {
                    s = xn2.InnerText;
                    break; // TODO: might not be correct. Was : Exit For
                }
            }
        }
        return s;
    }

    /// <summary>
    /// 儲存XML
    /// </summary>
    public static void SaveXML(string FileName, string ChildName, string Value)
    {
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(FileName);

         chkNode(ref xmlDoc, ChildName) ;//2011.9.29

        XmlNodeList nodeList = xmlDoc.SelectSingleNode("Info").ChildNodes;
        XmlNode xn = null;
        foreach (XmlNode xn_loopVariable in nodeList)
        {
            xn = xn_loopVariable;
            XmlElement xe = (XmlElement)xn;
            //If xe.GetAttribute(xe.Name) = ChildName Then
            //xe.SetAttribute(ChildName, Value)
            //End If

            XmlNodeList nls = xe.ChildNodes;
            XmlNode xn1 = null;
            foreach (XmlNode xn1_loopVariable in nls)
            {
                xn1 = xn1_loopVariable;
                XmlElement xe2 = (XmlElement)xn1;
                if (xe2.Name == ChildName)
                {
                    xe2.InnerText = Value;
                    break; // TODO: might not be correct. Was : Exit For
                }
            }
            break; // TODO: might not be correct. Was : Exit For
        }
        xmlDoc.Save(FileName);
    }

    /// <summary>
    /// 轉換格式 
    /// </summary>
    /// <param name="s"></param>
    /// <param name="isCurrency">轉換成貨幣格式#,###,###,###,###</param>
    public static string ToFormat(double s, bool isCurrency)
    {
        if (s != 0)
        {
            decimal val = Convert.ToDecimal(s);
            if (isCurrency)
            {
                return Strings.Format(val, "#,0.##");
            }
            else
            {
                return val.ToString();
            }
        }
        return s.ToString();
    }

    ///// <summary>
    ///// 設定DataGridView的數字欄位(內含自動靠右)
    ///// </summary>
    ///// <param name="DataGrid">DataGrid Object</param>
    ///// <param name="ColumnName">欄位名稱</param>
    ///// <param name="RoundNum">取小數點位數</param>
    //public static void SetColumnToPrice(DataGridView DataGrid, string ColumnName, int RoundNum)
    //{
    //    DataGrid.Columns(ColumnName).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
    //    DataGrid.Columns(ColumnName).DefaultCellStyle.Format = "N" + RoundNum.ToString();
    //}

    /// <summary>
    ///將 日期的時間 轉換成 HHMM 讓SAP B1 可以接受的格式
    /// </summary>
    public static string TimeToSAP(System.DateTime myDate)
    {
        string fDate = "";

        if (myDate.Hour <= 0)
        {
            return "";
        }
        if (myDate.Hour < 10)
        {
            fDate = fDate + "0" + myDate.Hour.ToString();
        }
        else
        {
            fDate = fDate + myDate.Hour.ToString();
        }
        if (myDate.Minute < 10)
        {
            fDate = fDate + "0" + myDate.Minute.ToString();
        }
        else
        {
            fDate = fDate + myDate.Minute.ToString();
        }

        return fDate;
    }
}
