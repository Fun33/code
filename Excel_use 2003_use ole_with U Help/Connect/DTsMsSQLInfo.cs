using System;
using System.Collections.Generic;
using System.Text;

namespace Panbor_ImportWebSO
{
    public sealed class DTsMsSQLInfo
    {
        private string _Server, _Sa,_Password,_DataBase;

        private const string Path = "C:\\\\Panbor\\";
        private const string FileName = Path + "MsSQL.tdc";

        public DTsMsSQLInfo()
        {
            System.IO.DirectoryInfo oDir = new System.IO.DirectoryInfo(Path);
            if (!oDir.Exists)
            {
                oDir.Create();
            }
            else
            {
                try
                {
                    LoadDecryptFile();
                }
                catch
                { }
            }
        }

        #region 公開屬性

        public string Server
        {
            get { return _Server; }
            set { _Server = value; }
        }

        public string Sa
        {
            get { return _Sa; }
            set { _Sa = value; }
        }

        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }

        public string DataBase
        {
            get { return _DataBase; }
            set { _DataBase = value; }
        }

        public string ConnectString
        {
            get
            {
                string s = string.Empty;
                if (!string.IsNullOrEmpty(this.Server) & !string.IsNullOrEmpty(this.DataBase) & !string.IsNullOrEmpty(this.Sa) & !string.IsNullOrEmpty(this.Password))
                {
                    s = "server=" + this.Server + ";database=" + this.DataBase + ";User ID=" + this.Sa + ";Pwd=" + this.Password;
                }
                return s;
            }
        }

        #endregion

        /// <summary>
        /// 儲存文件
        /// </summary>
        public void CreateEncrypt()
        {
            //server=10.204.121.8;database=ReportServer;User ID=sa;Pwd=ecudn08ccg3m/45k3
            string s = string.Empty;
            //第0位置Server
            //第1位置DataBase
            //第2位置Sa
            //第3位置Password
            s += this.Server;
            s += ";" + this.DataBase;
            s += ";" + this.Sa;
            s += ";" + this.Password;

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
                        this.Server = s;
                        break;
                    case 1:
                        this.DataBase = s;
                        break;
                    case 2:
                        this.Sa = s;
                        break;
                    case 3:
                        this.Password = s;
                        break;
                }
            }

        }

    }
}
