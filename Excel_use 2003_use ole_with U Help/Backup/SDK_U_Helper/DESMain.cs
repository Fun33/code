using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
//ref
//http://richielin-programer.blogspot.tw/2008/04/c-md5-des-rsa.html
// test not yet
 
    #region MD5
/// <summary>
/// 這方法,密碼若忘了,就回不來了,要重設
/// </summary>
    class MD5
    {
        /// <summary>   
        /// 取得 MD5 編碼後的 Hex 字串   
        /// 加密後為 32 Bytes Hex String (16 Byte)   
        /// </summary>   
        /// <span  name="original" class="mceItemParam"></span>原始字串</param>   
        /// <returns></returns>   
        public static string GetMD5(string original)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] b = md5.ComputeHash(Encoding.UTF8.GetBytes(original));
            return BitConverter.ToString(b).Replace("-", string.Empty);
        }
    }
    #endregion 
    #region DES
    public class DES
    {
        //ref http://www.dotblogs.com.tw/yc421206/archive/2012/04/18/71609.aspx
        /// <span  name="key" class="mceItemParam"></span>Key，長度必須為 8 個 ASCII 字元</param>   
        /// <span  name="iv" class="mceItemParam"></span>IV，長度必須為 8 個 ASCII 字元</param>   
         private static   string  key="Fun20254";
         private static   string iv = "Fun20254";
        /// <summary>   
        /// DES 加密字串   
        /// </summary>   
        public static string EncryptDES(string original)
        {
            try
            {
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                des.Key = Encoding.ASCII.GetBytes(key);
                des.IV = Encoding.ASCII.GetBytes(iv);
                byte[] s = Encoding.ASCII.GetBytes(original);
                ICryptoTransform desencrypt = des.CreateEncryptor();
                return BitConverter.ToString(desencrypt.TransformFinalBlock(s, 0, s.Length)).Replace("-", string.Empty);
            }
            catch (Exception ex)
            {
                return original; 
            }
        }

        /// <summary>   
        /// DES 解密字串   
        /// </summary>     
        public static string DecryptDES(string hexString )
        {
            try
            {
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                des.Key = Encoding.ASCII.GetBytes(key);
                des.IV = Encoding.ASCII.GetBytes(iv);

                byte[] s = new byte[hexString.Length / 2];
                int j = 0;
                for (int i = 0; i < hexString.Length / 2; i++)
                {
                    s[i] = Byte.Parse(hexString[j].ToString() + hexString[j + 1].ToString(), System.Globalization.NumberStyles.HexNumber);
                    j += 2;
                }
                ICryptoTransform desencrypt = des.CreateDecryptor();
                return Encoding.ASCII.GetString(desencrypt.TransformFinalBlock(s, 0, s.Length));
            }
            catch { return hexString; }
        }
        
    }
    #endregion 
    #region RSA
/// <summary>
    /// 很有問題,要再測.
/// </summary>
    class RSA 
    { 
//        RSA 加解密演算法
//RSA 是一種非對稱性加密演算法，其原理是以公鑰及私鑰來處理加解密 簡單來說，公鑰可以提供給任何需要加密的人，但是私鑰必須妥善保存 加密時以公鑰處理即可，但解密必須有私鑰
        public static string GetKey(string keyType)
        {
            string ret = "";

            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            if (keyType == "1")
            {
                // 公鑰 xml 字串   
                ret = rsa.ToXmlString(false);
            }
            else if (keyType == "2")
            {
                // 私鑰 xml 字串   
                ret = rsa.ToXmlString(true);
            }
            //else if (keyType == "3")
            //{
            //    // 公鑰   
            //    ret = rsa.ExportParameters(false);
            //}
            //else if (keyType == "4")
            //{
            //    // 私鑰   
            //    ret = rsa.ExportParameters(true);
            //}
            return ret;
        }
//        在 .NET Framework 中公私鑰可以 xml 及 RSAParameters 類別型態存在 而金鑰產生最簡單的方式是由 RSACryptoServiceProvider 類別來產生 每次初始化 RSACryptoServiceProvider 類別時即會亂數產生一組金鑰

 

//加解密時只要使用同一組金鑰 (公私鑰) 即可

        /// <summary>   
/// RSA 加密字串   
/// </summary>   
/// <span  name="original" class="mceItemParam"></span>原始字串</param>   
/// <span  name="xmlString" class="mceItemParam"></span>公鑰 xml 字串</param>   
/// <returns></returns>   
public static string EncryptRSA(string original, string xmlString)   
{   
try   
{   
RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();   
rsa.FromXmlString(xmlString);   
byte[] s = Encoding.ASCII.GetBytes(original);   
return BitConverter.ToString(rsa.Encrypt(s, false)).Replace("-", string.Empty);   
}   
catch { return original; }   
}   
  
/// <summary>   
/// RSA 加密字串   
/// 加密後為 256 Bytes Hex String (128 Byte)   
/// </summary>   
/// <span  name="original" class="mceItemParam"></span>原始字串</param>   
/// <span  name="parameters" class="mceItemParam"></span>公鑰 RSAParameters 類別</param>   
/// <returns></returns>   
public static string EncryptRSA(string original, RSAParameters parameters)   
{   
try   
{   
RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();   
rsa.ImportParameters(parameters);   
byte[] s = Encoding.ASCII.GetBytes(original);   
return BitConverter.ToString(rsa.Encrypt(s, false)).Replace("-", string.Empty);   
}   
catch { return original; }   
}   
  
/// <summary>   
/// RSA 解密字串   
/// </summary>   
/// <span  name="hexString" class="mceItemParam"></span>加密後 Hex String</param>   
/// <span  name="xmlString" class="mceItemParam"></span>私鑰 xml 字串</param>   
/// <returns></returns>   
public static string DecryptRSA(string hexString, string xmlString)   
{   
try   
{   
RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();   
rsa.FromXmlString(xmlString);   
byte[] s = new byte[hexString.Length / 2];   
int j = 0;   
for (int i = 0; i < hexString.Length/2; i++)   
{   
s[i] = Byte.Parse(hexString[j].ToString() + hexString[j + 1].ToString(), System.Globalization.NumberStyles.HexNumber);   
j += 2;   
}   
return Encoding.ASCII.GetString(rsa.Decrypt(s, false));   
}   
catch { return hexString; }   
}   
  
/// <summary>   
/// RSA 解密字串   
/// </summary>   
/// <span  name="hexString" class="mceItemParam"></span>加密後 Hex String</param>   
/// <span  name="parameters" class="mceItemParam"></span>私鑰 RSAParameters 類別</param>   
/// <returns></returns>   
public static string DecryptRSA(string hexString, RSAParameters parameters)   
{   
try   
{   
RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();   
rsa.ImportParameters(parameters);   
byte[] s = new byte[hexString.Length / 2];   
int j = 0;   
for (int i = 0; i < hexString.Length/2; i++)   
{   
s[i] = Byte.Parse(hexString[j].ToString() + hexString[j + 1].ToString(), System.Globalization.NumberStyles.HexNumber);   
j += 2;   
}   
return Encoding.ASCII.GetString(rsa.Decrypt(s, false));   
}   
catch { return hexString; }   
}

}
    #endregion

    #region AES
//測試沒有問題.但加出來的好長哦.
//ref http://www.dotblogs.com.tw/eaglewolf/archive/2011/06/26/29960.aspx
    //ref http://www.dotblogs.com.tw/yc421206/archive/2012/04/18/71609.aspx
/// <summary>
    /// 測試沒有問題.但加出來的好長哦.
/// </summary>
    public   class AES
    {
        private static string key = "33Fun20254";
        private static string iv = "33Fun20254";

        public static  string enprypt(string plainText )
        {
    
            RijndaelManaged AES = new RijndaelManaged();
            MD5CryptoServiceProvider MD5 = new MD5CryptoServiceProvider();
            byte[] plainTextData = Encoding.Unicode.GetBytes(plainText);
            byte[] keyData = MD5.ComputeHash(Encoding.Unicode.GetBytes(key));
            byte[] IVData = MD5.ComputeHash(Encoding.Unicode.GetBytes(iv));
            //byte[] keyData = Encoding.Unicode.GetBytes(key);
            //byte[] IVData =  Encoding.Unicode.GetBytes(iv);
        
            ICryptoTransform transform = AES.CreateEncryptor(keyData, IVData);
            byte[] outputData = transform.TransformFinalBlock(plainTextData, 0, plainTextData.Length);
            return Convert.ToBase64String(outputData);
        }
        public static  string decrypt( string value)
        {
            string ret = "";
            byte[] cipherTextData = Convert.FromBase64String(value);
 
            RijndaelManaged AES = new RijndaelManaged();
            MD5CryptoServiceProvider MD5 = new MD5CryptoServiceProvider();
            byte[] keyData = MD5.ComputeHash(Encoding.Unicode.GetBytes(key));
            byte[] IVData = MD5.ComputeHash(Encoding.Unicode.GetBytes(iv));
            //byte[] keyData = Encoding.Unicode.GetBytes(key);
            //byte[] IVData = Encoding.Unicode.GetBytes(iv);//指定的初始化向量 (IV) 不符合此演算法的區塊大小。//IV的字节数必须等于SymmetricAlgorithm.BlockSize/8
          
            ICryptoTransform transform = AES.CreateDecryptor(keyData, IVData);
            try//如果碼被破壞,就會產生錯誤:要解密的資料長度無效。 
            {
                byte[] outputData = transform.TransformFinalBlock(cipherTextData, 0, cipherTextData.Length);
                ret = Encoding.Unicode.GetString(outputData);
            }
            catch (Exception ex)
            { }
            return ret;
        }



    }
    #endregion
 
