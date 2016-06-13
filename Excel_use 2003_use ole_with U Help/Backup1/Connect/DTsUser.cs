using System;
using System.Collections.Generic;
using System.Text;

namespace Panbor_ImportWebSO
{
    public sealed class DTsUser
    {
        private string _UserID, _Passward;
        private bool _AutoLogin = false; 
        private string _OCLSType, _StationName, _UserName;
        private const string Path = "C:\\\\Panbor\\";
        private const string FileName = Path + "User.tdc";

        public DTsUser()
        {
            System.IO.DirectoryInfo oDir = new System.IO.DirectoryInfo(Path);
            if (!oDir.Exists)
            {
                oDir.Create();
            }
        }

        #region 公開屬性
        public string LoginID { get { return _UserID; } set { _UserID = value; } }
        public string Passward { get { return _Passward; } set { _Passward = value; } }
        public bool AutoLogin { get { return _AutoLogin; } set { _AutoLogin = value; } } 
        public string  StationNo { get { return _OCLSType; } set { _OCLSType = value; } }
        public string StationName { get { return _StationName; } set { _StationName = value; } }
        public string LoginName { get { return _UserName; } set { _UserName = value; } }

        #endregion

        /// <summary>
        /// 儲存文件
        /// </summary>
        public void CreateEncrypt()
        {
            string s = string.Empty;
            //第0位置UserID
            //第1位置Passward
            //第2位置AutoLogin
            //第3位置OCLSType
            s += this.LoginID;
            s += ";" + this.Passward;
            s += ";" + this.AutoLogin.ToString();
            s += ";" + this.StationNo;
            s += ";" + this.StationName;
            s += ";" + this.LoginName; 

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
                        this.LoginID = s;
                        break;
                    case 1:
                        this.Passward = s;
                        break;
                    case 2:
                        this.AutoLogin = bool.Parse(s);
                        break;
                    case 3:
                        this.StationNo  = s;
                        break;
                    case 4:
                        this.StationName = s;
                        break;
                    case 5:
                        this.LoginName = s;
                        break;
                }
            }

        }

    }
}
