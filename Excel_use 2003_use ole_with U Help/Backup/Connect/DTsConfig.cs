using System;
using System.Collections.Generic;
using System.Text;

namespace Panbor_ImportWebSO
{
    public sealed class DTsConfig
    {
        private string _LogPath, _SetingPath;
        private const string Path = "C:\\\\Panbor\\";
        private const string FileName = Path + "Config.tdc";
        //private  string FileName = System.Windows.Forms.Application.StartupPath + "\\" + "Config.tdc";

        public DTsConfig()
        {
            //System.IO.DirectoryInfo oDir = new System.IO.DirectoryInfo(System.Windows.Forms.Application.StartupPath+"\\");
            System.IO.DirectoryInfo oDir = new System.IO.DirectoryInfo(Path);
            if (!oDir.Exists)
            {
                oDir.Create();
            }
        }

        #region 公開屬性
        /// <summary>
        /// 系統設定儲存位置
        /// </summary>
        public string SetingPath
        {
            get { return _SetingPath; }
            set { _SetingPath = value; }
        }
        /// <summary>
        /// 系統歷程儲存位置
        /// </summary>
        public string LogPath
        {
            get { return _LogPath; }
            set { _LogPath = value; }
        }


        #endregion

        /// <summary>
        /// 儲存文件
        /// </summary>
        public void CreateEncrypt()
        {
            string s = string.Empty;
            //第0位置SetingPath
            //第1位置LogPath
            s += this.SetingPath;
            s += ";" + this.LogPath;

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
                        this.SetingPath = s;
                        break;
                    case 1:
                        this.LogPath = s;
                        break;
                }
            }

        }

    }
}
