using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
static class PropertyBPCardCode 
{

    private static string XmlFile =System.Windows.Forms. Application.StartupPath + "\\Option\\BPCardCode.xml";
    /// <summary>
    /// 大買家
    /// </summary>
    public static string BigBuyer
    {
        get { return Function.GetInfoData(XmlFile, "BigBuyer"); }
        set { Function.SaveXML(XmlFile, "BigBuyer", value); }
    }

    /// <summary>
    /// 興奇
    /// </summary>
    public static string Monday
    {
        get { return Function.GetInfoData(XmlFile, "Monday"); }
        set { Function.SaveXML(XmlFile, "Monday", value); }
    }

    ///// <summary>
    ///// 資料庫類型
    ///// </summary>
    //public static string DataServerType
    //{
    //    get { return POS_Function.GetInfoData(XmlFile, "DataServerType"); }
    //    set { POS_Function.SaveXML(XmlFile, "DataServerType", value); }
    //}

    ///// <summary>
    ///// 語言
    ///// </summary>
    //public static string Language
    //{
    //    get { return POS_Function.GetInfoData(XmlFile, "Language"); }
    //    set { POS_Function.SaveXML(XmlFile, "Language", value); }
    //}

    ///// <summary>
    ///// UseTrusted
    ///// </summary>
    //public static bool UseTrusted
    //{
    //    get
    //    {
    //        string s = POS_Function.GetInfoData(XmlFile, "UseTrusted");
    //        bool b = false;
    //        try
    //        {
    //            b = bool.Parse(s);
    //        }
    //        catch
    //        {
    //            b = false;
    //        }
    //        return b;
    //    }
    //    set { POS_Function.SaveXML(XmlFile, "UseTrusted", value); }
    //}

    ///// <summary>
    ///// 資料庫
    ///// </summary>
    //public static string DataBase
    //{
    //    get { return POS_Function.GetInfoData(XmlFile, "DataBase"); }
    //    set { POS_Function.SaveXML(XmlFile, "DataBase", value); }
    //}

    ///// <summary>
    ///// 資料庫帳號
    ///// </summary>
    //public static string SaID
    //{
    //    get { return POS_Function.GetInfoData(XmlFile, "ID"); }
    //    set { POS_Function.SaveXML(XmlFile, "ID", value); }
    //}

    ///// <summary>
    ///// 資料庫密碼
    ///// </summary>
    //public static string SaPassword
    //{
    //    get { return POS_Function.GetInfoData(XmlFile, "Password"); }
    //    set { POS_Function.SaveXML(XmlFile, "Password", value); }
    //}

    ///// <summary>
    ///// SAP帳號
    ///// </summary>
    //public static string SAPID
    //{
    //    get { return POS_Function.GetInfoData(XmlFile, "SAPID"); }
    //    set { POS_Function.SaveXML(XmlFile, "SAPID", value); }
    //}

    ///// <summary>
    ///// SAP密碼
    ///// </summary>
    //public static string SAPPWD
    //{
    //    get { return POS_Function.GetInfoData(XmlFile, "SAPPWD"); }
    //    set { POS_Function.SaveXML(XmlFile, "SAPPWD", value); }
    //}

}
