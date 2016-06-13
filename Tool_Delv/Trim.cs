using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.IO;

namespace AP_C
{
    public partial class FTrim : Form
    {
        //private BackgroundWorker bw;

        public FTrim(Main parent)
        {
            InitializeComponent();
            this.MdiParent = parent;
            this.WindowState = FormWindowState.Maximized;
 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = tbInput.Text;
            str = str.Replace("\t", "");
            ResetText(tbInput, str);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string str = tbInput.Text;
            str = str.Replace("\r\n", "");
            ResetText(tbInput, str);
        }
        private void ResetText(Control ctr,string str)
        {
            TextBox _ctr = (TextBox)ctr;
            _ctr.Text = str;
            _ctr.SelectAll();
            _ctr.Focus();            
        }

        private void buttonTrim_Click(object sender, EventArgs e)
        {
            string strArg = textBoxTrimArg.Text;
            string strOr = tbInput.Text;
            strOr = strOr.Replace(strArg, "");            
            ResetText(tbInput, strOr);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string strArg = txtSrcString.Text;
            string strOr = tbInput.Text;
            strOr = strOr.Replace(strArg,txtNewString.Text );
            ResetText(tbInput, strOr);
        }

        private void btnTrimPlus_Click(object sender, EventArgs e)
        {
            string str = tbInput.Text;
            str = str.Replace("\"+", "");
            str = str.Replace("\" +", "");
            
            str = str.Replace("\"&_", "");
            str = str.Replace("\" &_", "");
            str = str.Replace("\"& _", "");
            str = str.Replace("\" & _", "");

            str = str.Replace("\" _", "");

            str = str.Replace("& \"", "");

            str = str.Replace("\"", "");

            ResetText(tbInput, str);
        }

        private void btnPropertyNewLine_Click(object sender, EventArgs e)
        {
            string str = tbInput.Text;
            str = str.Replace(") As String", ") As String" + Environment.NewLine);
            str = str.Replace(" Get ", " Get " + Environment.NewLine);

            str = str.Replace("\")", "\")" + Environment.NewLine);
            str = str.Replace("String)", "String)" + Environment.NewLine);
            str = str.Replace(", value)", ", value)" + Environment.NewLine);
            str = str.Replace("End Set", "End Set" + Environment.NewLine);

            ResetText(tbInput, str);
        }
        private void RunSample01()
        {

            Debug.WriteLine("執行緒:{0}", Thread.CurrentThread.ManagedThreadId.ToString());
            Thread.Sleep(100);
        }
        private void button4_Click(object sender, EventArgs e)
        {
        
        }

        private void Trim_Load(object sender, EventArgs e)
        {
            Form.CheckForIllegalCrossThreadCalls = false;
        }
        public delegate void myDelegate();

        private void BtnRead_ALLfile_Click(object sender, EventArgs e)
        {
            //textBoxTrimArg.Text = @"D:\cadmen\una_work\ch8\CADMEN_POS\POS";
            string path = txPath.Text;
            Read_ALLfile(path);

            //textBoxOrl.Text = "在該資料夾，開啟一個記事本，將下列文字貼上、存成bat檔。" +
            //" @echo off" +
            //"dir /b /on >list.txt" +
            //" 對著這個bat檔按兩下，就會生出檔名列表的txt檔囉。";
        }
        public void Read_ALLfile(string path)
        {
            tbInput.Text = path + Environment.NewLine;
            foreach (string fname in System.IO.Directory.GetFileSystemEntries(path))
            {
                //rpt
                //if (fname.IndexOf(".rpt") > 0 && fname.IndexOf(".Designer") < 0)
                //    textBoxOrl.Text += fname.Replace(path, "").Replace(@"\","") +Environment.NewLine;
                //window form
                //if (fname.IndexOf(".vb") > 0 && fname.IndexOf(".Designer") < 0)
                //    textBoxOrl.Text += fname.Replace(path, "").Replace(@"\","") +Environment.NewLine;

                //addon.vb
                if (fname.IndexOf(".cs") > 0 )
                    tbInput.Text += fname.Replace(path, "").Replace(@"\","") +Environment.NewLine;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            button1_Click(sender, e);
            button2_Click(sender, e);
        }
        /// <summary>
        /// plus U & , & remove cell & remove col
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button7_Click(object sender, EventArgs e)
        { 
            string str = tbInput.Text;
            str = str.Replace("\t", "");
            ResetText(tbInput, str);

              str = tbInput.Text;
            str = str.Replace("\r\n", ",U_");
            str = "select U_" + str;
            ResetText(tbInput, str);
            
        }

      

        private void button4_Click_2(object sender, EventArgs e)
        {
            new FrmGetAndCopy().Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
           
            string [] val = tbInput . Text.Split(',');
            tbInput.Text = "";
            foreach (string s in val)
            {
                tbInput.Text += s + Environment.NewLine;
            }

        }

        private void button9_Click(object sender, EventArgs e)
        {
            string[] val = tbInput.Text.Split(',');
            tbInput.Text = "";
            foreach (string s in val)
            {
                //tbInput.Text += tx00.Text +  s+ Environment.NewLine;
                tbInput.Text += tx00.Text + s + ",";
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string abcd = "abcdefghijklmnopqrstuvwxyz";
            string xxx ="a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z,aa,ab,ac,ad,ae";
            string[] abcde = xxx.Split(',');
            string ret = "";
            for (int i=0;i<abcde.Length ;i++)
            {
                string val = abcde[i];                
                ret += val + "2";
                if (i != abcde.Length - 1)
                    ret += "&";                
            }
            tbInput.Text = ret;
        }
        /// <summary>
        /// abcd變a,b,c,d
        /// </summary>
        /// <param name="abcd"></param>
        private static void getStringArary(string abcd)
        {
            string ret = "";
            for (int i = 0; i < abcd.Length; i++)
            {
                ret += abcd.Substring(i, 1);
                if (i != (abcd.Length - 1))
                    ret += ",";
            }
            Console.WriteLine(ret);
        }

        // 宣告委派

        //private void DoWork()
        //{ 
        //    //1.建立ThreadStart委派 
        //    for (int i = 0; i < 99999999999; i++)
        //    {
        //        try
        //        {
        //            //2.建立Thread 類別
        //            Thread myThread = new Thread(myRun);
        //            //3.啟動執行緒
        //            myThread.Start();
        //        }
        //        catch (Exception)
        //        {
        //            //例外發生則終止迴圈執行
        //            break;
        //        }
        //    } 
        //}  

 
       
    }
}
