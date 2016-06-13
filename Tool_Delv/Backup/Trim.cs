using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

namespace AP_C
{
    public partial class Trim : Form
    {
        private BackgroundWorker bw;

        public Trim(Main parent)
        {
            InitializeComponent();
            this.MdiParent = parent;
            this.WindowState = FormWindowState.Maximized;
 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = textBoxOrl.Text;
            str = str.Replace("\t", "");
            ResetText(textBoxOrl, str);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string str = textBoxOrl.Text;
            str = str.Replace("\r\n", "");
            ResetText(textBoxOrl, str);
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
            string strOr = textBoxOrl.Text;
            strOr = strOr.Replace(strArg, "");            
            ResetText(textBoxOrl, strOr);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string strArg = txtSrcString.Text;
            string strOr = textBoxOrl.Text;
            strOr = strOr.Replace(strArg,txtNewString.Text );
            ResetText(textBoxOrl, strOr);
        }

        private void btnTrimPlus_Click(object sender, EventArgs e)
        {
            string str = textBoxOrl.Text;
            str = str.Replace("\"+", "");
            str = str.Replace("\" +", "");
            
            str = str.Replace("\"&_", "");
            str = str.Replace("\" &_", "");
            str = str.Replace("\"& _", "");
            str = str.Replace("\" & _", "");

            str = str.Replace("\" _", "");

            str = str.Replace("& \"", "");

            str = str.Replace("\"", "");

            ResetText(textBoxOrl, str);
        }

        private void btnPropertyNewLine_Click(object sender, EventArgs e)
        {
            string str = textBoxOrl.Text;
            str = str.Replace(") As String", ") As String" + Environment.NewLine);
            str = str.Replace(" Get ", " Get " + Environment.NewLine);

            str = str.Replace("\")", "\")" + Environment.NewLine);
            str = str.Replace("String)", "String)" + Environment.NewLine);
            str = str.Replace(", value)", ", value)" + Environment.NewLine);
            str = str.Replace("End Set", "End Set" + Environment.NewLine);

            ResetText(textBoxOrl, str);
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
        public delegate void myDelegate();  // 宣告委派

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
