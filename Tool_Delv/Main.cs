using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO.Ports;
using System.Threading;
using IWshRuntimeLibrary;

namespace AP_C
{

    public partial class Main : Form
    {
        Thread t1;
        string tx="";

        /// <summary>
        /// 開啟錢櫃1
        /// </summary>
        public static byte[] OpenMoneyBox1 = new byte[] { 27, 112, 0, 50, 250 };

        /// <summary>
        /// 開啟錢櫃2
        /// </summary>
        public static byte[] OpenMoneyBox2 = new byte[] { 27, 112, 1, 50, 250 };

        static SerialPort _serialPort = null;

        
        public Main()
        {
            InitializeComponent();
            IsMdiContainer = true;
            this.WindowState = FormWindowState.Maximized;
        }

        public void xxSerialPort()
        { 

        }

        private void daf()
        {
            _serialPort.Open();

        }

        private void b1isnToolStripMenuItem_Click(object sender, EventArgs e)
        {
        v1.    FB1iSN f = new v1. FB1iSN(this);
            f.Show();
        }

        private void trimToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FTrim f = new FTrim(this);
            f.Show();
        }

       

     

        private void threadToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void b1iSNxlsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            v1. FB1iSN_XLS f = new v1. FB1iSN_XLS(this);
            f.Show();
        }

        private void callChildToolStripMenuItem_Click(object sender, EventArgs e)
        {
      
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
 
            

            return;
            //int win = 0; 
            //win = RunWin(1, 1);
            //win = RunWin(1, 2);
            //win = RunWin(1, 3);
            //win = RunWin(3, 5);  
        }

        private static int RunWin( int i1, int i2)
        {
            int win = 0;
            double ret =i1 % 2;
            if ((ret) != 0)
                win += 100;
            if (i2 == 2 | i2 == 5 | i2 == 8)
                win += 200;
            Debug.WriteLine(win.ToString());
            return win;
        }

        private void payToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //string card_no = "4311952222222222";//信用卡卡號
            //string CARDM = "12";//卡片有效日期 $CARDM=MM
            //string CARDY = "15";//卡片有效日期 $CARDY=YY
            //string amount = "100";//金額
            //string od_sob = "t123451";//交易項目此欄可自由運用,如:放您的單號, 或程式回傳時要辨認的 keyword訂單單號英數
            //string cvv2 = "123";

            //GW_CashFlow.AcceptPayment obj = new GW_CashFlow.AcceptPayment(card_no,CARDM,CARDY,amount,od_sob,cvv2);
            //string ret = obj.Exec();
            //MessageBox.Show(ret);
        }
        
        private string Getspcheck()
        {
            //string chkcode = "94499380";
            string ret="";
            string sob = "BC53625487454";
            foreach (char  s in sob)
            {
                ret += GetWordA(s);
            }
            return ret;
        }
   
            private string GetWordA(char _word)
            {
                string word = _word.ToString().ToUpper();
                switch(word)
                {
 case "A":                        word="0";                        break;     
 case "B":                        word="1";                        break;     
 case "C":                        word="2";                        break;     
 case "D":                        word="3";                        break;     
 case "E":                        word="4";                        break;     
 case "F":                        word="5";                        break;     
 case "G":                        word="6";                        break;     
 case "H":                        word="7";                        break;     
 case "I":                        word="8";                        break;     
 case "J":                        word="9";                        break;     
 case "K":                        word="0";                        break;     
 case "L":                        word="1";                        break;     
 case "M":                        word="2";                        break;     
 case "N":                        word="3";                        break;     
 case "O":                        word="4";                        break;     
 case "P":                        word="5";                        break;     
 case "Q":                        word="6";                        break;     
 case "R":                        word="7";                        break;     
 case "S":                        word="8";                        break;     
 case "T":                        word="9";                        break;     
 case "U":                        word="0";                        break;     
 case "V":                        word="1";                        break;     
 case "W":                        word="2";                        break;     
 case "X":                        word="3";                        break;     
 case "Y":                        word="4";                        break;     
 case "Z":                        word="5";                        break;     
                    


                }
                return word;
            }

            private void Main_Load(object sender, EventArgs e)
            {
 
            }
            private string getxxx()
            {
                string ret = "";
                string val ="abcdefghijklmnopqrstuvwxyz";
                for (int i = 0; i < 26; i++)
                {
                  ret+="now!" + val.Substring(i, 1)+"1,";                   
                }
                return ret;
            }
            private void b1iSN3ToolStripMenuItem_Click(object sender, EventArgs e)
            {
               v1. FB1iSN3 obj = new v1. FB1iSN3(this);
                obj.Show();
            }

            private void testIfElseifToolStripMenuItem_Click(object sender, EventArgs e)
            {
                if (1 == 1)
                    MessageBox.Show("1");
                //else if (2==2)
                //    MessageBox.Show("2");
                //else if (3 == 3)
                //    MessageBox.Show("3");

            }

            private void testToolStripMenuItem1_Click(object sender, EventArgs e)
            {

            }

            private void pickToolStripMenuItem_Click(object sender, EventArgs e)
            {
                OpenFileDialog obj = new OpenFileDialog();
                 obj.ShowDialog();
                 Debug.WriteLine("i am "+obj.FileName);
                 
            }

            private void mB1iSN2_Click(object sender, EventArgs e)
            {
                FB1iSN2 obj = new FB1iSN2();
                obj.Show();
            }

            private void tmpToolStripMenuItem_Click(object sender, EventArgs e)
            {
                //int i = System.Text.Encoding.Default.GetBytes("Y:虛設品號").Length;
                //MessageBox.Show(i.ToString());

            }

       

            private void moveToolStripMenuItem_Click(object sender, EventArgs e)
            {
                FrmMove move = new FrmMove();
                move.Show();
            }

            private void talkToolStripMenuItem_Click(object sender, EventArgs e)
            {
                new FrmTalk().Show();
            }

            private void xxx(int[] arg)
            {
                foreach (int i in arg)
                {
                    Console.WriteLine(i.ToString());
                }
            }
            private void xxx2(params int[] arg)
            {
                foreach (int i in arg)
                {
                    Console.WriteLine(i.ToString());
                }
            }
            private void test1ToolStripMenuItem_Click(object sender, EventArgs e)
            {  
                int[] iAry = { 1, 2, 3, 4, 5 };
                xxx(iAry);
                xxx2(1, 2, 3, 4, 5);
                return;
                //string appName = "myApp_Tool";
                string exepath = Application.ExecutablePath;
                //new SDK_U_Helper.regedit().SetAutoRun(appName, exepath);

                //new SDK_U_Helper.lnk().CreateShortcut("Tool", exepath, "",System.Environment.CurrentDirectory );
                CreateShortcut("Dev_Tool", @"D:\Dev_Tool.exe", "", @"D:\");

            }
            public void CreateShortcut(string lnkFileName, string TargetPath, string Description, string WorkingDirectory)
            {
                //DesktopDirectory
                string shortcutPath = Environment.GetFolderPath(Environment.SpecialFolder.Startup) + " " + "\\" + lnkFileName + ".lnk";

                WshShell shell = new WshShell();
                IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutPath);
                
                shortcut.TargetPath = TargetPath;  //TargetPath 設置你的程式的位置。
                shortcut.WorkingDirectory = WorkingDirectory;//System.Environment.CurrentDirectory;//WorkingDirectory 工作目錄。 
                shortcut.WindowStyle = 1;//WindowStyle ：1、為 normal ，3、Maximized，7、Minimized。
                shortcut.Description = Description;
                shortcut.Save();//最後一定要Save，否則只 CreateShortcut 是創建不出 快捷方式的。

            }

            private void listFileToolStripMenuItem_Click(object sender, EventArgs e)
            {
                FrmGetAndCopy f = new FrmGetAndCopy();
                f.Show();
            }
      
         
 
       
  


    }


}