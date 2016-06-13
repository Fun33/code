using System;
using System.Collections.Generic;
using System.Text;

namespace Panbor_ImportWebSO
{
    public sealed class Des
    {
        [System.Runtime.InteropServices.DllImport("KERNEL32.dll", EntryPoint = "RtlZeroMemory", SetLastError = true)]
        internal static extern void ZeroMemory(IntPtr handle, int length);

        private string GenerateKey()
        {
            // Function to Generate a 64 bits Key.
            // Create an instance of Symetric Algorithm. Key and IV is generated automatically.
            //Dim desCrypto As DESCryptoServiceProvider = DirectCast(DESCryptoServiceProvider.Create(), DESCryptoServiceProvider)

            // Use the Automatically generated key for Encryption. 
            //Return ASCIIEncoding.ASCII.GetString(desCrypto.Key)
            return "TMVCTMVC";
        }

        /// <summary>
        /// 加密文件
        /// </summary>
        public void EncryptFile(string Value, string OuputFileName)
        {
            try
            {
                // Must be 64 bits, 8 bytes.
                // Distribute this key to the user who will decrypt this file.
                //Get the Key for the file to Encrypt.
                string sKey = GenerateKey();

                byte[] b = ASCIIEncoding.ASCII.GetBytes(Value);

                System.IO.FileStream fsEncrypted = new System.IO.FileStream(OuputFileName, System.IO.FileMode.Create, System.IO.FileAccess.Write);

                System.Security.Cryptography.DESCryptoServiceProvider DES = new System.Security.Cryptography.DESCryptoServiceProvider();
                DES.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
                DES.IV = ASCIIEncoding.ASCII.GetBytes(sKey);

                System.Security.Cryptography.ICryptoTransform desencrypt = DES.CreateEncryptor();
                System.Security.Cryptography.CryptoStream cs = new System.Security.Cryptography.CryptoStream(fsEncrypted, desencrypt, System.Security.Cryptography.CryptoStreamMode.Write);

                cs.Write(b, 0, b.Length);
                cs.Close();

                fsEncrypted.Close();

            }
            catch (Exception ex)
            { 
                throw ex;
            }
        }

        public string DecryptFile(string FileName)
        {
            System.IO.FileStream fs = null;
            string s = string.Empty;
            try
            {
                string sKey = GenerateKey();
                System.Security.Cryptography.DESCryptoServiceProvider DES = new System.Security.Cryptography.DESCryptoServiceProvider();
                DES.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
                DES.IV = ASCIIEncoding.ASCII.GetBytes(sKey);

                System.IO.FileInfo dirFile = new System.IO.FileInfo(FileName);
                if (!dirFile.Exists)
                {
                    return string.Empty;
                }

                fs = new System.IO.FileStream(FileName, System.IO.FileMode.Open, System.IO.FileAccess.Read);

                System.Security.Cryptography.ICryptoTransform desdecrypt = DES.CreateDecryptor();
                System.Security.Cryptography.CryptoStream cs = new System.Security.Cryptography.CryptoStream(fs, desdecrypt, System.Security.Cryptography.CryptoStreamMode.Read);

                s = new System.IO.StreamReader(cs).ReadToEnd();
                //Return 
                fs.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if ((fs != null))
                {
                    fs.Close();
                }
            }
            return s;
        }

        /// <summary>
        /// 清除記憶體
        /// </summary>
        private void Clear(string sSecretKey)
        {
            // For additional security Pin the key.
            System.Runtime.InteropServices.GCHandle Gch = System.Runtime.InteropServices.GCHandle.Alloc(sSecretKey, System.Runtime.InteropServices.GCHandleType.Pinned);
            // Remove the Key from memory. 
            ZeroMemory(Gch.AddrOfPinnedObject(), sSecretKey.Length * 2);
            Gch.Free();
        }

    }
}
