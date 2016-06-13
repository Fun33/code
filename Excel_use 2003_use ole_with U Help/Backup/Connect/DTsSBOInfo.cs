using System;
using System.Collections.Generic;
using System.Text;

namespace Panbor_ImportWebSO
{
    public class DTsSBOInfo
    {
        private string _LicenseServer, _UserName, _Password;
        private int _DataBaseType;
        private bool _UseTrusted = false;

        private const string Path = "C:\\\\Panbor\\";
        private const string FileName = Path + "SBO.tdc";

        public DTsSBOInfo()
        {
            System.IO.DirectoryInfo oDir = new System.IO.DirectoryInfo(Path);
            if (!oDir.Exists)
            {
                oDir.Create();
            }
        }

        #region 公開屬性

        public string LicenseServer
        {
            get { return _LicenseServer; }
            set { _LicenseServer = value; }
        }

        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }

        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }

        public int DataBaseType
        {
            get { return _DataBaseType; }
            set { _DataBaseType = value; }
        }

        public bool UseTrusted
        {
            get { return _UseTrusted; }
            set { _UseTrusted = value; }
        }

        #endregion

        /// <summary>
        /// 儲存文件
        /// </summary>
        public void CreateEncrypt()
        {
            string s = string.Empty;
            //第0位置LicenseServer
            //第1位置DataBaseType
            //第2位置UserName
            //第3位置Password
            //第4位置UseTrusted
            s += this.LicenseServer;
            s += ";" + this.DataBaseType.ToString();
            s += ";" + this.UserName;
            s += ";" + this.Password;
            s += ";" + this.UseTrusted.ToString();

            DesFile des = new DesFile();
            des.EncryptFile(s, FileName);
        }

        /// <summary>
        /// 讀取文件
        /// </summary>
        public void LoadDecryptFile()
        {
            //Load File
            DesFile des = new DesFile();
            string s = null;
            s = des.DecryptFile(FileName);

            if (string.IsNullOrEmpty(s))
            {
                return;
            }

            string[] ary = s.Split(new char[] { ';' });
            int i = 0;

            for (i = 0; i <= ary.Length - 1; i++)
            {
                s = ary[i];
                switch (i)
                {
                    case 0:
                        this.LicenseServer = s;
                        break;
                    case 1:
                        this.DataBaseType = System.Convert.ToInt32(s);
                        break;
                    case 2:
                        this.UserName = s;
                        break;
                    case 3:
                        this.Password = s;
                        break;
                    case 4:
                        this.UseTrusted = bool.Parse(s);
                        break;
                }
            }

        }

    }

}
