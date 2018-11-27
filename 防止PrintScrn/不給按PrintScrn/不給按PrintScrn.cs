using System;
using System.Text;
//加以下 
using System.Runtime.InteropServices;//找不到型別或命名空間名稱 'dllimport'//使用pinvoke (plateform invoke)的方式使用Win32 DLL時，必須使用System.Runtime.InteropServices這個namespace。
using System.Windows.Forms;

namespace 防止PrintScrn
{
    //https://www.cnblogs.com/oomusou/archive/2011/02/13/cs_pinvoke.html
    //https://msdn.microsoft.com/zh-cn/library/aa686045.aspx

    //https://dotblogs.com.tw/nobel12/2009/10/05/10915
    //get sysinfo 原來這樣,就可以被讀的清清楚楚.https://dotblogs.com.tw/atowngit/2009/08/31/10333

    //?why paste 之前copy的咪件
    //?how check who.focused
    //?how scoll bar of line
    //?how seleted all then copy all

    class StopPrinScrn
    {
        private System.Timers.Timer _TimersTimer;
        private string keyBuffer = string.Empty; 

        //在此宣告GetAsyncKeyState()這個function，使用DLLImport這個attribute告訴C#到User32.dll去找這個GetAsyncKeyState() function，
        //此外，C#規定pivoke的function都必須要是static extern。
        //' 宣告 API GetAsyncKeyState
        [DllImport("User32.dll")]

        private static extern short GetAsyncKeyState(System.Windows.Forms.Keys vKey); // Keys enumeration
        [DllImport("User32.dll")]
        private static extern IntPtr GetForegroundWindow();//取得目前畫面

        [DllImport("user32.dll")]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);//取得目前畫面的title

        [DllImport("oleacc.dll", SetLastError = true)]
        internal static extern IntPtr GetProcessHandleFromHwnd(IntPtr hwnd);

        public StopPrinScrn(System.Windows.Forms.Form frm)
        {
            this._TimersTimer = new System.Timers.Timer();
            this._TimersTimer.Interval = 100;//1/5 秒 ( 可自行調整 )
            this._TimersTimer.Elapsed += new System.Timers.ElapsedEventHandler(_TimersTimer_Elapsed);
            this._TimersTimer.SynchronizingObject = frm;//目前的執行緒必須先設為單一執行緒 Apartment (STA) 模式，才能進行 OLE 呼叫。請確認您的 Main 函式上已經標記有 STAThreadAttribute。
            this._TimersTimer.Start();

        }
        private string GetActiveWindowTitle()
        {
            const int nChars = 256;
            StringBuilder Buff = new StringBuilder(nChars);
            IntPtr handle = GetForegroundWindow();

            if (GetWindowText(handle, Buff, nChars) > 0)
            {
                return Buff.ToString();
            }
            return null;
        }
        /// <summary>
        ///   IntPtr handle = GetForegroundWindow();
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        private string GetActiveWindowTitle(IntPtr handle)
        {
            
            const int nChars = 256;
            StringBuilder Buff = new StringBuilder(nChars); 

            if (GetWindowText(handle, Buff, nChars) > 0)
            {
                return Buff.ToString();
            }
            return null;
        }
        private void _TimersTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            //Console.Write (DateTime.Now.ToString("yyyyMMdd HH:mm:ss:fff")+"   ");
            if (GetAsyncKeyState(Keys.PageDown) != 0)    //' GetAsyncKeyState 取得鍵盤狀態
            {
                log("PageDown");
            }
            if (GetAsyncKeyState(Keys.A) != 0 && GetAsyncKeyState(Keys.ControlKey) != 0)    //' GetAsyncKeyState 取得鍵盤狀態
            {
                //if (getProcessNameFromFocusedWindow() == "LINE")
                //{
                //    openExe("chrome.exe"); 
                //}
                log("全選");

            }
            copy();
            截營幕();
        }

        private void copy()
        {
            if (GetAsyncKeyState(Keys.C) != 0 && GetAsyncKeyState(Keys.ControlKey) != 0)    //' GetAsyncKeyState 取得鍵盤狀態
            {
                //MessageBox.Show("被我抓到了");
                if (Clipboard.ContainsText(TextDataFormat.Text))
                {
                    string str = Clipboard.GetText();
                    if (getProcessNameFromFocusedWindow() == "LINE")
                    {
                        Clipboard.Clear();//' 若按了 Print Screen 鍵, 則清空剪貼簿                   
                        savetxt(str);
                    }
                    log("copy-text");
                }
                else if (Clipboard.ContainsText(TextDataFormat.CommaSeparatedValue))
                {
                    log("copy-TextDataFormat.CommaSeparatedValue");
                    //Clipboard.Clear();
                }
                else if (Clipboard.ContainsText(TextDataFormat.Html))
                {
                    log("copy-Html");
                    //Clipboard.Clear();
                }
                else if (Clipboard.ContainsText(TextDataFormat.Rtf))
                {
                    log("copy-Rtf");
                    //Clipboard.Clear();
                }
                else if (Clipboard.ContainsText(TextDataFormat.UnicodeText))
                {
                    log("copy-UnicodeText");
                    //Clipboard.Clear();
                }
                else if (Clipboard.ContainsAudio())
                {
                    log("copy--ContainsAudio");
                }

                else if (Clipboard.ContainsFileDropList())
                {
                    System.Collections.Specialized.StringCollection colls = Clipboard.GetFileDropList();
                    string files = getFiles(colls);
                    log("copy--" + files);
                }
                else if (Clipboard.ContainsImage())
                {
                    log("copy--ContainsImage");
                }
                else
                {
                    //Clipboard.Clear(); 
                    log("copy--沒東西");
                }
                //Clipboard.Clear(); 
            }
        }

        private string getFiles(System.Collections.Specialized.StringCollection colls)
        {
            string ret = "";
            for (int i = 0; i < colls.Count; i++)
            {
                if (i > 0)
                    ret += ",";

                ret += colls[i];

            }
            return ret;
        }

        private void 截營幕()
        {
            //不給截營幕
            if (GetAsyncKeyState(Keys.Alt) != 0 && GetAsyncKeyState(Keys.PrintScreen) != 0)    //' GetAsyncKeyState 取得鍵盤狀態
            {
                openExe("mspaint.exe");
                System.Threading.Thread.Sleep(1000);//希望可以換成偵測到focus再貼
                SendKeys.Send("^{v}");
                log("alt截營幕");
            }
            if (GetAsyncKeyState(Keys.PrintScreen) != 0)    //' GetAsyncKeyState 取得鍵盤狀態
            {
                openExe("mspaint.exe");
                System.Threading.Thread.Sleep(1000);//希望可以換成偵測到focus再貼
                SendKeys.Send("^{v}");
                Console.WriteLine("貼");
                log("截營幕");
            }
        }
        /// <summary>
        /// 如果檔案總管的話,會抓不到.
        /// </summary>
        /// <returns></returns>
        private string getProcessNameFromFocusedWindow()
        {
            string ret = "";
            System.Diagnostics.Process[] processCollection = System.Diagnostics.Process.GetProcesses();

            if (processCollection != null && processCollection.Length >= 1 &&
           processCollection[0] != null)
            {
                IntPtr activeWindowHandle = GetForegroundWindow();
                foreach (System.Diagnostics.Process wordProcess in processCollection)
                {
                    if (wordProcess.MainWindowHandle == activeWindowHandle)
                    {
                        return wordProcess.ProcessName;
                    }
                }
            }
            return ret;
        }
        private void openExe()
        {
            //https://abgne.tw/code-snippets/dotnet-process.html
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            //proc.StartInfo.FileName = @"NotePad.exe";//可以用絶對路徑(未測試過)
            proc.StartInfo.FileName = @"explorer.exe";//可以用絶對路徑(未測試過)
            proc.StartInfo.Arguments = "";

            proc.Start();
        }
        private void openExe(string exeName)
        {
            //https://abgne.tw/code-snippets/dotnet-process.html
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            //proc.StartInfo.FileName = @"NotePad.exe";//可以用絶對路徑(未測試過)
            proc.StartInfo.FileName = exeName;//可以用絶對路徑(未測試過)
            proc.StartInfo.Arguments = "";

            proc.Start();
        }
        private void openfile(string filename)
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo pi = new System.Diagnostics.ProcessStartInfo();
            pi.UseShellExecute = true;
            pi.FileName = filename;
            p.StartInfo = pi;

            try
            {
                p.Start();
            }
            catch (Exception Ex)
            {
                //MessageBox.Show(Ex.Message);
            }
        }
        private void log(string str)
        {
            string filename = @"c:\log.txt";
            if (System.IO.File.Exists(filename) == false)
            {
                System.IO.FileStream fileStream = new System.IO.FileStream(filename, System.IO.FileMode.Create);
                fileStream.Close();   //切記開了要關,不然會被佔用而無法修改喔!!!
            }

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(filename, true))
            {
                string msg = DateTime.Now.ToString("yyyyMMdd HH:mm:ss:fff") + "  " + getProcessNameFromFocusedWindow() + "-[" + GetActiveWindowTitle()+"] " + str;
                file.WriteLine(msg);
            }
        }
        private void savetxt(string str)
        {
            string filename = @"c:\test" + DateTime.Now.ToString("yyyyMMdd HHmmss") + ".txt";
            //System.IO.FileStream fileStream = new System.IO.FileStream(filename, System.IO.FileMode.Create,Encoding.UTF8);

            //fileStream.Close();   //切記開了要關,不然會被佔用而無法修改喔!!!

            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(filename, false, Encoding.Default))
            {
                // 欲寫入的文字資料 ~ 
                sw.WriteLine(str);
                sw.WriteLine(DateTime.Now);
            }
            openfile(filename);
            //System.Threading.Thread.Sleep(75 );
            //System.IO.File.Delete(filename);
        }
        private void SaveJpg()
        {

            string ScreenPath = @"E:\123.jpg";

            IDataObject d = Clipboard.GetDataObject();

            if (d.GetDataPresent(DataFormats.Bitmap))
            {
                System.Drawing.Bitmap b = (System.Drawing.Bitmap)d.GetData(DataFormats.Bitmap);
                b.Save(ScreenPath);
            }
            openfile(ScreenPath);
        }
        private void SaveJpg2()
        {
            string fileName = @"E:\" + getDatetimeflowUUID() + ".Png";
            Clipboard.GetImage().Save(fileName, System.Drawing.Imaging.ImageFormat.Png);
            openfile(fileName);
        }
        private string getDatetimeflowUUID()
        {
            DateTime date = System.DateTime.Now;
            string ret = date.Year.ToString() + date.Month.ToString() + date.Day.ToString() + date.Hour.ToString() + date.Minute.ToString() + date.Second.ToString();
            return ret;
        }












    }
}
