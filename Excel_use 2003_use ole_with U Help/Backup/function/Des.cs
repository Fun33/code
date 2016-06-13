using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
public class des
{
    //必須是8位
    private static string skey = "33cadmen";
    ///    <summary>
    /// 字串加密
    /// </summary>
    public static string Encrypt(string pToEncrypt)
    {
        if (pToEncrypt == string.Empty)
            return string.Empty;

        System.Security.Cryptography.DESCryptoServiceProvider des = new System.Security.Cryptography.DESCryptoServiceProvider();
        byte[] inputByteArray = null;
        inputByteArray = System.Text.Encoding.Default.GetBytes(pToEncrypt);
        //'建立加密對象的密鑰和偏移量
        //'原文使用ASCIIEncoding.ASCII方法的GetBytes方法
        //'使得輸入密碼必須輸入英文文本
        des.Key = System.Text.ASCIIEncoding.ASCII.GetBytes(skey);
        des.IV = System.Text.ASCIIEncoding.ASCII.GetBytes(skey);
        //'寫二進制數組到加密流
        //'(把內存流中的內容全部寫入)
        System.IO.MemoryStream ms = new System.IO.MemoryStream();
        System.Security.Cryptography.CryptoStream cs = new System.Security.Cryptography.CryptoStream(ms, des.CreateEncryptor(), System.Security.Cryptography.CryptoStreamMode.Write);
        //'寫二進制數組到加密流
        //'(把內存流中的內容全部寫入)
        cs.Write(inputByteArray, 0, inputByteArray.Length);
        cs.FlushFinalBlock();
        //'建立輸出字符串
        System.Text.StringBuilder ret = new System.Text.StringBuilder();
        byte b = 0;
        foreach (byte b_loopVariable in ms.ToArray())
        {
            b = b_loopVariable;
            ret.AppendFormat("{0:X2}", b);
        }
        return ret.ToString();
    }


    ///    <summary>
    /// 字串解密
    /// </summary>
    public static string Decrypt(string pToDecrypt)
    {
        if (pToDecrypt == string.Empty)
            return string.Empty;

        try
        {
            System.Security.Cryptography.DESCryptoServiceProvider des = new System.Security.Cryptography.DESCryptoServiceProvider();
            //'把字符串放入byte數組
            int len = 0;
            len = pToDecrypt.Length / 2 - 1;
            byte[] inputByteArray = new byte[len + 1];
            int x = 0;
            int i = 0;
            for (x = 0; x <= len; x++)
            {
                i = Convert.ToInt32(pToDecrypt.Substring(x * 2, 2), 16);
                inputByteArray[x] = Convert.ToByte(i);
            }
            //'建立加密對象的密鑰和偏移量，此值重要，不能修改
            des.Key = System.Text.ASCIIEncoding.ASCII.GetBytes(skey);
            des.IV = System.Text.ASCIIEncoding.ASCII.GetBytes(skey);
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            System.Security.Cryptography.CryptoStream cs = new System.Security.Cryptography.CryptoStream(ms, des.CreateDecryptor(), System.Security.Cryptography.CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            return System.Text.Encoding.Default.GetString(ms.ToArray());
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }
}
