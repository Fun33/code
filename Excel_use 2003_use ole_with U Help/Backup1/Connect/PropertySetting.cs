using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

class PropertySetting
{
            [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        static extern uint GetPrivateProfileString(
           string lpAppName,
           string lpKeyName,
           string lpDefault,
           StringBuilder lpReturnedString,
           uint nSize,
           string lpFileName);

    [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    static extern bool WritePrivateProfileString(string lpAppName,
       string lpKeyName, string lpString, string lpFileName);

    private static string strIniPath = @"C:\Panbor\Panbor_ImportWebSO.ini";
    //private static string strIniPath=Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @" \Cadmen\Panbor_ImportWebSO.ini";
    public static string BigBuyer_CardCode
    {
        get { 
            return new TINI(strIniPath).getKeyValue("BigBuyer", "CardCode"); 
        }
        set { new TINI(strIniPath).setKeyValue("BigBuyer", "CardCode", value); }
    }
    public static string Monday_CardCode
    {
        get {  
            return new TINI(strIniPath).getKeyValue("Monday", "CardCode"); 
        }
        set { new TINI(strIniPath).setKeyValue("Monday", "CardCode", value); }
    }
    public static string LooCa_CardCode
    {
        get
        {
            return new TINI(strIniPath).getKeyValue("LooCa", "CardCode");
        }
        set { new TINI(strIniPath).setKeyValue("LooCa", "CardCode", value); }
    }
    public static string KIKY_CardCode
    {
        get
        {
            return new TINI(strIniPath).getKeyValue("KIKY", "CardCode");
        }
        set { new TINI(strIniPath).setKeyValue("KIKY", "CardCode", value); }
    }
    public static string MOMO_CardCode
    {
        get
        {
            return new TINI(strIniPath).getKeyValue("MOMO", "CardCode");
        }
        set { new TINI(strIniPath).setKeyValue("MOMO", "CardCode", value); }
    }
}
 
